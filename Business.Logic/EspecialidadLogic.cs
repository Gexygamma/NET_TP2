using System;
using System.Collections.Generic;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic
    {
        private EspecialidadAdapter EspecialidadData { get; set; }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
        }
    }
}
