using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using GestionDAL;
using GestionCommon.Entidades;
using GestionDomain.Resultados;
using GestionCommon.Filtros;

namespace GestionDomain
{
    public class EstadisticaDomain
    {
        private EstadisticaDAL _dal;

        public EstadisticaDomain(ILog log)
        {
            _dal = new EstadisticaDAL(log);
        }

        public IResultado<IList<Estadistica>> ObtenerTodos()
        {
            Resultado<IList<Estadistica>> resultado = new Resultado<IList<Estadistica>>();

            IList<Estadistica> estadisticas = new List<Estadistica>();
            estadisticas.Add(new TopAfiliadosConBonosSinComprarPorEllos());
            estadisticas.Add(new TopBonosFarmaciaVencidosPorAfiliado());
            estadisticas.Add(new TopCancelacionesProfesionales());
            estadisticas.Add(new TopEspecialidadesBonosFarmaciaRecetados());

            resultado.Retorno = estadisticas;

            return resultado;
        }

        public IResultado<IList<TopCancelacionesProfesionales>> ObtenerTopCancelacionesProfesionales(FiltroEstadistica filtro)
        {
            Resultado<IList<TopCancelacionesProfesionales>> resultado = new Resultado<IList<TopCancelacionesProfesionales>>();
            try
            {
                resultado.Retorno = _dal.ObtenerTopCancelacionesProfesionales(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<IList<TopBonosFarmaciaVencidosPorAfiliado>> ObtenerTopBonosFarmaciaVencidosPorAfiliado(FiltroEstadistica filtro)
        {
            Resultado<IList<TopBonosFarmaciaVencidosPorAfiliado>> resultado = new Resultado<IList<TopBonosFarmaciaVencidosPorAfiliado>>();
            try
            {
                resultado.Retorno = _dal.ObtenerTopBonosFarmaciaVencidosPorAfiliado(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<IList<TopEspecialidadesBonosFarmaciaRecetados>> ObtenerTopEspecialidadesBonosFarmaciaVencidos(FiltroEstadistica filtro)
        {
            Resultado<IList<TopEspecialidadesBonosFarmaciaRecetados>> resultado = new Resultado<IList<TopEspecialidadesBonosFarmaciaRecetados>>();
            try
            {
                resultado.Retorno = _dal.ObtenerTopEspecialidadesBonosFarmaciaRecetados(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<IList<TopAfiliadosConBonosSinComprarPorEllos>> ObtenerTopAfiliadosConBonosSinComprarPorEllos(FiltroEstadistica filtro)
        {
            Resultado<IList<TopAfiliadosConBonosSinComprarPorEllos>> resultado = new Resultado<IList<TopAfiliadosConBonosSinComprarPorEllos>>();
            try
            {
                resultado.Retorno = _dal.ObtenerTopAfiliadosConBonosSinComprarPorEllos(filtro);
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
