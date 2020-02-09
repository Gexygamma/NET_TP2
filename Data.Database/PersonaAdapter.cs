using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class PersonaAdapter : Adapter<Persona>
    {
        protected override Persona CrearDesdeReader(SqlDataReader dr)
        {
            Persona persona = new Persona
            {
                ID = (int)dr["id_persona"],
                Nombre = (string)dr["nombre"],
                Apellido = (string)dr["apellido"],
                Direccion = (string)dr["direccion"],
                Email = (string)dr["email"],
                Telefono = (string)dr["telefono"],
                FechaNacimiento = (DateTime)dr["fecha_nac"],
                Legajo = (int)dr["legajo"],
                TipoPersona = (TipoPersona)dr["tipo_persona"],
                IdPlan = (int)dr["id_plan"]
            };
            return persona;
        }

        internal override void CargarParametrosSql(SqlCommand cmd, Persona persona)
        {
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
            cmd.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
            cmd.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
            cmd.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int)persona.TipoPersona;
            cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IdPlan;
        }

        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas", SqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona persona = CrearDesdeReader(drPersonas);
                    personas.Add(persona);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona persona;
            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("SELECT * FROM personas WHERE id_persona=@id", SqlConn);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersona.ExecuteReader();
                if (drPersonas.Read())
                {
                    persona = CrearDesdeReader(drPersonas);
                }
                else
                {
                    persona = null;
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar persona por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return persona;
        }

        public int CountAdmins()
        {
            int count = 0;
            try
            {
                OpenConnection();
                SqlCommand cmdCount = new SqlCommand("SELECT count(*) AS count FROM personas WHERE tipo_persona=2", SqlConn);
                SqlDataReader dr = cmdCount.ExecuteReader();
                dr.Read();
                count = (int)dr["count"];
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al contar cantidad de administradores", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return count;
        }

        protected void Insert(Persona persona)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)" +
                   "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan)" +
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                CargarParametrosSql(cmdInsert, persona);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                persona.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE personas SET nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, " +
                    "telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona " +
                    "WHERE id_persona=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                CargarParametrosSql(cmdUpdate, persona);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE personas WHERE id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Persona persona)
        {
            switch (persona.State)
            {
                case BusinessEntity.States.New:
                    Insert(persona);
                    break;
                case BusinessEntity.States.Modified:
                    Update(persona);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(persona.ID);
                    break;
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
