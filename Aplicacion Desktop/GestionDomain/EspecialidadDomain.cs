using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionCommon.Helpers;
using GestionDomain.Resultados;
using System.Data.SqlClient;

namespace GestionDomain
{
    public class EspecialidadDomain
    {
        private EspecialidadDAL _dal;
        private EntidadBaseDomain<Especialidad, FiltroEspecialidad> _domain;

        public EspecialidadDomain(ILog log)
        {
            _dal = new EspecialidadDAL(log);
            _domain = new EntidadBaseDomain<Especialidad, FiltroEspecialidad>(_dal);
        }

        public IResultado<IList<Especialidad>> ObtenerTodos()
        {
            Resultado<IList<Especialidad>> resultado = new Resultado<IList<Especialidad>>();

            try
            {
                resultado.Retorno = _domain.ObtenerTodos();
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }
        
        public IResultado<IList<Especialidad>> Filtrar(FiltroEspecialidad filtro)
        {
            Resultado<IList<Especialidad>> resultado = new Resultado<IList<Especialidad>>();
            try
            {
                resultado.Retorno = _domain.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<Especialidad> Crear(Especialidad especialidad)
        {
            Resultado<Especialidad> resultado = new Resultado<Especialidad>();

            try
            {
                decimal id = _domain.Crear(especialidad);
                especialidad.IdEspecialidad = id;
                resultado.Retorno = especialidad;
            }
            catch (SqlException ex)
            {
                resultado.Correcto = false;
                if (ex.Errors.Count > 0)
                {
                    // Violación de constraint UNIQUE
                    if (ex.Class == 14 && (ex.Number == 2627 || ex.Number == 50000))
                    {
                        resultado.Mensajes.Add("No se permite valores repetidos para los campos.");
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

        public IResultado<Especialidad> Modificar(Especialidad especialidad)
        {
            Resultado<Especialidad> resultado = new Resultado<Especialidad>();

            try
            {
                resultado.Retorno = _domain.Modificar(especialidad);
            }
            catch (SqlException ex)
            {
                resultado.Correcto = false;
                if (ex.Errors.Count > 0)
                {
                    // Violación de constraint UNIQUE
                    if (ex.Class == 14 && (ex.Number == 2627 || ex.Number == 50000))
                    {
                        resultado.Mensajes.Add("No se permite valores repetidos para los campos.");
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

        public IResultado<bool> Borrar(Especialidad especialidad)
        {
            Resultado<bool> resultado = new Resultado<bool>();
            try
            {
                _domain.Borrar(especialidad.IdEspecialidad);
                resultado.Retorno = true;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
                throw;
            }

            return resultado;
        }

        public IResultado<IList<Especialidad>> ObtenerPorProfesional(Profesional profesional)
        {
            Resultado<IList<Especialidad>> resultado = new Resultado<IList<Especialidad>>();

            try
            {
                resultado.Retorno = _dal.ObtenerPorProfesional(profesional);
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
