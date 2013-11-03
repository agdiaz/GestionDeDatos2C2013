using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Enums
{
    //public enum EstadoCivil
    //{
    //    Soltero = 0,
    //    Casado = 1,
    //    Viudo = 2,
    //    Concubinato = 3,
    //    Divorciado = 4
    //}

    public class EstadoCivil
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    public class Soltero : EstadoCivil
    {
        public Soltero()
        {
            Id = 0;
            Nombre = "Soltero/a";
        }
    }
    public class Casado : EstadoCivil
    {
        public Casado()
        {
            Id = 1;
            Nombre = "Casado/a";
        }
    }
    public class Viudo : EstadoCivil
    {
        public Viudo()
        {
            Id = 2;
            Nombre = "Viudo/a";
        }
    }
    public class Concubinato : EstadoCivil
    {
        public Concubinato()
        {
            Id = 3;
            Nombre = "Concubinato";
        }
    }
    public class Divorciado : EstadoCivil
    {
        public Divorciado()
        {
            Id = 4;
            Nombre = "Divorciado/a";
        }
    }

    public class ListaEstadoCivil
    {
        public IList<EstadoCivil> Todos { get; set; }

        public ListaEstadoCivil()
        {
            Todos = new List<EstadoCivil>(5);
            Todos.Add(new Soltero());
            Todos.Add(new Casado());
            Todos.Add(new Viudo());
            Todos.Add(new Concubinato());
            Todos.Add(new Divorciado());
        }

        public EstadoCivil Obtener(int id)
        {
            return Todos.Where(e => e.Id == id).FirstOrDefault();
        }

        public EstadoCivil Obtener(string nombre)
        {
            return Todos.Where(e => e.Nombre == nombre).FirstOrDefault();
        }
    }

}
