using ProyectoFinal.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.CodeAnalysis.CSharp.Syntax;



namespace ProyectoFinal.Datos
{
    public class ProductoDatos
    {

        public List<Producto> ListarProducto()
        {
            var oLista = new List<Producto>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarProducto", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Producto()
                        {
                            id_producto = Convert.ToInt32(lector["id_producto"]),
                            prod_nombre= Convert.ToString(lector["prod_nombre"]),
                            prod_precio = Convert.ToDecimal(lector["prod_precio"]),
                            prod_stock = Convert.ToDecimal(lector["prod_stock"]),
                            prod_detalle = Convert.ToString(lector["prod_detalle"]),
                            prod_img = Convert.ToString(lector["prod_img"])
                            //prod_precio = Convert.ToDecimal(lector["prod_precio"].ToString()),Preguntar como guardar los decimales

                        });

                    }
                }

            }

            return oLista;
        }


        public Producto ObtenerProducto(int id_producto)
        {
            var oProducto = new Producto();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerProducto", conexionTemp);

                    cmd.Parameters.AddWithValue("id_prod", id_producto);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oProducto.id_producto = Convert.ToInt32(lector["id_producto"]);
                            oProducto.prod_nombre = Convert.ToString(lector["prod_nombre"]);
                            oProducto.prod_precio = Convert.ToDecimal(lector["prod_precio"]);
                            oProducto.prod_stock = Convert.ToDecimal(lector["prod_stock"]);
                            oProducto.prod_detalle = Convert.ToString(lector["prod_detalle"]);
                            oProducto.prod_img = Convert.ToString(lector["prod_img"]);

                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oProducto;
            }

            return oProducto;


        }




        public bool GuardarProducto(Producto oProducto)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarProducto", conexionTemp);

                    cmd.Parameters.AddWithValue("prod_nombre", oProducto.prod_nombre);
                    cmd.Parameters.AddWithValue("prod_precio", oProducto.prod_precio);
                    cmd.Parameters.AddWithValue("prod_stock", oProducto.prod_stock);
                    cmd.Parameters.AddWithValue("prod_detalle", oProducto.prod_detalle);
                    cmd.Parameters.AddWithValue("prod_img", oProducto.prod_img);

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



        public bool EditarProducto(Producto oProducto)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarProducto", conexionTemp);


                    cmd.Parameters.AddWithValue("id_producto", oProducto.id_producto);
                    cmd.Parameters.AddWithValue("prod_nombre", oProducto.prod_nombre);
                    cmd.Parameters.AddWithValue("prod_precio", oProducto.prod_precio);
                    cmd.Parameters.AddWithValue("prod_stock", oProducto.prod_stock);
                    cmd.Parameters.AddWithValue("prod_detalle", oProducto.prod_detalle);
                    cmd.Parameters.AddWithValue("prod_img", oProducto.prod_img);


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

        public bool EliminarProducto(int id_producto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarProducto", conexionTemp);
                    cmd.Parameters.AddWithValue("id_producto", id_producto);
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
