namespace Domain.Entities
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int TipoHabitacionEnum { get; set; }
        public ushort Capacidad { get; set; }
        public decimal Precio { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
        public virtual ICollection<Huesped> Huespedes { get; set; }
    }
}
