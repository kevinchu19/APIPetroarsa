using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class ComprobanteGenerado
    {
        [JsonIgnore]
        public string ModuloComprobante { get; set; }
        public string CodigoComprobante { get; set; }
        public int NumeroComprobante { get; set; }
        //public List<ImpuestosComprobanteGenerado> Impuestos { get; set; } = new List<ImpuestosComprobanteGenerado>();
        //public decimal? ImporteTotal{ get; set; }
            
    }
}
