using ApiPetroarsa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class FacturacionResponse : BaseResponse<ComprobanteGenerado>
    {
        
        public FacturacionResponse(string titulo, ComprobanteGenerado resource, string recurso) : base(titulo,resource, recurso) {}
        public FacturacionResponse(string titulo, string message) : base(titulo, message) { }

    }
}
