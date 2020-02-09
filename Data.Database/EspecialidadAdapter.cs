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
    public class EspecialidadAdapter : Adapter<Especialidad>
    {
        protected override Especialidad CrearDesdeReader(SqlDataReader dr)
        {
            Especialidad especialidad = new Especialidad
            {
                ID = (int)dr["id_especialidad"],
                Descripcion = (string)dr["desc_especialidad"]
            };
            return especialidad;
        }

        internal override void CargarParametrosSql(SqlCommand cmd, Especialidad especialidad)
        {
            cmd.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
        }

        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", SqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                while (drEspecialidades.Read())
                {
                    Especialidad especialidad = CrearDesdeReader(drEspecialidades);
                    especialidades.Add(especialidad);
                }
                drEspecialidades.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad especialidad;
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidad = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", SqlConn);
                cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();
                if (drEspecialidad.Read())
                {
                    especialidad = CrearDesdeReader(drEspecialidad);
                }
                else
                {
                    especialidad = null;
                }
                drEspecialidad.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar especialidad por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return especialidad;
        }

        protected void Insert(Especialidad especialidad)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO especialidades(desc_especialidad) VALUES (@desc_especialidad)" +
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                CargarParametrosSql(cmdInsert, especialidad);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                especialidad.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Especialidad especialidad)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE especialidades SET desc_especialidad=@desc_especialidad " +
                    "WHERE id_especialidad=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                CargarParametrosSql(cmdUpdate, especialidad);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {
            switch (especialidad.State)
            {
                case BusinessEntity.States.New:
                    Insert(especialidad);
                    break;
                case BusinessEntity.States.Modified:
                    Update(especialidad);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(especialidad.ID);
                    break;
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
