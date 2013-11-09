using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Enums
{
    //public enum Sexo
    //{
    //    Indefinido = 0,
    //    Femenino = 1,
    //    Masculino = 2
    //}

    public class Sexo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
        public override bool Equals(object obj)
        {
            Sexo otro = obj as Sexo;
            if (otro != null)
            {
                return otro.Id == this.Id;
            }
            return false;
        }
    }

    public class Indefinido : Sexo
    {
        public Indefinido()
        {
            Id = 0;
            Nombre = "Indefinido";
        }
    }

    public class Femenino : Sexo
    {
        public Femenino()
        {
            Id = 1;
            Nombre = "Femenino";
        }
    }

    public class Masculino : Sexo
    {
        public Masculino()
        {
            Id = 2;
            Nombre = "Masculino";
        }
    }

    public class ListaSexo
    {
        public IList<Sexo> Todos { get; set; }

        public ListaSexo()
        {
            Todos = new List<Sexo>(3);
            Todos.Add(new Indefinido());
            Todos.Add(new Femenino());
            Todos.Add(new Masculino());
        }

        public Sexo Obtener(int id)
        {
            return Todos.Where(s => s.Id == id).FirstOrDefault();
        }

        public Sexo Obtener(string nombre)
        {
            return Todos.Where(s => s.Nombre == nombre).FirstOrDefault();
        }
    }

}
