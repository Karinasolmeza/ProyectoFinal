using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class Promocion_productoController : Controller
    {

        Promocion_productoDatos promocion_productoDatos = new Promocion_productoDatos();


        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult Index()
        {

            var oLista = promocion_productoDatos.ListarPromocionProducto();

            return View(oLista);
        }


        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult GuardarPromocionProducto()
        {
            return View();
        }

        [Authorize(Roles = "administrador, empleado, supervisor")]
        [HttpPost]
        public IActionResult GuardarPromocionProducto(Promocion_producto oPromocion_producto)
        {
            var respuesta = promocion_productoDatos.GuardarPromocionProducto(oPromocion_producto);

            if (respuesta)
            {

                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }



        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult EditarPromocionProducto(int id)
        {
            var oPromocion_producto = promocion_productoDatos.ObtenerPromocionProducto(id);
            return View(oPromocion_producto);
        }


        [Authorize(Roles = "administrador, empleado, supervisor")]
        [HttpPost]
        public IActionResult EditarPromocionProducto(Promocion_producto oPromocion_producto)
        {
            var respuesta = promocion_productoDatos.EditarPromocionProducto(oPromocion_producto);

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
        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult EliminarPromocionProducto(int id)
        {
            var oPromocion_producto = promocion_productoDatos.ObtenerPromocionProducto(id);

            return View(oPromocion_producto);
        }


        [Authorize(Roles = "administrador, empleado, supervisor")]
        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarPromocionProducto(Promocion_producto oPromocion_producto)
        {
            var respuesta = promocion_productoDatos.EliminarPromocionProducto(oPromocion_producto.promo_numero);

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
