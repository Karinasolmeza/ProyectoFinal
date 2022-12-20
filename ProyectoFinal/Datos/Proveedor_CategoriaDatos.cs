using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class Proveedor_CategoriaDatos
    {



        public List<Proveedor_Categoria> ListarProveedorCategoria()
        {
            var oLista = new List<Proveedor_Categoria>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarProveedorCategoria", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Proveedor_Categoria()
                        {
                            id_proveedor = Convert.ToInt32(lector["id_proveedor"]),
                            id_categoria = Convert.ToInt32(lector["id_categoria"]),
                            proveedorCategoria = new Proveedor()
                            {
                                id_proveedor = Convert.ToInt32(lector["id_proveedor"]),
                                prove_nombre = Convert.ToString(lector["prove_nombre"]),
                           
                            },

                                categoriaProveedor = new Categoria()
                                {
                                    id_categoria = Convert.ToInt32(lector["id_categoria"]),
                                    categ_detalle = Convert.ToString(lector["categ_detalle"])
                    

                                }
                        });

                    }
                }

            }

            return oLista;
        }


        //public Proveedor_Categoria ObtenerProveedorCategoria(int id_proveedor, int id_categoria)
        //{
        //    var oProveedorCategoria = new Proveedor_Categoria();

        //    try
        //    {

        //        var conexion = new Conexion();

        //        using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
        //        {

        //            conexionTemp.Open();
        //            SqlCommand cmd = new SqlCommand("ObtenerProveedorCategoria", conexionTemp);

        //            cmd.Parameters.AddWithValue("id_proveedor", id_proveedor);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            using (var lector = cmd.ExecuteReader())
        //            {
        //                while (lector.Read())
        //                {
        //                    oProveedorCategoria.id_proveedor = Convert.ToInt32(lector["id_proveedor"]);
        //                    oProveedorCategoria.id_categoria = Convert.ToInt32(lector["id_categoria"]);




        //                }


        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        string error = e.Message;
        //        return oProveedorCategoria;
        //    }

        //    return oProveedorCategoria;


        //}


        public Proveedor_Categoria ObtenerProveedorCategoria(int id)
        {
            var oProveedorCategoria = new Proveedor_Categoria();

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    using (var cmd = new SqlCommand("ObtenerProveedorCategoria", conexionTemp))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id_proveedor", id);
                        cmd.Parameters.AddWithValue("id_categoria", id);

                        using (var lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                oProveedorCategoria.id_proveedor = Convert.ToInt32(lector["id_proveedor"]);
                                oProveedorCategoria.id_categoria = Convert.ToInt32(lector["id_categoria"]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Handle the exception here
            }

            return oProveedorCategoria;
        }








        public bool GuardarProveedorCategoria(Proveedor_Categoria oProveedorCategoria)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarProveedorCategoria", conexionTemp);

                    cmd.Parameters.AddWithValue("id_proveedor", oProveedorCategoria.id_proveedor);
                    cmd.Parameters.AddWithValue("id_categoria", oProveedorCategoria.id_categoria);
                    

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


        public bool EditarProveedorCategoria(Proveedor_Categoria oProveedorCategoria)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarProveedorCategoria", conexionTemp);


                    cmd.Parameters.AddWithValue("id_proveedor", oProveedorCategoria.id_proveedor);
                    cmd.Parameters.AddWithValue("id_categoria", oProveedorCategoria.id_categoria);




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



        public bool EliminarProveedorCategoria(int id_proveedor)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarProveedorCategoria", conexionTemp);
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
