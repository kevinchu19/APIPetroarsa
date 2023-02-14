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
    public class CuentaCorrienteController : ControllerBase
    {

        public CuentaCorrienteRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public CuentaCorrienteController(CuentaCorrienteRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }


        [HttpGet]
        [Route("{cliente}")]
        public async Task<ActionResult<IEnumerable<CuentaCorrienteDTO>>> GetByCliente(string cliente)
        {
            Logger.Information($"Se recibio consulta de cuenta corriente de cliente: {cliente}");

            IEnumerable<CuentaCorrienteDTO> response = await Repository.GetByCliente(cliente);

            return Ok(response);

        }

     
    }
}
