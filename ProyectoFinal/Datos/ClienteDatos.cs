using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProyectoFinal.Models;
using System.Data;
using System.Data.SqlClient;


namespace ProyectoFinal.Datos
{
    public class ClienteDatos

    {
        public List<Cliente> Listar()
        {
            var oLista = new List<Cliente>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("Listar", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Cliente()
                        {
                            id_cliente = Convert.ToInt32(lector["id_cliente"]),
                            clie_nombre = Convert.ToString(lector["clie_nombre"]),
                            clie_apellido = Convert.ToString(lector["clie_apellido"]),
                            clie_dni = Convert.ToString(lector["clie_dni"]),
                            clie_cuit = Convert.ToString(lector["clie_cuit"]),
                            clie_razon_social = Convert.ToString(lector["clie_razon_social"])

                        });

                    }
                }

            }

            return oLista;
        }


        public Cliente Obtener(int id_cliente)
        {
            var oCliente = new Cliente();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("Obtener", conexionTemp);

                    cmd.Parameters.AddWithValue("id_Contacto", id_cliente);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oCliente.id_cliente = Convert.ToInt32(lector["id_cliente"]);
                            oCliente.clie_nombre = Convert.ToString(lector["clie_nombre"]);
                            oCliente.clie_apellido = Convert.ToString(lector["clie_apellido"]);
                            oCliente.clie_dni = Convert.ToString(lector["clie_dni"]);
                            oCliente.clie_cuit = Convert.ToString(lector["clie_cuit"]);
                            oCliente.clie_razon_social = Convert.ToString(lector["clie_razon_social"]);

                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oCliente;
            }

                return oCliente;


            }

        


        public bool Guardar(Cliente oCliente)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", conexionTemp);

                    cmd.Parameters.AddWithValue("clie_nombre", oCliente.clie_nombre);
                    cmd.Parameters.AddWithValue("clie_apellido", oCliente.clie_apellido);
                    cmd.Parameters.AddWithValue("clie_dni", oCliente.clie_dni);
                    cmd.Parameters.AddWithValue("clie_cuit", oCliente.clie_cuit);
                    cmd.Parameters.AddWithValue("clie_razon_social", oCliente.clie_razon_social);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                }

                respuesta = true;
            } catch(Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }

            return respuesta;
    }



        public bool Editar(Cliente oCliente)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("Editar", conexionTemp);


                    cmd.Parameters.AddWithValue("id_cliente", oCliente.id_cliente);
                    cmd.Parameters.AddWithValue("clie_nombre", oCliente.clie_nombre);
                    cmd.Parameters.AddWithValue("clie_apellido", oCliente.clie_apellido);
                    cmd.Parameters.AddWithValue("clie_dni", oCliente.clie_dni);
                    cmd.Parameters.AddWithValue("clie_cuit", oCliente.clie_cuit);
                    cmd.Parameters.AddWithValue("clie_razon_social", oCliente.clie_razon_social);

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

        public bool Eliminar(int id_cliente)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", conexionTemp);
                    cmd.Parameters.AddWithValue("id_cliente", id_cliente);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                respuesta=false;    
            }
            return respuesta;
        }

    }
}