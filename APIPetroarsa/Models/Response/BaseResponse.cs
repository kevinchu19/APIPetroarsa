using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public abstract class BaseResponse<T>
    {

        public int Estado { get; set; }
        public string Titulo { get; set; }
        public string Mensaje{ get; set; }
        public T ComprobanteGenerado { get; set; }

        public virtual bool ShouldSerializeComprobanteGenerado()
        {
            return (ComprobanteGenerado != null);
        }


        protected BaseResponse(string titulo, T resource,string recurso)
        {
            Estado  = 200;
            Mensaje = $"{recurso} con éxito";
            Titulo = titulo;
            if (resource!=null)
            {
                ComprobanteGenerado = resource;
            }
            
        }
     
        protected BaseResponse(string titulo,string message)
        {
            Estado = 400;
            Mensaje = message;
            Titulo = titulo;
        }
    }
}

