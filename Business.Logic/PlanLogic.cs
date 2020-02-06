using System;
using System.Collections.Generic;
using System.Data;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic
    {
        private PlanAdapter PlanData { get; set; }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            List<Plan> planes = PlanData.GetAll();
            planes.RemoveAll(p => p.ID == 1); // Ignora el plan con ID==1
            return planes;
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public DataTable GetAllTable()
        {
            EspecialidadAdapter especialidadData = new EspecialidadAdapter();
            DataTable table = new DataTable();
            DataRow row;
            List<Plan> planes = GetAll();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("descPlan", typeof(string));
            table.Columns.Add("descEspecialidad", typeof(string));

            foreach (Plan plan in planes)
            {
                row = table.NewRow();
                row["ID"] = plan.ID;
                row["descPlan"] = plan.Descripcion;
                row["descEspecialidad"] = especialidadData.GetOne(plan.IdEspecialidad).Descripcion;
                table.Rows.Add(row);
            }

            return table;
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
    }
}
