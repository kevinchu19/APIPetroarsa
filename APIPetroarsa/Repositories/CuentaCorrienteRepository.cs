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
    public class CuentaCorrienteRepository: Repository
    {
        
        
        protected string Connectionstring { get; set; }

        public CuentaCorrienteRepository(PETROARSAContext context, Serilog.ILogger logger,IConfiguration configuration ):
            base(context, configuration, logger)
        {
            
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<IEnumerable<CuentaCorrienteDTO>> GetByCliente(string cliente)
        {
            List<CuentaCorrienteDTO> response = new List<CuentaCorrienteDTO>();
            
            response.AddRange(await ExecuteStoredProcedure<CuentaCorrienteDTO>("SM_SP_SF_CTACTE",
                                                                            new Dictionary<string, object>{
                                                                                { "@NROCTA", cliente }
                                                                            }));

            return response;
        }
       
    }
}

