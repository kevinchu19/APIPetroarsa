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
    public class SendMailRepository: Repository
    {
        
        
        protected string Connectionstring { get; set; }

        public SendMailRepository(PETROARSAContext context, Serilog.ILogger logger,IConfiguration configuration ):
            base(context, configuration, logger)
        {
            
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<SendMailResponse> GraboSendMail(Usr_Envslf SendMail)
        {

            SendMail.Usr_En_Fecmod = DateTime.Now;
            SendMail.Usr_En_Debaja = "N";
            SendMail.Usr_En_Oalias = "USR_ENVSLF";
            SendMail.Usr_En_Userid= "API_Salesforce";
            SendMail.Usr_En_Fecalt = DateTime.Now;
            SendMail.Usr_En_Ultopr = "A";
            
            await Context.Usr_Envslf.AddAsync(SendMail);
            await Context.SaveChangesAsync();
            return new SendMailResponse("OK", new SendMailDTO(), "Registro de envio de mail generado");
        }
       
    }
}

