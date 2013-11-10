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
        private EntidadBaseDomain<Turno, FiltroTurno> _domain;

        public TurnoDomain(ILog log)
        {
            _dal = new TurnoDAL(log);
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
    }
}
