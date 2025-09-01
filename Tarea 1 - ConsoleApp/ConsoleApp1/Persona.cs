namespace AlquilerPeliculas
{
    internal class Persona
    {
        private string _nombre;
        public string Nombre { get => _nombre; set => _nombre = value; }

        private int _dni;
        public int DNI
        { 
            get => _dni; 
            set => _dni = value >= 0 ? value : throw new ArgumentException("El número de DNI no debe ser negativo");
        }
        public Persona(string nombre, int dni)
        {
            Nombre = nombre;
            DNI = dni;
        }
    }
}
