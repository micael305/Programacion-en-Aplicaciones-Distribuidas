﻿namespace Tarea_2___WebApplication.Models
{
    public class ItemCarrito
    {
        public int IDProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal
        {
            get { return PrecioUnitario * Cantidad; }
        }
    }
}