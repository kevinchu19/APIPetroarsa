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
    public class ContactoController : ControllerBase
    {

        public ContactoRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public ContactoController(ContactoRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }


        [HttpPost]
        public async Task<ActionResult<ContactoResponse<ContactosDTO>>> Post([FromBody] ContactosDTO contacto)
        {
            
            Logger.Information($"Se recibio posteo de nuevo contacto: {contacto.NumeroCliente} - {contacto.ApellidoNombre}: {JsonConvert.SerializeObject(contacto)} ");



            Vtmclc ContactoFormat = Mapper.Map<ContactosDTO, Vtmclc>(contacto);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error de formato");
            }

            ContactoResponse<ContactosDTO> response = await Repository.GraboContacto(ContactoFormat);
            

            if (response.Estado != 200)
            {
                return BadRequest(response);
            }

            response.ComprobanteGenerado = contacto;

            return Ok(response);

        }

     
    }
}
