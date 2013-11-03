using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionCommon.Enums
{
    //public enum TipoDocumento
    //{
    //    DNI = 0,
    //    LC = 1,
    //    LE = 2,
    //    CI = 3
    //}

    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }

    public class TipoDocumentoDNI : TipoDocumento
    {
        public TipoDocumentoDNI()
        {
            Id = 0;
            Nombre = "DNI";
        }
    }
    public class TipoDocumentoLC : TipoDocumento
    {
        public TipoDocumentoLC()
        {
            Id = 1;
            Nombre = "LC";
        }
    }
    public class TipoDocumentoLE : TipoDocumento
    {
        public TipoDocumentoLE()
        {
            Id = 2;
            Nombre = "LE";
        }
    }
    public class TipoDocumentoCI : TipoDocumento
    {
        public TipoDocumentoCI()
        {
            Id = 3;
            Nombre = "CI";
        }
    }

    public class ListaTipoDocumento
    {
        public IList<TipoDocumento> Todos { get; set; }

        public ListaTipoDocumento()
        {
            Todos = new List<TipoDocumento>();
            Todos.Add(new TipoDocumentoDNI());
            Todos.Add(new TipoDocumentoLC());
            Todos.Add(new TipoDocumentoLE());
            Todos.Add(new TipoDocumentoCI());
        }

        public TipoDocumento Obtener(int id)
        {
            return Todos.Where(t => t.Id == id).FirstOrDefault();
        }
        public TipoDocumento Obtener(string nombre)
        {
            return Todos.Where(t => t.Nombre == nombre).FirstOrDefault();
        }
    }
}
