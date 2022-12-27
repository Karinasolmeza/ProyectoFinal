using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class PromocionesController : Controller
    {
        PromocionesDatos promocionesDatos = new PromocionesDatos();
        [Authorize(Roles = "administrador, empleado, supervisor")]


        public IActionResult Index()
        {

            var oLista = promocionesDatos.ListarPromociones();

            return View(oLista);
        }

        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult GuardarPromociones()
        {
            return View();
        }

        [Authorize(Roles = "administrador, empleado, supervisor")]
        [HttpPost]
        public IActionResult GuardarPromociones(Promociones oPromociones)
        {
            var respuesta = promocionesDatos.GuardarPromociones(oPromociones);

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
        //Método para la vista
        public IActionResult EditarPromociones(int id)
        {

            var oPromociones = promocionesDatos.ObtenerPromociones(id);

            return View(oPromociones);
        }




        [Authorize(Roles = "administrador, empleado, supervisor")]
        [HttpPost]
        public IActionResult EditarPromociones(Promociones oPromociones)
        {
            var respuesta = promocionesDatos.EditarPromociones(oPromociones);

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
        public IActionResult EliminarPromociones(int id)
        {
            var oPromociones = promocionesDatos.ObtenerPromociones(id);

            return View(oPromociones);
        }

        [Authorize(Roles = "administrador, empleado, supervisor")]
        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarPromociones(Promociones oPromociones)
        {
            var respuesta = promocionesDatos.EliminarPromociones(oPromociones.id_promo);

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
