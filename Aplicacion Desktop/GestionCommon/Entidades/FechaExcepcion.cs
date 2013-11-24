using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;

namespace GestionCommon.Entidades
{
    public class FechaExcepcion
    {
        public decimal IdFechaExcepcion { get; set; }
        public DateTime Dia { get; set; }
        public decimal IdAgenda { get; set; }

        public FechaExcepcion(DateTime d)
        {
            Dia = d;
        }
        public override string ToString()
        {
            return FechaHelper.Format(Dia, FechaHelper.DateFormat);
        }
        public override bool Equals(object obj)
        {
            FechaExcepcion otra = obj as FechaExcepcion;
            if (otra == null)
            {
                return false;
            }
            else
            {
                return this.Dia.Date == otra.Dia.Date;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
