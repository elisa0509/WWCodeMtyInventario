using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Negocio.POCO;
using Inventario.Negocio.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Web.Controllers
{
    public class CategoriaController : Controller
    {
        ICategoriaRepositorio _repositorio;

        public CategoriaController(ICategoriaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<ActionResult> Index()
        {
            var lista = await _repositorio.Todos();
            return View(lista.OrderBy(x => x.Nombre).ToList());
        }
         
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(Categoria categoria)
        {
            ViewData["MensajeError"] = "";
            if(ModelState.IsValid)
            {  
                var existeCategoria = await _repositorio.PorNombre(categoria.Nombre);
                if (existeCategoria == null)
                {
                    await _repositorio.Agregar(categoria);
                    return RedirectToAction("Index");
                } else
                {
                    ViewData["MensajeError"] = "Ya existe una categoria con ese nombre.";
                }
            }
            return View(categoria);

        }

       
        public async Task<ActionResult> Editar([FromRoute]int id)
        {
            var categoria = await _repositorio.PorId(id);
                
            return View(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Categoria categoria)
        {
            ViewData["MensajeError"] = "";
            if (ModelState.IsValid)
            {
                var existeCategoria = await _repositorio.PorNombre(categoria.Nombre);
                if (existeCategoria == null  || existeCategoria.Id == categoria.Id)
                {
                    await _repositorio.Editar(categoria);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["MensajeError"] = "Ya existe una categoria con ese nombre.";
                }
            }
            return View(categoria);
        }


    }
}