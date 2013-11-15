using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Enums
{
//    public enum DiaSemana
//    {
//        Domingo = 0,
//        Lunes = 1,
//        Martes = 2,
//        Miercoles = 3,
//        Jueves = 4,
//        Viernes = 5,
//        Sabado = 6
//    }

    public class DiaSemana
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraDesde { get; set; }
        public DateTime HoraHasta { get; set; }
        public DateTime HoraDesdeLimite { get; set; }
        public DateTime HoraHastaLimite { get; set; }

        public override string ToString()
        {
            return Nombre + " de " + this.HoraDesde.Hour + " a " + this.HoraHasta.Hour;
        }
    }

    public class Domingo : DiaSemana
    {
        public Domingo()
        {
            Id = 7;
            Nombre = "Domingo";
            HoraDesdeLimite = new DateTime(2013,1,1,0,0,0);
            HoraHastaLimite = new DateTime(2013,1,1,0,0,0);
        }
    }

    public class Lunes : DiaSemana
    {
        public Lunes()
        {
            Id = 1;
            Nombre = "Lunes";
            HoraDesdeLimite = new DateTime(2013, 1, 1, 7, 0, 0);
            HoraHastaLimite = new DateTime(2013, 1, 1, 20, 0, 0);
        }
    }

    public class Martes : DiaSemana
    {
        public Martes()
        {
            Id = 2;
            Nombre = "Martes";
            HoraDesdeLimite = new DateTime(2013, 1, 1, 7, 0, 0);
            HoraHastaLimite = new DateTime(2013, 1, 1, 20, 0, 0);
        }
    }

    public class Miercoles : DiaSemana
    {
        public Miercoles()
        {
            Id = 3;
            Nombre = "Miercoles";
            HoraDesdeLimite = new DateTime(2013, 1, 1, 7, 0, 0);
            HoraHastaLimite = new DateTime(2013, 1, 1, 20, 0, 0);
        }
    }

    public class Jueves : DiaSemana
    {
        public Jueves()
        {
            Id = 4;
            Nombre = "Jueves";
            HoraDesdeLimite = new DateTime(2013, 1, 1, 7, 0, 0);
            HoraHastaLimite = new DateTime(2013, 1, 1, 20, 0, 0);
        }
    }

    public class Viernes : DiaSemana
    {
        public Viernes()
        {
            Id = 5;
            Nombre = "Viernes";
            HoraDesdeLimite = new DateTime(2013, 1, 1, 7, 0, 0);
            HoraHastaLimite = new DateTime(2013, 1, 1, 20, 0, 0);
        }
    }

    public class Sabado : DiaSemana
    {
        public Sabado()
        {
            Id = 6;
            Nombre = "Sabado";
            HoraDesdeLimite = new DateTime(2013, 1, 1, 10, 0, 0);
            HoraHastaLimite = new DateTime(2013, 1, 1, 15, 0, 0);
        }
    }

    public class ListaDiaSemana
    {
        public IList<DiaSemana> Todos { get; set; }

        public ListaDiaSemana()
        {
            Todos = new List<DiaSemana>(7);
            Todos.Add(new Domingo());
            Todos.Add(new Lunes());
            Todos.Add(new Martes());
            Todos.Add(new Miercoles());
            Todos.Add(new Jueves());
            Todos.Add(new Viernes());
            Todos.Add(new Sabado());
        }

        public DiaSemana Obtener(int id)
        {
            return Todos.Where(s => s.Id == id).FirstOrDefault();
        }

        public DiaSemana Obtener(string nombre)
        {
            return Todos.Where(s => s.Nombre == nombre).FirstOrDefault();
        }
    }
}
