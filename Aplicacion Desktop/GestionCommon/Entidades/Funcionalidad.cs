using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Funcionalidad
    {
        public decimal IdFuncionalidad { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }
        public String Descripcion { get; set; }
    }
}
