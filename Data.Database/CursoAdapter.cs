using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class CursoAdapter : Adapter<Curso>
    {
        protected override Curso CrearDesdeReader(SqlDataReader dr)
        {
            Curso curso = new Curso()
            {
                ID = (int)dr["id_curso"],
                IdMateria = (int)dr["id_materia"],
                IdComision = (int)dr["id_comision"],
                Cupo = (int)dr["cupo"],
                AñoCalendario = (int)dr["anio_calendario"]
            };
            return curso;
        }

        internal override void CargarParametrosSql(SqlCommand cmd, Curso curso)
        {
            cmd.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IdMateria;
            cmd.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IdComision;
            cmd.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
            cmd.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AñoCalendario;
        }

        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos", SqlConn);
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                while (drCurso.Read())
                {
                    Curso curso= CrearDesdeReader(drCurso);
                    cursos.Add(curso);
                }
                drCurso.Close();
            }
            finally
            {
                CloseConnection();
            }
            return cursos;
        }

        public Curso GetLatestOneMateriaComision(int idMateria, int idComision)
        {
            Curso curso;
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos WHERE id_materia=@id_materia AND " +
                    "id_comision=@id_comision ORDER BY anio_calendario DESC", SqlConn);
                cmdCurso.Parameters.Add("@id_materia", SqlDbType.Int).Value = idMateria;
                cmdCurso.Parameters.Add("@id_comision", SqlDbType.Int).Value = idComision;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                if (drCurso.Read())
                {
                    curso = CrearDesdeReader(drCurso);
                }
                else
                {
                    curso = null;
                }
                drCurso.Close();
            }
            finally
            {
                CloseConnection();
            }
            return curso;
        }

        public Curso GetOne(int ID)
        {
            Curso curso;
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("SELECT * FROM cursos WHERE id_curso=@id", SqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();
                if (drCurso.Read())
                {
                    curso = CrearDesdeReader(drCurso);
                }
                else
                {
                    curso = null;
                }
                drCurso.Close();
            }
            finally
            {
                CloseConnection();
            }
            return curso;
        }

        protected void Insert(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO cursos(id_materia,id_comision,anio_calendario,cupo)" +
                   "VALUES (@id_materia,@id_comision,@anio_calendario,@cupo)" +
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                CargarParametrosSql(cmdInsert, curso);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                curso.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE cursos SET id_materia=@id_materia,id_comision=@id_comision," +
                    "anio_calendario=@anio_calendario,cupo=@cupo " +
                    "WHERE id_curso=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                CargarParametrosSql(cmdUpdate, curso);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            switch (curso.State)
            {
                case BusinessEntity.States.New:
                    Insert(curso);
                    break;
                case BusinessEntity.States.Modified:
                    Update(curso);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(curso.ID);
                    break;
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}
