using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Bussines.Interfaces
{
    public interface IGeneradorImpresionEvento
    {
        /// <summary>
        /// Imprime los eventos que se reciben como parámetro
        /// </summary>
        /// <param name="lstEventos">Lista de eventos</param>
        void ImprimirEventos(List<EventosDTO> lstEventos);
    }
}
