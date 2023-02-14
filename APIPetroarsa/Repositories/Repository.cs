
using ApiPetroarsa.Entities;
using Microsoft.Data.SqlClient;
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

        public TResponse MapToValue<TResponse>(SqlDataReader reader)
        {
            var respuesta = (TResponse)Activator.CreateInstance(typeof(TResponse), new object[] { });
            Type typeResponse = typeof(TResponse);
            System.Reflection.PropertyInfo[] listaPropiedades = typeResponse.GetProperties();

            for (int i = 0; i < listaPropiedades.Count(); i++)
            {
                if (reader.GetColumnSchema().Any(c => c.ColumnName == listaPropiedades[i].Name))
                {
                    if (reader[listaPropiedades[i].Name] != DBNull.Value)
                    {

                        if (listaPropiedades[i].PropertyType == typeof(string))
                        {
                            listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name].ToString());
                        }
                        else
                        {
                            if (listaPropiedades[i].PropertyType == typeof(bool))
                            {
                                listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name].ToString() == "S" ? true : false);
                            }
                            else
                            {
                                if (listaPropiedades[i].PropertyType == typeof(decimal))
                                {
                                    listaPropiedades[i].SetValue(respuesta, (decimal)reader[listaPropiedades[i].Name]);
                                }
                                else
                                {
                                    listaPropiedades[i].SetValue(respuesta, reader[listaPropiedades[i].Name]);
                                }
                            }
                        }

                    }
                }

            }

            return respuesta;
        }

        public async Task<IEnumerable<TResult>> ExecuteStoredProcedure<TResult>(string sqlCommand, Dictionary<string, object> parameters)
        {
            List<TResult> result = new List<TResult>();

            using (SqlConnection sql = new SqlConnection(Configuration.GetConnectionString("DefaultConnectionString")))
            {
                using (SqlCommand cmd = new SqlCommand(sqlCommand, sql))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(item.Key, item.Value));
                    }

                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(MapToValue<TResult>(reader));
                        }
                    }
                }
            }

            return result;

        }
    }
}
