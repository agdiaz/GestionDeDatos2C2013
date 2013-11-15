using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using GestionDAL;
using GestionDomain.Resultados;
using GestionCommon.Entidades;

namespace GestionDomain
{
    public class CancelacionDomain
    {
        private CancelacionDAL _dal;

        public CancelacionDomain(ILog log)
        {
            _dal = new CancelacionDAL(log);
        }

        public IResultado<GestionCommon.Entidades.Cancelacion> Cancelar(Cancelacion c)
        {
            Resultado<Cancelacion> resultado = new Resultado<Cancelacion>();
            try
            {
                _dal.RegistrarCancelacion(c);
                resultado.Retorno = c;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<IList<Turno>> BuscarTurnos(decimal idP, DateTime fecha)
        {
            Resultado<IList<Turno>> resultado = new Resultado<IList<Turno>>();
            try
            {
                resultado.Retorno = _dal.BuscarTurnos(idP, fecha);
            }
            catch (Exception ex)
            {
                resultado.Retorno = new List<Turno>();
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

    }
}
