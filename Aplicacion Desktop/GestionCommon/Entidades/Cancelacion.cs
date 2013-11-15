using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Cancelacion
    {
        public decimal IdTipoCancelacion { get; set; }
        public decimal IdTurno { get; set; }
        public DateTime Fecha { get; set; }
        public bool Habilitado { get; set; }
        public char CanceladoPor { get; set; }
        public string Motivo { get; set; }

    }
}
