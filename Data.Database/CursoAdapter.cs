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
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", ex);
                throw ExcepcionManejada;
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
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar curso mas reciente por materia y comisión", ex);
                throw ExcepcionManejada;
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
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return curso;
        }

        protected void Insert(Curso curso, DocenteCurso titular, DocenteCurso auxiliar)
        {
            DocenteCursoAdapter docenteCursoData = new DocenteCursoAdapter();

            try
            {
                OpenConnection();
                SqlTransaction transaction = SqlConn.BeginTransaction();
                SqlCommand cmdInsert;
                try
                {
                    cmdInsert = new SqlCommand(
                        "INSERT INTO cursos(id_materia,id_comision,anio_calendario,cupo)" +
                        "VALUES (@id_materia,@id_comision,@anio_calendario,@cupo)" +
                        "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                        SqlConn, transaction);
                    CargarParametrosSql(cmdInsert, curso);
                    // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                    curso.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());

                    titular.IdCurso = curso.ID;
                    cmdInsert = new SqlCommand(
                        "INSERT INTO docentes_cursos(id_curso,id_docente,cargo)" +
                        "VALUES (@id_curso,@id_docente,@cargo)" +
                        "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                        SqlConn, transaction);
                    docenteCursoData.CargarParametrosSql(cmdInsert, titular);
                    // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                    titular.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());

                    if (auxiliar != null)
                    {
                        auxiliar.IdCurso = curso.ID;
                        cmdInsert = new SqlCommand(
                            "INSERT INTO docentes_cursos(id_curso,id_docente,cargo)" +
                            "VALUES (@id_curso,@id_docente,@cargo)" +
                            "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                            SqlConn, transaction);
                        docenteCursoData.CargarParametrosSql(cmdInsert, auxiliar);
                        // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                        auxiliar.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Exception ExcepcionManejada = new Exception("Error al insertar curso", ex);
                    throw ExcepcionManejada;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Curso curso, DocenteCurso titular, DocenteCurso auxiliar)
        {
            DocenteCursoAdapter docenteCursoData = new DocenteCursoAdapter();

            try
            {
                OpenConnection();
                SqlTransaction transaction = SqlConn.BeginTransaction();
                SqlCommand cmdUpdate;
                try
                {
                    cmdUpdate = new SqlCommand(
                        "UPDATE cursos SET id_materia=@id_materia,id_comision=@id_comision," +
                        "anio_calendario=@anio_calendario,cupo=@cupo " +
                        "WHERE id_curso=@id", SqlConn, transaction);
                    cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                    CargarParametrosSql(cmdUpdate, curso);
                    cmdUpdate.ExecuteNonQuery();

                    cmdUpdate = new SqlCommand(
                        "UPDATE docentes_cursos SET id_curso=@id_curso,id_docente=@id_docente," +
                        "cargo=@cargo WHERE id_dictado=@id", SqlConn, transaction);
                    cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = titular.ID;
                    docenteCursoData.CargarParametrosSql(cmdUpdate, titular);
                    cmdUpdate.ExecuteNonQuery();

                    if (auxiliar != null)
                    {
                        switch (auxiliar.State)
                        {
                            case BusinessEntity.States.New:
                                auxiliar.IdCurso = curso.ID;
                                cmdUpdate = new SqlCommand(
                                    "INSERT INTO docentes_cursos(id_curso,id_docente,cargo)" +
                                    "VALUES (@id_curso,@id_docente,@cargo)" +
                                    "SELECT @@identity", SqlConn, transaction);
                                docenteCursoData.CargarParametrosSql(cmdUpdate, auxiliar);
                                auxiliar.ID = decimal.ToInt32((decimal)cmdUpdate.ExecuteScalar());
                                break;
                            case BusinessEntity.States.Modified:
                                cmdUpdate = new SqlCommand(
                                "UPDATE docentes_cursos SET id_curso=@id_curso,id_docente=@id_docente," +
                                "cargo=@cargo WHERE id_dictado=@id", SqlConn, transaction);
                                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = auxiliar.ID;
                                docenteCursoData.CargarParametrosSql(cmdUpdate, auxiliar);
                                cmdUpdate.ExecuteNonQuery();
                                break;
                            case BusinessEntity.States.Deleted:
                                cmdUpdate = new SqlCommand("DELETE docentes_cursos WHERE id_dictado=@id", SqlConn, transaction);
                                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = auxiliar.ID;
                                cmdUpdate.ExecuteNonQuery();
                                break;
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Exception ExcepcionManejada = new Exception("Error al insertar curso", ex);
                    throw ExcepcionManejada;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Delete(int idCurso, int idTitular, DocenteCurso auxiliar)
        {
            try
            {
                OpenConnection();
                SqlTransaction transaction = SqlConn.BeginTransaction();
                SqlCommand cmdDelete;
                try
                {
                    cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado=@id", SqlConn, transaction);
                    cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = idTitular;
                    cmdDelete.ExecuteNonQuery();

                    if (auxiliar != null)
                    {
                        cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado=@id", SqlConn, transaction);
                        cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = auxiliar.ID;
                        cmdDelete.ExecuteNonQuery();
                    }

                    cmdDelete = new SqlCommand("DELETE cursos WHERE id_curso=@id", SqlConn, transaction);
                    cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = idCurso;
                    cmdDelete.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Exception ExcepcionManejada = new Exception("Error al eliminar curso", ex);
                    throw ExcepcionManejada;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Curso curso, DocenteCurso titular, DocenteCurso auxiliar)
        {
            switch (curso.State)
            {
                case BusinessEntity.States.New:
                    Insert(curso, titular, auxiliar);
                    break;
                case BusinessEntity.States.Modified:
                    Update(curso, titular, auxiliar);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(curso.ID, titular.ID, auxiliar);
                    break;
            }
            curso.State = BusinessEntity.States.Unmodified;
            titular.State = BusinessEntity.States.Unmodified;
            if (auxiliar != null)
                auxiliar.State = BusinessEntity.States.Unmodified;
        }

       
    }
}
