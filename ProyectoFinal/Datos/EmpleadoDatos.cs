using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class EmpleadoDatos
    {


        public List<Empleado> ListarEmpleado()
        {
            var oLista = new List<Empleado>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarEmpleado", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Empleado()
                        {
                            id_empleado = Convert.ToInt32(lector["id_empleado"]),
                            emple_nombre = Convert.ToString(lector["emple_nombre"]),
                            emple_apellido= Convert.ToString(lector["emple_apellido"]),
                        
                        });

                    }
                }

            }

            return oLista;
        }


        public Empleado ObtenerEmpleado(int id_empleado)
        {
            var oEmpleado = new Empleado();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerEmpleado", conexionTemp);

                    cmd.Parameters.AddWithValue("id_emple", id_empleado);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oEmpleado.id_empleado = Convert.ToInt32(lector["id_empleado"]);
                            oEmpleado.emple_nombre = Convert.ToString(lector["emple_nombre"]);
                            oEmpleado.emple_apellido = Convert.ToString(lector["emple_apellido"]);
                         

                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oEmpleado;
            }

            return oEmpleado;


        }




        public bool GuardarEmpleado(Empleado oEmpleado)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarEmpleado", conexionTemp);

                    cmd.Parameters.AddWithValue("emple_nombre", oEmpleado.emple_nombre);
                    cmd.Parameters.AddWithValue("emple_apellido", oEmpleado.emple_apellido);
              

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



        public bool EditarEmpleado(Empleado oEmpleado)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarEmpleado", conexionTemp);


                    cmd.Parameters.AddWithValue("id_empleado", oEmpleado.id_empleado);
                    cmd.Parameters.AddWithValue("emple_nombre", oEmpleado.emple_nombre);
                    cmd.Parameters.AddWithValue("emple_apellido", oEmpleado.emple_apellido);
                

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

        public bool EliminarEmpleado(int id_empleado)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarEmpleado", conexionTemp);
                    cmd.Parameters.AddWithValue("id_empleado", id_empleado);
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
