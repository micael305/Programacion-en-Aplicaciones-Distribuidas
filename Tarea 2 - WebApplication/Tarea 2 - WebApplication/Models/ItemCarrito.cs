namespace Tarea_2___WebApplication.Models
{
    public class ItemCarrito : Producto
    {
        public int Cantidad { get; set; }
        public decimal Subtotal
        {
            get { return Precio * Cantidad; }
        }
    }
}