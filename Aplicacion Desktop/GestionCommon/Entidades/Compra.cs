using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Compra
    {
        public decimal IdCompra { get; set; }
        public decimal IdAfiliado { get; set; }
        public bool Habilitado { get; set; }
    }
}
