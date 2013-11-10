using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class ItemReceta
    {
        public decimal IdItemReceta { get; set; }
        public decimal IdReceta { get; set; }
        public decimal IdMedicamento { get; set; }
        public string NombreMedicamento { get; set; }
        public int Cantidad { get; set; }
        public string CantidadEnLetras { get; set; }
        public bool Habilitado { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - Cant: {1} ({2})", NombreMedicamento, Cantidad, CantidadEnLetras);
        }
    }
}
