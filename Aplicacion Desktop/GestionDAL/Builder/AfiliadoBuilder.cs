using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class AfiliadoBuilder : IBuilder<Afiliado>
    {

        #region Miembros de IBuilder<Afiliado>

        Afiliado IBuilder<Afiliado>.Build(System.Data.DataRow row)
        {
            Afiliado a = new Afiliado();

            a.EstadoCivil = GestionCommon.Enums.EstadoCivil.Soltero;
            a.Documento = Convert.ToDecimal(row["documento"]);
            a.Apellido = Convert.ToString(row["apellido"]);
            a.CantidadHijos = Convert.ToInt32(row["cantidad_hijos"]);
            a.Direccion = Convert.ToString(row["direccion"]);
            a.FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]);
            a.Habilitado = Convert.ToBoolean(row["habilitado"]);
            a.IdAfiliado = Convert.ToDecimal(row["id_afiliado"]);
            a.IdPlanMedico = Convert.ToDecimal(row["id_plan_medico"]);
            a.Mail = Convert.ToString(row["mail"]);
            a.Nombre = Convert.ToString(row["nombre"]);
            a.NroPrincipal = Convert.ToDecimal(row["nro_principal"]);
            a.NroSecundario = Convert.ToDecimal(row["nro_secundario"]);
            a.Sexo = GestionCommon.Enums.Sexo.Indefinido;
            a.Telefono = Convert.ToDecimal(row["telefono"]);
            a.TipoDocumento = GestionCommon.Enums.TipoDocumento.DNI;

            return a;
        }

        #endregion
    }
}
