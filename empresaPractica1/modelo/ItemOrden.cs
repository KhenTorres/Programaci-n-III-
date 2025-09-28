using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.modelo
{
    internal class ItemOrden
    {
        // se almacena el producto del item
        public Producto Producto { get; set; }

        // se almacena la cantidad del producto en la orden
        public int Cantidad { get; set; }

        // se construye un item de orden con producto y cantidad
        public ItemOrden(Producto producto, int cantidad)
        {
            if (producto == null)
                throw new ArgumentException("El producto no puede ser nulo.");
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            Producto = producto;
            Cantidad = cantidad;
        }

        // se devuelve una representacion de texto del item de orden
        public override string ToString()
        {
            return $"{Producto.Nombre} x {Cantidad} (Subtotal: {Producto.Precio * Cantidad:C})";
        }
    }
}