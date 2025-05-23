﻿using ApiPetroarsa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models.Response
{
    public class FacturacionResponse<T>
    {
        public int Estado { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public T ComprobanteGenerado { get; set; }

        public virtual bool ShouldSerializeComprobanteGenerado()
        {
            return (ComprobanteGenerado != null);
        }


        public FacturacionResponse(string titulo, T resource, string recurso)
        {
            Estado = 200;
            Mensaje = $"{recurso} con éxito";
            Titulo = titulo;
            if (resource != null)
            {
                ComprobanteGenerado = resource;
            }

        }

        public FacturacionResponse(string titulo, string message)
        {
            Estado = 400;
            Mensaje = message;
            Titulo = titulo;
        }
    }
}
