using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionDAL
{
    public interface IEntidadDAL<T, W>
    {
        T Obtener(decimal id);
        IList<T> ObtenerTodos();
        void Borrar(decimal id);
        T Modificar(T entidad);
        T Crear(T entidad);
        IList<T> Filtrar(W entidad);
    }
}
