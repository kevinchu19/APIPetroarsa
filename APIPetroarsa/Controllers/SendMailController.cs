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

namespace ApiPetroarsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {

        public SendMailRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public SendMailController(SendMailRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }


        [HttpPost]
        public async Task<ActionResult<SendMailResponse<SendMailDTO>>> Post([FromBody] SendMailDTO SendMail)
        {
            
            Logger.Information($"Se recibio posteo de nuevo SendMail: {SendMail.codigoComprobante} - {SendMail.numeroComprobante}: {JsonConvert.SerializeObject(SendMail)} ");


            Usr_Envslf SendMailFormat = Mapper.Map<SendMailDTO, Usr_Envslf>(SendMail);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            SendMailResponse<SendMailDTO> response = await Repository.GraboSendMail(SendMailFormat);
            

            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            response.ComprobanteGenerado = SendMail;

            return Ok(response);

        }

     
    }
}
