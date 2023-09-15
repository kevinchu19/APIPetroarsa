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
    public class BonificacionController : ControllerBase
    {

        public BonificacionRepository Repository { get; }
        public ILogger Logger { get; }
        public IMapper Mapper { get; }
        public IWebHostEnvironment Env { get; }

        public BonificacionController(BonificacionRepository repository, Serilog.ILogger logger, IMapper mapper, IWebHostEnvironment env)
        {
            Repository = repository;
            Logger = logger;
            Mapper = mapper;
            Env = env;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BonificacionDTO>>> Get()
        {
            Logger.Information($"Se recibio consulta de Bonificaciones");

            IEnumerable<BonificacionDTO> response = await Repository.Get();

            return Ok(response);
        }

     
    }
}
