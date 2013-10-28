using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;

namespace GestionDomain
{
    public class EntidadBaseDomain<T, W> : IEntidadDomain<T, W>
    {
        private IEntidadDAL<T, W> _dal;

        public EntidadBaseDomain(IEntidadDAL<T, W> dal)
        {
            _dal = dal;
        }

        #region IEntidadDomain<T, W>

        public IEntidadDAL<T, W> DAL
        {
            get { return _dal; }
        }

        public T Obtener(decimal id)
        {
            return _dal.Obtener(id);
        }

        public IList<T> ObtenerTodos()
        {
            return _dal.ObtenerTodos();
        }

        public void Borrar(decimal id)
        {
            _dal.Borrar(id);
        }

        public T Modificar(T entidad)
        {
            return _dal.Modificar(entidad);
        }

        public T Crear(T entidad)
        {
            return _dal.Crear(entidad);
        }

        public IList<T> Filtrar(W filtro)
        {
            return _dal.Filtrar(filtro);
        }

        #endregion
    }
}
