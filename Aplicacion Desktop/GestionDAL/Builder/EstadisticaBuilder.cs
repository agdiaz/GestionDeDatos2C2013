using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class TopCancelacionesProfesionalesBuilder : IBuilder<TopCancelacionesProfesionales>
    {

        #region Miembros de IBuilder<TopCancelacionesProfesionales>

        public TopCancelacionesProfesionales Build(System.Data.DataRow row)
        {
            TopCancelacionesProfesionales topCancelacionesProfesionales = new TopCancelacionesProfesionales();
            topCancelacionesProfesionales.Especialidad = row["especialidad"].ToString();
            topCancelacionesProfesionales.CantidadCancelaciones = Convert.ToInt32(row["cantidad_cancelaciones"].ToString());
            return topCancelacionesProfesionales;
        }

        #endregion
    }

    public class TopCancelacionesAfiliadosBuilder : IBuilder<TopCancelacionesAfiliados>
    {

        #region Miembros de IBuilder<TopCancelacionesAfiliados>

        public TopCancelacionesAfiliados Build(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class TopBonosFarmaciaVencidosPorAfiliadoBuilder : IBuilder<TopBonosFarmaciaVencidosPorAfiliado>
    {

        #region Miembros de IBuilder<TopBonosFarmaciaVencidosPorAfiliado>

        public TopBonosFarmaciaVencidosPorAfiliado Build(System.Data.DataRow row)
        {
            TopBonosFarmaciaVencidosPorAfiliado topBonosFarmaciaVencidasPorAfiliado = new TopBonosFarmaciaVencidosPorAfiliado();
            topBonosFarmaciaVencidasPorAfiliado.IdAfiliado = Convert.ToDecimal(row["id_afiliado"].ToString());
            topBonosFarmaciaVencidasPorAfiliado.BonosVencidosFarmacia = Convert.ToInt32(row["bonos_vencidos"].ToString());
            return topBonosFarmaciaVencidasPorAfiliado;
        }

        #endregion
    }

    public class TopEspecialidadesBonosFarmaciaRecetadosBuilder : IBuilder<TopEspecialidadesBonosFarmaciaRecetados>
    {

        #region Miembros de IBuilder<TopEspecialidadesBonosFarmaciaVencidos>

        public TopEspecialidadesBonosFarmaciaRecetados Build(System.Data.DataRow row)
        {
            TopEspecialidadesBonosFarmaciaRecetados topEspecialidadesBonosFarmaciaRecetados = new TopEspecialidadesBonosFarmaciaRecetados();
            topEspecialidadesBonosFarmaciaRecetados.Especialidad = row["especialidad"].ToString();
            topEspecialidadesBonosFarmaciaRecetados.BonosFarmaciaRecetados = Convert.ToInt32(row["bonos_farmacia_recetados"].ToString());
            return topEspecialidadesBonosFarmaciaRecetados;
        }

        #endregion
    }

    public class TopAfiliadosConBonosSinComprarPorEllosBuilder : IBuilder<TopAfiliadosConBonosSinComprarPorEllos>
    {

        #region Miembros de IBuilder<TopAfiliadosConBonosSinComprarPorEllos>

        public TopAfiliadosConBonosSinComprarPorEllos Build(System.Data.DataRow row)
        {
            TopAfiliadosConBonosSinComprarPorEllos topAfiliadosConBonosSinComprarPorEllos = new TopAfiliadosConBonosSinComprarPorEllos();
            topAfiliadosConBonosSinComprarPorEllos.IdAfiliado = Convert.ToDecimal(row["id_afiliado"].ToString());
            topAfiliadosConBonosSinComprarPorEllos.BonosUtilizados = Convert.ToInt32(row["bonos_utilizados"].ToString());
            return topAfiliadosConBonosSinComprarPorEllos;
        }

        #endregion
    }

}
