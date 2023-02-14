using ApiPetroarsa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class ContactoResponse : BaseResponse<ContactosDTO>
    {
        
        public ContactoResponse(string titulo, ContactosDTO resource, string recurso) : base(titulo,resource, recurso) {}
        public ContactoResponse(string titulo, string message) : base(titulo, message) { }

    }
}
