namespace AlquilerPeliculas
{
    internal class VideoClub
    {
        public List<Alquiler> Alquileres { get; set; } = new List<Alquiler>();
        public List<Socio> Socios { get; set; } = new List<Socio>();
        public List<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
        public void MostrarAlquileresPendientes()
        {
            var alquileresPendientes = from alq in Alquileres
                                       where alq.FechaDevolucion == null
                                       select alq;

            if(alquileresPendientes.Any())
            {
                Console.WriteLine("--- Alquileres pendientes ---");
                foreach (var alq in alquileresPendientes)
                {
                    Console.WriteLine(alq.ToString());
                }
            }
            else
            {
                Console.WriteLine("No hay alquileres pendientes.");
            }

        }
    }
}
