using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using GestionDAL;
using GestionCommon.Entidades;
using GestionDomain.Resultados;

namespace GestionDomain
{
    public class TipoCancelacionDomain
    {
        private TipoCancelacionDAL _dal;
        public TipoCancelacionDomain(ILog log)
        {
            _dal = new TipoCancelacionDAL(log);
        }

        public IResultado<IList<TipoCancelacion>> ObtenerTodos()
        {
            Resultado<IList<TipoCancelacion>> resultado = new Resultado<IList<TipoCancelacion>>();
            try
            {
                resultado.Retorno = _dal.ObtenerTodos();
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
