using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;

namespace GestionDomain
{
    public interface IEntidadDomain<T>
    {
        IEntidadDAL<T> DAL { get; }

        T Obtener(int id);
        IList<T> ObtenerTodos();
        void Borrar(int id);
        T Modificar(T entidad);
        T Crear(T entidad);
    }
}
