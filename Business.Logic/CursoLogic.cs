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
    public class CursoLogic
    {
        private ComisionLogic ComisionLogic { get; set; }
        private CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public Curso GetOne(int id)
        {
            return CursoData.GetOne(id);
        }

        public DataTable GetTable(List<Curso> cursos)
        {
            MateriaAdapter materiaData = new MateriaAdapter();
            ComisionAdapter comisionData = new ComisionAdapter();

            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("descMateria", typeof(string));
            table.Columns.Add("descComision", typeof(string));
            table.Columns.Add("anioCalendario", typeof(int));
            table.Columns.Add("cupo", typeof(int));

            DataRow row;

            foreach (Curso curso in cursos)
            {
                row = table.NewRow();
                row["ID"] = curso.ID;
                row["descMateria"] = materiaData.GetOne(curso.IdMateria).Descripcion;
                row["descComision"] = comisionData.GetOne(curso.IdComision).Descripcion;
                row["anioCalendario"] = curso.AñoCalendario;
                row["cupo"] = curso.Cupo;
                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable GetAllTable()
        {
            return GetTable(CursoData.GetAll());
        }

        public DataTable GetAllTablePorCupo()
        {
            return GetTable(CursoData.GetAllPorCupo());
        }

        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }
    }
}
