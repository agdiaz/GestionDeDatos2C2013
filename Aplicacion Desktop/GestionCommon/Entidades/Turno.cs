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
        public decimal IdAfiliado { get; set; }
        public bool Habilitado { get; set; }
    }
}
