using System;
using System.Collections.Generic;

namespace Hospital.Integratio.Deploy.Models;

public partial class TipoServicio
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
