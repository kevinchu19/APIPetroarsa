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
    public class BonificacionRepository: Repository
    {
        
        
        protected string Connectionstring { get; set; }

        public BonificacionRepository(PETROARSAContext context, Serilog.ILogger logger,IConfiguration configuration ):
            base(context, configuration, logger)
        {
            
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<IEnumerable<BonificacionDTO>> Get()
        {
            List<BonificacionDTO> response = new List<BonificacionDTO>();
            
            response.AddRange(await ExecuteStoredProcedure<BonificacionDTO>("SM_SP_SF_FCTBAH", new Dictionary<string, object>()));

            return response;
        }
       
    }
}

