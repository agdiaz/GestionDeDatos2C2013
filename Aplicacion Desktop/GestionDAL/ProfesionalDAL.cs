using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using System.Data.SqlClient;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;

namespace GestionDAL
{
    public class ProfesionalDAL : EntidadBaseDAL<Profesional, FiltroProfesional>
    {
        public ProfesionalDAL(ILog log)
        :base(new SqlServerConector(log), new ProfesionalBuilder(), "Profesional")
        {

        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroProfesional entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pApellido = new SqlParameter("@p_apellido", System.Data.SqlDbType.VarChar, 255, "p_apellido");
            pApellido.Value = entidad.Apellido;
            parametros.Add(pApellido);

            SqlParameter pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.VarChar, 255, "p_tipo_documento");
            pTipoDocumento.Value = entidad.TipoDni;
            parametros.Add(pTipoDocumento);

            SqlParameter pDocumento = new SqlParameter("@p_documento", System.Data.SqlDbType.Decimal, 18, "p_documento");
            pDocumento.Value = entidad.Dni;
            parametros.Add(pDocumento);

            SqlParameter pDireccion = new SqlParameter("@p_direccion", System.Data.SqlDbType.VarChar, 255, "p_direccion");
            pDireccion.Value = entidad.Direccion;
            parametros.Add(pDireccion);

            SqlParameter pTelefono = new SqlParameter("@p_telefono", System.Data.SqlDbType.Decimal, 18, "p_telefono");
            pTelefono.Value = entidad.Telefono;
            parametros.Add(pTelefono);

            SqlParameter pMail = new SqlParameter("@p_mail", System.Data.SqlDbType.VarChar, 255, "p_mail");
            pMail.Value = entidad.Mail;
            parametros.Add(pMail);

            SqlParameter pFechaNacimiento = new SqlParameter("@p_fecha_nacimiento", System.Data.SqlDbType.Date, 4, "p_fecha_nacimiento");
            pFechaNacimiento.Value = entidad.FechaNacimiento;
            parametros.Add(pFechaNacimiento);

            SqlParameter pSexo = new SqlParameter("@p_sexo", System.Data.SqlDbType.Int, 4, "p_sexo");
            pSexo.Value = entidad.Sexo;
            parametros.Add(pSexo);

            SqlParameter pMatricula = new SqlParameter("@p_matricula", System.Data.SqlDbType.Decimal, 18, "p_matricula");
            pMatricula.Value = entidad.Matricula;
            parametros.Add(pMatricula);

            SqlParameter pIdTipoEspecialidad = new SqlParameter("@p_id_tipo_especialidad", System.Data.SqlDbType.Decimal, 18, "p_id_tipo_especialidad");
            pIdTipoEspecialidad.Value = entidad.IdTipoEspecialidad;
            parametros.Add(pIdTipoEspecialidad);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosModificar(Profesional entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pApellido = new SqlParameter("@p_apellido", System.Data.SqlDbType.VarChar, 255, "p_apellido");
            pApellido.Value = entidad.Apellido;
            parametros.Add(pApellido);

            SqlParameter pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.VarChar, 255, "p_tipo_documento");
            pTipoDocumento.Value = entidad.TipoDni;
            parametros.Add(pTipoDocumento);

            SqlParameter pDocumento = new SqlParameter("@p_documento", System.Data.SqlDbType.Decimal, 18, "p_documento");
            pDocumento.Value = entidad.Dni;
            parametros.Add(pDocumento);

            SqlParameter pDireccion = new SqlParameter("@p_direccion", System.Data.SqlDbType.VarChar, 255, "p_direccion");
            pDireccion.Value = entidad.Direccion;
            parametros.Add(pDireccion);

            SqlParameter pTelefono = new SqlParameter("@p_telefono", System.Data.SqlDbType.Decimal, 18, "p_telefono");
            pTelefono.Value = entidad.Telefono;
            parametros.Add(pTelefono);

            SqlParameter pMail = new SqlParameter("@p_mail", System.Data.SqlDbType.VarChar, 255, "p_mail");
            pMail.Value = entidad.Mail;
            parametros.Add(pMail);

            SqlParameter pFechaNacimiento = new SqlParameter("@p_fecha_nacimiento", System.Data.SqlDbType.Date, 4, "p_fecha_nacimiento");
            pFechaNacimiento.Value = entidad.FechaNacimiento;
            parametros.Add(pFechaNacimiento);

            SqlParameter pSexo = new SqlParameter("@p_sexo", System.Data.SqlDbType.Int, 4, "p_sexo");
            pSexo.Value = entidad.Sexo;
            parametros.Add(pSexo);

            SqlParameter pMatricula = new SqlParameter("@p_matricula", System.Data.SqlDbType.Decimal, 18, "p_matricula");
            pMatricula.Value = entidad.Matricula;
            parametros.Add(pMatricula);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Profesional entidad)
        {
            throw new NotImplementedException();
        }
    }
}
