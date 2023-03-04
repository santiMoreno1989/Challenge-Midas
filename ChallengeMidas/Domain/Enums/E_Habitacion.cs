using System.ComponentModel;

namespace Domain.Enums
{
    public enum E_Habitacion
    {
        [Description("Habitación doble clásica")]
        DobleClasica = 1,

        [Description("Habitación triple clásica")]
        TripleClasica,

        [Description("Habitación deluxe con cama extragrande")]
        HabitacionDeluxe,

        [Description("Suite con vistas a la montaña")]
        Suite
    }
}
