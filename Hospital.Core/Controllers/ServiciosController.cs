using Hospital.Core.Context;
using Hospital.Core.Models.SaveViewModel;
using Hospital.Core.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Core.Controllers
{
    [Authorize]
    public class ServiciosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var areasMedicas = _context.AreasMedicas.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.areasMedicas = areasMedicas;

            var tipoServicio = _context.TipoServicio.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.tipoServicio = tipoServicio;
            return View(new SaveServicioViewModel());
        }
        [HttpPost]
        public IActionResult Create(SaveServicioViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _context.Servicios.Add(new Models.Servicios() 
                {
                    IdAreaMedica = model.IdAreaMedica,
                    IdTipoServicio = model.IdTipoServico,
                    Costo = model.Costo,
                    Estado = true
                });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var areasMedicas = _context.AreasMedicas.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.areasMedicas = areasMedicas;

            var tipoServicio = _context.TipoServicio.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.tipoServicio = tipoServicio;
            return View(model);
        }
        public IActionResult Edit(int id) 
        {
            var servicio = _context.Servicios.FirstOrDefault(s => s.Id == id);
            var areasMedicas = _context.AreasMedicas.Select(r => new SelectListItem
            {
                Selected = servicio.IdAreaMedica == r.Id,
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.areasMedicas = areasMedicas;

            var tipoServicio = _context.TipoServicio.Select(r => new SelectListItem
            {
                Selected = servicio.IdTipoServicio == r.Id,
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.tipoServicio = tipoServicio;

            return View(new SaveServicioViewModel() 
            {
                Id = id,
                Estado = servicio.Estado,
                Costo = servicio.Costo,
                IdAreaMedica= servicio.IdAreaMedica,
                IdTipoServico = servicio.IdTipoServicio});
        }
        [HttpPost]
        public IActionResult Edit(SaveServicioViewModel model)
        {
            var servicio = _context.Servicios.AsNoTracking().FirstOrDefault(s => s.Id == model.Id);

            if (ModelState.IsValid)
            {
                servicio.Costo = model.Costo;
                servicio.IdAreaMedica = model.IdAreaMedica;
                servicio.IdTipoServicio = model.IdTipoServico;
                _context.Servicios.Update(servicio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var areasMedicas = _context.AreasMedicas.Select(r => new SelectListItem
            {
                Selected = servicio.IdAreaMedica == r.Id,
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.areasMedicas = areasMedicas;

            var tipoServicio = _context.TipoServicio.Select(r => new SelectListItem
            {
                Selected = servicio.IdTipoServicio == r.Id,
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();
            ViewBag.tipoServicio = tipoServicio;
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var servicio = _context.Servicios.FirstOrDefault(s => s.Id == id);
            var areasMedicas = _context.AreasMedicas.Select(r => new SelectListItem
            {
                Selected = servicio.IdAreaMedica == r.Id,
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.areasMedicas = areasMedicas;

            var tipoServicio = _context.TipoServicio.Select(r => new SelectListItem
            {
                Selected = servicio.IdTipoServicio == r.Id,
                Value = r.Id.ToString(),
                Text = r.Descripcion
            }).ToList();

            ViewBag.tipoServicio = tipoServicio;

            return View(new SaveServicioViewModel()
            {
                Id = id,
                Estado = servicio.Estado,
                Costo = servicio.Costo,
                IdAreaMedica = servicio.IdAreaMedica,
                IdTipoServico = servicio.IdTipoServicio
            });
        }
        public async Task<IActionResult> ActivateDisactivate(int id)
        { 
            var servcio = _context.Servicios.AsNoTracking().FirstOrDefault(s=>s.Id == id);
            servcio.Estado = !servcio.Estado;
            _context.Servicios.Update(servcio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public JsonResult GetAll()
        {
            var listServicios = new List<ServicioViewModel>();
            foreach (var servicio in _context.Servicios.Include(e=>e.AreasMedicas).Include(e=>e.TipoServicio))
            {
                listServicios.Add(new ServicioViewModel
                {
                    Id = servicio.Id,
                    IdAreaMedica = servicio.IdAreaMedica,
                    IdTipoServico = servicio.IdTipoServicio,
                    Costo = servicio.Costo,
                    Estado = servicio.Estado,
                    DescricionTipoServcio = servicio.TipoServicio.Descripcion,
                    DescripcionAreaMedica = servicio.AreasMedicas.Descripcion
                });

            }
            return Json(new { data = listServicios });
        }
    }
}
