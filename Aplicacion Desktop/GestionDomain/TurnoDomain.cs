using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionCommon.Helpers;

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
    }
}
