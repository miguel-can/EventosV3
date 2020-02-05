using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Bussines.Interfaces
{
    public interface ILectorArchivo
    {
        /// <summary>
        /// Método que recupera el contenido de un archivo de texto.
        /// </summary>
        /// <param name="_cRuta">Ruta fisica del archivo txt.</param>
        /// <returns>Array de strings</returns>
        string[] ObtenerContenido(string _cRuta);
    }
}
