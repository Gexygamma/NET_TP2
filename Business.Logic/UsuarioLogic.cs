using System;
using System.Collections.Generic;
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

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
    }
}
