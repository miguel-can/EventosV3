using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Bussines.Interfaces
{
    public interface IGeneradorMensajeEvento
    {
        /// <summary>
        /// Método que generá un Mensaje de acuerdo a los parámetros recibidos.
        /// </summary>
        /// <param name="lActual">lActual: Si la fecha no es pasado</param>
        /// <param name="dCantidad">Cantidad en meses, días, horas o minutos</param>
        /// <returns>Cadena</returns>
        string  GeneraMensaje(bool lActual, double dCantidad);
    }
}
