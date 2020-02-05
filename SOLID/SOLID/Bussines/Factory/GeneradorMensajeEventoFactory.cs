using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.Bussines.Interfaces;

namespace SOLID.Bussines.Factory
{
    public class GeneradorMensajeEventoFactory
    {
        /// <summary>
        /// Devuelve el servicio correspondiente de acuerdo al tipo de período recibido como parámetro.
        /// </summary>
        /// <param name="_iTipoPeriodo">Tipo de periodo del Enum BanderasEventos</param>
        /// <returns>Servicio del tipo de interfaz IGeneradorMensajeEvento</returns>
        public IGeneradorMensajeEvento ObtenerInstanciaGeneradorMensajeEvento(int _iTipoPeriodo)
        {
            IGeneradorMensajeEvento svrService = null;

            switch (_iTipoPeriodo)
            {
                case 1:
                    svrService = new GeneradorMensajeEventoMesService();
                    break;
                case 2:
                    svrService = new GeneradorMensajeEventoDiaService();
                    break;
                case 3:
                    svrService = new GeneradorMensajeEventoHoraService();
                    break;
                case 4:
                    svrService = new GeneradorMensajeEventoMinutoService();
                    break;
            }
            return svrService;
        }
    }
}
