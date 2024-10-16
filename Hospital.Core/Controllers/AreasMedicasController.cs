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
    public class AreasMedicasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AreasMedicasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View(new SaveAreaMedicaViewModel());
        }
        [HttpPost]
        public IActionResult Create(SaveAreaMedicaViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _context.AreasMedicas.Add(new Models.AreasMedicas() 
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
            var area = _context.AreasMedicas.FirstOrDefault(a => a.Id == id);
            return View(new SaveAreaMedicaViewModel() {Descripcion = area.Descripcion,Id= area.Id,Estado = area.Estado });
        }
        [HttpPost]
        public IActionResult Edit(SaveAreaMedicaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.AreasMedicas.Update(new Models.AreasMedicas()
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
            var area = _context.AreasMedicas.AsNoTracking().FirstOrDefault(a => a.Id == id);
            area.Estado = !area.Estado;
             _context.AreasMedicas.Update(area);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var area = _context.AreasMedicas.FirstOrDefault(a => a.Id == id);
            return View(new SaveAreaMedicaViewModel() { Descripcion = area.Descripcion, Id = area.Id, Estado = area.Estado });
        }
        public JsonResult GetAll()
        {
            var listAreas = new List<AreaMedicaViewModel>();

            foreach (var area in _context.AreasMedicas)
            {
                listAreas.Add(new AreaMedicaViewModel 
                {
                    Id = area.Id,
                    Descripcion= area.Descripcion,
                    Estado= area.Estado,
                });
            }
            return Json( new { data= listAreas });
        }

    }
}
