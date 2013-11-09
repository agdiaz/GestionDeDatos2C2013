using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;
using GestionCommon.Entidades;
using GestionCommon.Filtros;
using GestionCommon.Helpers;
using GestionDomain.Resultados;

namespace GestionDomain
{
    public class AfiliadoDomain
    {
        private AfiliadoDAL _dal;
        private IEntidadDomain<Afiliado, FiltroAfiliado> _domain;

        public AfiliadoDomain(ILog log)
        {
            _dal = new AfiliadoDAL(log);
            _domain = new EntidadBaseDomain<Afiliado, FiltroAfiliado>(_dal);
        }

        public IResultado<IList<Afiliado>> Filtrar(FiltroAfiliado filtro)
        {
            Resultado<IList<Afiliado>> resultado = new Resultado<IList<Afiliado>>();

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


        public IResultado<Afiliado> Crear(Afiliado afiliado)
        {
            Resultado<Afiliado> resultado = new Resultado<Afiliado>();

            try
            {
                decimal idNuevoAfiliado = _domain.Crear(afiliado);
                Afiliado afiliadoNuevo = _domain.Obtener(idNuevoAfiliado);
                afiliado.NroPrincipal = afiliadoNuevo.NroPrincipal;
                afiliado.NroSecundario = afiliado.NroSecundario;
                afiliado.IdAfiliado = idNuevoAfiliado;
            }
            catch (Exception ex)
            {
                resultado.Correcto = false;
                resultado.Mensajes.Add(ex.Message);
            }
            return resultado;
        }

        public IResultado<Afiliado> Modificar(Afiliado afiliado)
        {
            Resultado<Afiliado> resultado = new Resultado<Afiliado>();
            try
            {
                resultado.Retorno = _domain.Modificar(afiliado);
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
