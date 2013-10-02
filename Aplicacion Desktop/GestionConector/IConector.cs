using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GestionConector
{
    public interface IConector
    {
        DataSet RealizarConsulta(string consulta);
        DataSet RealizarConsulta(string consulta, IList<SqlParameter> parametros);
        
        int EjecutarComando(string comando);
        int EjecutarComando(string comando, IList<SqlParameter> parametros);

        DataSet RealizarConsultaAlmacenada(string comando);
        DataSet RealizarConsultaAlmacenada(string comando, IList<SqlParameter> parametros);
    }
}
