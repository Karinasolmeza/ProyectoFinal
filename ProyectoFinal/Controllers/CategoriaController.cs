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

        public IActionResult GuardarCategoria()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GuardarCategoria(Categoria oCategoria)
        {
            var respuesta = categoriaDatos.GuardarCategoria(oCategoria);

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
        public IActionResult EditarCategoria(int id)
        {

            var oCategoria = categoriaDatos.ObtenerCategoria(id);

            return View(oCategoria);
        }





        [HttpPost]
        public IActionResult EditarCategoria(Categoria  oCategoria)
        {
            var respuesta = categoriaDatos.EditarCategoria(oCategoria);

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

        public IActionResult EliminarCategoria(int id)
        {
            var oCategoria = categoriaDatos.ObtenerCategoria(id);

            return View(oCategoria);
        }

        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarCategoria(Categoria oCategoria)
        {
            var respuesta = categoriaDatos.EliminarCategoria(oCategoria.id_categoria);

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
