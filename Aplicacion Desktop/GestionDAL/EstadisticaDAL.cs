﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using GestionConector;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using System.Data.SqlClient;
using System.Data;
using GestionDAL.Builder;

namespace GestionDAL
{
    public class EstadisticaDAL
    {
        #region Atributos
        private SqlServerConector _conector;

        private const string SP_TOPCANCELACIONESPROFESIONALES = "[top_4].sp_topcancelacionesprofesionales";
        private const string SP_TOPCANCELACIONESAFILIADOS = "[top_4].sp_topcancelacionesafiliados";
        private const string SP_TOPBONOSFARMACIAVENCIDOSPORAFILIADO = "[top_4].sp_topbonosfarmaciavencidosporafiliado";
        private const string SP_TOPESPECIALIDADESBONOSFARMACIARECETADOS = "[top_4].sp_topespecialidadesbonosfarmaciarecetados";
        private const string SP_TOPAFILIADOSCONBONOSSINCOMPRARPORELLOS = "[top_4].sp_topafiliadosconbonossincomprarporellos";
        #endregion

        #region Constructor
        public EstadisticaDAL(ILog log)
        {
            _conector = new SqlServerConector(log);
        }
        #endregion
        
        #region Listados de Estadisticas
        public IList<TopCancelacionesProfesionales> ObtenerTopCancelacionesProfesionales(FiltroEstadistica filtro)
        {
            IList<SqlParameter> parametros = ArmarFiltro(filtro);

            DataSet ds = _conector.RealizarConsultaAlmacenada(SP_TOPCANCELACIONESPROFESIONALES, parametros);
            IList<TopCancelacionesProfesionales> filas = new List<TopCancelacionesProfesionales>(5);
            
            TopCancelacionesProfesionalesBuilder builder = new TopCancelacionesProfesionalesBuilder();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                filas.Add(builder.Build(row));
            }

            return filas;
        }

        public IList<TopCancelacionesAfiliados> ObtenerTopCancelacionesAfiliados(FiltroEstadistica filtro)
        {
            IList<SqlParameter> parametros = ArmarFiltro(filtro);

            DataSet ds = _conector.RealizarConsultaAlmacenada(SP_TOPCANCELACIONESAFILIADOS, parametros);
            IList<TopCancelacionesAfiliados> filas = new List<TopCancelacionesAfiliados>(5);
            
            TopCancelacionesAfiliadosBuilder builder = new TopCancelacionesAfiliadosBuilder();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                filas.Add(builder.Build(row));   
            }

            return filas;
        }

        public IList<TopBonosFarmaciaVencidosPorAfiliado> ObtenerTopBonosFarmaciaVencidosPorAfiliado(FiltroEstadistica filtro)
        {
            IList<SqlParameter> parametros = ArmarFiltro(filtro);

            DataSet ds = _conector.RealizarConsultaAlmacenada(SP_TOPBONOSFARMACIAVENCIDOSPORAFILIADO, parametros);
            IList<TopBonosFarmaciaVencidosPorAfiliado> filas = new List<TopBonosFarmaciaVencidosPorAfiliado>(5);
            
            TopBonosFarmaciaVencidosPorAfiliadoBuilder builder = new TopBonosFarmaciaVencidosPorAfiliadoBuilder();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                filas.Add(builder.Build(row));
            }

            return filas;
        }

        public IList<TopEspecialidadesBonosFarmaciaRecetados> ObtenerTopEspecialidadesBonosFarmaciaRecetados(FiltroEstadistica filtro)
        {
            IList<SqlParameter> parametros = ArmarFiltro(filtro);

            DataSet ds = _conector.RealizarConsultaAlmacenada(SP_TOPESPECIALIDADESBONOSFARMACIARECETADOS, parametros);
            IList<TopEspecialidadesBonosFarmaciaRecetados> filas = new List<TopEspecialidadesBonosFarmaciaRecetados>(5);
            
            TopEspecialidadesBonosFarmaciaRecetadosBuilder builder = new TopEspecialidadesBonosFarmaciaRecetadosBuilder();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                filas.Add(builder.Build(row));
            }

            return filas;
        }

        public IList<TopAfiliadosConBonosSinComprarPorEllos> ObtenerTopAfiliadosConBonosSinComprarPorEllos(FiltroEstadistica filtro)
        {
            IList<SqlParameter> parametros = ArmarFiltro(filtro);

            DataSet ds = _conector.RealizarConsultaAlmacenada(SP_TOPAFILIADOSCONBONOSSINCOMPRARPORELLOS, parametros);
            IList<TopAfiliadosConBonosSinComprarPorEllos> filas = new List<TopAfiliadosConBonosSinComprarPorEllos>(5);
            
            TopAfiliadosConBonosSinComprarPorEllosBuilder builder = new TopAfiliadosConBonosSinComprarPorEllosBuilder();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                filas.Add(builder.Build(row)); 
            }

            return filas;
        }
        #endregion
        
        #region Métodos privados
        private IList<SqlParameter> ArmarFiltro(FiltroEstadistica filtro)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>(2);
            SqlParameter pDesde = new SqlParameter("@p_desde", System.Data.SqlDbType.DateTime, 8, "p_desde");
            pDesde.Value = filtro.Periodo.Inicio;
            parametros.Add(pDesde);

            SqlParameter pFin = new SqlParameter("@p_fin", System.Data.SqlDbType.DateTime, 8, "p_fin");
            pFin.Value = filtro.Periodo.Fin;
            parametros.Add(pFin);
            
            return parametros;
        }
        #endregion
    }
}
