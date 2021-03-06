﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Enums;

namespace GestionCommon.Entidades
{
    public class Profesional
    {
        public decimal IdProfesional { get; set; }
        public decimal IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDocumento TipoDni { get; set; }
        public decimal Dni { get; set; }
        public string Direccion { get; set; }
        public decimal Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public decimal Matricula { get; set; }
        public bool Habilitado { get; set; }

        public string NombreCompleto { get { return string.Format("Dr. {0} {1}", Nombre, Apellido); } }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
