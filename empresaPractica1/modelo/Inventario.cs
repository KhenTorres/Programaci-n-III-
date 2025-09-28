using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.modelo
{
    internal class Inventario
    {
        // se almacenan los productos con sus cantidades
        private Dictionary<string, int> productos;

        // se construye un inventario vacio
        public Inventario()
        {
            productos = new Dictionary<string, int>();
        }

        // se agrega un producto al inventario
        public void AgregarProducto(Producto producto, int cantidad)
        {
            if (producto == null)
                throw new ArgumentException("El producto no puede ser nulo.");
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            if (productos.ContainsKey(producto.Nombre))
                productos[producto.Nombre] += cantidad;
            else
                productos[producto.Nombre] = cantidad;
        }

        // se remueve un producto del inventario
        public void RemoverProducto(Producto producto, int cantidad)
        {
            if (!productos.ContainsKey(producto.Nombre))
                throw new InvalidOperationException("El producto no existe en inventario.");

            if (productos[producto.Nombre] < cantidad)
                throw new InvalidOperationException("No hay suficiente stock para remover.");

            productos[producto.Nombre] -= cantidad;

            if (productos[producto.Nombre] == 0)
                productos.Remove(producto.Nombre);
        }

        // se obtiene la cantidad de un producto en inventario
        public int ObtenerCantidad(string nombreProducto)
        {
            return productos.ContainsKey(nombreProducto) ? productos[nombreProducto] : 0;
        }

        // se devuelve una representacion de texto del inventario
        public override string ToString()
        {
            return string.Join(Environment.NewLine, productos.Select(p => $"{p.Key}: {p.Value} unidades"));
        }
    }
}