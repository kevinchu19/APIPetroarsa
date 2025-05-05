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
    public class ContactoRepository: Repository
    {
        
        
        protected string Connectionstring { get; set; }

        public ContactoRepository(PETROARSAContext context, Serilog.ILogger logger,IConfiguration configuration ):
            base(context, configuration, logger)
        {
            
            Connectionstring = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<ContactoResponse<ContactosDTO>> GraboContacto(Vtmclc contacto)
        {

            Vtmclh cliente = await Context.Vtmclh.Where(c => c.Vtmclh_Nrocta == contacto.Vtmclc_Nrocta).FirstOrDefaultAsync();

            if (cliente ==null)
            {
                return new ContactoResponse<ContactosDTO>("Bad Request", $"El cliente {contacto.Vtmclc_Nrocta} no existe");
            }

            contacto.Vtmclc_Fecmod = DateTime.Now;
            contacto.Vtmclc_Debaja = "N";
            contacto.Vtmclc_Oalias = "VTMCLC";
            contacto.Vtmclc_Userid = "API_Salesforce";

            var existe= await Context.Vtmclc.AnyAsync(c => c.Vtmclc_Nrocta == contacto.Vtmclc_Nrocta &&
                                                                      c.Vtmclc_Codcon == contacto.Vtmclc_Codcon);
            if (existe)
            {

                var entry = Context.Entry(contacto);
                contacto.Vtmclc_Ultopr = "M";

                Context.Update(contacto);
                entry.Property("Vtmclc_Fecalt").IsModified = false;
                
                await Context.SaveChangesAsync();
                
                return new ContactoResponse<ContactosDTO>("Ok", new ContactosDTO(), $"El contacto fue actualizado");
            }

            contacto.Vtmclc_Fecalt = DateTime.Now;
            contacto.Vtmclc_Ultopr = "A";
            
            await Context.Vtmclc.AddAsync(contacto);
            await Context.SaveChangesAsync();
            return new ContactoResponse<ContactosDTO>("OK", new ContactosDTO(), "Contacto generado");
        }
       
    }
}

