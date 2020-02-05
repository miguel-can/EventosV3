using SOLID.Bussines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Bussines
{
    public class GeneradorMensajeEventoMesService : IGeneradorMensajeEvento
    {
        /// <summary>
        /// Método que generá un Mensaje para el período Mes.
        /// </summary>
        /// <param name="_lActual">lActual: Si la fecha no es pasado</param>
        /// <param name="_dCantidad">Cantidad en meses, días, horas o minutos</param>
        /// <returns>Cadena</returns>
        public string GeneraMensaje(bool _lActual, double _dCantidad)
        {
            return string.Format(_lActual ? " Ocurrirá dentro de {0} Meses" : " Ocurrio hace {0} Meses", _dCantidad);
        }
    }
}
