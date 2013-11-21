using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDomain.Resultados;
using GestionCommon.Entidades;
using GestionDAL;
using GestionCommon.Helpers;
using GestionCommon.Filtros;
using System.Data.SqlClient;

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
                Boolean resul = _dal.AgendaValida(nuevaAgenda);
                if (!resul)
                {
                    throw new NotImplementedException("Superposición de días de la agenda.");
                }
                                
                nuevaAgenda.Id = _domain.Crear(nuevaAgenda);

                foreach (DiaAgenda diaAgenda in diasAgenda)
                {
                    diaAgenda.Id = nuevaAgenda.Id;
                    decimal idDia = _dalDiaAgenda.Crear(diaAgenda); //Asocia la agenda creada con los días.
                }

                resultado.Retorno = nuevaAgenda;
            }
            catch (SqlException ex)
            {
                resultado.Correcto = false;
                if (ex.Errors.Count > 0)
                {
                    // Violación de constraint UNIQUE
                    if (ex.Class == 14 && (ex.Number == 2627 || ex.Number == 50000))
                    {
                        resultado.Mensajes.Add("No se permite valores repetidos.");
                    }
                }
                resultado.Mensajes.Add(ex.Message);
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
