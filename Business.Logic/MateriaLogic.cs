using System;
using System.Collections.Generic;
using System.Data;
using Business.Entities;
using Data.Database;
namespace Business.Logic
{
    public class MateriaLogic
    {
        private MateriaAdapter MateriaData { get; set; }

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }
        
        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }

        public DataTable GetAllTable()
        {
            PlanAdapter planData = new PlanAdapter();

            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("descMateria", typeof(string));
            table.Columns.Add("hsSemanales", typeof(int));
            table.Columns.Add("hsTotales", typeof(int));
            table.Columns.Add("descPlan", typeof(string));

            List<Materia> materias = GetAll();
            DataRow row;

            foreach (Materia materia in materias)
            {
                row = table.NewRow();
                row["ID"] = materia.ID;
                row["descMateria"] = materia.Descripcion;
                row["hsSemanales"] = materia.HsSemanales;
                row["hsTotales"] = materia.HsTotales;
                row["descPlan"] = planData.GetOne(materia.IdPlan).Descripcion;
                table.Rows.Add(row);
            }

            return table;
        }

    }
}
