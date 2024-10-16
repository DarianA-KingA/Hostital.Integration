using Hospital.Core.Context;
using Hospital.Core.Models.SaveViewModel;
using Hospital.Core.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Core.Controllers
{
    [Authorize]
    public class TiposServiciosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TiposServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View(new SaveTipoServicioViewModel());
        }
        [HttpPost]
        public IActionResult Create(SaveTipoServicioViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _context.TipoServicio.Add(new Models.TipoServicio() 
                {
                    Descripcion = model.Descripcion,
                    Estado = true
                });
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var tipoServ = _context.TipoServicio.FirstOrDefault(a => a.Id == id);
            return View(new SaveTipoServicioViewModel() {Descripcion = tipoServ.Descripcion,Id= tipoServ.Id,Estado = tipoServ.Estado });
        }
        [HttpPost]
        public IActionResult Edit(SaveTipoServicioViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.TipoServicio.Update(new Models.TipoServicio()
                {
                    Id = model.Id,
                    Descripcion = model.Descripcion,
                    Estado = model.Estado
                });
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> ActivateDisactivate(int id)
        {
            var tipoServ = _context.TipoServicio.AsNoTracking().FirstOrDefault(a => a.Id == id);
            tipoServ.Estado = !tipoServ.Estado;
             _context.TipoServicio.Update(tipoServ);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var tipoServ = _context.TipoServicio.FirstOrDefault(a => a.Id == id);
            return View(new SaveTipoServicioViewModel() { Descripcion = tipoServ.Descripcion, Id = tipoServ.Id, Estado = tipoServ.Estado });
        }
        public JsonResult GetAll()
        {
            var listTipoServ = new List<TipoServicioViewModel>();

            foreach (var area in _context.TipoServicio)
            {
                listTipoServ.Add(new TipoServicioViewModel 
                {
                    Id = area.Id,
                    Descripcion= area.Descripcion,
                    Estado= area.Estado,
                });
            }
            return Json( new { data= listTipoServ });
        }

    }
}
