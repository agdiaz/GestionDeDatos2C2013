using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Entidades.Ejemplo;
using GestionDAL.Ejemplo;
using GestionCommon.Helpers;

namespace GestionDomain.Ejemplo
{
    public class EntidadEjemploDomain : EntidadBaseDomain<EntidadEjemplo>
    {
        public EntidadEjemploDomain(ILog log)
        :base(new EntidadEjemploDAL(log))
        {
            
        }
    }
}
