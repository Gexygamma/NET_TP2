using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic
    {
        private ComisionAdapter ComisionData { get; set; }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public List<Comision> GetAllPlan(int idPlan)
        {
            return ComisionData.GetAllPlan(idPlan);
        }

        public List<Comision> GetAllMateria(int idMateria)
        {
            return ComisionData.GetAllMateria(idMateria);
        }

        public Comision GetOne(int id)
        {
            return ComisionData.GetOne(id);
        }

        /// <summary>
        /// Obtiene todas las comisiones y las empaqueta en un DataTable.
        /// </summary>
        public DataTable GetAllTable()
        {
            PlanAdapter planData = new PlanAdapter();
            
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("descComision", typeof(string));
            table.Columns.Add("anio", typeof(int));
            table.Columns.Add("descPlan", typeof(string));

            List<Comision> comisiones = GetAll();
            DataRow row;

            foreach (Comision comision in comisiones)
            {
                row = table.NewRow();
                row["ID"] = comision.ID;
                row["descComision"] = comision.Descripcion;
                row["anio"] = comision.AñoEspecialidad;
                row["descPlan"] = planData.GetOne(comision.IdPlan).Descripcion;
                table.Rows.Add(row);
            }

            return table;
        }

        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }
    }
}
