namespace AlquilerPeliculas
{
    internal class Alquiler
    {
        public Socio Socio { get; set; }
        public Pelicula Pelicula { get; set; }  
        public DateTime FechaAlquiler { get; set; }
        public DateTime ?FechaDevolucion { get; set; }

        public Alquiler(Socio socio, Pelicula pelicula)
        {
            Socio = socio;
            Pelicula = pelicula;
            FechaAlquiler = DateTime.Now;
            FechaDevolucion = null;
        }
        public override string ToString()
        {
            string estado = FechaDevolucion.HasValue //para saber si es null
            ? $"Devuelta el {FechaDevolucion.Value}"
            : "Pendiente de Devolución";
            return $"Socio: {Socio.Nombre} | Pelicula: {Pelicula.Nombre} | {estado}";
        }
    }
}
