using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models
{
    public class SendMailDTO
    {
        public string moduloComprobante { get; set; }
        public string codigoComprobante { get; set; }
        public int? numeroComprobante { get; set; }
        public string mailCliente { get; set; }
        public string mailVendedor { get; set; }

    }
}
