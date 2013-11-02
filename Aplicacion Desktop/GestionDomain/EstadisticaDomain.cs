using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionCommon.Helpers;
using GestionDAL;

namespace GestionDomain
{
    public class EstadisticaDomain
    {
        private EstadisticaDAL _dal;

        public EstadisticaDomain(ILog log)
        {
            _dal = new EstadisticaDAL(log);
        }
    }
}
