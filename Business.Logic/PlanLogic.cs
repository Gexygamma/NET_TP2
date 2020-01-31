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
            return PlanData.GetAll();
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public DataTable GetConsultaPlanes()
        {
            EspecialidadAdapter especialidadData = new EspecialidadAdapter();
            DataTable table = new DataTable();
            DataRow row;
            List<Plan> planes = GetAll();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("descripcionPlan", typeof(string));
            table.Columns.Add("descripcionEspecialidad", typeof(string));

            foreach (Plan plan in planes)
            {
                row = table.NewRow();
                row["ID"] = plan.ID;
                row["descripcionPlan"] = plan.Descripcion;
                row["descripcionEspecialidad"] = especialidadData.GetOne(plan.IdEspecialidad).Descripcion;
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
