using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models
{
    public class ImpuestosFacturasDTO
    {
        public string TipoConceptoImpuesto{ get; set; }
        public string CodigoConceptoImpuesto { get; set; }
        public decimal ImporteGravado { get; set; }
        public decimal Tasa { get; set; }
        public decimal ImporteImpuesto { get; set; }
        
        
    }
}
