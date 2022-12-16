using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos

{
    public class DA_Logica
    {
        public List<Usuario> ListarUsuario()
        {


            var oLista = new List<Usuario>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarUsuario", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Usuario()
                        {
                            id_usuario = Convert.ToInt32(lector["id_usuario"]),
                            Nombre = Convert.ToString(lector["Nombre"]),
                            Correo = Convert.ToString(lector["Correo"]),
                            Clave = Convert.ToString(lector["Clave"]),
                            usuario_rol = Convert.ToInt32(lector["usuario_rol"]),

                        });

                    }
                }

            }

            return oLista;
        }



        //    return new List<Usuario>
        //    {

        // new Usuario { Nombre = "Enrique", Correo = "administrador@gmail.com", Clave = "123", Roles = new string[] { "Administrador" } },
        // new Usuario { Nombre = "Ariel", Correo = "supervisor@gmail.com", Clave = "123", Roles = new string[] { "Supervisor" } },
        // new Usuario { Nombre = "Alejandro", Correo = "empleado@gmail.com", Clave = "123", Roles = new string[] { "Empleado" } },
        // new Usuario { Nombre = "Matias", Correo = "cliente@gmail.com", Clave = "123", Roles = new string[] { "Cliente" } },

        // new Usuario { Nombre = "Maria", Correo = "superempleado@gmail.com", Clave = "123", Roles = new string[] { "Supervisor", "Empleado"} },

        //    };
        //}

        //devuelve usuario único según su correo y contraseña 
        public Usuario ValidarUsuario(string _correo, string _clave)
        {

            return ListarUsuario().Where(item => item.Correo == _correo && item.Clave == _clave).FirstOrDefault();
        }





    }

}