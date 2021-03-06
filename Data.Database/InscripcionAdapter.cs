﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class InscripcionAdapter : Adapter<AlumnoInscripcion>
    {
        protected override AlumnoInscripcion CrearDesdeReader(SqlDataReader dr)
        {
            AlumnoInscripcion inscripcion = new AlumnoInscripcion
            {
                ID = (int)dr["id_inscripcion"],
                IdAlumno = (int)dr["id_alumno"],
                IdCurso = (int)dr["id_curso"],
                Condicion = (string)dr["condicion"],
                Nota = (int)dr["nota"]
            };
            return inscripcion;
        }

        internal override void CargarParametrosSql(SqlCommand cmd, AlumnoInscripcion inscripcion)
        {
            cmd.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IdAlumno;
            cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IdCurso;
            cmd.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
            cmd.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion inscripcion;
            try
            {
                OpenConnection();
                SqlCommand cmdInscripcion = new SqlCommand("SELECT * FROM alumnos_inscripciones " +
                    "WHERE id_inscripcion=@id", SqlConn);
                cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drInscripcion = cmdInscripcion.ExecuteReader();
                if (drInscripcion.Read())
                {
                    inscripcion = CrearDesdeReader(drInscripcion);
                }
                else
                {
                    inscripcion = null;
                }
                drInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar inscripcion por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return inscripcion;
        }

        private List<AlumnoInscripcion> GetMany(SqlCommand cmd)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                cmd.Connection = SqlConn;
                SqlDataReader drInscripcion = cmd.ExecuteReader();
                while (drInscripcion.Read())
                {
                    AlumnoInscripcion inscripcion = CrearDesdeReader(drInscripcion);
                    inscripciones.Add(inscripcion);
                }
                drInscripcion.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return inscripciones;
        }

        public List<AlumnoInscripcion> GetAllAlumno(int idAlumno)
        {
            SqlCommand cmdInscripcion = new SqlCommand("SELECT * FROM alumnos_inscripciones " +
                "WHERE id_alumno=@id");
            cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
            return GetMany(cmdInscripcion);
        }

        public List<AlumnoInscripcion> GetAllCurso(int idCurso)
        {
            SqlCommand cmdInscripcion = new SqlCommand("SELECT * FROM alumnos_inscripciones " +
                "WHERE id_curso=@id");
            cmdInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = idCurso;
            return GetMany(cmdInscripcion);
        }

        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO alumnos_inscripciones(id_alumno,id_curso,condicion,nota)" +
                   "VALUES (@id_alumno,@id_curso,@condicion,@nota)" +
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                CargarParametrosSql(cmdInsert, inscripcion);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                inscripcion.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar inscripcion", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET id_alumno=@id_alumno,id_curso=@id_curso," +
                    "condicion=@condicion,nota=@nota " +
                    "WHERE id_inscripcion=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                CargarParametrosSql(cmdUpdate, inscripcion);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripcion", ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE inscripcion WHERE id_inscripcion=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripcion", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion inscripcion)
        {
            switch (inscripcion.State)
            {
                case BusinessEntity.States.New:
                    Insert(inscripcion);
                    break;
                case BusinessEntity.States.Modified:
                    Update(inscripcion);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(inscripcion.ID);
                    break;
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
    }
}
