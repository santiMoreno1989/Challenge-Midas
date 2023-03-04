namespace Domain.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Duracion { get; set; }
        public int TipoHabitacionEnum { get; set; }
        public uint Precio { get; set; }
        public virtual Habitacion Habitacion { get; set; }
        public virtual Huesped Huesped { get; set; }
    }
}
