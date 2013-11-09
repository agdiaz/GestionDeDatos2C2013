using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionDAL;
using GestionCommon.Helpers;
using GestionDomain.Resultados;

namespace GestionDomain
{
    public class PlanMedicoDomain
    {
        PlanMedicoDAL _dal;
        EntidadBaseDomain<PlanMedico, FiltroPlanMedico> _domain;

        public PlanMedicoDomain(ILog log)
        {
            _dal = new PlanMedicoDAL(log);
            _domain = new EntidadBaseDomain<PlanMedico, FiltroPlanMedico>(_dal);
        }

        public IResultado<IList<PlanMedico>> Filtrar(FiltroPlanMedico filtro)
        {
            Resultado<IList<PlanMedico>> resultado = new Resultado<IList<PlanMedico>>();
            try
            {
                resultado.Retorno = _domain.Filtrar(filtro);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<PlanMedico> Obtener(decimal p)
        {
            Resultado<PlanMedico> resultado = new Resultado<PlanMedico>();

            try
            {
                resultado.Retorno = _dal.Obtener(p);
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
