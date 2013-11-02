using System;
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

        private const string SP_TOPCANCELACIONESPROFESIONALES = "sp_topcancelacionesprofesionales";
        private const string SP_TOPCANCELACIONESAFILIADOS = "sp_topcancelacionesafiliados";
        private const string SP_TOPBONOSFARMACIAVENCIDOSPORAFILIADO = "sp_topbonosfarmaciavencidosporafiliado";
        private const string SP_TOPESPECIALIDADESBONOSFARMACIAVENCIDOS = "sp_topespecialidadesbonosfarmaciavencidos";
        private const string SP_TOPAFILIADOSCONBONOSSINCOMPRARPORELLOS = "sp_topafiliadosconbonossincomprarporellos";
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

        public IList<TopEspecialidadesBonosFarmaciaVencidos> ObtenerTopEspecialidadesBonosFarmaciaVencidos(FiltroEstadistica filtro)
        {
            IList<SqlParameter> parametros = ArmarFiltro(filtro);

            DataSet ds = _conector.RealizarConsultaAlmacenada(SP_TOPESPECIALIDADESBONOSFARMACIAVENCIDOS, parametros);
            IList<TopEspecialidadesBonosFarmaciaVencidos> filas = new List<TopEspecialidadesBonosFarmaciaVencidos>(5);
            
            TopEspecialidadesBonosFarmaciaVencidosBuilder builder = new TopEspecialidadesBonosFarmaciaVencidosBuilder();

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
            SqlParameter pDesde = new SqlParameter("@p_desde", System.Data.SqlDbType.DateTime, 4, "p_desde");
            pDesde.Value = filtro.Periodo.Inicio;
            parametros.Add(pDesde);

            SqlParameter pFin = new SqlParameter("@p_fin", System.Data.SqlDbType.DateTime, 4, "p_fin");
            pFin.Value = filtro.Periodo.Fin;
            parametros.Add(pFin);
            
            return parametros;
        }
        #endregion
    }
}
