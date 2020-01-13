using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic
    {
        private PersonaAdapter PersonaData { get; set; }

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public int CountAdmins()
        {
            return PersonaData.CountAdmins();
        }

        public void Save(Persona persona)
        {
            PersonaData.Save(persona);
        }
    }
}
