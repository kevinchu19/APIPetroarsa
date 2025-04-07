using ApiPetroarsa.Models;
using ApiPetroarsa.Models.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Models
{
    public class FacturacionDTO
    {
        public string Identificador { get; set; }
        public string FechadeMovimiento { get; set; }
        public string Cliente { get; set; }
        public string ClienteACobrar { get; set; }
        public string UsuarioCarga { get; set; }
        public string OrderId { get; set; }
        public string CondiciondePago { get; set; }
        public string Deposito { get; set; }
        public string ListaPrecios { get; set; }
        public string Texto { get; set; }
        public string NombreContado { get; set; }
        public string DireccionContado { get; set; }
        public string PaisContado { get; set; }
        public string CodigoPostalContado { get; set; }
        public string SituacionImpositivaContado { get; set; }
        public string TipoDocumentoContado { get; set; }
        public string NumeroDocumentoContado { get; set; }
        public string Jurisdiccion { get; set; }
        public string CodigoDireccionEntrega { get; set; }
        public string Telefono { get; set; }
        public string JurisdiccionContado { get; set; }
        [AllowedMoneda(ErrorMessage = "La moneda no es válida. Valores permitodos: ARS | USD.")]
        public string Moneda { get; set; }

        public ICollection<FacturacionItemsDTO> Items {get;set;}


    }

    public class AllowedMonedaAttribute : ValidationAttribute
    {
        private readonly string[] valoresPermitidos = { "ARS", "USD" };

        public override bool IsValid(object value)
        {
            if (value == null || !valoresPermitidos.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}
