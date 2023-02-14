using ApiPetroarsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetroarsa.Interfaces
{
    public interface IOEObject
    {
       
        public Save save()
        {
            return new Save
            {
                Result = true,
                errorMessage = ""
            };
        }

        public void asignoaTM<T>(string table, string field, T value, int deepnessLevel)
        {

        }


        public void instancioObjeto(string tipoOperacion)
        {

        }

        public void closeObjectInstance()
        {

        }

        public void limpioGrilla(string table)
        {

        }
        private void resuelvoValor(dynamic oField, object value)
        {

        }

    }
}
