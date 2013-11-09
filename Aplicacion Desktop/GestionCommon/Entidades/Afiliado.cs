using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Enums;

namespace GestionCommon.Entidades
{
    public class Afiliado
    {
        public decimal NroAfiliado { get { return NroPrincipal + NroSecundario; } }

        public decimal IdAfiliado { get; set; }
        public decimal NroPrincipal { get; set; }
        public decimal NroSecundario { get; set; }
        public decimal IdPlanMedico { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public decimal Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public decimal Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public bool Habilitado { get; set; }

        

        #region Atributos que no son de la base de datos
        public string NombreCompleto { get { return string.Format("{0} {1}", Nombre, Apellido); } }
        public int CantidadHijos { get; set; }
        public bool TienePareja { get { return new List<EstadoCivil>() { new Casado(), new Concubinato() }.Contains(this.EstadoCivil); } }
        #endregion

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
