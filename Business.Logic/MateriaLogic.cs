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

        public DataTable GetConsultaMaterias()
        {
            PlanAdapter planData = new PlanAdapter();
            DataTable table = new DataTable();
            DataRow row;
            List<Materia> materias = GetAll();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("descripcionMateria", typeof(string));
            table.Columns.Add("hsSemanales", typeof(int));
            table.Columns.Add("hsTotales", typeof(int));
            table.Columns.Add("descripcionPlan", typeof(string));

            foreach(Materia materia in materias)
            {
                row = table.NewRow();
                row["ID"] = materia.ID;
                row["descripcionMateria"] = materia.Descripcion;
                row["hsSemanales"] = materia.HsSemanales;
                row["hsTotales"] = materia.HsTotales;
                row["descripcionPlan"] = planData.GetOne(materia.IdPlan).Descripcion;
                table.Rows.Add(row);
            }
            return table;
        }

    }
}
