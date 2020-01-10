using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
                CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usuario = new Usuario();
            try
            {
                OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usuario.ID = (int)drUsuarios["id_usuario"];
                    usuario.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usuario.Clave = (string)drUsuarios["clave"];
                    usuario.Habilitado = (bool)drUsuarios["habilitado"];
                    usuario.Nombre = (string)drUsuarios["nombre"];
                    usuario.Apellido = (string)drUsuarios["apellido"];
                    usuario.Email = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
                CloseConnection();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            return usuario;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete usuarios where id_usuario=@id",sqlConn);
                cmdDelete.Parameters.Add("@id",SqlDbType.Int).Value= ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada=
                    new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Update(Usuario usuario)
        {
            try
            { 
                OpenConnection();
                SqlCommand cmdSave=new SqlCommand(
                    "UPDATE usuarios SET clave=@clave, "+ 
                    "habilitado= @habilitado, nombre=@nombre, apellido=@apellido, email=@email"+
                    "WHERE id_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar,50).Value=usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value=usuario.Email;
                cmdSave.ExecuteNonQuery();
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
        protected void Insert(Usuario usuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                   "insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email)"+
                   "values (@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email)"+
                   "select @@identity", // Esta �ltima l�nea es para recuperar el ID autogenerado desde la bd.
                   sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                // Se obtiene el ID autogenerado y se lo guarda a la entidad.
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
