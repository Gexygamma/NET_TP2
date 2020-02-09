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
    public class MateriaAdapter : Adapter<Materia>
    {
        protected override Materia CrearDesdeReader(SqlDataReader dr)
        {
            Materia materia = new Materia
            {
                ID = (int)dr["id_materia"],
                Descripcion = (string)dr["desc_materia"],
                HsSemanales = (int)dr["hs_semanales"],
                HsTotales = (int)dr["hs_totales"],
                IdPlan = (int)dr["id_plan"]
            };
            return materia;
        }

        internal override void CargarParametrosSql(SqlCommand cmd, Materia materia)
        {
            cmd.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
            cmd.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
            cmd.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
            cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IdPlan;
        }

        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("SELECT * FROM materias", SqlConn);
                SqlDataReader drMateria = cmdMateria.ExecuteReader();
                while (drMateria.Read())
                {
                    Materia materia = CrearDesdeReader(drMateria);
                    materias.Add(materia);
                }
                drMateria.Close();
            }
            finally
            {
                CloseConnection();
            }
            return materias;
        }
        public Materia GetOne(int ID)
        {
            Materia materia;
            try
            {
                OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("SELECT * FROM materias WHERE id_materia=@id", SqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMateria = cmdMateria.ExecuteReader();
                if (drMateria.Read())
                {
                    materia = CrearDesdeReader(drMateria);
                }
                else
                {
                    materia = null;
                }
                drMateria.Close();
            }
            finally
            {
                CloseConnection();
            }
            return materia;
        }

        protected void Insert(Materia materia)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO materias(desc_materia,hs_semanales,hs_totales,id_plan)" +
                   "VALUES (@desc_materia,@hs_semanales,@hs_totales,@id_plan)" +
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                CargarParametrosSql(cmdInsert, materia);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                materia.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Materia materia)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE materias SET desc_materia=@desc_materia,hs_semanales=@hs_semanales, " +
                    "hs_totales=@hs_totales,id_plan=@id_plan " +
                    "WHERE id_materia=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                CargarParametrosSql(cmdUpdate, materia);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", ex);
                throw ExcepcionManejada;

            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Materia materia)
        {
            switch (materia.State)
            {
                case BusinessEntity.States.New:
                    Insert(materia);
                    break;
                case BusinessEntity.States.Modified:
                    Update(materia);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(materia.ID);
                    break;
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}



