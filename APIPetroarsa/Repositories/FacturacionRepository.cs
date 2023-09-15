using ApiPetroarsa.Entities;
using ApiPetroarsa.Helpers;
using ApiPetroarsa.Interfaces;
using ApiPetroarsa.Models;
using ApiPetroarsa.Models.Response;
using ApiPetroarsa.OE;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApiPetroarsa.Repositories
{
    public class FacturacionRepository: Repository
    {
        
        public FC_RR_FCRMVH oFcrmvh { get; set; }
        protected string Connectionstring { get; set; }

        public FacturacionRepository(PETROARSAContext context, Serilog.ILogger logger,IConfiguration configuration) :
            base(context, configuration, logger)
        {
            //oFcrmvh = oInstanceFCRMVH;
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<FacturacionResponse> GraboFacturacion(FcrmvhDTO pedido, string tipoOperacion)
        {
            oFcrmvh = new FC_RR_FCRMVH(Configuration["User"], Configuration["Password"], Configuration["CompanyName"], Configuration["PathLanguage"]);

            Vtmclh cliente = await Context.Vtmclh.Where(c => c.Vtmclh_Nrocta == pedido.Fcrmvh_Nrocta).FirstOrDefaultAsync();
            if (cliente == null)
            {
                return new FacturacionResponse("Bad Request",  $"El cliente {pedido.Fcrmvh_Nrocta} no existe.");
            }

            oFcrmvh.instancioObjeto(tipoOperacion);

            oFcrmvh.asignoaTMWizard("VIRT_CIRCOM", "0200", Logger);
            oFcrmvh.asignoaTMWizard("VIRT_CIRAPL", "0200", Logger);
            string sCodfor = await CalculoComprobanteFC(pedido.Fcrmvh_Deposi);

            if (sCodfor == "")
            {
                string sErrorMessage = $"No existe un formulario asociado al deposito {pedido.Fcrmvh_Deposi}";
                Logger.Warning(sErrorMessage);
                return new FacturacionResponse("Bad Request", sErrorMessage);
            }
            oFcrmvh.asignoaTMWizard("VIRT_CODCFC", sCodfor, Logger);

            oFcrmvh.MoveNext();

            Type typeFactura = pedido.GetType();

            IEnumerable<PropertyInfo> listaPropiedades = typeFactura.GetProperties()
                                                            .Where(e => e.Name != "Virt_Circom" &&
                                                                        e.Name != "Virt_Cirapl" &&
                                                                        e.Name != "Virt_Codcvt");



            foreach (PropertyInfo propiedad in listaPropiedades)
            {
               
                if (propiedad.PropertyType == typeof(ICollection<FcrmviDTO>))
                {

                    foreach (FcrmviDTO item in pedido.Items)
                    {
                        oFcrmvh.asignoaTM("FCRMVI", "", item, 2, Logger);
                    }
                }
                else
                {
                    oFcrmvh.asignoaTM("FCRMVH", propiedad.Name, propiedad.GetValue(pedido, null), 1, Logger);
                }
                

            }

            oFcrmvh.FuerzoPestanaLimiteDeCredito();

            Save PerformedOperation = oFcrmvh.save();

            //bool result = false;
            //string mensajeError = "Prueba sin grabar";
            bool result = PerformedOperation.Result;
            string mensajeError = PerformedOperation.errorMessage;

            oFcrmvh.closeObjectInstance();

            if (result == false)
            {
                return new FacturacionResponse("Bad Request",  mensajeError);
            }


            //PerformedOperation.ComprobanteGenerado.Impuestos.AddRange(await RecuperoImpuestosComprobante(PerformedOperation.ComprobanteGenerado.ModuloComprobante,
            //                                                                                PerformedOperation.ComprobanteGenerado.CodigoComprobante,
            //                                                                              PerformedOperation.ComprobanteGenerado.NumeroComprobante));

            //PerformedOperation.ComprobanteGenerado.ImporteTotal = await RecuperoTotalComprobante(PerformedOperation.ComprobanteGenerado.ModuloComprobante,
            //                                                             PerformedOperation.ComprobanteGenerado.CodigoComprobante,
            //                                                           PerformedOperation.ComprobanteGenerado.NumeroComprobante);

            return new FacturacionResponse("OK", PerformedOperation.ComprobanteGenerado, "Comprobante generado");
        }
       
        //public async Task<decimal?> RecuperoTotalComprobante(string moduloComprobante, string codigoComprobante, int numeroComprobante)
        //{
        //    Vtrmvi total = await Context.Vtrmvi
        //                .Where(c => c.Vtrmvi_Modfor == moduloComprobante &&
        //                            c.Vtrmvi_Codfor == codigoComprobante &&
        //                            c.Vtrmvi_Nrofor == numeroComprobante &&
        //                            c.Vtrmvi_Tipcpt == "T").FirstOrDefaultAsync();
        //    return total.Vtrmvi_Impnac;
        //}

        //public async Task<IEnumerable<ImpuestosComprobanteGenerado>> RecuperoImpuestosComprobante(string moduloComprobante, string codigoComprobante, int numeroComprobante)
        //{
        //    List<ImpuestosComprobanteGenerado> result = new List<ImpuestosComprobanteGenerado>();

        //    IEnumerable<Vtrmvp> impuestos = await Context.Vtrmvp
        //                .Where(c => c.Vtrmvp_Modfor == moduloComprobante &&
        //                            c.Vtrmvp_Codfor == codigoComprobante &&
        //                            c.Vtrmvp_Nrofor == numeroComprobante).ToListAsync();
        //    foreach (Vtrmvp impuesto in impuestos)
        //    {
        //        result.Add(new ImpuestosComprobanteGenerado()
        //        {
        //            TipoConcepto = impuesto.Vtrmvp_Tipcpt,
        //            Concepto = impuesto.Vtrmvp_Codcpt,
        //            ImporteGravado = impuesto.Vtrmvp_Impgra,
        //            Tasa = impuesto.Vtrmvp_Porcen,
        //            ImporteImpuesto = impuesto.Vtrmvp_Impues

        //        });

        //    }

        //    return result;
        //}

        private async Task<string> GeneroCodigoPostal(string pais, string codpos, string jurisdiccion)
        {
            Grtpac codigoPostal = await Context.Grtpac
                                        .Where(c => c.GrtpacCodpai == pais && c.GrtpacCodpos == codpos)
                                        .FirstOrDefaultAsync();
            if (codigoPostal == null)
            {
                Grtpac newCodigoPostal = new Grtpac
                {
                    GrtpacCodpai = pais,
                    GrtpacCodpos = codpos,
                    GrtpacDescrp = "Generado Automáticamente",
                    GrtpacPaipro = pais,
                    GrtpacCodpro = "NA",
                    GrtpacFecalt = DateTime.Now,
                    GrtpacFecmod = DateTime.Now,
                    GrtpacUltopr = "A",
                    GrtpacOalias = "GRTPAC",
                    GrtpacDebaja = "N",
                    GrtpacUserid = "API"
                };
                await Context.Grtpac.AddAsync(newCodigoPostal);
                try
                {
                    await Context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return $"Error al generar codigo postal {newCodigoPostal.GrtpacCodpos}: {e.InnerException.Message}";
                }
            }

            return "";
        }

        private async Task<string> CalculoComprobanteFC(string deposito)
        {
            string sSql = "";
            string codfor = "";

            sSql = "SELECT isnull(USR_STTDEH_CODFOR,'') USR_STTDEH_CODFOR FROM STTDEH " +
                " WHERE " +
                $" STTDEH_DEPOSI = '{ deposito}'";

            using (SqlConnection sql = new SqlConnection(Connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(sSql, sql))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                             codfor = (string)reader["USR_STTDEH_CODFOR"];
                        }
                    }
                }
                
                return codfor.Trim();
            }
        }
    }
}

