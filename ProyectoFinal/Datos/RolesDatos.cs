﻿using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Datos
{
    public class RolesDatos
    {

        public List<Roles> ListarRol()
        {
            var oLista = new List<Roles>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();


                //Aca instancio un objeto para las query y la relaciono con el sp


                SqlCommand cmd = new SqlCommand("ListarRol", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Roles()
                        {
                            id_rol = Convert.ToInt32(lector["id_rol"]),
                            rol_detalle = Convert.ToString(lector["rol_detalle"]),
                           

                        });

                    }
                }

            }

            return oLista;
        }


        public Roles ObtenerRol(int id_rol)
        {
            var oRol = new Roles();

            try
            {

                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerRol", conexionTemp);

                    cmd.Parameters.AddWithValue("id_rol", id_rol);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oRol.id_rol = Convert.ToInt32(lector["id_rol"]);
                            oRol.rol_detalle = Convert.ToString(lector["rol_detalle"]);
                           

                        }


                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oRol;
            }

            return oRol;


        }




        public bool GuardarRol(Roles oRol)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarRol", conexionTemp);

                    cmd.Parameters.AddWithValue("rol_detalle", oRol.rol_detalle);
                 

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



        public bool EditarRol(Roles oRol)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarRol", conexionTemp);


                    cmd.Parameters.AddWithValue("id_rol", oRol.id_rol);
                    cmd.Parameters.AddWithValue("rol_detalle", oRol.rol_detalle);
                  
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

        public bool EliminarRol(int id_rol)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarRol", conexionTemp);
                    cmd.Parameters.AddWithValue("id_rol", id_rol);
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
