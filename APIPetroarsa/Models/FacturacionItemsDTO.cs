using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models
{
    public class FacturacionItemsDTO
    {
        public string TipoProducto { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Bonificacion1 { get; set; }
        public decimal Bonificacion2 { get; set; }
        public string Observaciones { get; set; }
        public FcrmvhDTO Header { get; set; }
    }
}
