using ProyectoFinal.Models;

namespace ProyectoFinal.Datos

{
    public class DA_Logica
    {
        public List<Usuario> ListaUsuario()
        {

            return new List<Usuario>
            {
         new Usuario { Nombre = "Enrique", Correo = "administrador@gmail.com", Clave = "123", Roles = new string[] { "Administrador" } },
         new Usuario { Nombre = "Ariel", Correo = "supervisor@gmail.com", Clave = "123", Roles = new string[] { "Supervisor" } },
         new Usuario { Nombre = "Alejandro", Correo = "empleado@gmail.com", Clave = "123", Roles = new string[] { "Empleado" } },
         new Usuario { Nombre = "Matias", Correo = "cliente@gmail.com", Clave = "123", Roles = new string[] { "Cliente" } },

         new Usuario { Nombre = "Maria", Correo = "superempleado@gmail.com", Clave = "123", Roles = new string[] { "Supervisor", "Empleado"} },

            };
        }

        //devuelve usuario único según su correo y contraseña 
        public Usuario ValidarUsuario(string _correo, string _clave)
        {

            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }





    }
}
