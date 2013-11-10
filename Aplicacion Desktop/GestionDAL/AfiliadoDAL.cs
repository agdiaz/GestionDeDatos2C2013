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
    public class AfiliadoDAL : EntidadBaseDAL<Afiliado, FiltroAfiliado>
    {
        public AfiliadoDAL(ILog log)
            : base(new SqlServerConector(log), new AfiliadoBuilder(), "Afiliado")
        {

        }

        protected override IList<SqlParameter> GenerarParametrosFiltrar(FiltroAfiliado filtro)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            var pNumeroPrincipal = new SqlParameter("@p_nro_principal", System.Data.SqlDbType.Decimal, 18, "p_nro_principal");
            if (filtro.NroPrincipal.HasValue)
                pNumeroPrincipal.Value = filtro.NroPrincipal.Value;
            parametros.Add(pNumeroPrincipal);
           
            var pNumeroSecundario = new SqlParameter("@p_nro_secundario", System.Data.SqlDbType.Decimal, 18, "p_nro_secundario");
            if(filtro.NroSecundario.HasValue)
                pNumeroSecundario.Value = filtro.NroSecundario.Value;
            parametros.Add(pNumeroSecundario);

            var pIdPlanMedico = new SqlParameter("@p_id_plan_medico", System.Data.SqlDbType.Decimal, 18, "p_id_plan_medico");
            if(filtro.IdPlanMedico.HasValue)
                pIdPlanMedico.Value = filtro.IdPlanMedico.Value;
            parametros.Add(pIdPlanMedico);

            var pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.Int, 4, "p_tipo_documento");
            if(filtro.IdTipoDocumento != null)
                pTipoDocumento.Value = filtro.IdTipoDocumento.Id;
            parametros.Add(pTipoDocumento);

            var pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = filtro.Nombre;
            parametros.Add(pNombre);

            var pApellido = new SqlParameter("@p_apellido", System.Data.SqlDbType.VarChar, 255, "p_apellido");
            pApellido.Value = filtro.Apellido;
            parametros.Add(pApellido);

            var pDireccion = new SqlParameter("@p_direccion", System.Data.SqlDbType.VarChar, 255, "p_direccion");
            pDireccion.Value = filtro.Direccion;
            parametros.Add(pDireccion);

            var pDocumento = new SqlParameter("@p_documento", System.Data.SqlDbType.Decimal, 18, "p_documento");
            if(filtro.Documento.HasValue)
                pDocumento.Value = filtro.Documento.Value;
            parametros.Add(pDocumento);

            var pMail = new SqlParameter("@p_mail", System.Data.SqlDbType.VarChar, 255, "p_mail");
            pMail.Value = filtro.Mail;
            parametros.Add(pMail);

            var pTelefono = new SqlParameter("@p_telefono", System.Data.SqlDbType.Decimal, 18, "p_telefono");
            if(filtro.Telefono.HasValue)
                pTelefono.Value = filtro.Telefono.Value;
            parametros.Add(pTelefono);

            var pFechaNac = new SqlParameter("@p_fecha_nac", System.Data.SqlDbType.DateTime, 8, "p_fecha_nac");
            if(filtro.FechaNacimiento.HasValue)
            pFechaNac.Value = filtro.FechaNacimiento.Value;
            parametros.Add(pFechaNac);

            var pSexo = new SqlParameter("@p_sexo", System.Data.SqlDbType.Int, 4, "p_sexo");
            if(filtro.IdSexo != null)
                pSexo.Value = filtro.IdSexo.Id;
            parametros.Add(pSexo);

            var pEstadoCivil = new SqlParameter("@p_estado_civil", System.Data.SqlDbType.Int, 4, "p_estado_civil");
            if(filtro.IdEstadoCivil != null)
                pEstadoCivil.Value = filtro.IdEstadoCivil.Id;
            parametros.Add(pEstadoCivil);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosModificar(Afiliado entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();

            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Value = entidad.IdAfiliado;
            parametros.Add(pId);

            SqlParameter pNroPrincipal = new SqlParameter("@p_nro_principal", System.Data.SqlDbType.Decimal, 18, "p_nro_principal");
            pNroPrincipal.Value = entidad.NroPrincipal;
            parametros.Add(pNroPrincipal);

            SqlParameter pNroSecundario = new SqlParameter("@p_nro_secundario", System.Data.SqlDbType.Decimal, 18, "p_nro_secundario");
            pNroSecundario.Value = entidad.NroSecundario;
            parametros.Add(pNroSecundario);


            SqlParameter pIdPlanMedico = new SqlParameter("@p_id_plan_medico", System.Data.SqlDbType.Decimal, 18, "p_id_plan_medico");
            pIdPlanMedico.Value = entidad.IdPlanMedico;
            parametros.Add(pIdPlanMedico);

            SqlParameter pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.Int, 4, "p_tipo_documento");
            pTipoDocumento.Value = entidad.TipoDocumento.Id;
            parametros.Add(pTipoDocumento);

            SqlParameter pDocumento = new SqlParameter("@p_documento", System.Data.SqlDbType.Decimal, 18, "p_documento");
            pDocumento.Value = entidad.Documento;
            parametros.Add(pDocumento);

            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pApellido = new SqlParameter("@p_apellido", System.Data.SqlDbType.VarChar, 255, "p_apellido");
            pApellido.Value = entidad.Apellido;
            parametros.Add(pApellido);

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

            SqlParameter pEstadoCivil = new SqlParameter("@p_estado_civil", System.Data.SqlDbType.Int, 4, "p_estado_civil");
            pEstadoCivil.Value = entidad.Sexo.Id;
            parametros.Add(pEstadoCivil);

            SqlParameter pFechaHoy = new SqlParameter("@p_fecha_hoy", System.Data.SqlDbType.DateTime, 8, "p_fecha_hoy");
            pFechaHoy.Value = FechaHelper.Ahora();
            parametros.Add(pFechaHoy);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosCrear(Afiliado entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            
            SqlParameter pId = new SqlParameter("@p_id", System.Data.SqlDbType.Decimal, 18, "p_id");
            pId.Direction = System.Data.ParameterDirection.Output;
            parametros.Add(pId);

            SqlParameter pNroPrincipal = new SqlParameter("@p_nro_principal", System.Data.SqlDbType.Decimal, 18, "p_nro_principal");
            pNroPrincipal.Value = entidad.NroPrincipal;
            parametros.Add(pNroPrincipal);

            SqlParameter pNroSecundario = new SqlParameter("@p_nro_secundario", System.Data.SqlDbType.Decimal, 18, "p_nro_secundario");
            pNroSecundario.Value = entidad.NroSecundario;
            parametros.Add(pNroSecundario);


            SqlParameter pIdPlanMedico = new SqlParameter("@p_id_plan_medico", System.Data.SqlDbType.Decimal, 18, "p_id_plan_medico");
            pIdPlanMedico.Value = entidad.IdPlanMedico;
            parametros.Add(pIdPlanMedico);

            SqlParameter pTipoDocumento = new SqlParameter("@p_tipo_documento", System.Data.SqlDbType.Int, 4, "p_tipo_documento");
            pTipoDocumento.Value = entidad.TipoDocumento.Id;
            parametros.Add(pTipoDocumento);

            SqlParameter pDocumento = new SqlParameter("@p_documento", System.Data.SqlDbType.Decimal, 18, "p_documento");
            pDocumento.Value = entidad.Documento;
            parametros.Add(pDocumento);

            SqlParameter pNombre = new SqlParameter("@p_nombre", System.Data.SqlDbType.VarChar, 255, "p_nombre");
            pNombre.Value = entidad.Nombre;
            parametros.Add(pNombre);

            SqlParameter pApellido = new SqlParameter("@p_apellido", System.Data.SqlDbType.VarChar, 255, "p_apellido");
            pApellido.Value = entidad.Apellido;
            parametros.Add(pApellido);

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

            SqlParameter pEstadoCivil = new SqlParameter("@p_estado_civil", System.Data.SqlDbType.Int, 4, "p_estado_civil");
            pEstadoCivil.Value = entidad.Sexo.Id;
            parametros.Add(pEstadoCivil);

            return parametros;
        }

        protected override IList<SqlParameter> GenerarParametrosBorrar(decimal id)
        {
            IList <SqlParameter>  parameters = base.GenerarParametrosBorrar(id);
            
            SqlParameter fechaBaja = new SqlParameter("@p_fecha_baja", System.Data.SqlDbType.DateTime, 8, "p_fecha_baja");
            fechaBaja.Value = FechaHelper.Ahora();
            parameters.Add(fechaBaja);
            
            return parameters;
        }
    }
}
