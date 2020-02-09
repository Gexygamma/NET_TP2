using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
		private int _AñoCalendario;
		public int AñoCalendario
		{
			get { return _AñoCalendario; }
			set { _AñoCalendario = value; }
		}

		private int _Cupo;
		public int Cupo
		{
			get { return _Cupo; }
			set { _Cupo = value; }
		}

		private int _IdComision;
		public int IdComision
		{
			get { return _IdComision; }
			set { _IdComision = value; }
		}

		private int _IdMateria;
		public int IdMateria
		{
			get { return _IdMateria; }
			set { _IdMateria = value; }
		}
	}
}
