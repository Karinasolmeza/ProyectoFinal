using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class Promocion_productoDatos
    {

        public List<Promocion_producto> ListarPromocionProducto()
        {
            var oLista = new List<Promocion_producto>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();




                SqlCommand cmd = new SqlCommand("ListarPromocionProducto", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_promo", DBNull.Value);
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {

                        oLista.Add(new Promocion_producto()
                        {
                            promo_numero = Convert.ToInt32(lector["promo_numero"]),
                            id_promo = Convert.ToInt32(lector["id_promo"]),
                            id_producto = Convert.ToInt32(lector["id_producto"]),
                           
                            promo_fecha_inicio = Convert.ToDateTime(lector["promo_fecha_inicio"]),
                            promo_fecha_fin = Convert.ToDateTime(lector["promo_fecha_fin"]),





                        });

                    }
                }

            }

            return oLista;
        }





        public Promocion_producto ObtenerPromocionProducto(int promo_numero)
        {
            var oPromocion_producto = new Promocion_producto();

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerPromocionProducto", conexionTemp);

                    //cmd.Parameters.AddWithValue("@id_orden", DBNull.Value);
                    //cmd.Parameters.Add("@id_detalle_orden", SqlDbType.Int).Value = id_detalle_orden;
                    cmd.Parameters.AddWithValue("promo_numero", promo_numero);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {


                        while (lector.Read())
                        {
                            Console.WriteLine("Leyendo fila:");
                            for (int i = 0; i < lector.FieldCount; i++)
                            {
                                Console.WriteLine($"Columna {i}: {lector[i]}");
                            }
                            oPromocion_producto.promo_numero = Convert.ToInt32(lector["promo_numero"]);
                            oPromocion_producto.id_promo = Convert.ToInt32(lector["id_promo"]);
                            oPromocion_producto.id_producto = Convert.ToInt32(lector["id_producto"]);
                            oPromocion_producto.promo_fecha_inicio = Convert.ToDateTime(lector["promo_fecha_inicio"]);
                            oPromocion_producto.promo_fecha_fin = Convert.ToDateTime(lector["promo_fecha_fin"]);
                           
                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oPromocion_producto;
            }

            return oPromocion_producto;

        }




        public bool GuardarPromocionProducto(Promocion_producto oPromocion_producto)
        {
            bool respuesta;

            try
            {
               


                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarPromocionProducto", conexionTemp);

                    cmd.Parameters.AddWithValue("id_promo", oPromocion_producto.id_promo);
                    cmd.Parameters.AddWithValue("id_producto", oPromocion_producto.id_producto);
                    cmd.Parameters.AddWithValue("promo_fecha_inicio", oPromocion_producto.promo_fecha_inicio);
                    cmd.Parameters.AddWithValue("promo_fecha_fin", oPromocion_producto.promo_fecha_fin);
                 

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



        public bool EditarPromocionProducto(Promocion_producto oPromocion_producto)
        {
            bool respuesta;

            try
            {

             
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarPromocionProducto", conexionTemp);

                    cmd.Parameters.AddWithValue("@promo_numero", oPromocion_producto.promo_numero);
                    cmd.Parameters.AddWithValue("@id_promo", oPromocion_producto.id_promo);
                    cmd.Parameters.AddWithValue("@id_producto", oPromocion_producto.id_producto);
                    cmd.Parameters.AddWithValue("@promo_fecha_inicio", oPromocion_producto.promo_fecha_inicio);
                    cmd.Parameters.AddWithValue("@promo_fecha_fin", oPromocion_producto.promo_fecha_fin);
                    

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



        public bool EliminarPromocionProducto(int promo_numero)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarPromocionProducto", conexionTemp);
                    cmd.Parameters.AddWithValue("promo_numero",promo_numero);
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
