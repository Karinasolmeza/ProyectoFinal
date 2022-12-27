using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.CodeMetrics;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Datos
{
    public class OrdenDatos
    {
        private Detalle_orden detalleAsociado;

        public List<Orden> ListarOrden()
        {
            var oLista = new List<Orden>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarOrden", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Orden()
                        {
                            id_orden = Convert.ToInt32(lector["id_orden"]),
                            //ord_fecha_de_generacion = Convert.ToDateTime(lector["ord_fecha_de_generacion"]),
                            ord_fecha_de_generacion = lector["ord_fecha_de_generacion"] is DBNull ?
                            null :
                            (DateTime?)Convert.ToDateTime(lector["ord_fecha_de_generacion"]),
                            ord_fecha_entrega = lector["ord_fecha_entrega"] is DBNull ?
                            null :
                            (DateTime?)Convert.ToDateTime(lector["ord_fecha_entrega"]),


                            //ord_fecha_entrega = Convert.ToDateTime(lector["ord_fecha_entrega"]),

                            ord_id_cliente = Convert.ToInt32(lector["ord_id_cliente"]),
                            ord_id_empleado = Convert.ToInt32(lector["ord_id_empleado"]),
                            //string ord_fecha_generacion = Convert.ToDateTime(lector["ord_fecha_generacion"]).ToString("dd/MM/yyyy");
                            //detalleAsociado = new DetalleOrden()
                            //{
                            //    id_detalle_orden = Convert.ToInt32(lector["id_detalle_orden"]),
                            //    det_id_orden = Convert.ToInt32(lector["det_id_orden"]),
                            //    det_id_producto = Convert.ToInt32(lector["ord_id_producto"]),
                            //    det_ord_precio = Convert.ToDecimal(lector["det_ord_precio"]),
                            //    det_ord_cantidad = Convert.ToDecimal(lector["det_ord_cantidad"])


                            //}






                        });

                    }
                }

            }

            return oLista;
        }



        
        public Orden ObtenerOrden(int id_orden)
        {
            var oOrden = new Orden();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerOrden", conexionTemp);

                    cmd.Parameters.AddWithValue("id_orden", id_orden);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oOrden.id_orden = Convert.ToInt32(lector["id_orden"]);
                            oOrden.ord_fecha_de_generacion = lector["ord_fecha_de_generacion"] is DBNull ?
                            null :
                            (DateTime?)Convert.ToDateTime(lector["ord_fecha_de_generacion"]);
                            oOrden.ord_fecha_entrega = lector["ord_fecha_entrega"] is DBNull ?
                            null :
                            (DateTime?)Convert.ToDateTime(lector["ord_fecha_entrega"]);


                    
                            oOrden.ord_id_cliente = Convert.ToInt32(lector["ord_id_cliente"]);

                            oOrden.ord_id_empleado = Convert.ToInt32(lector["ord_id_empleado"]);



                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oOrden;
            }

            return oOrden;


        }




        public bool GuardarOrden(Orden oOrden)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarOrden", conexionTemp);

                    cmd.Parameters.AddWithValue("ord_fecha_de_generacion", oOrden.ord_fecha_de_generacion);
                    cmd.Parameters.AddWithValue("ord_fecha_entrega", oOrden.ord_fecha_entrega);
                    
                    cmd.Parameters.AddWithValue("ord_id_cliente", oOrden.ord_id_cliente);
                    cmd.Parameters.AddWithValue("ord_id_empleado", oOrden.ord_id_empleado);
                  



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


        public bool GuardarOrdenCliente(Orden oOrden)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarOrdenCliente", conexionTemp);

                    cmd.Parameters.AddWithValue("ord_fecha_de_generacion", oOrden.ord_fecha_de_generacion);
                    cmd.Parameters.AddWithValue("ord_fecha_entrega", oOrden.ord_fecha_entrega);

                    cmd.Parameters.AddWithValue("ord_id_cliente", oOrden.ord_id_cliente);
                    cmd.Parameters.AddWithValue("ord_id_empleado", oOrden.ord_id_empleado);




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





        public bool EditarOrden(Orden oOrden)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarOrden", conexionTemp);


                    cmd.Parameters.AddWithValue("id_orden", oOrden.id_orden);
                    cmd.Parameters.AddWithValue("ord_fecha_de_generacion", oOrden.ord_fecha_de_generacion);
                    cmd.Parameters.AddWithValue("ord_fecha_entrega", oOrden.ord_fecha_entrega);
                    cmd.Parameters.AddWithValue("ord_id_cliente", oOrden.ord_id_cliente);
                    cmd.Parameters.AddWithValue("ord_id_empleado", oOrden.ord_id_empleado);
                 

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


        public bool EliminarOrden(int id_orden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_orden", id_orden);
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



//oOrden.detalleAsociado = new Detalle_orden();
//oOrden.detalleAsociado.det_ord_total = oOrden.detalleAsociado.det_ord_precio * oOrden.detalleAsociado.det_ord_cantidad;
//using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
//{
//    conexionTemp.Open();
//    SqlCommand cmd = new SqlCommand("GenerarOrden", conexionTemp);

//    cmd.Parameters.AddWithValue("@ord_fecha_de_generacion", oOrden.ord_fecha_de_generacion);
//    cmd.Parameters.AddWithValue("@ord_fecha_entrega", oOrden.ord_fecha_entrega);

//    cmd.Parameters.AddWithValue("@ord_id_cliente", oOrden.ord_id_cliente);
//    cmd.Parameters.AddWithValue("@ord_id_empleado", oOrden.ord_id_empleado);

//    cmd.Parameters.AddWithValue("@det_id_producto", oOrden.detalleAsociado.det_id_producto);
//    cmd.Parameters.AddWithValue("@det_ord_precio", oOrden.detalleAsociado.det_ord_precio);
//    cmd.Parameters.AddWithValue("@det_ord_cantidad", oOrden.detalleAsociado.det_ord_cantidad);

//    cmd.CommandType = CommandType.StoredProcedure;

//    cmd.ExecuteNonQuery();
//}