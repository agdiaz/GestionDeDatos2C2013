using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDomain.Resultados;
using GestionCommon.Entidades;
using GestionDAL;
using GestionCommon.Helpers;
using GestionCommon.Filtros;


namespace GestionDomain
{
    public class AgendaDomain
    {
        private AgendaDAL _dal;
        private DiaAgendaDAL _dalDiaAgenda;
        private EntidadBaseDomain<Agenda, FiltroAgenda> _domain;

        public AgendaDomain(ILog log)
        {
            _dal = new AgendaDAL(log);
            _dalDiaAgenda = new DiaAgendaDAL(log);
            _domain = new EntidadBaseDomain<Agenda, FiltroAgenda>(_dal);
        }

        public IResultado<Agenda> Alta()
        {
            Resultado<Agenda> resultado = new Resultado<Agenda>();
            return resultado;
        }


        public IResultado<Agenda> Alta(Agenda nuevaAgenda, IList<DiaAgenda> diasAgenda)
        {
            Resultado<Agenda> resultado = new Resultado<Agenda>();
            try
            {
                decimal id = _domain.Crear(nuevaAgenda);
                nuevaAgenda.Id = id;

                foreach (DiaAgenda diaAgenda in diasAgenda)
                {
                    decimal idDia = _dalDiaAgenda.Crear(diaAgenda);
                    _dal.AsociarDiaAAgenda(nuevaAgenda.Id, diaAgenda.Id);
                }

                resultado.Retorno = nuevaAgenda;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }
    }
}
