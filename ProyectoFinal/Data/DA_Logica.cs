﻿using ProyectoFinal.Models;

namespace ProyectoFinal.Data

{
    public class DA_Logica
    {
        public List<Usuario> ListaUsuario()
        {

            return new List<Usuario>
            {
         new Usuario { Nombre = "jose", Correo = "administrador@gmail.com", Clave = "123", Roles = new string[] { "Administrador" } },
         new Usuario { Nombre = "maria", Correo = "supervisor@gmail.com", Clave = "123", Roles = new string[] { "Supervisor" } },
         new Usuario { Nombre = "Juan", Correo = "empleado@gmail.com", Clave = "123", Roles = new string[] { "Empleado" } },
         new Usuario { Nombre = "Oscar", Correo = "superempleado@gmail.com", Clave = "123", Roles = new string[] { "Supervisor", "Empleado"} },

            };
        }

        //devuelve usuario único según su correo y contraseña 
        public Usuario ValidarUsuario(string _correo, string _clave)
        {

            return ListaUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }





    }
}