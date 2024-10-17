namespace Hospital.Integration.DTO.ViewModel
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Cedula { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public List<string> Rol { get; set; }
        public List<CitaViewModel> Citas { get; set; }
    }
}
