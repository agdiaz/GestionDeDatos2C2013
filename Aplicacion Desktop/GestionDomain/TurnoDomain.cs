using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionCommon.Helpers;
using GestionDomain.Resultados;

namespace GestionDomain
{
    public class TurnoDomain
    {
        private TurnoDAL _dal;
        private ResultadoTurnoDAL _resultadoTurnoDal;

        private EntidadBaseDomain<Turno, FiltroTurno> _domain;

        public TurnoDomain(ILog log)
        {
            _dal = new TurnoDAL(log);
            _resultadoTurnoDal = new ResultadoTurnoDAL(log);
            _domain = new EntidadBaseDomain<Turno, FiltroTurno>(_dal);
        }

        public IResultado<bool> RegistrarTurno(Turno t)
        {
            Resultado<bool> resultado = new Resultado<bool>();
            try
            {
                _dal.Crear(t);
                resultado.Retorno = true;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<ResultadoTurno> RegistrarResultadoTurno(ResultadoTurno t)
        {
            Resultado<ResultadoTurno> resultado = new Resultado<ResultadoTurno>();
            try
            {
                decimal id = _resultadoTurnoDal.Crear(t);
                t.IdResultadoTurno = id;
                resultado.Retorno = t;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<FechaTurno> ObtenerFechasParaTurnos(decimal idProfesional, DateTime hoy)
        {
            Resultado<FechaTurno> resultado = new Resultado<FechaTurno>();
            try
            {
                resultado.Retorno = _resultadoTurnoDal.ObtenerFechasParaTurnos(idProfesional, hoy);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add("No se encontraron días disponibles");
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<IList<TurnoDisponible>> ObtenerHorasParaTurno(DateTime hoy, decimal idProfesional)
        {
            Resultado<IList<TurnoDisponible>> resultado = new Resultado<IList<TurnoDisponible>>();
            try
            {
                resultado.Retorno = _resultadoTurnoDal.ObtenerHorasParaTurno(idProfesional, hoy);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add("No se encontraron horas");
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }
    }
}
