using System;
using System.Collections.Generic;

namespace Hospital.Integratio.Deploy.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public int IdCajero { get; set; }

    public int IdPaciente { get; set; }

    public int IdServicio { get; set; }

    public int TipoTransaccion { get; set; }

    public int EstadoTransaccion { get; set; }

    public double Monto { get; set; }

    public DateTime Fecha { get; set; }

    public bool Estado { get; set; }

    public virtual EstadoTransaccione EstadoTransaccionNavigation { get; set; } = null!;

    public virtual Usuario IdCajeroNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;

    public virtual TipoTransaccion TipoTransaccionNavigation { get; set; } = null!;
}
