using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPetroarsa.Entities;
using ApiPetroarsa.Models;
using ApiPetroarsa.OE;
using ApiPetroarsa.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ApiPetroarsa.Helpers;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using ApiPetroarsa.Interfaces;
using ApiPetroarsa.Models;
using ApiPetroarsa.MapperHelp;
using Newtonsoft.Json.Serialization;

namespace ApiPetroarsa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddTransient(provider =>
            //    new VT_TT_VTMCLH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]));

        
            //services.AddTransient(provider =>
            //    new FC_RR_FCRMVH("admin", Configuration["PasswordAdmin"], Configuration["CompanyName"], Configuration["PathLanguage"]));

            

            services.AddScoped<FacturacionRepository>();

            services.AddScoped<ContactoRepository>();
            services.AddScoped<CuentaCorrienteRepository>();

            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());

                configuration.CreateMap<FacturacionDTO, FcrmvhDTO>()
                .ForMember(dest => dest.Fcrmvh_Fchmov, opt => opt.MapFrom(src => src.FechadeMovimiento))
                .ForMember(dest => dest.Fcrmvh_Nrocta, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.Usr_Fcrmvh_Clicob, opt => opt.MapFrom(src => src.ClienteACobrar))
                .ForMember(dest => dest.Usr_Fcrmvh_Usrslf, opt => opt.MapFrom(src => src.UsuarioCarga))
                .ForMember(dest => dest.Usr_Fcrmvh_Nroext, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.Fcrmvh_Cndpag, opt => opt.MapFrom(src => src.CondiciondePago))
                .ForMember(dest => dest.Fcrmvh_Deposi, opt => opt.MapFrom(src => src.Deposito))
                .ForMember(dest => dest.Fcrmvh_Codlis, opt => opt.MapFrom(src => src.ListaPrecios))
                .ForMember(dest => dest.Fcrmvh_Textos, opt => opt.MapFrom(src => src.Texto))
                .ForMember(dest => dest.Fcrmvh_Nombre, opt => opt.MapFrom(src => src.NombreContado))
                .ForMember(dest => dest.Fcrmvh_Direcc, opt => opt.MapFrom(src => src.DireccionContado))
                .ForMember(dest => dest.Fcrmvh_Codpai, opt => opt.MapFrom(src => src.PaisContado))
                .ForMember(dest => dest.Fcrmvh_Codpos, opt => opt.MapFrom(src => src.CodigoPostalContado))
                .ForMember(dest => dest.Fcrmvh_Coniva, opt => opt.MapFrom(src => src.SituacionImpositivaContado))
                .ForMember(dest => dest.Fcrmvh_Cntpdc, opt => opt.MapFrom(src => src.TipoDocumentoContado))
                .ForMember(dest => dest.Fcrmvh_Nrodoc, opt => opt.MapFrom(src => src.NumeroDocumentoContado))
                .ForMember(dest => dest.Fcrmvh_Jurisd, opt => opt.MapFrom(src => src.Jurisdiccion))
                .ForMember(dest => dest.Virt_Cdent1, opt => opt.MapFrom(src => src.CodigoDireccionEntrega))
                .ForMember(dest => dest.Fcrmvh_Telefn, opt => opt.MapFrom(src => src.Telefono))
                .ForMember(dest => dest.Fcrmvh_Jurctd, opt => opt.MapFrom(src => src.JurisdiccionContado))
                .ReverseMap();

                configuration.CreateMap < FacturacionItemsDTO, FcrmviDTO > ()
                .ForMember(dest => dest.Fcrmvi_Tipori, opt => opt.MapFrom(src => src.TipoProducto))
                .ForMember(dest => dest.Fcrmvi_Artori, opt => opt.MapFrom(src => src.Producto))
                .ForMember(dest => dest.Fcrmvi_Cantid, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.Fcrmvi_Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Fcrmvi_Pctbf1, opt => opt.MapFrom(src => src.Bonificacion1))
                .ForMember(dest => dest.Fcrmvi_Pctbf2, opt => opt.MapFrom(src => src.Bonificacion2))
                .ForMember(dest => dest.Fcrmvi_Textos, opt => opt.MapFrom(src => src.Observaciones))
                .ReverseMap();


                configuration.CreateMap<ContactosDTO, Vtmclc>()
                .ForMember(dest => dest.Vtmclc_Nrocta, opt => opt.MapFrom(src => src.NumeroCliente))
                .ForMember(dest => dest.Vtmclc_Codcon, opt => opt.MapFrom(src => src.ApellidoNombre))
                .ForMember(dest => dest.Vtmclc_Puesto, opt => opt.MapFrom(src => src.Puesto))
                .ForMember(dest => dest.Vtmclc_Observ, opt => opt.MapFrom(src => src.Observacion))
                .ForMember(dest => dest.Vtmclc_Tipsex, opt => opt.MapFrom(src => src.Sexo))
                .ForMember(dest => dest.Vtmclc_Direml, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Vtmclc_Telint, opt => opt.MapFrom(src => src.Telefono))
                .ForMember(dest => dest.Vtmclc_Celula, opt => opt.MapFrom(src => src.Celular))
                .ForMember(dest => dest.Vtmclc_Recfac, opt => opt.MapFrom(src => src.ReclamoFacturas))
                .ForMember(dest => dest.Vtmclc_Refcma, opt => opt.MapFrom(src => src.RecibeFacturaMail))

               .ReverseMap();


            }
                , typeof(Startup));


            services.AddMvc(Options =>
            {
                Options.Filters.Add(typeof(FiltrodeExcepcion));
            })
                .AddJsonOptions(options =>
                    { 
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                        options.JsonSerializerOptions.IgnoreNullValues = true;
                    })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                
            

            services.AddDbContext<PETROARSAContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")).EnableSensitiveDataLogging());
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddControllers();
            services.AddCors();


            services.AddMvc()
                .AddXmlDataContractSerializerFormatters();


            services.AddSingleton<Serilog.ILogger>(options =>
            {
                var connstring = Configuration["Serilog:SerilogConnectionString"];
                var tableName = Configuration["Serilog:TableName"];

                return new LoggerConfiguration()
                            .WriteTo
                            .MSSqlServer(
                                connectionString: connstring,
                                sinkOptions: new MSSqlServerSinkOptions { TableName = tableName, AutoCreateSqlTable = true },
                                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                            .CreateLogger();

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
