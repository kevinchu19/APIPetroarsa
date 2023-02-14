using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class ImpuestosComprobanteGenerado
    {
        public string TipoConcepto { get; set; }
        public string Concepto { get; set; }
        public decimal? ImporteGravado { get; set; }
        public decimal? Tasa { get; set; }
        public decimal? ImporteImpuesto { get; set; } 
    }
}
