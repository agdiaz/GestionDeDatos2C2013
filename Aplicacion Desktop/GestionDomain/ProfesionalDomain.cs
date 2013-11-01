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
    public class ProfesionalDomain
    {
        private ProfesionalDAL _dal;
        private EntidadBaseDomain<Profesional, FiltroProfesional> _domain;

        public ProfesionalDomain(ILog log)
        {
            _dal = new ProfesionalDAL(log);
            _domain = new EntidadBaseDomain<Profesional, FiltroProfesional>(_dal);
        }

        public IResultado<IList<Profesional>> ObtenerTodos()
        {
            Resultado<IList<Profesional>> resultado = new Resultado<IList<Profesional>>();

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

        public IResultado<IList<Profesional>> Filtrar(FiltroProfesional filtro)
        {
            Resultado<IList<Profesional>> resultado = new Resultado<IList<Profesional>>();
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

        public IResultado<Profesional> Crear(Profesional profesional)
        {
            Resultado<Profesional> resultado = new Resultado<Profesional>();

            try
            {
                resultado.Retorno = _domain.Crear(profesional);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<Profesional> Modificar(Profesional profesional)
        {
            Resultado<Profesional> resultado = new Resultado<Profesional>();

            try
            {
                resultado.Retorno = _domain.Modificar(profesional);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<bool> Borrar(Profesional profesional)
        {
            Resultado<bool> resultado = new Resultado<bool>();
            try
            {
                _domain.Borrar(profesional.IdProfesional);
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

    }
}
