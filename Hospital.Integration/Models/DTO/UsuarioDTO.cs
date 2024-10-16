using System.ComponentModel.DataAnnotations;

namespace Hospital.Integration.Models.DTO
{
    public class UsuarioDTO:BaseEntity
    {

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaNacimiento { get; set; } 


        public string Cedula { get; set; }


        public string Direccion { get; set; }

        public DateTime FechaCreacion { get; set; } 
        public DateTime UltimaModificacion { get; set; }


    }

}
