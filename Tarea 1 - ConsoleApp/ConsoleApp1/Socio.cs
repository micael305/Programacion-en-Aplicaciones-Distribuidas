namespace AlquilerPeliculas
{
    internal class Socio: Persona
    {

        public int NumeroSocio { get; set; }

        public Socio(string nombre, int dni, int numeroSocio) : base(nombre, dni) => NumeroSocio = numeroSocio;

    }
}
