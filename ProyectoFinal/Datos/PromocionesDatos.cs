using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class PromocionesDatos
    {

        public List<Promociones> ListarPromociones()
        {
            var oLista = new List<Promociones>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarPromociones", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Promociones()
                        {
                            id_promo = Convert.ToInt32(lector["id_promo"]),
                            promo_nombre = Convert.ToString(lector["promo_nombre"]),
                            promo_descuento = Convert.ToDecimal(lector["promo_descuento"])



                        });

                    }
                }

            }

            return oLista;
        }


        public Promociones ObtenerPromociones(int id_promo)
        {
            var oPromociones = new Promociones();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerPromociones", conexionTemp);

                    cmd.Parameters.AddWithValue("id_promo", id_promo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {

                            oPromociones.id_promo = Convert.ToInt32(lector["id_promo"]);
                            oPromociones.promo_nombre = Convert.ToString(lector["promo_nombre"]);
                            oPromociones.promo_descuento = Convert.ToDecimal(lector["promo_descuento"]);


                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oPromociones;
            }

            return oPromociones;


        }




        public bool GuardarPromociones(Promociones oPromociones)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarPromociones", conexionTemp);

                    cmd.Parameters.AddWithValue("promo_nombre", oPromociones.promo_nombre);
                    cmd.Parameters.AddWithValue("promo_descuento",oPromociones.promo_descuento);


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



        public bool EditarPromociones(Promociones oPromociones)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarPromociones", conexionTemp);




                    cmd.Parameters.AddWithValue("id_promo", oPromociones.id_promo);
                    cmd.Parameters.AddWithValue("promo_nombre", oPromociones.promo_nombre);
                    cmd.Parameters.AddWithValue("promo_descuento", oPromociones.promo_descuento);   

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

        public bool EliminarPromociones(int id_promo)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarPromociones", conexionTemp);
                    cmd.Parameters.AddWithValue("id_promo", id_promo);
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
