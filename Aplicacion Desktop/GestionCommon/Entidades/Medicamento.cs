﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Entidades
{
    public class Medicamento
    {
        public decimal IdMedicamento { get; set; }
        public string Nombre { get; set; }
        public bool Habilitado { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
