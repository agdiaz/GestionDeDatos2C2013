using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Helpers;
using GestionDAL;
using GestionDomain.Resultados;

namespace GestionDomain
{
    public class MedicamentoDomain
    {
        private MedicamentoDAL _dal;
        private EntidadBaseDomain<Medicamento, Medicamento> _domain;

        public MedicamentoDomain(ILog log)
        {
            _dal = new MedicamentoDAL(log);
            _domain = new EntidadBaseDomain<Medicamento, Medicamento>(_dal);
        }


        public IResultado<IList<Medicamento>> Filtrar(Medicamento m)
        {
            Resultado<IList<Medicamento>> resultado = new Resultado<IList<Medicamento>>();

            try
            {
                resultado.Retorno = _domain.Filtrar(m);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }
    }
}
