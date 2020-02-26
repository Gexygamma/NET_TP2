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
    public class InscripcionLogic
    {
        private readonly InscripcionAdapter InscripcionData;

        public InscripcionLogic()
        {
            InscripcionData = new InscripcionAdapter();
        }

        public DataTable GetAllAlumnoTable(int idAlumno)
        {
            CursoAdapter cursoData = new CursoAdapter();
            MateriaAdapter materiaData = new MateriaAdapter();
            ComisionAdapter comisionData = new ComisionAdapter();

            DataTable table = new DataTable();
            table.Columns.Add("descMateria", typeof(string));
            table.Columns.Add("descComision", typeof(string));
            table.Columns.Add("anioCalendario", typeof(int));
            table.Columns.Add("condicion", typeof(string));
            table.Columns.Add("nota", typeof(int));

            List<AlumnoInscripcion> inscripciones = InscripcionData.GetAllAlumno(idAlumno);
            DataRow row;

            foreach (AlumnoInscripcion inscripcion in inscripciones)
            {
                row = table.NewRow();
                Curso curso = cursoData.GetOne(inscripcion.IdCurso);
                row["descMateria"] = materiaData.GetOne(curso.IdMateria).Descripcion;
                row["descComision"] = comisionData.GetOne(curso.IdComision).Descripcion;
                row["anioCalendario"] = curso.AñoCalendario;
                row["condicion"] = inscripcion.Condicion;
                row["nota"] = inscripcion.Nota;
                table.Rows.Add(row);
            }

            return table;
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            InscripcionData.Save(inscripcion);
        }

    }
}
