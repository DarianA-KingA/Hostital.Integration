namespace Hospital.Integration.DTO.SaveViewModel
{
    public class SaveTransaccionViewModel
    {
        public string IdCajero { get; set; }
        public string IdPaciente { get; set; }
        public int IdTipoTransaccion { get; set; }
        public int IdEstadoTransaccion { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        //public int idCita { get; set; }
        public string Comentario { get; set; }
        public string Token { get; set; }
    }
}
