using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Core.Controllers
{
    [Authorize]
    public class TransaccionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
