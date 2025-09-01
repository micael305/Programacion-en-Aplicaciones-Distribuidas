namespace AlquilerPeliculas
{
    internal class Pelicula
    {
        public string Nombre { get; set; }

        public string Genero { get; set; }

        public int Codigo { get; set; }

        public Pelicula(int codigo, string nombre, string genero)
        {
            Codigo = codigo;
            Nombre = nombre;
            Genero = genero;
        }
    }
}
