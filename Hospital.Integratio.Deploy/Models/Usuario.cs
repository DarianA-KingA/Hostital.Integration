using System;
using System.Collections.Generic;

namespace Hospital.Integratio.Deploy.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Cedula { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime UltimaModificacion { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Perfile> Perfiles { get; set; } = new List<Perfile>();

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
