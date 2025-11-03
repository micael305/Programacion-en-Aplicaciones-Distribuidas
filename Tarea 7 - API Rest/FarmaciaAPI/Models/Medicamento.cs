namespace FarmaciaAPI.Models
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Laboratorio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}