using SOLID.Bussines.Interfaces;
using System;
using System.Collections.Generic;

namespace SOLID.Bussines
{
    public class GeneradorImpresionConsolaService : IGeneradorImpresionEvento
    {
        /// <summary>
        /// Imprime los eventos que se reciben como parámetro en consola
        /// </summary>
        /// <param name="lstEventos">Lista de evento</param>
        public void ImprimirEventos(List<EventosDTO> _lstEventos)
        {
            foreach (EventosDTO item in _lstEventos)
            {
                Console.WriteLine(item.cEvento + " " + item.cEventoImprime);
            }

            Console.Write("Presiona cualquier tecla para salir del programa...");
            Console.ReadKey();
        }
    }
}
