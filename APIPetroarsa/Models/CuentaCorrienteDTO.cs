using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models
{
    public class CuentaCorrienteDTO
    {
        public string Cuenta__c { get; set; }
        public string Vendedor__c { get; set; }
        public string Tipo_de_producto__c { get; set; }
        public string Cod_formulario__c { get; set; }
        public Int64 Num_formulario__c { get; set; }
        public DateTime Fecha_movimiento__c { get; set; }
        public DateTime Fecha_vencimiento__c { get; set; }
        public decimal Importe_dolares__c { get; set; }
        public decimal Importe_pesos__c { get; set; }
        
    }
}
