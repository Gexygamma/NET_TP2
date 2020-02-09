using System;
using System.Collections.Generic;
using System.Data;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic
    {
        private UsuarioAdapter UsuarioData { get; set; }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public Usuario GetNombreUsuario(string nombreUsuario)
        {
            return UsuarioData.GetNombreUsuario(nombreUsuario);
        }

        public void Save(Usuario usuario, Persona persona)
        {
            UsuarioData.Save(usuario, persona);
        }

        public DataTable GetAllTable()
        {
            PersonaAdapter personaData = new PersonaAdapter();

            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("nombre", typeof(string));
            table.Columns.Add("apellido", typeof(string));
            table.Columns.Add("nombreUsuario", typeof(string));
            table.Columns.Add("email", typeof(string));
            table.Columns.Add("tipo", typeof(TipoPersona));
            table.Columns.Add("habilitado", typeof(bool));

            List<Usuario> usuarios = GetAll();
            DataRow row;

            foreach (Usuario usuario in usuarios)
            {
                Persona persona = personaData.GetOne(usuario.IdPersona);
                row = table.NewRow();
                row["ID"] = usuario.ID;
                row["nombre"] = persona.Nombre;
                row["apellido"] = persona.Apellido;
                row["nombreUsuario"] = usuario.NombreUsuario;
                row["email"] = persona.Email;
                row["tipo"] = persona.TipoPersona;
                row["habilitado"] = usuario.Habilitado;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
