﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public enum TipoPersona
	{
		Alumno,
		Profesor,
		Admin
	}

	public class Persona : BusinessEntity
    {
		private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Apellido;
		public string Apellido
		{
			get { return _Apellido; }
			set { _Apellido = value; }
		}

		public string NombreCompleto
		{
			get { return _Nombre + " " + _Apellido; }
		}

		private string _Direccion;
		public string Direccion
		{
			get { return _Direccion; }
			set { _Direccion = value; }
		}

		private string _Email;
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		private string _Telefono;
		public string Telefono
		{
			get { return _Telefono; }
			set { _Telefono = value; }
		}

		private DateTime _FechaNacimiento;
		public DateTime FechaNacimiento
		{
			get { return _FechaNacimiento; }
			set { _FechaNacimiento = value; }
		}

		private int _Legajo;
		public int Legajo
		{
			get { return _Legajo; }
			set { _Legajo = value; }
		}

		private TipoPersona _TipoPersona;
		public TipoPersona TipoPersona
		{
			get { return _TipoPersona; }
			set { _TipoPersona = value; }
		}

		private int _IdPlan;
		public int IdPlan
		{
			get { return _IdPlan; }
			set { _IdPlan = value; }
		}
	}
}
