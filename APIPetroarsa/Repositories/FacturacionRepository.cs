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

        public async Task<FacturacionResponse<ComprobanteGenerado>> GraboFacturacion(FcrmvhDTO pedido, string tipoOperacion)
        {
            oFcrmvh = new FC_RR_FCRMVH(Configuration["User"], Configuration["Password"], Configuration["CompanyName"], Configuration["PathLanguage"]);

            Vtmclh cliente = await Context.Vtmclh.Where(c => c.Vtmclh_Nrocta == pedido.Fcrmvh_Nrocta).FirstOrDefaultAsync();
            if (cliente == null)
            {
                return new FacturacionResponse<ComprobanteGenerado>("Bad Request", $"El cliente {pedido.Fcrmvh_Nrocta} no existe.");
            }

            oFcrmvh.instancioObjeto(tipoOperacion);

            oFcrmvh.asignoaTMWizard("VIRT_CIRCOM", "0200", Logger);
            oFcrmvh.asignoaTMWizard("VIRT_CIRAPL", "0200", Logger);
            string sCodfor = await CalculoComprobanteFC(pedido.Fcrmvh_Deposi);

            if (sCodfor == "")
            {
                string sErrorMessage = $"No existe un formulario asociado al deposito {pedido.Fcrmvh_Deposi}";
                Logger.Warning(sErrorMessage);
                return new FacturacionResponse<ComprobanteGenerado>("Bad Request", sErrorMessage);
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
                return new FacturacionResponse<ComprobanteGenerado>("Bad Request",  mensajeError);
            }


       
            return new FacturacionResponse<ComprobanteGenerado>("OK", PerformedOperation.ComprobanteGenerado, "Comprobante generado");
        }
       

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

        public async Task<List<EstadoPedidoDTO>> GetEstadoPedido(string identi)
        {
            List <EstadoPedidoDTO> response = new List<EstadoPedidoDTO>();

            response.AddRange(await ExecuteStoredProcedure<EstadoPedidoDTO>("SM_SP_SF_ESTADOPEDIDO",
                                                                            new Dictionary<string, object>{
                                                                                { "@IDENTI", identi}
                                                                            }));

            return response;
        }
    }
}

