using ApiPetroarsa.Helpers;
using ApiPetroarsa.Interfaces;
using ApiPetroarsa.Models;
using ApiPetroarsa.Models.Response;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ApiPetroarsa.OE
{
    public abstract class OEBase: IOEObject
    {
        protected Type OEType { get; set; }
        protected object OEInst { get; set; }
        protected object oApplication { get; set; }
        protected object oCompany { get; set; }
        protected object oWizard { get; set; }
        protected object oCurrentStep { get; set; }
        protected object oFieldsWizard { get; set; }
        protected object oInstance { get; set; }
        protected object oTable { get; set; }
        protected object oRow { get; set; }
        protected object oField { get; set; }
        public string _pathLanguage { get; }

        public OEBase(string user, string password, string companyName, string pathLanguage)
        {
            OEType = Type.GetTypeFromProgID("cwlwoe.global");
            OEInst = Activator.CreateInstance(OEType);
            string[] userPassword = new string[] { user, password };
            object[] company = new string[] { companyName };

            oApplication = OEType.InvokeMember("GetApplication", BindingFlags.InvokeMethod, null, OEInst, userPassword);
            oCompany = OEType.InvokeMember("Companies", BindingFlags.GetProperty, null, oApplication, company);
            _pathLanguage = pathLanguage;
        }


        public void asignoaTMWizard<T>(string field, T valor, Serilog.ILogger logger)
        {
            oCurrentStep = OEType.InvokeMember("CurrentStep", BindingFlags.GetProperty, null, oWizard, null);
            oTable= OEType.InvokeMember("Table", BindingFlags.GetProperty, null, oCurrentStep, null);
            oFieldsWizard= OEType.InvokeMember("Fields", BindingFlags.InvokeMethod, null, oTable, null);

            if (!campoAuditoria(field))
            {
                try
                {
                    oField = OEType.InvokeMember("Item", BindingFlags.InvokeMethod, null, oFieldsWizard, new object[] { field });
                }
                catch { }

                resuelvoValor(oField, valor, logger);
            }

        }
        public void asignoaTM<T>(string table, string field, T valor, int deepnessLevel, Serilog.ILogger logger)
        {
            object value;

            oRow = null;

            oTable = OEType.InvokeMember("Table", BindingFlags.GetProperty, null, oInstance, null);
            if (deepnessLevel == 1)
            {
                oRow = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
            }
            else
            {
                dynamic oTableHeader = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
                dynamic oTableGrid = OEType.InvokeMember("Tables", BindingFlags.GetProperty, null, oTableHeader, new object[] { table });
                dynamic oRows = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTableGrid, null);
                dynamic count = OEType.InvokeMember("Count", BindingFlags.GetProperty, null, oRows, null);

                oRow = OEType.InvokeMember("Add", BindingFlags.InvokeMethod, null, oRows, new object[] { (int)count + 1 });
            }

            
            switch (field) // si el campo es vacio, esta mandando un item de grilla
            {

                case "":
                    T item = (T)(object)valor;
                    Type typeItem = item.GetType();

                    PropertyInfo[] listaPropiedades = typeItem.GetProperties();

                    foreach (PropertyInfo propiedad in listaPropiedades)
                    {
                        if (!campoAuditoria(propiedad.Name) && !propiedad.PropertyType.Namespace.StartsWith("ApiPetroarsa")) //para validar que solo tome tipos de dato system base
                        { 
                            oField = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oRow, new object[] { propiedad.Name });
                            value = propiedad.GetValue(item, null);
                            resuelvoValor(oField, value, logger);
                        }
                    }

                    break;

                default:
                    if (!campoAuditoria(field))
                    {
                        try
                        {
                            oField = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oRow, new object[] { field });
                        }
                        catch 
                        {
                            throw new BadRequestException($"Error al completar el campo {field} con el valor {valor}: El campo no existe");
                        }

                        resuelvoValor(oField, valor, logger);
                    }

                    break;

            }


        }


        public void limpioGrilla(string table)
        {
            dynamic oTableHeader = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[] { 1 });
            dynamic oTableGrid = OEType.InvokeMember("Tables", BindingFlags.GetProperty, null, oTableHeader, new object[] { table });
            dynamic oRows = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTableGrid, null);
            //Limpio grilla
            OEType.InvokeMember("Clear", BindingFlags.InvokeMethod, null, oRows, null);
        }

        public void closeObjectInstance()
        { 
            if (oFieldsWizard != null) { Marshal.ReleaseComObject(oFieldsWizard);}
            if (oCurrentStep != null) { Marshal.ReleaseComObject(oCurrentStep);}    
            if (oWizard != null) { Marshal.ReleaseComObject(oWizard);}
            if (oField != null) { Marshal.ReleaseComObject(oField);}
            if (oRow != null) { Marshal.ReleaseComObject(oRow); }
            if (oTable != null) { Marshal.ReleaseComObject(oTable); }
            if (oInstance != null) { Marshal.ReleaseComObject(oInstance); }
            Marshal.ReleaseComObject(oApplication);
            Marshal.ReleaseComObject(oCompany);
            //OEType = null;
        }

        //public string completaImpuestos(ICollection<Fcrmvi07> impuestos)
        //{
            
        //    decimal sumatoriaAsiento = 0;
            
        //    oTable = OEType.InvokeMember("Table", BindingFlags.GetProperty, null, oInstance, null);

        //    dynamic oRows = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oTable, new object[]{ 1 });
        //    dynamic oImpuestosCalculadosSoftland = OEType.InvokeMember("Tables", BindingFlags.GetProperty, null, oRows, new object[] { "FCRMVI07" });
        //    OEType.InvokeMember("Activate", BindingFlags.InvokeMethod, null, oImpuestosCalculadosSoftland, null);
        //    dynamic oImpuestosSoftlandRows = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oImpuestosCalculadosSoftland, null);

        //    foreach (dynamic oImpuestoSoftland in oImpuestosSoftlandRows)
        //    {
        //        foreach (Fcrmvi07 impuesto in impuestos)
        //        {
                                    
        //            dynamic oTipcpt = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oImpuestoSoftland, new object[] { "FCRMVI07_TIPCPT" });
        //            dynamic oCodcpt= OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oImpuestoSoftland, new object[] { "FCRMVI07_CODCPT" });
        //            dynamic oImpgra = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oImpuestoSoftland, new object[] { "FCRMVI07_IMPGRA" });
        //            dynamic oPorcen = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oImpuestoSoftland, new object[] { "FCRMVI07_PORCEN" });
        //            dynamic oIngres = OEType.InvokeMember("Fields", BindingFlags.GetProperty, null, oImpuestoSoftland, new object[] { "FCRMVI07_INGRES" });
                   
        //            dynamic oTipcptValue = OEType.InvokeMember("Value", BindingFlags.GetProperty, null, oTipcpt, null);
        //            dynamic oCodcptValue = OEType.InvokeMember("Value", BindingFlags.GetProperty, null, oCodcpt, null);
                    
        //            if (oTipcptValue != "A")
        //            {
        //                if (oTipcptValue == impuesto.Fcrmvi07_Tipcpt && oCodcptValue == impuesto.Fcrmvi07_Codcpt)
        //                {
        //                    OEType.InvokeMember("Enabled", BindingFlags.SetProperty, null, oIngres, new object[] { true });
        //                    OEType.InvokeMember("Enabled", BindingFlags.SetProperty, null, oImpgra, new object[] { true });
        //                    OEType.InvokeMember("Enabled", BindingFlags.SetProperty, null, oPorcen, new object[] { true });
                            
        //                    OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oIngres, new object[] { impuesto.Fcrmvi07_Ingres });
        //                    OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oImpgra, new object[] { impuesto.Fcrmvi07_Impgra });
        //                    OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oPorcen, new object[] { impuesto.Fcrmvi07_Porcen });

        //                    //sumatoriaAsiento += impuesto.Fcrmvi07_Ingres;
        //                    impuesto.ExisteImpuesto = true;
        //                    break;
        //                }
        //                else
        //                {
        //                    OEType.InvokeMember("Enabled", BindingFlags.SetProperty, null, oIngres, new object[] { true });
        //                    OEType.InvokeMember("Enabled", BindingFlags.SetProperty, null, oImpgra, new object[] { true });
        //                    OEType.InvokeMember("Enabled", BindingFlags.SetProperty, null, oPorcen, new object[] { true });
                            
        //                    OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oIngres, new object[] { 0 });
        //                    OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oImpgra, new object[] { 0 });
        //                    OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oPorcen, new object[] { 0 });
        //                }
        //            }
                    
        //        }

        //    }

        //    Fcrmvi07 impuestoInexistente = impuestos.FirstOrDefault(i => i.ExisteImpuesto == false);

        //    if (impuestoInexistente != null)
        //    {
        //        return $"El concepto {impuestoInexistente.Fcrmvi07_Tipcpt} - {impuestoInexistente.Fcrmvi07_Codcpt} no existe en calculo original del sistema. No puede registrar el comprobante.";
        //    }
            


        //    if (impuestos.Count() > 0)
        //    {
        //        object lastRow = OEType.InvokeMember("Count", BindingFlags.GetProperty, null, oImpuestosSoftlandRows, null);
        //        dynamic oRowTotal = OEType.InvokeMember("Rows", BindingFlags.GetProperty, null, oImpuestosCalculadosSoftland, new object[] { lastRow });
        //        dynamic oIngresTotal = OEType.InvokeMember("fields", BindingFlags.GetProperty, null, oRowTotal, new object[] { "FCRMVI07_INGRES" });
        //        dynamic oIngresTotalValue = OEType.InvokeMember("value", BindingFlags.GetProperty, null, oIngresTotal, null);
        //        sumatoriaAsiento = (decimal)OEType.InvokeMember("sum", BindingFlags.InvokeMethod, null, oImpuestosSoftlandRows, new object[] { "FCRMVI07_INGRES" });

        //        OEType.InvokeMember("Enabled", BindingFlags.SetProperty, null, oIngresTotal, new object[] { true });
        //        OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oIngresTotal, new object[] { sumatoriaAsiento - (decimal)oIngresTotalValue });

        //    }
        //    return "";
        //}

        public Save save()
        {
            string[] sErrorMessage = new string[] { null };
            object result = OEType.InvokeMember("Save", BindingFlags.InvokeMethod, null, oInstance, sErrorMessage);
            ComprobanteGenerado comprobanteGenerado = new ComprobanteGenerado( );
            
            Translate oTranslate = new Translate(_pathLanguage);

            if ((bool)result == false && sErrorMessage[0] == null)
            {
                int messageCount = (int)OEType.InvokeMember("MessageCount", BindingFlags.GetProperty, null, oInstance, null);
                int i;
                for (i = messageCount; i >= 1; i--)
                {
                    dynamic oMessages = OEType.InvokeMember("Messages", BindingFlags.GetProperty, null, oInstance, new object[] { i });
                    string description = (string)OEType.InvokeMember("Description", BindingFlags.GetProperty, null, oMessages, null);
                    if (description != "")
                    {
                        sErrorMessage[0] =  oTranslate.traducir(description);
                        break;
                    }
                }
            }
            else
            {
                dynamic oDataAccess = OEType.InvokeMember("DataAccess", BindingFlags.GetProperty, null, oInstance, null);
                dynamic oPerformedOperations = OEType.InvokeMember("PerformedOperations", BindingFlags.GetProperty, null, oDataAccess, null);
                foreach (dynamic oPerform in oPerformedOperations)
                {
                    dynamic oKeys = OEType.InvokeMember("Keys", BindingFlags.GetProperty, null, oPerform, null);
                    int count = OEType.InvokeMember("Count", BindingFlags.GetProperty, null, oKeys, null);
                    for (int i = 1; i <= count; i++)
                    {
                        dynamic oKey = OEType.InvokeMember("Keys", BindingFlags.GetProperty, null, oPerform, new object[] { i });
                        string name = OEType.InvokeMember("Name", BindingFlags.GetProperty, null, oKey, null);
                        switch (name.Substring(name.Length-6,6))
                        {
                            case "MODFOR":
                                comprobanteGenerado.ModuloComprobante = OEType.InvokeMember("Value", BindingFlags.GetProperty, null, oKey, null);
                                break;
                            case "CODFOR":
                                comprobanteGenerado.CodigoComprobante = OEType.InvokeMember("Value", BindingFlags.GetProperty, null, oKey, null);
                                break;
                            case "NROFOR":
                                comprobanteGenerado.NumeroComprobante = OEType.InvokeMember("Value", BindingFlags.GetProperty, null, oKey, null);
                                break;
                            default:
                                break;
                        }
                    }
                }

            }

            this.closeObjectInstance();

            return new Save
            {
                Result = (bool)result,
                errorMessage = sErrorMessage[0],
                ComprobanteGenerado = comprobanteGenerado
            };


        }

        protected bool campoAuditoria(string field)
        {
            string camposAuditoria = "FECALT,FECMOD,ULTOPR,DEBAJA,OALIAS,USERID,CONTRATO";
            try
            {
                if (camposAuditoria.IndexOf(field.Substring(field.Length - 6, 6).ToUpper()) >= 0)
                {
                    return true;
                }
            }
            catch{}

            return false;
        }

        protected void resuelvoValor(dynamic oField, object value, Serilog.ILogger logger)
        {
            if(OEType.InvokeMember("Name", BindingFlags.GetProperty, null, oField, null) == "CJRMVI_CHEQUE")
            {
                var a = 1;
            }
            bool campoHabilitado;
            try
            {
                try
                {
                    campoHabilitado = (bool)OEType.InvokeMember("Readonly", BindingFlags.GetProperty, null, oField, null);
                }
                catch
                {
                    //Si es campo de wizard entra por aca
                    campoHabilitado = !(bool)OEType.InvokeMember("Enabled", BindingFlags.GetProperty, null, oField, null);
                }
                if (!campoHabilitado)
                {
                    try
                    {
                        //OEType.InvokeMember("Validating", BindingFlags.SetProperty, null, oInstance, new object[] { true });
                    }
                    catch {}
                    switch ((int)OEType.InvokeMember("DataType", BindingFlags.GetProperty, null, oField, null))
                    {
                        
                        case 8:
                            //if (value != null) //fecha
                            //{

                            //    DateTime dateValue = (DateTime)value;
                            //    value = dateValue.ToString("yyyyMMdd");
                            //    OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { value });
                            //    logger.Information($"campo {OEType.InvokeMember("Name", BindingFlags.GetProperty, null, oField, null)} completado con el valor {value}");
                            //}
                            break;
                        case 3: case 4: case 5: case 6: case 7: case 9: //numero

                            if (value != null)
                            {
                                OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { value });
                                logger.Information($"campo {OEType.InvokeMember("Name", BindingFlags.GetProperty, null, oField, null)} completado con el valor {value}");
                            }
                            
                            break;
                        default:

                            if ((string)value != "null" && (string)value != "NULL" && value != null) //caracter
                            {
                                OEType.InvokeMember("Value", BindingFlags.SetProperty, null, oField, new object[] { value });
                                logger.Information($"campo {OEType.InvokeMember("Name", BindingFlags.GetProperty, null, oField, null)} completado con el valor {value}");
                            }
                            break;

                    };
                    
                }

                
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Error al completar el campo {OEType.InvokeMember("Name", BindingFlags.GetProperty, null, oField, null)} con el valor {value}: {e.Message}");
            }
            
        }

    }
}
