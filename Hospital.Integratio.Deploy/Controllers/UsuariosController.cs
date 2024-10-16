using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Integratio.Deploy.Context;
using Hospital.Integratio.Deploy.Models;

namespace Hospital.Integratio.Deploy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsuariosController()
        {
            _context = new ApplicationContext();
        }
        //[HttpGet("GetUsuario")]
        [HttpGet("GetUsuario")]
        public async Task<ICollection<Usuario>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }
        [HttpGet("GetString")]
        public string GetString()
        {
            return "Result";
        }

    }
}
