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
        public string Especialidad { get; set; }
        public int CantidadCancelaciones { get; set; }

        public TopCancelacionesProfesionales()
            : base(1, "Top 5 de las especialidades que más registraron cancelaciones de profesionales")
        {
            
        }
    }

    public class TopCancelacionesAfiliados : Estadistica
    {
        public TopCancelacionesAfiliados()
            : base(99, "Top 5 de las especialidades que más registraron cancelaciones de pacientes")
        {

        }
    }

    public class TopBonosFarmaciaVencidosPorAfiliado : Estadistica
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int BonosVencidosFarmacia { get; set; }

        public TopBonosFarmaciaVencidosPorAfiliado()
            : base(2, "Top 5 de la cantridad total de bonos farmacia vencidos por afiliado")
        {

        }
    }

    public class TopEspecialidadesBonosFarmaciaRecetados : Estadistica
    {
        public string Especialidad { get; set; }
        public int BonosFarmaciaRecetados { get; set; }

        public TopEspecialidadesBonosFarmaciaRecetados()
            :base(3, "Top 5 de las especialidades de médicos con más bonos de farmacia recetados")
        {

        }
    }

    public class TopAfiliadosConBonosSinComprarPorEllos : Estadistica
    {
        public decimal IdAfiliado { get; set; }
        public int BonosUtilizados { get; set; }

        public TopAfiliadosConBonosSinComprarPorEllos()
            :base(4, "Top 10 de los afiliados que utilizaron bonos que ellos mismos no compraron")
        {

        }

    }   
}