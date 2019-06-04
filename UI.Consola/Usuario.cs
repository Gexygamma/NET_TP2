using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuario
    {
        public UsuarioLogic UsuarioNegocio
        {
            get; set;
        }

        public Usuario ()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("1 – Listado General");
                Console.WriteLine("2 – Consulta");
                Console.WriteLine("3 – Agregar");
                Console.WriteLine("4 - Modificar ");
                Console.WriteLine("5 - Eliminar ");
                Console.WriteLine("6 - Salir");
                op = int.Parse(Console.ReadLine());
                    
                switch (op)
                {
                    case 1:
                        this.ListadoGeneral(); 
                        break;
                    case 2:
                        this.Consulta();
                        break;
                    case 3:
                        this.Agregar();
                        break;
                    case 4:
                        this.Modificar();
                        break;
                    case 5:
                        this.Eliminar();
                        break;
                }
                Console.ReadKey();
            } while (op != 6);
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Business.Entities.Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }

        public void MostrarDatos(Business.Entities.Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t \tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t \tApellido : {0}", usr.Apellido);
            Console.WriteLine("\t \tNombreUsuario : {0}", usr.NombreUsuario);
            Console.WriteLine("\t \tClave : {0}", usr.Clave);
            Console.WriteLine("\t \tEmail  : {0}", usr.Email);
            Console.WriteLine("\t \tHabilitado : {0}", usr.Habilitado);
        }

        public void Consulta()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a consultar:");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine("\tLa ID ingresada debe ser un número entero.");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine("\tNo existe el ID ingresado.");
            }
            catch (Exception e) 
            {
                Console.WriteLine("\t{0}", e.Message);
            }
            finally
            {
                Console.WriteLine("\tPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        // TODO: Algunas funciones comparten mucho código y deberían separarce
        public void Agregar()
        {
            Business.Entities.Usuario usr = new Business.Entities.Usuario();

            Console.Clear();
            Console.Write("Ingrese nombre: ");
            usr.Nombre = Console.ReadLine();
            Console.Write("Ingrese apellido: ");
            usr.Apellido = Console.ReadLine();
            Console.Write("Ingrese nombre de usuario: ");
            usr.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese clave: ");
            usr.Clave = Console.ReadLine();
            Console.Write("Ingrese email: ");
            usr.Email = Console.ReadLine();
            String h;
            do
            {
                Console.Write("Ingrese habilitación de usuario (S/N): ");
                h = Console.ReadLine();
            } while (h != "S" && h != "s" && h != "N" && h != "n");
            usr.Habilitado = ((h == "S") || (h == "s"));
            usr.State = BusinessEntity.States.Modified;
            UsuarioNegocio.Save(usr);
            Console.WriteLine("\nID: {0}", usr.ID);
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Business.Entities.Usuario usr = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese nombre: ");
                usr.Nombre = Console.ReadLine();
                Console.Write("Ingrese apellido: ");
                usr.Apellido = Console.ReadLine();
                Console.Write("Ingrese nombre de usuario: ");
                usr.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese clave: ");
                usr.Clave = Console.ReadLine();
                Console.Write("Ingrese email: ");
                usr.Email = Console.ReadLine();
                String h;
                do
                {
                    Console.Write("Ingrese habilitación de usuario (S/N): ");
                    h = Console.ReadLine();
                } while (h != "S" && h != "s" && h != "N" && h != "n");
                usr.Habilitado = ((h == "S") || (h == "s"));
                usr.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usr);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("\nLa ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n{0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("\nLa ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n{0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
