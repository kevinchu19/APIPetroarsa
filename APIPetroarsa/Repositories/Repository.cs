
using ApiPetroarsa.Entities;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Repositories
{
    public class Repository
    {

        public PETROARSAContext Context { get; }
        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        public Repository(PETROARSAContext context, IConfiguration configuration, Serilog.ILogger logger)
        {
            Context = context;
            Configuration = configuration;
            Logger = logger;
        }

    }
}
