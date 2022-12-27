using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal.Controllers
{
    public class Proveedor_CategoriaController : Controller
    {
        Proveedor_CategoriaDatos proveedor_CategoriaDatos = new Proveedor_CategoriaDatos();


        [Authorize(Roles = "administrador, supervisor, empleado")]
        public IActionResult Index()
        {

            var oLista = proveedor_CategoriaDatos.ListarProveedorCategoria();

            return View(oLista);
        }


        [Authorize(Roles = "administrador, supervisor, empleado")]
        public IActionResult GuardarProveedorCategoria()
        {
            return View();
        }


        [Authorize(Roles = "administrador, supervisor, empleado")]
        [HttpPost]
        public IActionResult GuardarProveedorCategoria(Proveedor_Categoria oProveedor_Categoria)
        {
            var respuesta = proveedor_CategoriaDatos.GuardarProveedorCategoria(oProveedor_Categoria);

            if (respuesta)
            {

                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }


        [Authorize(Roles = "administrador, supervisor, empleado")]
        //Método para la vista
        public IActionResult EditarProveedorCategoria(int id)
        {

            var oProveedor_Categoria = proveedor_CategoriaDatos.ObtenerProveedorCategoria(id);

            return View(oProveedor_Categoria);
        }





        [Authorize(Roles = "administrador, supervisor, empleado")]
        [HttpPost]
        public IActionResult EditarProveedorCategoria(Proveedor_Categoria oProveedor_Categoria)
        {
            var respuesta = proveedor_CategoriaDatos.EditarProveedorCategoria(oProveedor_Categoria);

            if (respuesta)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        [Authorize(Roles = "administrador, supervisor, empleado")]
        //Método para vista eliminar

                public IActionResult EliminarProveedorCategoria(int id)
        {
            var oProveedor_Categoria = proveedor_CategoriaDatos.ObtenerProveedorCategoria(id);

            return View(oProveedor_Categoria);
        }

        //        //Método para logica de eliminar 
        //        [HttpPost]
        //        public IActionResult EliminarProveedorCategoria(Proveedor_Categoria oProveedor_Categoria)
        //        {
        //            var respuesta = proveedor_CategoriaDatos.EliminarProveedorCategoria(oProveedor_Categoria.id_proveedor);

        //            if (respuesta)
        //            {

        //                return RedirectToAction("Index");
        //            }

        //            else
        //            {
        //                return View();
        //            }
        //        }

        [Authorize(Roles = "administrador, supervisor, empleado")]
        [HttpPost]
        public ActionResult EliminarProveedorCategoria(int id_proveedor, int id_categoria)
        {
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarProveedorCategoria", conexionTemp);
                    cmd.Parameters.AddWithValue("id_proveedor", id_proveedor);
                    cmd.Parameters.AddWithValue("id_categoria", id_categoria);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                // Redirigir a la vista "ListadoProveedoresCategorias"
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View("Error");
            }
        }


    }
}




