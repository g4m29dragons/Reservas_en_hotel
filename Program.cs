namespace Ejercicio_1_Hotel
{
    internal class Program
    {

        // Clase base para representar una habitación
        class Habitacion
        {
            public int Numero { get; set; }
            public int Capacidad { get; set; }
            public bool AireAcondicionado { get; set; }
            public bool Disponible { get; set; }

            public Habitacion(int numero, int capacidad, bool aireAcondicionado)
            {
                Numero = numero;
                Capacidad = capacidad;
                AireAcondicionado = aireAcondicionado;
                Disponible = true;
            }

            public virtual decimal CalcularPrecioReserva(int cantidadPersonas)
            {
                // Precio base por noche (se puede ajustar según criterios del hotel)
                decimal precioBase = 100;
                // Se puede agregar lógica para calcular el precio dependiendo de la capacidad de la habitación, servicios adicionales, etc.
                return precioBase;
            }
        }

        // Clase derivada que representa una habitación en el Hotel Candelaria
        class HabitacionCandelaria : Habitacion
        {
            public HabitacionCandelaria(int numero, int capacidad, bool aireAcondicionado)
                : base(numero, capacidad, aireAcondicionado)
            {
            }

            // Override del método CalcularPrecioReserva para ajustar el precio específico del Hotel Candelaria
            public override decimal CalcularPrecioReserva(int cantidadPersonas)
            {
                decimal precioBase = base.CalcularPrecioReserva(cantidadPersonas);
                // Se puede agregar lógica específica del Hotel Candelaria para ajustar el precio base
                return precioBase * cantidadPersonas;
            }
        }

        private class Program2
        {
            static List<Habitacion> habitaciones = new List<Habitacion>();

            static void Main(string[] args)
            {
                // Crear algunas habitaciones de ejemplo para el Hotel Candelaria
                habitaciones.Add(new HabitacionCandelaria(101, 2, true));
                habitaciones.Add(new HabitacionCandelaria(102, 4, true));
                habitaciones.Add(new HabitacionCandelaria(103, 1, false));

                // Ejemplo de uso: realizar una reserva
                RealizarReserva();
            }

            static void RealizarReserva()
            {
                Console.WriteLine("Bienvenido al Hotel Candelaria");
                Console.WriteLine("Habitaciones disponibles:");

                // Mostrar las habitaciones disponibles
                foreach (var habitacion in habitaciones)
                {
                    if (habitacion.Disponible)
                    {
                        Console.WriteLine($"Habitación {habitacion.Numero} - Capacidad: {habitacion.Capacidad} personas - {(habitacion.AireAcondicionado ? "Con" : "Sin")} aire acondicionado");
                    }
                }

                // Solicitar información al usuario para realizar la reserva
                Console.WriteLine("\nIngrese el número de habitación que desea reservar:");
                int numeroHabitacion = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la fecha de llegada (dd/mm/aaaa):");
                DateTime fechaLlegada = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la cantidad de personas:");
                int cantidadPersonas = int.Parse(Console.ReadLine());

                // Buscar la habitación seleccionada
                Habitacion habitacionSeleccionada = habitaciones.Find(h => h.Numero == numeroHabitacion);

                if (habitacionSeleccionada != null && habitacionSeleccionada.Disponible)
                {
                    // Marcar la habitación como no disponible
                    habitacionSeleccionada.Disponible = false;

                    // Calcular el precio de la reserva
                    decimal precioReserva = habitacionSeleccionada.CalcularPrecioReserva(cantidadPersonas);

                    // Mostrar información de la reserva
                    Console.WriteLine("\nReserva realizada con éxito:");
                    Console.WriteLine($"Habitación: {habitacionSeleccionada.Numero}");
                    Console.WriteLine($"Fecha de llegada: {fechaLlegada.ToShortDateString()}");
                    Console.WriteLine($"Cantidad de personas: {cantidadPersonas}");
                    Console.WriteLine($"Precio de la reserva: ${precioReserva}");
                }
                else
                {
                    Console.WriteLine("La habitación seleccionada no está disponible.");
                }
            }
        }
    }

}