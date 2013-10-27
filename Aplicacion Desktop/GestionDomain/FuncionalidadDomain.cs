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
    public class FuncionalidadDomain
    {
        private FuncionalidadDAL _dal;
        private EntidadBaseDomain<Funcionalidad> _domain;

        public FuncionalidadDomain(ILog log)
        {
            _dal = new FuncionalidadDAL(log);
            _domain = new EntidadBaseDomain<Funcionalidad>(_dal);
        }

        public IResultado<Funcionalidad> Obtener(int id)
        {
            Resultado<Funcionalidad> resultado = new Resultado<Funcionalidad>();
            
            if (id > 0)
            {
                try
                {
                    resultado.Retorno = _domain.Obtener(id);
                }
                catch (Exception ex)
                {
                    resultado.Correcto = false;
                    resultado.Mensajes.Add(ex.Message);
                }
            }
            else
            {
                resultado.Retorno = ObtenerFuncionalidadGenerica().Retorno;
            }
            return resultado;
        }

        public IResultado<Funcionalidad> ObtenerFuncionalidadGenerica()
        {
            Resultado<Funcionalidad> resultado = new Resultado<Funcionalidad>();
            Funcionalidad f = new Funcionalidad() { IdFuncionalidad = -1, Nombre = "Sin identificar"};
            return resultado;
        }

        public IResultado<IList<Funcionalidad>> ObtenerFuncionalidades(decimal idRol)
        {
            Resultado<IList<Funcionalidad>> resultado = new Resultado<IList<Funcionalidad>>();
            if (idRol > 0)
            {
                try
                {
                    resultado.Retorno = _dal.ObtenerFuncionalidades(idRol);
                }
                catch (Exception ex)
                {
                    resultado.Correcto = false;
                    resultado.Mensajes.Add(ex.Message);
                }
            }
            else
            {
                IList<Funcionalidad> funcionalidades = new List<Funcionalidad>();

                resultado.Retorno = funcionalidades;
            }

            return resultado;

        }

        public IResultado<IList<Funcionalidad>> ObtenerTodos()
        {
            Resultado<IList<Funcionalidad>> resultado = new Resultado<IList<Funcionalidad>>();
            try
            {
                //Solo DEBUG:
                //resultado.Retorno = _domain.ObtenerTodos();
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
