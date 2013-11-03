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
            if (!string.IsNullOrEmpty(entidad.Nombre))
                pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pApellido = new SqlParameter("@p_apellido", System.Data.SqlDbType.VarChar, 255, "p_apellido");
            if (!string.IsNullOrEmpty(entidad.Apellido))
                pApellido.Value = entidad.Apellido;
            parametros.Add(pApellido);

            SqlParameter pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.Int, 4, "p_tipo_documento");
            if (entidad.TipoDni.HasValue)
                pTipoDocumento.Value = entidad.TipoDni.Value;
            parametros.Add(pTipoDocumento);

            SqlParameter pDocumento = new SqlParameter("@p_documento", System.Data.SqlDbType.Decimal, 18, "p_documento");
            if (entidad.Dni.HasValue)
                pDocumento.Value = entidad.Dni.Value;
            parametros.Add(pDocumento);

            SqlParameter pDireccion = new SqlParameter("@p_direccion", System.Data.SqlDbType.VarChar, 255, "p_direccion");
            if (!string.IsNullOrEmpty(entidad.Direccion))
                pDireccion.Value = entidad.Direccion;
            parametros.Add(pDireccion);

            SqlParameter pTelefono = new SqlParameter("@p_telefono", System.Data.SqlDbType.Decimal, 18, "p_telefono");
            if (entidad.Telefono.HasValue)
                pTelefono.Value = entidad.Telefono.Value;
            parametros.Add(pTelefono);

            SqlParameter pMail = new SqlParameter("@p_mail", System.Data.SqlDbType.VarChar, 255, "p_mail");
            if (!string.IsNullOrEmpty(entidad.Mail))
                pMail.Value = entidad.Mail;
            parametros.Add(pMail);

            SqlParameter pFechaNacimiento = new SqlParameter("@p_fecha_nacimiento", System.Data.SqlDbType.DateTime, 8, "p_fecha_nacimiento");
            if (entidad.FechaNacimiento.HasValue)
                pFechaNacimiento.Value = entidad.FechaNacimiento.Value;
            parametros.Add(pFechaNacimiento);

            SqlParameter pSexo = new SqlParameter("@p_sexo", System.Data.SqlDbType.Int, 4, "p_sexo");
            if (entidad.Sexo.HasValue)
                pSexo.Value = entidad.Sexo.Value;
            parametros.Add(pSexo);

            SqlParameter pMatricula = new SqlParameter("@p_matricula", System.Data.SqlDbType.Decimal, 18, "p_matricula");
            if (entidad.Matricula.HasValue)
                pMatricula.Value = entidad.Matricula.Value;
            parametros.Add(pMatricula);

            SqlParameter pIdEspecialidad = new SqlParameter("@p_id_especialidad", System.Data.SqlDbType.Decimal, 18, "p_id_especialidad");
            if (entidad.IdEspecialidad.HasValue)
                pIdEspecialidad.Value = entidad.IdEspecialidad.Value;
            parametros.Add(pIdEspecialidad);

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

            SqlParameter pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.Int, 4, "p_tipo_documento");
            pTipoDocumento.Value = entidad.TipoDni.Id;
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

            SqlParameter pFechaNacimiento = new SqlParameter("@p_fecha_nacimiento", System.Data.SqlDbType.DateTime, 8, "p_fecha_nacimiento");
            pFechaNacimiento.Value = entidad.FechaNacimiento;
            parametros.Add(pFechaNacimiento);

            SqlParameter pSexo = new SqlParameter("@p_sexo", System.Data.SqlDbType.Int, 4, "p_sexo");
            pSexo.Value = entidad.Sexo.Id;
            parametros.Add(pSexo);

            SqlParameter pMatricula = new SqlParameter("@p_matricula", System.Data.SqlDbType.Decimal, 18, "p_matricula");
            pMatricula.Value = entidad.Matricula;
            parametros.Add(pMatricula);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Profesional entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pApellido = new SqlParameter("@p_apellido", System.Data.SqlDbType.VarChar, 255, "p_apellido");
            pApellido.Value = entidad.Apellido;
            parametros.Add(pApellido);

            SqlParameter pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.Int, 4, "p_tipo_documento");
            pTipoDocumento.Value = entidad.TipoDni.Id;
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

            SqlParameter pFechaNacimiento = new SqlParameter("@p_fecha_nacimiento", System.Data.SqlDbType.DateTime, 8, "p_fecha_nacimiento");
            pFechaNacimiento.Value = entidad.FechaNacimiento;
            parametros.Add(pFechaNacimiento);

            SqlParameter pSexo = new SqlParameter("@p_sexo", System.Data.SqlDbType.Int, 4, "p_sexo");
            pSexo.Value = entidad.Sexo.Id;
            parametros.Add(pSexo);

            SqlParameter pMatricula = new SqlParameter("@p_matricula", System.Data.SqlDbType.Decimal, 18, "p_matricula");
            pMatricula.Value = entidad.Matricula;
            parametros.Add(pMatricula);

            return parametros;

        }

        public bool AsociarProfesionalEspecialidad(Profesional profesional, Especialidad especialidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            
            SqlParameter pIdProfesional = new SqlParameter("@p_id_profesional", System.Data.SqlDbType.Decimal, 18, "p_id_profesional");
            pIdProfesional.Value = profesional.IdProfesional;
            parametros.Add(pIdProfesional);

            SqlParameter pIdEspecialidad = new SqlParameter("@p_id_especialidad", System.Data.SqlDbType.Decimal, 18, "p_id_especialidad");
            pIdEspecialidad.Value = especialidad.IdEspecialidad;
            parametros.Add(pIdEspecialidad);

            _connector.RealizarConsultaAlmacenada("[TOP_4].[sp_Profesional_asociar_especialidad]", parametros);

            return true;
            
        }
    }
}
