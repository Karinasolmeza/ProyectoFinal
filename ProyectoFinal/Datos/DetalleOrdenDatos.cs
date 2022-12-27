using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace ProyectoFinal.Datos
{
	public class DetalleOrdenDatos
	{

        public List<Detalle_orden> ListarDetalleOrden()
        {
            var oLista = new List<Detalle_orden>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();




                            SqlCommand cmd = new SqlCommand("ListarDetalleOrden", conexionTemp);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_orden", DBNull.Value);
                        using (var lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {

                        oLista.Add(new Detalle_orden()
                                {
                                    id_detalle_orden = Convert.ToInt32(lector["id_detalle_orden"]),
                                    det_id_orden = Convert.ToInt32(lector["det_id_orden"]),
                                    det_id_producto = Convert.ToInt32(lector["det_id_producto"]),
                                    det_ord_precio = Convert.ToDecimal(lector["det_ord_precio"]),
                                    det_ord_cantidad = Convert.ToDecimal(lector["det_ord_cantidad"]),
                                    det_ord_total = Convert.ToDecimal(lector["det_ord_total"]),





                        });

                    }
                }

            }

            return oLista;
        }




     
        public Detalle_orden ObtenerDetalleOrden(int id_detalle_orden)
        {
            var oDetalleOrden = new Detalle_orden();

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerDetalleOrden", conexionTemp);

                    //cmd.Parameters.AddWithValue("@id_orden", DBNull.Value);
                    //cmd.Parameters.Add("@id_detalle_orden", SqlDbType.Int).Value = id_detalle_orden;
                    cmd.Parameters.AddWithValue("id_detalle_orden", id_detalle_orden);
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
                            oDetalleOrden.id_detalle_orden = Convert.ToInt32(lector["id_detalle_orden"]);
                            oDetalleOrden.det_id_orden = Convert.ToInt32(lector["det_id_orden"]);
                            oDetalleOrden.det_id_producto = Convert.ToInt32(lector["det_id_producto"]);
                            oDetalleOrden.det_ord_precio = Convert.ToDecimal(lector["det_ord_precio"]);
                            oDetalleOrden.det_ord_cantidad = Convert.ToDecimal(lector["det_ord_cantidad"]);
                            oDetalleOrden.det_ord_total = Convert.ToDecimal(lector["det_ord_total"]);
                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oDetalleOrden;
            }

            return oDetalleOrden;

        }



        //while (lector.Read())


        //{
        //    oDetalleOrden.id_detalle_orden = Convert.ToInt32(lector["id_detalle_orden"]);
        //    oDetalleOrden.det_id_orden = Convert.ToInt32(lector["det_id_orden"]);
        //    oDetalleOrden.det_id_producto = Convert.ToInt32(lector["det_id_producto"]);
        //    oDetalleOrden.det_ord_precio = Convert.ToDecimal(lector["det_ord_precio"]);
        //    oDetalleOrden.det_ord_cantidad = Convert.ToDecimal(lector["det_ord_cantidad"]);
        //}



        public bool GuardarDetalleOrden(Detalle_orden oDetalleOrden){
            bool respuesta;

            try
            {
                //esto precio cant
                oDetalleOrden.det_ord_total = oDetalleOrden.det_ord_precio * oDetalleOrden.det_ord_cantidad;
                



                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarDetalleOrden", conexionTemp);

                    cmd.Parameters.AddWithValue("det_id_orden", oDetalleOrden.det_id_orden);
                    cmd.Parameters.AddWithValue("det_id_producto", oDetalleOrden.det_id_producto);
                    cmd.Parameters.AddWithValue("det_ord_precio", oDetalleOrden.det_ord_precio);
                    cmd.Parameters.AddWithValue("det_ord_cantidad", oDetalleOrden.det_ord_cantidad);
                    //cmd.Parameters.AddWithValue("det_ord_cantidad_descontar", oDetalleOrden.det_ord_cantidad); // <-- Agregar parámetro adicional




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


        //DETALLE CLIENTE

        public bool GuardarDetalleOrdenCliente(Detalle_orden oDetalleOrden)
        {
            bool respuesta;

            try
            {
                //esto precio cant
                oDetalleOrden.det_ord_total = oDetalleOrden.det_ord_precio * oDetalleOrden.det_ord_cantidad;




                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarDetalleOrdenCliente", conexionTemp);

                    cmd.Parameters.AddWithValue("det_id_orden", oDetalleOrden.det_id_orden);
                    cmd.Parameters.AddWithValue("det_id_producto", oDetalleOrden.det_id_producto);
                    cmd.Parameters.AddWithValue("det_ord_precio", oDetalleOrden.det_ord_precio);
                    cmd.Parameters.AddWithValue("det_ord_cantidad", oDetalleOrden.det_ord_cantidad);
                    //cmd.Parameters.AddWithValue("det_ord_cantidad_descontar", oDetalleOrden.det_ord_cantidad); // <-- Agregar parámetro adicional




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




        public bool EditarDetalleOrden(Detalle_orden oDetalleOrden)
        {
            bool respuesta;

            try
            {

                //esto precio cant
                oDetalleOrden.det_ord_total = oDetalleOrden.det_ord_precio * oDetalleOrden.det_ord_cantidad;
            

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarDetalleOrden", conexionTemp);

                    cmd.Parameters.AddWithValue("@id_detalle_orden", oDetalleOrden.id_detalle_orden);
                    cmd.Parameters.AddWithValue("@det_id_orden", oDetalleOrden.det_id_orden);
                    cmd.Parameters.AddWithValue("@det_id_producto", oDetalleOrden.det_id_producto);
                    cmd.Parameters.AddWithValue("@det_ord_precio", oDetalleOrden.det_ord_precio);
                    cmd.Parameters.AddWithValue("@det_ord_cantidad", oDetalleOrden.det_ord_cantidad);
                    //cmd.Parameters.AddWithValue("det_ord_total", oDetalleOrden.det_ord_total);

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



        public bool EliminarDetalleOrden(int id_detalle_orden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarDetalleOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_detalle_orden", id_detalle_orden);
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
