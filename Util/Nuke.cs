using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Util
{
    public class Nuke
    {
        public static void TruncarBaseDatos()
        {
            Adapter<BusinessEntity>.TruncarBaseDatos();
        }
    }
}
