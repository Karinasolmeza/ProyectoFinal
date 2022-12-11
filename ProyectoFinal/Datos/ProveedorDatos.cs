using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;



namespace ProyectoFinal.Datos
{
    public class ProveedorDatos
    {

        public List<Proveedor> ListarProveedor()
        {
            var oLista = new List<Proveedor> ();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarProveedor", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Proveedor()
                        {
                            id_proveedor = Convert.ToInt32(lector["id_proveedor"]),
                            prove_nombre = Convert.ToString(lector["prove_nombre"]),
                            prove_apellido = Convert.ToString(lector["prove_apellido"]),
                            prove_direccion = Convert.ToString(lector["prove_direccion"]),
                            prove_cuit = Convert.ToString(lector["prove_cuit"])
                          
                            

                        });

                    }
                }

            }

            return oLista;
        }


        public Proveedor ObtenerProveedor(int id_proveedor)
        {
            var oProveedor = new Proveedor();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerProveedor", conexionTemp);

                    cmd.Parameters.AddWithValue("id_Prove", id_proveedor);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            
                    oProveedor.id_proveedor = Convert.ToInt32(lector["id_proveedor"]);
                    oProveedor.prove_nombre = Convert.ToString(lector["prove_nombre"]);
                    oProveedor.prove_apellido = Convert.ToString(lector["prove_apellido"]);
                    oProveedor.prove_direccion = Convert.ToString(lector["prove_direccion"]);
                    oProveedor.prove_cuit = Convert.ToString(lector["prove_cuit"]);
                          

                        }


            }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oProveedor;
            }

            return oProveedor;


        }




        public bool GuardarProveedor(Proveedor oProveedor)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarProveedor", conexionTemp);

                    cmd.Parameters.AddWithValue("prove_nombre", oProveedor.prove_nombre);
                    cmd.Parameters.AddWithValue("prove_apellido", oProveedor.prove_apellido);
                    cmd.Parameters.AddWithValue("prove_direccion", oProveedor.prove_direccion);
                    cmd.Parameters.AddWithValue("prove_cuit", oProveedor.prove_cuit);
            
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



        public bool EditarProveedor(Proveedor oProveedor)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarProveedor", conexionTemp);


               

                    cmd.Parameters.AddWithValue("id_proveedor", oProveedor.id_proveedor);
                    cmd.Parameters.AddWithValue("prove_nombre", oProveedor.prove_nombre);
                    cmd.Parameters.AddWithValue("prove_apellido", oProveedor.prove_apellido);
                    cmd.Parameters.AddWithValue("prove_direccion", oProveedor.prove_direccion);
                    cmd.Parameters.AddWithValue("prove_cuit", oProveedor.prove_cuit);



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

        public bool EliminarProveedor(int id_proveedor)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarProveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("id_proveedor", id_proveedor);
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





    }
}
