using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ApiPetroarsa.Models
{
    public partial class FcrmvhDTO
    {
        public string Fcrmvh_Fchmov { get; set; }
        public string Fcrmvh_Nrocta { get; set; }
        public string Usr_Fcrmvh_Clicob { get; set; }
        public string Usr_Fcrmvh_Usrslf { get; set; }
        public string Usr_Fcrmvh_Nroext { get; set; }
        public string Fcrmvh_Cndpag { get; set; }
        public string Fcrmvh_Deposi { get; set; }
        public string Fcrmvh_Sector { get; set; } = "U";
        public string Fcrmvh_Codlis { get; set; }
        public string Fcrmvh_Textos { get; set; }
        public string Fcrmvh_Nombre { get; set; }
        public string Fcrmvh_Direcc { get; set; }
        public string Fcrmvh_Codpai { get; set; }
        public string Fcrmvh_Codpos { get; set; }
        public string Fcrmvh_Coniva { get; set; }
        public string Fcrmvh_Cntpdc { get; set; }
        public string Fcrmvh_Nrodoc { get; set; }
        public string Fcrmvh_Jurisd { get; set; }
        public string Virt_Cdent1 { get; set; }
        public string Fcrmvh_Telefn { get; set; }
        public string Fcrmvh_Jurctd { get; set; }

        public ICollection<FcrmviDTO> Items { get; set; }
    }
}
