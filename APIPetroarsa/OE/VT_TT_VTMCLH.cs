using ApiPetroarsa.Helpers;
using ApiPetroarsa.Interfaces;
using ApiPetroarsa.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ApiPetroarsa.OE
{
    public class VT_TT_VTMCLH: OEBase, IOEObject
    {
        
        public VT_TT_VTMCLH(string user, string password, string companyName, string pathLanguage): 
            base(user, password, companyName, pathLanguage) //NO AGREGAR DEPENDENCIAS A OTROS SERVICIOS
        {}

        public void instancioObjeto(string tipoOperacion)
        {
            object[] objetoSoftland = new object[] { "VTMCLH", 4, tipoOperacion};
            oInstance = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, oCompany, objetoSoftland);
                
        }
     
        
    }
}