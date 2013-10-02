using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace GestionConector
{
    public class SqlServerConector : IConector
    {
        #region Atributos
        private string _connectionString;
        private ILog _logger;
        #endregion

        #region Constructor
        public SqlServerConector(ILog log)
        {
            _connectionString = AppConfigReader.Get("connection_string");
            _logger = log;
        }
        #endregion
        
        #region IConector

        public DataSet RealizarConsulta(string consulta)
        {
            return RealizarConsulta(consulta, null);
        }

        public DataSet RealizarConsulta(string consulta, IList<SqlParameter> parametros)
        {
            _logger.Log(string.Format("Realizar consulta: {0}", consulta));

            DataSet ds = new DataSet();

            SqlConnection connection = GenerarConexion();
            using (SqlCommand sqlCommand = new SqlCommand(consulta))
            {
                sqlCommand.Connection = connection;

                AgregarParametros(parametros, sqlCommand);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(ds);
            }
            connection.Close();
            return ds;
        }

        public int EjecutarComando(string comando)
        {
            return EjecutarComando(comando, null);
        }

        public int EjecutarComando(string comando, IList<SqlParameter> parametros)
        {
            _logger.Log(string.Format("Ejecutar Comando: {0}", comando));

            int rowsAffected = 0;
            SqlConnection sqlConnection = GenerarConexion();
            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(comando))
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                AgregarParametros(parametros, sqlCommand);

                rowsAffected = sqlCommand.ExecuteNonQuery();
            }

            sqlConnection.Close();
            return rowsAffected;
        }

        public DataSet RealizarConsultaAlmacenada(string comando)
        {
            return RealizarConsultaAlmacenada(comando, null);
        }

        public DataSet RealizarConsultaAlmacenada(string comando, IList<SqlParameter> parametros)
        {
            _logger.Log(string.Format("Realizar Consulta Almacenada: {0}", comando));

            DataSet ds = new DataSet();

            SqlConnection sqlConnection = GenerarConexion();
            using (SqlCommand sqlCommand = new SqlCommand(comando))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

                AgregarParametros(parametros, sqlCommand);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(ds);
            }
            sqlConnection.Close();
            return ds;
        }

        #endregion

        #region Métodos privados
        private SqlConnection GenerarConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            return sqlConnection;
        }
        
        private void AgregarParametros(IList<SqlParameter> parametros, SqlCommand sqlCommand)
        {
            if (parametros != null)
            {
                foreach (SqlParameter item in parametros)
                {
                    _logger.Log(string.Format("'{0}' -> {1}", item.SourceColumn, item.Value));    
                    sqlCommand.Parameters.Add(item);
                }
            }
        }
        #endregion
    }
}
