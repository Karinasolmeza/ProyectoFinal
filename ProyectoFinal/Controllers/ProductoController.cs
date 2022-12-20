using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;
using System.Data;

namespace ProyectoFinal.Controllers
{
    public class ProductoController : Controller
    {
        ProductoDatos productoDatos = new ProductoDatos();


        [Authorize(Roles = "administrador, empleado")]
        public IActionResult Index()
        {

            var oLista = productoDatos.ListarProducto();

            return View(oLista);
        }

        [Authorize(Roles = "cliente, administrador")]
        public IActionResult mostrarProducto()
        {

            var oLista = productoDatos.mostrarProducto();

            return View(oLista);
        }
        public IActionResult GuardarProducto()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GuardarProducto(Producto oProducto)
        {
            var respuesta = productoDatos.GuardarProducto(oProducto);

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
        public IActionResult EditarProducto(int id)
        {

            var oProducto = productoDatos.ObtenerProducto(id);

            return View(oProducto);
        }





        [HttpPost]
        public IActionResult EditarProducto(Producto oProducto)
        {
            var respuesta = productoDatos.EditarProducto(oProducto);

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

        public IActionResult EliminarProducto(int id)
        {
            var oProducto = productoDatos.ObtenerProducto(id);

            return View(oProducto);
        }

        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarProducto(Producto oProducto)
        {
            var respuesta = productoDatos.EliminarProducto(oProducto.id_producto);

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
