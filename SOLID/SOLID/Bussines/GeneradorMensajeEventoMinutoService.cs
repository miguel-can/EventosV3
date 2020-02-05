using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.Bussines.Interfaces;

namespace SOLID.Bussines
{
    public class GeneradorMensajeEventoMinutoService : IGeneradorMensajeEvento
    {
        /// <summary>
        /// Método que generá un Mensaje para el período Minuto.
        /// </summary>
        /// <param name="_lActual">lActual: Si la fecha no es pasado</param>
        /// <param name="_dCantidad">Cantidad en meses, días, horas o minutos</param>
        /// <returns>Cadena</returns>
        public string GeneraMensaje(bool _lActual, double _dCantidad)
        {
            return string.Format(_lActual ? " Ocurrirá dentro de {0} Minutos" : " Ocurrio hace {0} Minutos", _dCantidad);
        }
    }
}
