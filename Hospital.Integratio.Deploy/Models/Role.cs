using System;
using System.Collections.Generic;

namespace Hospital.Integratio.Deploy.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Perfile> Perfiles { get; set; } = new List<Perfile>();
}
