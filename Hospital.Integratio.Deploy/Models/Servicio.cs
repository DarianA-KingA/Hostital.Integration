using System;
using System.Collections.Generic;

namespace Hospital.Integratio.Deploy.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public int IdTipoServicio { get; set; }

    public int IdAreaMedica { get; set; }

    public double Costo { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual AreasMedica IdAreaMedicaNavigation { get; set; } = null!;

    public virtual TipoServicio IdTipoServicioNavigation { get; set; } = null!;

    public virtual Transaccione? Transaccione { get; set; }
}
