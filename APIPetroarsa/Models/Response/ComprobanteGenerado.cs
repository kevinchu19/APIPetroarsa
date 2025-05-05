using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class ComprobanteGenerado
    {
        public string? codigocomprobante { get; set; }
        public Int64? numerocomprobante { get; set; }
    }
}
