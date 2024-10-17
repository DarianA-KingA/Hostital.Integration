using Hospital.Core;
using Hospital.Core.DTO;
using Hospital.Core.Models.SaveViewModel;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Hospital.Client
{
    internal class Program
    { 
        const string baseUrl = "https://localhost:44330/acces"; // Cambia por tu URL de la API
        const string token = "Integration"; // Cambia por tu URL de la API
        static async Task Main(string[] args)
        {
            //await GetUserWithAppoinmnetAsync();
            var newUser = new SaveUserViewModelDTO
            {
                UserName = "nuevo@usuario.com",
                Email = "nuevo@usuario.com",
                Name = "Nombre",
                LastName = "Apellido",
                PhoneNumber = "1234567890",
                Address = "Dirección",
                Birthday = DateTime.Now.AddYears(-25),
                Cedula = "12345678901",
                Password = "Admin123*",
                RoleName = SD.Role_Usuairo,
                Token = token,
            };
            await CreateUserAsync(newUser);
        }
        public static async Task GetUserWithAppoinmnetAsync()
        {
            var endpoint = "/GetUserWithAppoinmnet"; // Ajusta el endpoint si es necesario

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Configura el token como body
                var content = new StringContent($"\"{token}\"", Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}{endpoint}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);  // Puedes procesar la respuesta aquí
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }
        public static async Task CreateUserAsync(SaveUserViewModelDTO model)
        {
            var endpoint = "/CreateUser"; // Ajusta el endpoint si es necesario

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Configura el token y el modelo de usuario como body
                var jsonData = JsonSerializer.Serialize(new { model});
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}{endpoint}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(result);  // Puedes procesar la respuesta aquí
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
        }

    }
}
