using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;
using System.Data;

namespace ProyectoFinal.Controllers
{
	public class CategoriaController : Controller
    {

        CategoriaDatos categoriaDatos = new CategoriaDatos();

        [Authorize(Roles = "administrador,empleado")]


        public IActionResult Index()
        {

            var oLista = categoriaDatos.ListarCategoria();

            return View(oLista);
        }

        [Authorize(Roles = "administrador,empleado")]
        public IActionResult GuardarCategoria()
        {
            return View();
        }

        [Authorize(Roles = "administrador,empleado")]
        [HttpPost]
        public IActionResult GuardarCategoria(Categoria oCategoria)
        {
            var respuesta = categoriaDatos.GuardarCategoria(oCategoria);

            if (respuesta)
            {
                TempData["Mensaje"] = "Categoria ha sido creada exitosamente";
                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }

        [Authorize(Roles = "administrador,empleado")]
        //Método para la vista
        public IActionResult EditarCategoria(int id)
        {

            var oCategoria = categoriaDatos.ObtenerCategoria(id);

            return View(oCategoria);
        }




        [Authorize(Roles = "administrador,empleado")]
        [HttpPost]
        public IActionResult EditarCategoria(Categoria  oCategoria)
        {
            var respuesta = categoriaDatos.EditarCategoria(oCategoria);

            if (respuesta)
            {
                TempData["MensajeInfo"] = "Categoria ha sido actualizada";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        //Método para vista eliminar 
        [Authorize(Roles = "administrador,empleado")]
        public IActionResult EliminarCategoria(int id)
        {
            var oCategoria = categoriaDatos.ObtenerCategoria(id);

            return View(oCategoria);
        }


        [Authorize(Roles = "administrador,empleado")]
        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarCategoria(Categoria oCategoria)
        {
            var respuesta = categoriaDatos.EliminarCategoria(oCategoria.id_categoria);

            if (respuesta)
            {
                TempData["MensajeError"] = "Categoria ha sido eliminada";
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

    }
}
