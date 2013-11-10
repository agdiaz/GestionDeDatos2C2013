﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionConector;
using GestionDAL.Builder;
using System.Data.SqlClient;

namespace GestionDAL
{
    public class ResultadoTurnoDAL : EntidadBaseDAL<ResultadoTurno, ResultadoTurno>
    {
        public ResultadoTurnoDAL(ILog log)
            :base(new SqlServerConector(log), new ResultadoTurnoBuilder(), "ResultadoTurno")    
        {

        }
        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosFiltrar(ResultadoTurno entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosModificar(ResultadoTurno entidad)
        {
            throw new NotImplementedException();
        }

        protected override IList<System.Data.SqlClient.SqlParameter> GenerarParametrosCrear(ResultadoTurno entidad)
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
	        
            SqlParameter pIdTurno = new SqlParameter("@p_id_turno", System.Data.SqlDbType.Decimal, 18, "p_id_turno");
            pIdTurno.Value = entidad.IdTurno;
            parametros.Add(pIdTurno);

            SqlParameter pSintoma = new SqlParameter("@p_sintoma", System.Data.SqlDbType.VarChar, 255, "p_sintoma");
            pSintoma.Value = entidad.Sintoma;
            parametros.Add(pSintoma);

            SqlParameter pDiagnostico = new SqlParameter("@p_diagnostico", System.Data.SqlDbType.VarChar, 255, "p_diagnostico");
            pDiagnostico.Value = entidad.Diagnostico;
            parametros.Add(pDiagnostico);

            SqlParameter pFecha = new SqlParameter("@p_fecha_diagnostico", System.Data.SqlDbType.DateTime, 8, "p_fecha_diagnostico");
            pFecha.Value = entidad.FechaDiagnostico;
            parametros.Add(pFecha);
            
            return parametros;
        }
    }
}