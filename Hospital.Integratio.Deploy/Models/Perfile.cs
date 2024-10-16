using System;
using System.Collections.Generic;

namespace Hospital.Integratio.Deploy.Models;

public partial class Perfile
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public bool Estado { get; set; }

    public virtual Role IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
