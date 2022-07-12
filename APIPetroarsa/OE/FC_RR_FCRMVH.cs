using ApiPetroarsa.Interfaces;
using System.Reflection;


namespace ApiPetroarsa.OE
{
    public class FC_RR_FCRMVH: OEBase, IOEObject
    {
        
        public FC_RR_FCRMVH(string user, string password, string companyName, string pathLanguage): 
            base(user, password, companyName, pathLanguage) //NO AGREGAR DEPENDENCIAS A OTROS SERVICIOS
        {}

        public void instancioObjeto(string tipoOperacion)
        {
            object[] objetoSoftland = new object[] { "FCRMVH", 4, tipoOperacion};
            oWizard = OEType.InvokeMember("GetObject", BindingFlags.InvokeMethod, null, oCompany, objetoSoftland);
            
        }

        public void MoveNext()
        {
            OEType.InvokeMember("MoveNext", BindingFlags.InvokeMethod, null, oWizard, null);
            oInstance = OEType.InvokeMember("NextObject", BindingFlags.GetProperty, null, oWizard, null);
        }

    }
}