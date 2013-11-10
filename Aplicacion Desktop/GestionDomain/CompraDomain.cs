using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDomain.Resultados;
using GestionCommon.Entidades;
using GestionDAL;
using GestionCommon.Helpers;

namespace GestionDomain
{
    public class CompraDomain
    {
        private CompraDAL _dal;

        public CompraDomain(ILog logger)
        {
            _dal = new CompraDAL();
        }

        public IResultado<bool> Comprar(Afiliado afiliado, PlanMedico plan, IList<BonoConsulta> bonosConsulta, IList<BonoFarmacia> bonosFarmacia)
        {
            Resultado<bool> resultado = new Resultado<bool>();

            try
            {
                DateTime fechaImpresion = FechaHelper.Ahora();
                decimal idCompra = _dal.RegistrarCompra(afiliado, fechaImpresion);
                foreach (BonoConsulta bono in bonosConsulta)
                {
                    bono.FechaImpresion = fechaImpresion;
                    bono.IdCompra = idCompra;
                    _dal.CrearBonoConsulta(bono);
                }

                foreach (BonoFarmacia bono in bonosFarmacia)
                {
                    bono.FechaImpresion = fechaImpresion;
                    bono.IdCompra = idCompra;
                    _dal.CrearBonoFarmacia(bono);
                }

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
