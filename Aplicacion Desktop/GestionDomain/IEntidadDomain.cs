using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionDAL;

namespace GestionDomain
{
    public interface IEntidadDomain<T, W>
    {
        IEntidadDAL<T, W> DAL { get; }

        T Obtener(decimal id);
        IList<T> ObtenerTodos();
        void Borrar(decimal id);
        T Modificar(T entidad);
        decimal Crear(T entidad);
        IList<T> Filtrar(W filtro);
    }
}
