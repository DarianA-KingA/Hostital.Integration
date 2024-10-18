using Flurl.Http;
using Hospital.Integration.Context;
using Hospital.Integration.DTO.SaveViewModel;
using Newtonsoft.Json;
using System.Text;

namespace Hospital.Integration.Helpers
{
    public class Core
    {
        private readonly ApplicationContext _context;
        private const string token = "Integration";
        private const string urlLocal = "https://localhost:44330/Acces";
        public Core( ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<bool> CoreOnline()
        {
            try
            {
                var client = new HttpClient();

                // El token que enviarás al endpoint
                var token = "Integration";

                // Serializar el token a JSON
                var json = JsonConvert.SerializeObject(token);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST al endpoint
                var response = await client.GetAsync($"{urlLocal}/GetServicios");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex) { return false; }
            
        }
        public async Task Transfer()
        {
            string baseUrlUser = $"{urlLocal}/CreateUser";
            var usarios =  _context.Usuarios.Where(u => u.Pendiente);
            foreach (var usario in usarios)
            {
                var model = new SaveUserViewModel() 
                {
                    UserName = usario.UserName,
                    Email = usario.Email,
                    Name =  usario.Name,
                    LastName = usario.LastName,
                    PhoneNumber = usario.PhoneNumber,
                    Address = usario.Address,
                    Birthday = usario.Birthday,
                    Cedula = usario.Cedula,
                    Password = usario.Password,
                    RoleName = usario.RoleName,
                    Token = SD.Token_Integration
                };
                try
                {
                    var result = await baseUrlUser.PostJsonAsync(model);
                    if (result.ResponseMessage.IsSuccessStatusCode)
                    {
                        usario.Pendiente = false;
                    }
                }
                catch (Exception ex)
                {
                    
                }
               
            }
        }
    }
}
