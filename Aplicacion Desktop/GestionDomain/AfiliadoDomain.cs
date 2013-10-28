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

    }
}
