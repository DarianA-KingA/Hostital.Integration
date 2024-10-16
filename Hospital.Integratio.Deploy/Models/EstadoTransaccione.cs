using System;
using System.Collections.Generic;

namespace Hospital.Integratio.Deploy.Models;

public partial class EstadoTransaccione
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
