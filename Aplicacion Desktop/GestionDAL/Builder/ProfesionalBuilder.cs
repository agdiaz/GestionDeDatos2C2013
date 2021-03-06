﻿using System;
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
            profesional.TipoDni = new ListaTipoDocumento().Obtener(Convert.ToInt32(row["tipo_documento"]));
            profesional.Dni = Convert.ToDecimal(row["documento"]);
            profesional.Telefono = Convert.ToDecimal(row["telefono"]);
            profesional.Mail = Convert.ToString(row["mail"]);
            profesional.FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"]);
            profesional.Sexo = new ListaSexo().Obtener(Convert.ToInt32(row["sexo"]));
            profesional.Matricula = Convert.ToDecimal(row["matricula"]);
            profesional.Direccion = Convert.ToString(row["direccion"]);
            profesional.Habilitado = Convert.ToBoolean(row["habilitado"]);
            return profesional;
        }

        #endregion
    }
}
