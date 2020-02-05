using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID.Bussines.Interfaces;
using SOLID.Bussines;

namespace SOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
                evento1,25/01/2020
                evento2,30/01/2020 12:00:00 PM (Formato para HRS)
             */

            List<EventosDTO> lstEventosFinal = new List<EventosDTO>();            
            ILectorArchivo svrLeerArchivoService = new LectorArchivoTxtService();
            IGeneradorImpresionEvento svrGeneradorImpresion = new GeneradorImpresionConsolaService();

            ProcesadorEventosTxtService objProcesadorEventosTxt = new ProcesadorEventosTxtService(svrLeerArchivoService);
            lstEventosFinal = objProcesadorEventosTxt.Procesar(@"file.txt", ",", DateTime.Now);
            svrGeneradorImpresion.ImprimirEventos(lstEventosFinal);
        }
    }
}
