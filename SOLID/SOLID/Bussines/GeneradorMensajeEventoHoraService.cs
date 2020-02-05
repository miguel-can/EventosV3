using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.Bussines.Interfaces;

namespace SOLID.Bussines
{
    public class GeneradorMensajeEventoHoraService : IGeneradorMensajeEvento
    {
        /// <summary>
        /// Método que generá un Mensaje para el período Hora.
        /// </summary>
        /// <param name="_lActual">lActual: Si la fecha no es pasado</param>
        /// <param name="_dCantidad">Cantidad en meses, días, horas o minutos</param>
        /// <returns>Cadena</returns>
        public string GeneraMensaje(bool _lActual, double _dCantidad)
        {
            return string.Format(_lActual ? " Ocurrirá dentro de {0} Horas" : " Ocurrio hace {0} Horas", _dCantidad);
        }
    }
}
