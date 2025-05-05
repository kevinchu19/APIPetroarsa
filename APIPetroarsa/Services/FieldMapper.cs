using ApiPetroarsa.Services.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ApiPetroarsa.Services
{
    public class FieldMapper
    {
        public List<FieldMap> fieldMap { get; set; }
        private static string fileContent = String.Empty;

        public bool LoadMappingFile(string path)
        {
            try
            {
                fileContent = System.IO.File.ReadAllText(path);
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                fieldMap = JsonConvert.DeserializeObject<List<FieldMap>>(fileContent, settings);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
