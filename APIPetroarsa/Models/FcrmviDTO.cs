using System;
using System.Collections.Generic;

#nullable disable

namespace ApiPetroarsa.Models
{
    public partial class FcrmviDTO
    {
        public string Fcrmvi_Tipori { get; set; }
        public string Fcrmvi_Artori { get; set; }
        public decimal Fcrmvi_Cantid { get; set; }
        public decimal Fcrmvi_Precio { get; set; }
        public decimal Fcrmvi_Pctbf1 { get; set; }
        public decimal Fcrmvi_Pctbf2 { get; set; }
        public string Fcrmvi_Textos { get; set; }
    }
}
