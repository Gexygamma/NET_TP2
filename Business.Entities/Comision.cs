using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
		private int _AñoEspecialidad;
		public int AñoEspecialidad
		{
			get { return _AñoEspecialidad; }
			set { _AñoEspecialidad = value; }
		}

		private int _IdPlan;
		public int IdPlan
		{
			get { return _IdPlan; }
			set { _IdPlan = value; }
		}

		private string _Descripcion;
		public string Descripcion
		{
			get { return _Descripcion; }
			set { _Descripcion = value; }
		}
	}
}
