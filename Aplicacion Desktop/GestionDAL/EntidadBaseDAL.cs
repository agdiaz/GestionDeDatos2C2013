using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionConector;
using System.Data;
using GestionDAL.Builder;
using System.Data.SqlClient;
using GestionCommon.Entidades;
using GestionCommon.Helpers;

namespace GestionDAL
{
    public abstract class EntidadBaseDAL<T> : IEntidadDAL<T>
    {
        #region Atributos
        private IConector _connector;
        private IBuilder<T> _builder;
        private string _nombreEntidad;
        
        protected string _sp_obtener;
        protected string _sp_obtener_todos;
        protected string _sp_borrar;
        protected string _sp_modificar;
        protected string _sp_crear;
        #endregion
        
        #region Constructor
        public EntidadBaseDAL(IConector connector, IBuilder<T> builder, string nombreEntidad)
        {
            _connector = connector;
            _builder = builder;
            _nombreEntidad = nombreEntidad;

            GenerarNombresSP();
        }
        #endregion
        
        #region IEntidadDAL
        /// <summary>
        /// Permite obtener un objeto a partir de su registro en la tabla
        /// </summary>
        /// <param name="id">El identificador único del registro</param>
        /// <returns>La entidad que representa ese registro</returns>
        public T Obtener(decimal id)
        {
            //Configuro el parametro:
            IList<SqlParameter> parametros = GenerarParametrosObtener();
            
            //Ejecuto el stored procedure
            DataSet ds = _connector.RealizarConsultaAlmacenada(_sp_obtener, parametros);
            
            //Construyo el objeto a partir del registro
            T registro = _builder.Build(ds.Tables[0].Rows[0]);

            //Retorno el objeto
            return registro;
        }
        
        /// <summary>
        /// Permite obtener todos los objetos de la tabla
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> ObtenerTodos()
        {
            IList<T> todos = new List<T>();

            DataSet ds = _connector.RealizarConsultaAlmacenada(_sp_obtener_todos);
            foreach (DataRow registro in ds.Tables[0].Rows)
            {
                todos.Add(_builder.Build(registro));
            }

            return todos;
        }

        /// <summary>
        /// Da de baja lógicamente al registro que corresponda al id.
        /// </summary>
        /// <param name="id">Id del registro a dar de baja logicamente</param>
        public virtual void Borrar(decimal id)
        {
            //Configuro el parametro:
            IList<SqlParameter> parametros = GenerarParametrosBorrar();

            //Ejecuto el stored procedure
            _connector.EjecutarComando(_sp_borrar, parametros);
         
        }
        
        /// <summary>
        /// Modifica una entidad
        /// </summary>
        /// <param name="entidad">La entidad modificada</param>
        /// <returns>La misma entidad modificada</returns>
        public T Modificar(T entidad)
        {
            IList<SqlParameter> parametros = this.GenerarParametrosModificar(entidad);
            _connector.EjecutarComando(_sp_modificar, parametros);
            return entidad;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public T Crear(T entidad)
        {
            IList<SqlParameter> parametros = this.GenerarParametrosCrear(entidad);
            _connector.EjecutarComando(_sp_crear, parametros);
            EntidadBase entidadBase = entidad as EntidadBase;

            entidadBase.Id = Convert.ToInt32(parametros[0]);
            return entidad;
        }
        #endregion

        #region Sobrecargas
        protected virtual IList<SqlParameter> GenerarParametrosBorrar()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>(1);
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"));
            return parametros;
        }
        protected virtual IList<SqlParameter> GenerarParametrosObtener()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>(1);
            parametros.Add(new SqlParameter("@p_id", SqlDbType.Int, 4, "p_id"));
            return parametros;
        }
        protected abstract IList<SqlParameter> GenerarParametrosModificar(T entidad);
        protected abstract IList<SqlParameter> GenerarParametrosCrear(T entidad);
        #endregion

        #region Métodos privados
        private void GenerarNombresSP()
        {
            string esquema = AppConfigReader.Get("BaseDeDatos_Esquema");

            _sp_obtener = string.Format(AppConfigReader.Get("SP_Obtener"), esquema, _nombreEntidad);
            _sp_obtener_todos = string.Format(AppConfigReader.Get("SP_Obtener_Todos"), esquema, _nombreEntidad);
            _sp_borrar = string.Format(AppConfigReader.Get("SP_Borrar"), esquema, _nombreEntidad);
            _sp_modificar = string.Format(AppConfigReader.Get("SP_Actualizar"), esquema, _nombreEntidad);
            _sp_crear = string.Format(AppConfigReader.Get("SP_Insertar"), esquema, _nombreEntidad);
        }
        #endregion
    }
}
