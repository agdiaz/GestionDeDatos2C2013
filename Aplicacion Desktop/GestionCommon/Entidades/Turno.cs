using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Turno
    {
        public DateTime Fecha { get; set; }
        public decimal IdTurno { get; set; }
        public decimal IdProfesional { get; set; }
        public string NombreProfesional { get; set; }
        public decimal IdAfiliado { get; set; }
        public string NombreAfiliado { get; set; }
        public bool Habilitado { get; set; }

        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        
        public override string ToString()
        {
            return string.Format("Día {0} - Profesional: {1}" ,HoraInicio, NombreProfesional);
        }
    }
}
