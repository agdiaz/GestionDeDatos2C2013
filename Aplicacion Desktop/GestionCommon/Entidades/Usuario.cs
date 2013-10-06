using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Usuario
    {
        public decimal IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Habilitado { get; set; }
    }
}
