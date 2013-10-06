using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;

namespace GestionDAL.Builder
{
    public class MedicamentoBuilder : IBuilder<Medicamento>
    {
        #region Miembros de IBuilder<Medicamento>

        public Medicamento Build(System.Data.DataRow row)
        {
            Medicamento medicamento = new Medicamento();
            medicamento.IdMedicamento = Convert.ToDecimal(row["id_medicamento"]);
            medicamento.Nombre = Convert.ToString(row["nombre"]);
            medicamento.Habilitado = Convert.ToBoolean(row["habilitado"]);
            return medicamento;
        }

        #endregion
    }
}
