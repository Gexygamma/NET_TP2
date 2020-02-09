using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class ComisionAdapter : Adapter<Comision>
    {
        protected override Comision CrearDesdeReader(SqlDataReader dr)
        {
            Comision comision = new Comision()
            {
                ID = (int)dr["id_comision"],
                Descripcion = (string)dr["desc_comision"],
                AñoEspecialidad = (int)dr["anio_especialidad"],
                IdPlan = (int)dr["id_plan"]
            };
            return comision;
        }

        internal override void CargarParametrosSql(SqlCommand cmd, Comision comision)
        {
            cmd.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
            cmd.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AñoEspecialidad;
            cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
        }

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("SELECT * FROM comisiones", SqlConn);
                SqlDataReader drComision = cmdComision.ExecuteReader();
                while (drComision.Read())
                {
                    Comision comision = CrearDesdeReader(drComision);
                    comisiones.Add(comision);
                }
                drComision.Close();
            }
            finally
            {
                CloseConnection();
            }
            return comisiones;
        }

        public List<Comision> GetAllPlan(int idPlan)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("SELECT * FROM comisiones WHERE id_plan=@id_plan", SqlConn);
                cmdComision.Parameters.Add("@id_plan", SqlDbType.Int).Value = idPlan;
                SqlDataReader drComision = cmdComision.ExecuteReader();
                while (drComision.Read())
                {
                    Comision comision = CrearDesdeReader(drComision);
                    comisiones.Add(comision);
                }
                drComision.Close();
            }
            finally
            {
                CloseConnection();
            }
            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision comision;
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id", SqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComision = cmdComision.ExecuteReader();
                if (drComision.Read())
                {
                    comision = CrearDesdeReader(drComision);
                }
                else
                {
                    comision = null;
                }
                drComision.Close();
            }
            finally
            {
                CloseConnection();
            }
            return comision;
        }

        protected void Insert(Comision comision)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO comisiones(desc_comision,anio_especialidad,id_plan)" +
                   "VALUES (@desc_comision,@anio_especialidad,@id_plan)" +
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                CargarParametrosSql(cmdInsert, comision);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                comision.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar comisión", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE comisiones SET desc_comision=@desc_comision,anio_especialidad=@anio_especialidad," +
                    "id_plan=@id_plan WHERE id_comision=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                CargarParametrosSql(cmdUpdate, comision);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comisión", ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comisión", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            switch (comision.State)
            {
                case BusinessEntity.States.New:
                    Insert(comision);
                    break;
                case BusinessEntity.States.Modified:
                    Update(comision);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(comision.ID);
                    break;
            }
            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
