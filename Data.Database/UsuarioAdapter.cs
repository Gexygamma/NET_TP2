using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter<Usuario>
    {
        protected override Usuario CrearDesdeReader(SqlDataReader dr)
        {
            Usuario usuario = new Usuario
            {
                ID = (int)dr["id_usuario"],
                NombreUsuario = (string)dr["nombre_usuario"],
                Clave = (string)dr["clave"],
                Habilitado = (bool)dr["habilitado"],
                Nombre = (string)dr["nombre"],
                Apellido = (string)dr["apellido"],
                Email = (string)dr["email"],
                IdPersona = (int)dr["id_persona"]
            };
            return usuario;
        }

        internal override void CargarParametrosSql(SqlCommand cmd, Usuario usuario)
        {
            cmd.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
            cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
            cmd.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
            cmd.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
        }
        
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", SqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usuario = CrearDesdeReader(drUsuarios);
                    usuarios.Add(usuario);
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usuario;
            try
            {
                OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario=@id", SqlConn);
                cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usuario = CrearDesdeReader(drUsuarios);
                }
                else
                {
                    usuario = null;
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar usuario por id", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return usuario;
        }

        public Usuario GetNombreUsuario(string nombreUsuario)
        {
            Usuario usuario;
            try
            {
                OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario=@nombre_usuario", SqlConn);
                cmdUsuario.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = nombreUsuario;
                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usuario = CrearDesdeReader(drUsuarios);
                }
                else
                {
                    usuario = null;
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar usuario por nombre de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return usuario;
        }

        protected void Insert(Usuario usuario, Persona persona)
        {
            PersonaAdapter personaData = new PersonaAdapter();

            try
            {
                OpenConnection();
                SqlTransaction transaction = SqlConn.BeginTransaction();
                SqlCommand cmdInsert;
                try
                {
                    cmdInsert = new SqlCommand(
                       "INSERT INTO personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)" +
                       "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan)" +
                       "SELECT @@identity",
                       SqlConn, transaction);
                    personaData.CargarParametrosSql(cmdInsert, persona);
                    persona.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
                    usuario.IdPersona = persona.ID;

                    cmdInsert = new SqlCommand(
                       "INSERT INTO usuarios(nombre_usuario, clave, habilitado, nombre, apellido, email, id_persona)" +
                       "VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @id_persona)" +
                       "SELECT @@identity",
                       SqlConn, transaction);
                    CargarParametrosSql(cmdInsert, usuario);
                    usuario.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Exception ExcepcionManejada = new Exception("Error al insertar usuario y persona", ex);
                    throw ExcepcionManejada;
                }
                
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Usuario usuario, Persona persona)
        {
            PersonaAdapter personaData = new PersonaAdapter();

            try
            {
                OpenConnection();
                SqlTransaction transaction = SqlConn.BeginTransaction();
                SqlCommand cmdUpdate;
                try
                {
                    cmdUpdate = new SqlCommand(
                       "UPDATE personas SET nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, " +
                        "telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan " +
                        "WHERE id_persona=@id",
                       SqlConn, transaction);
                    cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                    personaData.CargarParametrosSql(cmdUpdate, persona);
                    cmdUpdate.ExecuteNonQuery();

                    cmdUpdate = new SqlCommand(
                       "UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, habilitado=@habilitado, " +
                        "nombre=@nombre, apellido=@apellido, email=@email, id_persona=@id_persona " +
                        "WHERE id_usuario=@id",
                       SqlConn, transaction);
                    cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                    CargarParametrosSql(cmdUpdate, usuario);
                    cmdUpdate.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Exception ExcepcionManejada = new Exception("Error al actualizar usuario y persona", ex);
                    throw ExcepcionManejada;
                }

            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Delete(int IdUsuario, int IdPersona)
        {
            try
            {
                OpenConnection();
                SqlTransaction transaction = SqlConn.BeginTransaction();
                SqlCommand cmdDelete;
                try
                {
                    cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario=@id", SqlConn, transaction);
                    cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IdUsuario;
                    cmdDelete.ExecuteNonQuery();

                    cmdDelete = new SqlCommand("DELETE personas WHERE id_persona=@id", SqlConn, transaction);
                    cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IdPersona;
                    cmdDelete.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Exception ExcepcionManejada = new Exception("Error al eliminar usuario y persona", ex);
                    throw ExcepcionManejada;
                }

            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Usuario usuario, Persona persona)
        {
            switch (usuario.State)
            {
                case BusinessEntity.States.New:
                    Insert(usuario, persona);
                    break;
                case BusinessEntity.States.Modified:
                    Update(usuario, persona);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(usuario.ID, persona.ID);
                    break;
            }
            usuario.State = BusinessEntity.States.Unmodified;
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
