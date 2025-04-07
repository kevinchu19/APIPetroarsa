using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPetroarsa.Models;
using ApiPetroarsa.Entities;
using ApiPetroarsa.Helpers;
using ApiPetroarsa.Models;
using ApiPetroarsa.Models.Response;
using ApiPetroarsa.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Serilog;
using Newtonsoft.Json;
using ApiPetroarsa.Services;
using Microsoft.Extensions.Configuration;

namespace ApiPetroarsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {

        public FacturacionRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }

        public FacturacionController(FacturacionRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
            Configuration = configuration;
        }


        //[HttpGet]
        //public async Task<ActionResult<FacturasDTO>> Get(string codigoComprobante, int? numeroComprobante, int? idOperacion)
        //{

        //    FacturasDTO factura = Mapper.Map<FacturasDTO>(await Repository.Get(codigoComprobante, numeroComprobante, idOperacion));


        //    if (factura ==null)
        //    {
        //        throw new BadRequestException("El comprobante solicitado no existe.");
        //    }
        //    Vtrmvh header = await Repository.RecuperoDatosCAE("VT", factura.CodigoComprobante, factura.NumeroComprobante);
        //    factura.NumeroCAE = header.Vtrmvh_Nrocae;
        //    factura.VencimientoCAE = header.Vtrmvh_Vencae;

        //    factura.ImpuestosFactura.AddRange(await Repository.RecuperoImpuestosComprobante("VT", factura.CodigoComprobante, factura.NumeroComprobante));
        //    factura.ImporteTotal = await Repository.RecuperoTotalComprobante("VT", factura.CodigoComprobante, factura.NumeroComprobante);

        //    return factura;
        //}
        [HttpPost]
        public async Task<ActionResult<ComprobanteResponse>> Post([FromBody] FacturacionDTO pedido)
        {
            Logger.Information($"Se recibio posteo de nuevo comprobante:4 {pedido.OrderId}: { JsonConvert.SerializeObject(pedido)}");



            FcrmvhDTO facturacionFormat = Mapper.Map<FacturacionDTO, FcrmvhDTO>(pedido);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            FacturacionResponse<ComprobanteGenerado> response = await Repository.GraboFacturacion(facturacionFormat, "NEW");


            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

        [HttpPost]
        [Route("v2")]
        public async Task<ActionResult<ComprobanteResponse>> PostV2([FromBody] FacturacionDTO pedido)
        {

            FieldMapper mapping = new FieldMapper();
            if (!mapping.LoadMappingFile(AppDomain.CurrentDomain.BaseDirectory + @"\Services\FieldMapFiles\Facturacion.json"))
            {
                return BadRequest(new ComprobanteDTO((string?)pedido.GetType()
                  .GetProperty("Identificador")
                  .GetValue(pedido), "400", "Error de configuracion", "No se encontro el archivo de configuracion del endpoint", null));
            };

            string errorMessage = await Repository.ExecuteSqlInsertToTablaSAR(mapping.fieldMap,
                                                                             pedido,
                                                                             pedido.Identificador,
                                                                             Configuration["Facturacion:JobName"]);
            if (errorMessage != "")
            {
                return BadRequest(new ComprobanteResponse(new ComprobanteDTO(pedido.Identificador, "400", "Bad Request", errorMessage, null)));
            };



            return Ok(new ComprobanteResponse(new ComprobanteDTO(pedido.Identificador, "200", "OK", errorMessage, null)));

        }

        [HttpGet]
        
        [Route("{identificador}")]
        public async Task<ActionResult<ComprobanteResponse>> GetFacturacion(string identificador)
        {
            ComprobanteResponse respuesta = await Repository.GetTransaccion(identificador, "SAR_FCRMVH");

            switch (respuesta.response.status)
            {
                case "404":
                    return NotFound(respuesta);
                    break;
                default:
                    return Ok(respuesta);
                    break;
            }

        }

    }
}
