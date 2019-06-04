using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Nota : BusinessEntity
    {
        private int _Nro;
        public int Nro
        {
            get { return _Nro; }
            set { _Nro = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private DateTime _FechaCreacion;
        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; }
        }

        private bool _Completado;
        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }

        private DateTime _FechaCompletado;
        public DateTime FechaCompletado
        {
            get { return _FechaCompletado; }
            set { _FechaCompletado = value; }
        }

    }
}
