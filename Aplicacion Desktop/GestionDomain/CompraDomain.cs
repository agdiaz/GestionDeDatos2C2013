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
        private BonoConsultaDAL _bonoConsultaDal;
        private BonoFarmaciaDAL _bonoFarmaciaDal;

        public CompraDomain(ILog logger)
        {
            _bonoConsultaDal = new BonoConsultaDAL(logger);
            _bonoFarmaciaDal = new BonoFarmaciaDAL(logger);
            _dal = new CompraDAL(logger);
        }

        public IResultado<Compra> Comprar(Afiliado afiliado, decimal costo, IList<BonoConsulta> bonosConsulta, IList<BonoFarmacia> bonosFarmacia)
        {
             Resultado<Compra> resultado = new Resultado<Compra>();

            try
            {
                Compra compra = new Compra();

                DateTime fechaImpresion = FechaHelper.Ahora();
                
                decimal idCompra = _dal.RegistrarCompra(afiliado, fechaImpresion, costo);
                compra.IdCompra = idCompra;

                foreach (BonoConsulta bono in bonosConsulta)
                {
                    bono.FechaImpresion = fechaImpresion;
                    bono.IdCompra = idCompra;
                    decimal idBono = _dal.CrearBonoConsulta(bono);
                    bono.IdBonoConsulta = idBono;
                    compra.BonosConsulta.Add(bono);
                }

                foreach (BonoFarmacia bono in bonosFarmacia)
                {
                    bono.FechaImpresion = fechaImpresion;
                    bono.IdCompra = idCompra;
                    decimal idBono =_dal.CrearBonoFarmacia(bono);
                    bono.IdBonoFarmacia = idBono;
                    compra.BonosFarmacia.Add(bono);
                }
                resultado.Retorno = compra;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }

            return resultado;
        }

        public IResultado<BonoConsulta> ObtenerBonoConsulta(decimal p)
        {
            Resultado<BonoConsulta> resultado = new Resultado<BonoConsulta>();
            try
            {
                resultado.Retorno = _bonoConsultaDal.Obtener(p);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add("No se ha encontrado el bono");
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<BonoFarmacia> ObtenerBonoFarmacia(decimal p)
        {
            Resultado<BonoFarmacia> resultado = new Resultado<BonoFarmacia>();
            try
            {
                resultado.Retorno = _bonoFarmaciaDal.Obtener(p);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add("No se ha encontrado el bono");
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;

        }

        public IResultado<bool> RegistrarLlegada(decimal idBono, decimal idTurno, DateTime fecha)
        {
            Resultado<bool> resultado = new Resultado<bool>();
            try
            {
                resultado.Retorno = _bonoConsultaDal.RegistrarLlegada(idBono, idTurno, fecha);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;            
        }

        public IResultado<BonoFarmacia> ValidarBonoFarmacia(decimal idBono, decimal nroPrincipal, DateTime fecha)
        {
            Resultado<BonoFarmacia> resultado = new Resultado<BonoFarmacia>();
            try
            {
                resultado.Retorno = _bonoFarmaciaDal.Validar(idBono, fecha, nroPrincipal );
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add("No se ha encontrado el bono");
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;

        }

        public IResultado<BonoConsulta> ValidarBonoConsulta(decimal idBono, decimal nroPrincipal, decimal idPlan)
        {
            Resultado<BonoConsulta> resultado = new Resultado<BonoConsulta>();
            try
            {
                resultado.Retorno = _bonoConsultaDal.Validar(idBono, nroPrincipal, idPlan);
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add("No se ha encontrado el bono");
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;

        
        
        }
    }
}
