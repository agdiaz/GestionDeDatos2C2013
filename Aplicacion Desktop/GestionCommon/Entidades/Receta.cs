using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Receta
    {
        public decimal IdBonoFarmacia { get; set; }
        public decimal IdReceta { get; set; }
        public decimal IdResultadoTurno { get; set; }
        public bool Habilitado { get; set; }
        public DateTime Fecha { get; set; }
        public IList<ItemReceta> Items { get; set; }

        public Receta()
        {
            Items = new List<ItemReceta>();
        }
    }
}
