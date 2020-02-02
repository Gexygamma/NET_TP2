using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class PlanAdapter : Adapter<Plan>
    {
        protected override Plan CrearDesdeReader(SqlDataReader dr)
        {
            Plan plan = new Plan
            {
                ID = (int)dr["id_plan"],
                Descripcion = (string)dr["desc_plan"],
                IdEspecialidad = (int)dr["id_especialidad"]
            };
            return plan;
        }

        protected override void CargarParametrosSql(SqlCommand cmd, Plan plan)
        {
            cmd.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
            cmd.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
        }

        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes WHERE NOT id_plan=1", SqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();
                while (drPlanes.Read())
                {
                    Plan plan = CrearDesdeReader(drPlanes);
                    planes.Add(plan);
                }
                drPlanes.Close();
            }
            finally
            {
                CloseConnection();
            }
            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan plan;
            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("SELECT * FROM planes WHERE id_plan=@id", SqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlan.ExecuteReader();
                if (drPlanes.Read())
                {
                    plan = CrearDesdeReader(drPlanes);
                }
                else
                {
                    plan = null;
                }
                drPlanes.Close();
            }
            finally
            {
                CloseConnection();
            }
            return plan;
        }

        protected override void Insert(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO planes(desc_plan, id_especialidad)" +
                   "VALUES (@desc_plan, @id_especialidad)" +
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                CargarParametrosSql(cmdInsert, plan);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                plan.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected override void Update(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE planes SET desc_plan=@desc_plan, id_especialidad=@id_especialidad " +
                    "WHERE id_plan=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                CargarParametrosSql(cmdUpdate, plan);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected override void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE planes WHERE id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", ex);
                throw ExcepcionManejada;
               
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
