using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Enums;

namespace GestionCommon.Filtros
{
    public class FiltroAfiliado
    {
        public decimal? NroPrincipal { get; set; }
        public decimal? NroSecundario { get; set; }
        public decimal? IdPlanMedico { get; set; }
        public TipoDocumento IdTipoDocumento { get; set; }
        public decimal? Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public decimal? Telefono { get; set; }
        public string Mail { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Sexo IdSexo { get; set; }
        public EstadoCivil IdEstadoCivil { get; set; }

    }
}
