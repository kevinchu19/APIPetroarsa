using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models
{
    public class ContactosDTO
    {
        public string NumeroCliente { get; set; }
        public string ApellidoNombre { get; set; }
        public string Puesto { get; set; }
        public string Observacion { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string ReclamoFacturas { get; set; }
        public string RecibeFacturaMail { get; set; }
        public bool Activo { get; set; }

    }
}
