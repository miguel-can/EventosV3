using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.Bussines.Interfaces;
namespace SOLID.Bussines
{
    public class LectorArchivoTxtService : ILectorArchivo
    {
        /// <summary>
        /// Método que recupera el contenido de un archivo de texto.
        /// </summary>
        /// <param name="_cRuta">Ruta fisica del archivo txt.</param>
        /// <returns>Array de strings</returns>
        public string[] ObtenerContenido(string _cRuta)
        {
            return System.IO.File.ReadAllLines(_cRuta);
        }
    }
}
