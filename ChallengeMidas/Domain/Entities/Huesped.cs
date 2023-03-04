namespace Domain.Entities
{
    public class Huesped
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public int? ReservaId { get; set; }
        public virtual Reserva Reserva { get; set; }
        public int? HabitacionId { get; set; }
        public virtual Habitacion Habitacion { get; set; }
    }
}
