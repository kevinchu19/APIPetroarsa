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

        public FacturacionController(FacturacionRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
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
        public async Task<ActionResult<FacturacionResponse>> Post([FromBody] FacturacionDTO pedido)
        {
            Logger.Information($"Se recibio posteo de nuevo comprobante: {pedido.OrderId}");



            FcrmvhDTO facturacionFormat = Mapper.Map<FacturacionDTO, FcrmvhDTO>(pedido);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            FacturacionResponse response = await Repository.GraboFacturacion(facturacionFormat, "NEW");
            

            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

     
    }
}
