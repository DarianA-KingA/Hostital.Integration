using System;
using System.Collections.Generic;

namespace Hospital.Integratio.Deploy.Models;

public partial class Cita
{
    public int Id { get; set; }

    public int IdPaciente { get; set; }

    public int IdServicio { get; set; }

    public int IdTransaccion { get; set; }

    public DateTime FechaAgendada { get; set; }

    public bool Estado { get; set; }

    public virtual Usuario IdPacienteNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
