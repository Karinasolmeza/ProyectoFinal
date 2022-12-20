using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;


namespace ProyectoFinal.Datos

{
	public class CategoriaDatos
	{


        public List<Categoria> ListarCategoria()
        {
            var oLista = new List<Categoria>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarCategoria", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Categoria()
                        {
                            id_categoria = Convert.ToInt32(lector["id_categoria"]),
                           categ_detalle = Convert.ToString(lector["categ_detalle"])
                        


                        });

                    }
                }

            }

            return oLista;
        }


        public Categoria ObtenerCategoria(int id_categoria)
        {
            var oCategoria = new Categoria();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerCategoria", conexionTemp);

                    cmd.Parameters.AddWithValue("id_Categ", id_categoria);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {

                            oCategoria.id_categoria = Convert.ToInt32(lector["id_categoria"]);
                            oCategoria.categ_detalle = Convert.ToString(lector["categ_detalle"]);
                         

                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oCategoria;
            }

            return oCategoria;


        }




        public bool GuardarCategoria(Categoria oCategoria)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarCategoria", conexionTemp);

                    cmd.Parameters.AddWithValue("categ_detalle", oCategoria.categ_detalle);
                  

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



        public bool EditarCategoria(Categoria oCategoria)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarCategoria", conexionTemp);




                    cmd.Parameters.AddWithValue("id_categoria", oCategoria.id_categoria);
                    cmd.Parameters.AddWithValue("categ_detalle", oCategoria.categ_detalle);
                 
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

        public bool EliminarCategoria(int id_categoria)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarCategoria", conexionTemp);
                    cmd.Parameters.AddWithValue("id_categoria", id_categoria);
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
