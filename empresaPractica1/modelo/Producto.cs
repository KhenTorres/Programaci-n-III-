using System;

namespace empresaPractica1.modelo
{
    internal class Producto
    {
        // se almacena el nombre del producto
        public string Nombre { get; set; }

        // se almacena el precio del producto
        public decimal Precio { get; set; }

        // se construye un producto con nombre y precio
        public Producto(string nombre, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a cero.");

            Nombre = nombre;
            Precio = precio;
        }

        // se devuelve una representacion de texto del producto
        public override string ToString()
        {
            return $"Producto: {Nombre}, Precio: {Precio:C}";
        }
    }
}
