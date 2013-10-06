using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Enums;

namespace GestionCommon.Entidades
{
    public class Afiliado
    {
        public decimal IdAfiliado { get; set; }
        public decimal NroPrincipal { get; set; }
        public decimal NroSecundario { get; set; }
        public decimal IdPlanMedico { get; set; }
        public TipoDocumento TipoDni { get; set; }
        public decimal Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public decimal Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public int CantidadHijos { get; set; }
        public bool Habilitado { get; set; }
    }
}
