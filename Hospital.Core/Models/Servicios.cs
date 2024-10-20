﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Core.Models
{
    public class Servicios:BaseEntity
    {

        [Required]
        [ForeignKey(nameof(TipoServicio))]
        public int IdTipoServicio { get; set; }
        [Required]
        [ForeignKey(nameof(AreasMedicas))]
        public int IdAreaMedica { get; set; }
        [Required]
        public double Costo { get; set; }

        #region Navigation propeties
        public virtual TipoServicio TipoServicio { get; set; }
        public virtual AreasMedicas AreasMedicas { get; set; }
        public virtual ICollection<Citas> Citas { get; set; }
        public virtual ICollection<Transacciones> Transacciones { get; set; }
        #endregion
    }
}
