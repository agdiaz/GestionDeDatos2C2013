using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Filtros
{
    public class FiltroProfesional
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDni { get; set; }
        public decimal Dni { get; set; }
        public string Direccion { get; set; }
        public decimal Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo { get; set; }
        public decimal Matricula { get; set; }
        public decimal IdTipoEspecialidad { get; set; }
    }
}
