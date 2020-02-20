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
    public class DocenteCursoAdapter : Adapter<DocenteCurso>
    {
        protected override DocenteCurso CrearDesdeReader(SqlDataReader dr)
        {
            DocenteCurso docenteCurso = new DocenteCurso()
            {
                ID = (int)dr["id_dictado"],
                IdCurso = (int)dr["id_curso"],
                IdDocente = (int)dr["id_docente"],
                Cargo = (TipoCargo)dr["cargo"]
            };
            return docenteCurso;
        }

        internal override void CargarParametrosSql(SqlCommand cmd, DocenteCurso docenteCurso)
        {
            cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IdCurso;
            cmd.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IdDocente;
            cmd.Parameters.Add("@cargo", SqlDbType.Int).Value = (int)docenteCurso.Cargo;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docenteCurso;
            try
            {
                OpenConnection();
                SqlCommand cmdDictado = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_dictado=@id", SqlConn);
                cmdDictado.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDictado = cmdDictado.ExecuteReader();
                if (drDictado.Read())
                {
                    docenteCurso = CrearDesdeReader(drDictado);
                }
                else
                {
                    docenteCurso = null;
                }
                drDictado.Close();
            }
            finally
            {
                CloseConnection();
            }
            return docenteCurso;
        }

        public DocenteCurso GetOneCurso(Curso curso, TipoCargo cargo)
        {
            DocenteCurso docenteCurso;
            try
            {
                OpenConnection();
                SqlCommand cmdDictado = new SqlCommand("SELECT * FROM docentes_cursos " +
                    "WHERE id_curso=@id AND cargo=@cargo", SqlConn);
                cmdDictado.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdDictado.Parameters.Add("@cargo", SqlDbType.Int).Value = (int)cargo;
                SqlDataReader drDictado = cmdDictado.ExecuteReader();
                if (drDictado.Read())
                {
                    docenteCurso = CrearDesdeReader(drDictado);
                }
                else
                {
                    docenteCurso = null;
                }
                drDictado.Close();
            }
            finally
            {
                CloseConnection();
            }
            return docenteCurso;
        }

        protected void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO docentes_cursos(id_curso,id_docente,cargo)" +
                   "VALUES (@id_curso,@id_docente,@cargo)" +
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                CargarParametrosSql(cmdInsert, docenteCurso);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                docenteCurso.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE docentes_cursos SET id_curso=@id_curso,id_docente=@id_docente," +
                    "cargo=@cargo WHERE id_dictado=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = docenteCurso.ID;
                CargarParametrosSql(cmdUpdate, docenteCurso);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del dictado", ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(DocenteCurso docenteCurso)
        {
            switch (docenteCurso.State)
            {
                case BusinessEntity.States.New:
                    Insert(docenteCurso);
                    break;
                case BusinessEntity.States.Modified:
                    Update(docenteCurso);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(docenteCurso.ID);
                    break;
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }
    }
}
