using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Bussines.Interfaces
{
    public interface IProcesadorArchivo 
    {
        /// <summary>
        /// Contiene la lógica para el procesamiento de un archivo
        /// </summary>
        /// <param name="_cRutaArchivo">Ruta fisica del archivo txt.</param>
        /// <param name="_cSeparador">Simbolo separador</param>
        /// <param name="_dtFecha">Fecha a comparar</param>
        /// <returns>Lista del tipo EventosDTO</returns>
        List<EventosDTO> Procesar(string _cRutaArchivo, string _cSeparador, DateTime _dtFecha);
    }
}
