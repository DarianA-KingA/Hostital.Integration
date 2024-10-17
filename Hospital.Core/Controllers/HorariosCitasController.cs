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
    public class HorariosCitasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HorariosCitasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View(new SaveHorarioCitaViewModel());
        }
        [HttpPost]
        public IActionResult Create(SaveHorarioCitaViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _context.HorariosCitas.Add(new Models.HorariosCitas() 
                {
                    HoraInicio = model.HoraInicio,
                    HoraFin = model.HoraFin,
                    Estado = true
                });
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var area = _context.HorariosCitas.FirstOrDefault(a => a.Id == id);
            return View(new SaveHorarioCitaViewModel() {HoraInicio = area.HoraInicio, HoraFin= area.HoraFin,Id= area.Id,Estado = area.Estado });
        }
        [HttpPost]
        public IActionResult Edit(SaveHorarioCitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.HorariosCitas.Update(new Models.HorariosCitas()
                {
                    Id = model.Id,
                    HoraInicio = model.HoraInicio,
                    HoraFin = model.HoraFin,
                    Estado = true
                });
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> ActivateDisactivate(int id)
        {
            var area = _context.HorariosCitas.AsNoTracking().FirstOrDefault(a => a.Id == id);
            area.Estado = !area.Estado;
             _context.HorariosCitas.Update(area);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var area = _context.HorariosCitas.FirstOrDefault(a => a.Id == id);
            return View(new SaveHorarioCitaViewModel() { HoraInicio = area.HoraInicio, HoraFin = area.HoraFin, Id = area.Id, Estado = area.Estado });
        }
        public JsonResult GetAll()
        {
            var listHorarios = new List<HorarioCitaViewModel>();

            foreach (var horario in _context.HorariosCitas)
            {
                listHorarios.Add(new HorarioCitaViewModel 
                {
                    Id = horario.Id,
                    HoraInicio = horario.HoraInicio,
                    HoraFin = horario.HoraFin,
                    Estado = horario.Estado
                });
            }
            return Json( new { data= listHorarios });
        }

    }
}
