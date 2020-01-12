using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace Util
{
    public class Autentificacion
    {
        /// <summary>
        /// <para>Obtiene un Usuario autentificado desde la base de datos si su nombre y clave son correctos.</para>
        /// <para>Devuelve null si no se encuentra o si las credenciales son incorrectas.</para>
        /// </summary>
        /// <param name="nombreUsuario">El nombre del usuario a buscar.</param>
        /// <param name="clave">La clave a verificar.</param>
        public static Usuario AutentificarUsuario(string nombreUsuario, string clave)
        {
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            Usuario usuario = usuarioLogic.GetNombreUsuario(nombreUsuario);
            if (usuario == null)
            {
                return null;
            }
            else if (usuario.Clave != clave)
            {
                return null;
            }
            else
            {
                return usuario;
            }
        }
    }
}
