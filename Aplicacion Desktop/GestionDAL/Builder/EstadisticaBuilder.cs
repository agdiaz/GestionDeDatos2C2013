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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        #endregion
    }

    public class TopEspecialidadesBonosFarmaciaVencidosBuilder : IBuilder<TopEspecialidadesBonosFarmaciaVencidos>
    {

        #region Miembros de IBuilder<TopEspecialidadesBonosFarmaciaVencidos>

        public TopEspecialidadesBonosFarmaciaVencidos Build(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class TopAfiliadosConBonosSinComprarPorEllosBuilder : IBuilder<TopAfiliadosConBonosSinComprarPorEllos>
    {

        #region Miembros de IBuilder<TopAfiliadosConBonosSinComprarPorEllos>

        public TopAfiliadosConBonosSinComprarPorEllos Build(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
