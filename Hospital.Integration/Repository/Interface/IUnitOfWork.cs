namespace Hospital.Integration.Repository.Interface
{
    public interface IUnitOfWork
    {
        public IAreasMedicasRepository AreasMedicas { get;  }
        public ICitasRepository Citas { get;  }
        public IEstadoTransaccionRepository EstadoTransaccion { get;  }
        public IPerfilesRepository PerfilesRepository { get;  }
        public IRolesRepository Roles { get;  }
        public IServiciosRepository Servicios { get;  }
        public ITipoServicioRepository TipoServicio { get;  }
        public ITipoTransaccionRepository TipoTransaccion { get;  }
        public ITransaccionesRepository Transacciones { get;  }
        public IUsuarioRepository Usuario { get;  }
        Task SaveAsync();
    }
}
