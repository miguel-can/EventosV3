using System;
using System.Collections.Generic;
using SOLID.Bussines.Interfaces;
using SOLID.Bussines.Factory;
using SOLID.Data.Enum;
namespace SOLID.Bussines
{
    public class ProcesadorEventosTxtService : IProcesadorArchivo
    {
        private ILectorArchivo svrLectorArchivoTxt;
        private string cSeparador;
        private DateTime dtFechaActual;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_svrLectorArchivoTxt">Objeto del tipo ILectorArchivo</param>
        public ProcesadorEventosTxtService(ILectorArchivo _svrLectorArchivoTxt)
        {
            this.svrLectorArchivoTxt = _svrLectorArchivoTxt;
        }
        /// <summary>
        /// Contiene la lógica para el procesamiento de un archivo de texto
        /// </summary>
        /// <param name="_cRutaArchivo">Ruta fisica del archivo txt.</param>
        /// <param name="_cSeparador">Simbolo separador</param>
        /// <param name="_dtFecha">Fecha a comparar</param>
        /// <returns>Lista del tipo EventosDTO</returns>
        public List<EventosDTO> Procesar(string _cRutaArchivo, string _cSeparador, DateTime _dtFecha)
        {
            string[] arrContenido = null;
            List<EventosDTO> lstEventos = new List<EventosDTO>();
            EventosDTO entEvento = new EventosDTO();
            IGeneradorMensajeEvento svrGeneradorEventoService = null;
            this.cSeparador = _cSeparador;
            this.dtFechaActual = _dtFecha;
            arrContenido = this.svrLectorArchivoTxt.ObtenerContenido(_cRutaArchivo);            
            GeneradorMensajeEventoFactory generadorEventoFactory = new GeneradorMensajeEventoFactory();            

            foreach (var a in arrContenido)
            {
                entEvento = new EventosDTO();
                ValidarEntrada(a);
                entEvento = crearInstancia(a);
                //MES
                if (entEvento.iTotalMeses >= 1 || entEvento.iTotalMeses <= -1)
                {
                    svrGeneradorEventoService = generadorEventoFactory.ObtenerInstanciaGeneradorMensajeEvento((int)BanderasEvento.Periodos.MES);
                    entEvento.cEventoImprime = svrGeneradorEventoService.GeneraMensaje((entEvento.iTotalMeses > 0 ? true : false), Math.Truncate(Math.Abs(entEvento.iTotalMeses)));
                } // DIA
                else if (entEvento.iTotalDias >= 1 || entEvento.iTotalDias <= -1)
                {
                    svrGeneradorEventoService = generadorEventoFactory.ObtenerInstanciaGeneradorMensajeEvento((int)BanderasEvento.Periodos.DIA);
                    entEvento.cEventoImprime = svrGeneradorEventoService.GeneraMensaje((entEvento.iTotalDias > 0 ? true : false), Math.Truncate(Math.Abs(entEvento.iTotalDias)));
                }//Horas
                else if (entEvento.iTotalHOras >= 1 || entEvento.iTotalHOras <= -1)
                {
                    svrGeneradorEventoService = generadorEventoFactory.ObtenerInstanciaGeneradorMensajeEvento((int)BanderasEvento.Periodos.HORA);
                    entEvento.cEventoImprime = svrGeneradorEventoService.GeneraMensaje((entEvento.iTotalHOras > 0 ? true : false), Math.Truncate(Math.Abs(entEvento.iTotalHOras)));
                }//Minutos
                else if (entEvento.iTotalMinutos >= 1 || entEvento.iTotalMinutos <= -1)
                {
                    svrGeneradorEventoService = generadorEventoFactory.ObtenerInstanciaGeneradorMensajeEvento((int)BanderasEvento.Periodos.MINUTO);
                    entEvento.cEventoImprime = svrGeneradorEventoService.GeneraMensaje((entEvento.iTotalMinutos > 0 ? true : false), Math.Truncate(Math.Abs(entEvento.iTotalMinutos)));
                }
                lstEventos.Add(entEvento);
            }
            return lstEventos;
        }
        /// <summary>
        /// Verifica que la linea recibida como parámetro coincida con el separado especificado
        /// </summary>
        /// <param name="_cLinea">Linea de texto del archivo de texto</param>
        private void ValidarEntrada(string _cLinea)
        {
            if (!_cLinea.Contains(cSeparador))
                throw new Exception("No tiene el formato correcto");
        }
        /// <summary>
        /// Genera una instancia de la clase EventosDTO
        /// </summary>
        /// <param name="_cLinea">Linea de texto del archivo de texto</param>
        /// <returns>Instancia de la clase EventosDTO</returns>
        private EventosDTO crearInstancia(string _cLinea)
        {
            EventosDTO Evento = new EventosDTO();
            string[] arrayDatos = ExtraerCampos(_cLinea);
            AsignarCampos(Evento, arrayDatos);
            return Evento;
        }
        /// <summary>
        /// Asigna valores a los campos de la clase EventosDTO 
        /// </summary>
        /// <param name="_evento">Objeto de la clase EventosDTO</param>
        /// <param name="_arrayDatos">Array con los valores de la linea</param>
        private void AsignarCampos(EventosDTO _evento, string[] _arrayDatos)
        {
            DateTime dtEvento = DateTime.Parse(_arrayDatos[1]);
            TimeSpan time = ObtenerDiferenciaFecha(dtFechaActual, dtEvento);            
            _evento.cEvento = _arrayDatos[0];
            _evento.dtEvento = dtEvento;
            _evento.iTotalDias = time.TotalDays;
            _evento.iTotalHOras = time.TotalHours;
            _evento.iTotalMinutos = time.TotalMinutes;
            _evento.iTotalMeses = CalcularNumeroMeses(time.TotalDays);
        }    
        /// <summary>
        /// Obtiene en forma de array el contenido de la linea de texto.
        /// </summary>
        /// <param name="_cLinea">Linea de texto del archivo de texto</param>
        /// <returns>Array de strings</returns>
        private string[] ExtraerCampos(string _cLinea)
        {
            return _cLinea.Split(cSeparador[0]);
        }
        /// <summary>
        /// Obtiene la diferencia entre dos fechas.
        /// </summary>
        /// <param name="_dtInicio">Fecha de inicio</param>
        /// <param name="_dtFin">Fecha fin</param>
        /// <returns>Diferencia entre fecha en TimeSpan</returns>
        private TimeSpan ObtenerDiferenciaFecha(DateTime _dtInicio, DateTime _dtFin)
        {
            return _dtFin - _dtInicio;
        }
        private double CalcularNumeroMeses(double dTotalDias)
        {
            return dTotalDias / 30;
        }
    }
}
