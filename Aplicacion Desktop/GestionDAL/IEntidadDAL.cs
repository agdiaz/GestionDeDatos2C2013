using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionDAL
{
    public interface IEntidadDAL<T>
    {
        T Obtener(int id);
        IList<T> ObtenerTodos();
        void Borrar(int id);
        T Modificar(T entidad);
        T Crear(T entidad);
    }
}
