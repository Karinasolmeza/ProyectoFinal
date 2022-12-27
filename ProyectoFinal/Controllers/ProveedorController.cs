using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class ProveedorController : Controller
    {
       
            ProveedorDatos proveedorDatos = new ProveedorDatos();



        [Authorize(Roles = "administrador, supervisor, empleado")]
        public IActionResult Index()
            {

                var oLista = proveedorDatos.ListarProveedor();

                return View(oLista);
            }


        [Authorize(Roles = "administrador, supervisor, empleado")]
        public IActionResult GuardarProveedor()
            {
                return View();
            }


        [Authorize(Roles = "administrador, supervisor, empleado")]
        [HttpPost]
            public IActionResult GuardarProveedor(Proveedor oProveedor)
            {
                var respuesta = proveedorDatos.GuardarProveedor(oProveedor);

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
        public IActionResult EditarProveedor(int id)
            {

                var oProveedor = proveedorDatos.ObtenerProveedor(id);

                return View(oProveedor);
            }





        [Authorize(Roles = "administrador, supervisor, empleado")]
        [HttpPost]
            public IActionResult EditarProveedor(Proveedor oProveedor)
            {
                var respuesta = proveedorDatos.EditarProveedor(oProveedor);

                if (respuesta)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }


        //Método para vista eliminar 

        [Authorize(Roles = "administrador, supervisor, empleado")]
        public IActionResult EliminarProveedor(int id)
            {
                var oProveedor = proveedorDatos.ObtenerProveedor(id);

                return View(oProveedor);
            }



        [Authorize(Roles = "administrador, supervisor, empleado")]
        //Método para logica de eliminar 
        [HttpPost]
            public IActionResult EliminarProveedor(Proveedor oProveedor)
            {
                var respuesta = proveedorDatos.EliminarProveedor(oProveedor.id_proveedor);

                if (respuesta)
                {

                    return RedirectToAction("Index");
                }

                else
                {
                    return View();
                }
            }

        }
    }
