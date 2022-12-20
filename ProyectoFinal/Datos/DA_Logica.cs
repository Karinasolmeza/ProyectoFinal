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
                            rolAsociado = new Roles()
                            {
                                id_rol = Convert.ToInt32(lector["id_rol"]),
                                rol_detalle = Convert.ToString(lector["rol_detalle"]),
                            }
                        });

                    }
                }

            }

            return oLista;
        }



        public List<Usuario> ListarUsuarioRol()
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


                SqlCommand cmd = new SqlCommand("ListarUsuarioRol", conexionTemp);
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
                            rolAsociado = new Roles()
                            {
                                id_rol = Convert.ToInt32(lector["id_rol"]),
                                rol_detalle = Convert.ToString(lector["rol_detalle"]),
                            }
                        });

                    }
                }

            }

            return oLista;
        }

        public Usuario ObtenerUsuario(int id_usuario)
        {
            var oUsuario = new Usuario();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerUsuario", conexionTemp);

                    cmd.Parameters.AddWithValue("id_usuario", id_usuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oUsuario.id_usuario = Convert.ToInt32(lector["id_usuario"]);
                            oUsuario.Nombre = Convert.ToString(lector["Nombre"]);
                            oUsuario.Correo = Convert.ToString(lector["Correo"]);
                            oUsuario.Clave = Convert.ToString(lector["Clave"]);
                            oUsuario.usuario_rol = Convert.ToInt32(lector["usuario_rol"]);
                          


                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oUsuario;
            }

            return oUsuario;


        }



        public bool GuardarUsuario(Usuario oUsuario)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarUsuario", conexionTemp);

                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                    cmd.Parameters.AddWithValue("usuario_rol", oUsuario.usuario_rol);
                 


                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
        }



        public bool EditarUsuario(Usuario oUsuario)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarUsuario", conexionTemp);


                    cmd.Parameters.AddWithValue("id_usuario", oUsuario.id_usuario);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                    cmd.Parameters.AddWithValue("usuario_rol", oUsuario.usuario_rol);
                  



                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }

                respuesta = true;
            }

            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;

            }

            return respuesta;

        }




        public bool EliminarUsuario(int id_usuario)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", conexionTemp);
                    cmd.Parameters.AddWithValue("id_usuario", id_usuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
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




        public Usuario AutenticarUsuario(string Correo, string Clave)
        {
            //Esta variable recibe la informacion
            var usuario = new Usuario();
            //Instancia de la conexion
            var conexion = new Conexion();
            try
            {
                //Usando using definimos el tiempo de vida de la conexion
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    //Aca abro la conexion
                    conexionTemp.Open();
                    //Aca instancio un objeto para las query y la relaciono con el sp
                    SqlCommand cmd = new SqlCommand("AutenticarUsuario", conexionTemp);
                    cmd.Parameters.AddWithValue("Correo", Correo);
                    cmd.Parameters.AddWithValue("Clave", Clave);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    //Comienzo la lectura de datos
                    using (var lector = cmd.ExecuteReader())
                    {
                        //mientras haya registros van a almacenarse en el oLista
                        while (lector.Read())
                        {
                            usuario.Nombre = Convert.ToString(lector["Nombre"]);
                            usuario.Correo = Convert.ToString(lector["Correo"]);
                            usuario.Clave = Convert.ToString(lector["Clave"]);
                            usuario.usuario_rol = Convert.ToInt32(lector["usuario_rol"]);
                            usuario.rolAsociado = new Roles()
                            {
                                id_rol = Convert.ToInt32(lector["id_rol"]),
                                rol_detalle = Convert.ToString(lector["rol_detalle"])
                            };
                        }
                    }
                }
                return usuario;
            }
            catch
            {
                return null;
            }
        }



    }

}