using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class OrdenController : Controller
    {
        OrdenDatos ordenDatos = new OrdenDatos();


        [Authorize(Roles = "administrador, empleado")]
        public IActionResult Index()
        {

            var oLista = ordenDatos.ListarOrden();

            return View(oLista);
        }


        [Authorize(Roles = "administrador, empleado")]
        public IActionResult GuardarOrden()
        {
            return View();
        }

        [Authorize(Roles = "administrador, empleado")]
        [HttpPost]
        public IActionResult GuardarOrden(Orden oOrden)
        {
            var respuesta = ordenDatos.GuardarOrden(oOrden);

            if (respuesta)
            {
                TempData["Mensaje"] = "Orden ha sido generada exitosamente";
                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }

    
        //Vista Orden Cliente
        public IActionResult GuardarOrdenCliente()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult GuardarOrdenCliente(Orden oOrden)
        {
            var respuesta = ordenDatos.GuardarOrdenCliente(oOrden);

            if (respuesta)
            {
                TempData["Mensaje"] = "Orden ha sido guardado exitosamente, Por favor complete su detalle ";
                return RedirectToAction("GuardarDetalleOrdenCliente", "DetalleOrden");

            }

            else
            {
                return View();
            }
        }







        //[HttpPost]
        //public IActionResult NuevaOrden(Orden orden)
        //{
        //    // Validar la orden
        //    if (!ModelState.IsValid)
        //    {
        //        // Si la orden es inválida, volver a mostrar la vista
        //        return View(orden);
        //    }

        //    // Insertar la orden en la base de datos
        //    int id_orden = GuardarOrden(orden);

        //    // Crear una instancia del controlador de DetalleOrden
        //    DetalleOrdenController detalleOrdenController = new DetalleOrdenController();

        //    // Insertar los detalles de la orden en la base de datos
        //    foreach (var detalle in orden.Detalles)
        //    {
        //        detalle.det_id_orden = id_orden;
        //        detalleOrdenController.GuardarDetalleOrden(detalle);
        //    }

        //    // Redirigir a la página de confirmación
        //    return RedirectToAction("Confirmacion");
        //}





        [Authorize(Roles = "administrador, empleado")]
        //Método para la vista
        public IActionResult EditarOrden(int id)
        {

            var oOrden = ordenDatos.ObtenerOrden(id);

            return View(oOrden);
        }




        [Authorize(Roles = "administrador, empleado")]
        [HttpPost]
        public IActionResult EditarOrden(Orden oOrden)
        {
            var respuesta = ordenDatos.EditarOrden(oOrden);

            if (respuesta)
            {
                TempData["MensajeInfo"] = "Orden actualizada exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        //Método para vista eliminar 
        [Authorize(Roles = "administrador, empleado")]
        public IActionResult EliminarOrden(int id)
        {
            var oOrden = ordenDatos.ObtenerOrden(id);

            return View(oOrden);
        }


        [Authorize(Roles = "administrador, empleado")]
        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarOrden(Orden oOrden)
        {
            var respuesta = ordenDatos.EliminarOrden(oOrden.id_orden);

            if (respuesta)
            {
                TempData["MensajeError"] = "Orden eliminada";
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }
    }
}
