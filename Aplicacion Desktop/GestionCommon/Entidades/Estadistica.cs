using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Estadistica
    {
        public decimal IdEstadistica { get; private set; }
        public string NombreEstadistica { get; private set; }

        public Estadistica(decimal idEstadistica, string nombreEstadistica)
        {
            IdEstadistica = idEstadistica;
            NombreEstadistica = nombreEstadistica;
        }
    }

    public class TopCancelacionesProfesionales : Estadistica
    {
        public TopCancelacionesProfesionales()
            : base(1, "Top 5 de las especialidades que más registraron cancelaciones de profesionales")
        {

        }
    }

    public class TopCancelacionesAfiliados : Estadistica
    {
        public TopCancelacionesAfiliados()
            : base(2, "Top 5 de las especialidades que más registraron cancelaciones de pacientes")
        {

        }
    }

    public class TopBonosFarmaciaVencidosPorAfiliado : Estadistica
    {
        public TopBonosFarmaciaVencidosPorAfiliado()
            : base(3, "Top 5 de la cantridad total de bonos farmacia vencidos por afiliado")
        {

        }
    }

    public class TopEspecialidadesBonosFarmaciaVencidos : Estadistica
    {
        public TopEspecialidadesBonosFarmaciaVencidos()
            :base(4, "Top 5 de las especialidades de médicos con más bonos de farmacia recetados")
        {

        }
    }

    public class TopAfiliadosConBonosSinComprarPorEllos : Estadistica
    {
        public TopAfiliadosConBonosSinComprarPorEllos()
            :base(5, "Top 10 de los afiliados que utilizaron bonos que ellos mismos no compraron")
        {

        }

    }   
}