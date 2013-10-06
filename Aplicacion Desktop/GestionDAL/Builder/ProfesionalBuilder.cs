using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Enums;

namespace GestionDAL.Builder
{
    public class ProfesionalBuilder : IBuilder<Profesional>
    {
        #region Miembros de IBuilder<Profesional>

        public Profesional Build(System.Data.DataRow row)
        {
            Profesional profesional = new Profesional();
            profesional.IdProfesional = Convert.ToDecimal(row["id_profesional"]);
            profesional.IdUsuario = Convert.ToDecimal(row["id_usuario"]);
            profesional.Nombre = Convert.ToString(row["nombre"]);
            profesional.Apellido = Convert.ToString(row["apellido"]);
            profesional.TipoDni = Convert.ToString(row["tipo_dni"]);
            profesional.Dni = Convert.ToDecimal(row["dni"]);
            profesional.Telefono = Convert.ToDecimal(row["telefono"]);
            profesional.Mail = Convert.ToString(row["mail"]);
            profesional.FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]);
            profesional.Sexo = (Sexo)Convert.ToInt32(row["sexo"]);
            profesional.Matricula = Convert.ToDecimal(row["matricula"]);
            profesional.Habilitado = Convert.ToBoolean(row["habilitado"]);
            return profesional;
        }

        #endregion
    }
}
