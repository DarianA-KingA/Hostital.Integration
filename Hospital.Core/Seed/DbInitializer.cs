using Hospital.Core.Context;
using Hospital.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Core.Seed
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public DbInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }
        public void Seed()
        {
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();

            if (!_roleManager.RoleExistsAsync(SD.Role_Cajero).GetAwaiter().GetResult())
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Cajero)).GetAwaiter().GetResult();

            if (!_roleManager.RoleExistsAsync(SD.Role_Usuairo).GetAwaiter().GetResult())
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Usuairo)).GetAwaiter().GetResult();

            var user = _userManager.FindByEmailAsync("admin@dotnet.com").GetAwaiter().GetResult();
            if (user==null)
            {
                var x = _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@dotnet.com",
                    Email = "admin@dotnet.com",
                    Name = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Address = "Some address",
                    Birthday = DateTime.Now,
                    Cedula ="40143245345",
                    FechaCreacion = DateTime.Now
                }, "Admin123*").GetAwaiter().GetResult();
                var result = x.Succeeded;
                var createdUser = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@dotnet.com");
                _userManager.AddToRoleAsync(createdUser, SD.Role_Admin).GetAwaiter().GetResult();
            }


        }
    }
}
