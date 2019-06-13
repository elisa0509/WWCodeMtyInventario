using Microsoft.AspNetCore.Mvc;

namespace Inventario.Web.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}