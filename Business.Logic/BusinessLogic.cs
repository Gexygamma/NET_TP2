using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class BusinessLogic
    {
        public Data.Database.UsuarioAdapter UsuarioData
        {
            get; set;
        }
    }

    public class UsuarioLogic : BusinessLogic
    {
        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
    }
}
