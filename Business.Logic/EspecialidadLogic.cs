using System;
using System.Collections.Generic;
using System.Data;
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
            List<Especialidad> especialidades = EspecialidadData.GetAll();
            especialidades.RemoveAll(e => e.ID == 1); // Ignora la especialidad con ID==1
            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        /// <summary>
        /// Obtiene todas las especialidades y las empaqueta en un DataTable.
        /// </summary>
        public DataTable GetAllTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("desc", typeof(string));

            List<Especialidad> especialidades = GetAll();
            DataRow row;

            foreach (Especialidad especialidad in especialidades)
            {
                row = table.NewRow();
                row["ID"] = especialidad.ID;
                row["desc"] = especialidad.Descripcion;
                table.Rows.Add(row);
            }

            return table;
        }

        public void Save(Especialidad especialidad)
        {
            EspecialidadData.Save(especialidad);
        }
    }
}
