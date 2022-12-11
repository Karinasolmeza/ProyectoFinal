using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class ProveedorController : Controller
    {
       
            ProveedorDatos proveedorDatos = new ProveedorDatos();



            public IActionResult Index()
            {

                var oLista = proveedorDatos.ListarProveedor();

                return View(oLista);
            }

            public IActionResult GuardarProveedor()
            {
                return View();
            }


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


            //Método para la vista
            public IActionResult EditarProveedor(int id)
            {

                var oProveedor = proveedorDatos.ObtenerProveedor(id);

                return View(oProveedor);
            }





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

            public IActionResult EliminarProveedor(int id)
            {
                var oProveedor = proveedorDatos.ObtenerProveedor(id);

                return View(oProveedor);
            }

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
