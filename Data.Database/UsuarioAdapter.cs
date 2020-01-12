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

        protected override void CargarParametrosSql(SqlCommand cmd, Usuario usuario)
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

        protected override void Insert(Usuario usuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                   "INSERT INTO usuarios(nombre_usuario, clave, habilitado, nombre, apellido, email, id_persona)"+
                   "VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @id_persona)"+
                   "SELECT @@identity", // Esta última línea es para recuperar el ID autogenerado desde la bd.
                   SqlConn);
                cmdInsert.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                CargarParametrosSql(cmdInsert, usuario);
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                usuario.ID = decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex) 
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", ex);
                throw ExcepcionManejada;
            }
            finally 
            {
                CloseConnection();
            }
        }

        protected override void Update(Usuario usuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, habilitado=@habilitado, " +
                    "nombre=@nombre, apellido=@apellido, email=@email, id_persona=@id_persona " +
                    "WHERE id_usuario=@id", SqlConn);
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                CargarParametrosSql(cmdUpdate, usuario);
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", ex);
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
                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
