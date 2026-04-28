using Laboratorio05.BL;
using Laboratorio05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio05.UI.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public IActionResult Index()
        {
            var productos = _productoService.ObtenerTodos();
            return View(productos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productoService.Agregar(producto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al crear el producto: {ex.Message}");
                }
            }
            return View(producto);
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var producto = _productoService.ObtenerPorId(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return View(producto);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productoService.Actualizar(producto);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException)
                {
                    return NotFound();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al actualizar el producto: {ex.Message}");
                }
            }
            return View(producto);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var producto = _productoService.ObtenerPorId(id);
                if (producto == null)
                {
                    return NotFound();
                }
                return View(producto);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _productoService.Eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }
    }
}
