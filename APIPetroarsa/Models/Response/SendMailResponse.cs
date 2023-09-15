using ApiPetroarsa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class SendMailResponse : BaseResponse<SendMailDTO>
    {
        
        public SendMailResponse(string titulo, SendMailDTO resource, string recurso) : base(titulo,resource, recurso) {}
        public SendMailResponse(string titulo, string message) : base(titulo, message) { }

    }
}
