﻿using System;
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
                decimal id = _domain.Crear(profesional);
                profesional.IdProfesional = id;

                resultado.Retorno = profesional;
            }
            catch (SqlException ex)
            {
                resultado.Correcto = false;
                if (ex.Errors.Count > 0)
                {
                    // Violación de constraint UNIQUE
                    if (ex.Class == 14 && (ex.Number == 2627 || ex.Number == 50000))
                    {
                        resultado.Mensajes.Add("No se permite valores repetidos para los campos 'Nro de Documento' o 'Matricula'.");
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

        public IResultado<Profesional> Modificar(Profesional profesional)
        {
            Resultado<Profesional> resultado = new Resultado<Profesional>();

            try
            {
                resultado.Retorno = _domain.Modificar(profesional);
            }
            catch (SqlException ex)
            {
                resultado.Correcto = false;
                if (ex.Errors.Count > 0)
                {
                    // Violación de constraint UNIQUE
                    if (ex.Class == 14 && (ex.Number == 2627 || ex.Number == 50000))
                    {
                        resultado.Mensajes.Add("No se permite valores repetidos para los campos 'Nro de Documento' o 'Matricula'.");
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

        public IResultado<bool> AsociarProfesionalEspecialidad(Profesional profesional, Especialidad especialidad)
        {
            Resultado<bool> resultado = new Resultado<bool>();

            try
            {
                resultado.Retorno = _dal.AsociarProfesionalEspecialidad(profesional, especialidad);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<bool> LimpiarEspecialidades(Profesional prof)
        {
            Resultado<bool> resultado = new Resultado<bool>();
            try
            {
                _dal.LimpiarEspecialidades(prof);
                resultado.Retorno = true;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<Profesional> ObtenerPorUsuario(Usuario usuario)
        {
            Resultado<Profesional> resultado = new Resultado<Profesional>();
            try
            {
                resultado.Retorno = _dal.ObtenerPorUsuario(usuario.IdUsuario);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add("No se ha encontrado el profesional para ese usuario");
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }
    }
}
