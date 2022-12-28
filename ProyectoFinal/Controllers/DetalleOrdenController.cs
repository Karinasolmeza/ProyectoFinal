using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
	public class DetalleOrdenController : Controller
	{
        DetalleOrdenDatos detalleordenDatos = new DetalleOrdenDatos();


        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult Index()
        {

            var oLista = detalleordenDatos.ListarDetalleOrden();

            return View(oLista);
        }


        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult GuardarDetalleOrden()
        {
            return View();
        }

        [Authorize(Roles = "administrador, empleado, supervisor")]
        [HttpPost]
        public IActionResult GuardarDetalleOrden(Detalle_orden oDetalleOrden)
        {
            var respuesta = detalleordenDatos.GuardarDetalleOrden(oDetalleOrden);

            if (respuesta)
            {
                TempData["Mensaje"] = "El Detalle ha sido guardado exitosamente";
                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }

        
        //Vista Detalle Cliente
        public IActionResult GuardarDetalleOrdenCliente()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GuardarDetalleOrdenCliente(Detalle_orden oDetalleOrden)
        {
            var respuesta = detalleordenDatos.GuardarDetalleOrdenCliente(oDetalleOrden);

            if (respuesta)
            {
                TempData["Mensaje"] = "El Detalle ha sido guardado exitosamente";
                return RedirectToAction("Index", "Home");

            }

            else
            {
                return View();
            }
        }


        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult EditarDetalleOrden(int id)
           {
            var oDetalleOrden = detalleordenDatos.ObtenerDetalleOrden(id);
            return View(oDetalleOrden);
        }


        [Authorize(Roles = "administrador, empleado, supervisor")]
        [HttpPost]
        public IActionResult EditarDetalleOrden(Detalle_orden oDetalleOrden)
        {
            var respuesta = detalleordenDatos.EditarDetalleOrden(oDetalleOrden);

            if (respuesta)
            {
                TempData["MensajeInfo"] = "El Detalle ha sido actualizado";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }




        //Método para vista eliminar 
        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult EliminarDetalleOrden(int id)
        {
            var oDetalleOrden = detalleordenDatos.ObtenerDetalleOrden(id);

            return View(oDetalleOrden);
        }


        [Authorize(Roles = "administrador, empleado, supervisor")]
        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarDetalleOrden(Detalle_orden oDetalleOrden)
        {
            var respuesta = detalleordenDatos.EliminarDetalleOrden(oDetalleOrden.id_detalle_orden);

            if (respuesta)
            {
                TempData["MensajeError"] = "El Detalle ha sido eliminado";
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }
    }
}
