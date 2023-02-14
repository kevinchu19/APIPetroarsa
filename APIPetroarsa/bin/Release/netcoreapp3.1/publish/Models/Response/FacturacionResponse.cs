using ApiPetroarsa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class FacturacionResponse : BaseResponse<ComprobanteGenerado>
    {
        
        public FacturacionResponse(string titulo, int idOperacion, ComprobanteGenerado resource, string recurso) : base(titulo,idOperacion,resource, recurso) {}
        public FacturacionResponse(string titulo, int idOperacion, string message) : base(titulo, idOperacion, message) { }

    }
}
