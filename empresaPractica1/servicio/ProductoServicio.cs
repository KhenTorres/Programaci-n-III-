using empresaPractica1.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.servicio
{
    internal class ProductoServicio
    {
        // lista que almacena todos los productos registrados
        private List<Producto> productos;

        // constructor inicializa la lista de productos vacia
        public ProductoServicio()
        {
            productos = new List<Producto>();
        }

        // metodo para agregar un producto a la lista
        public void AgregarProducto(Producto prod)
        {
            if (prod == null)
            {
                throw new ArgumentNullException("El producto no puede ser nulo.");
            }

            // se valida que no exista un producto con el mismo nombre para evitar duplicados
            if (productos.Any(p => p.Nombre == prod.Nombre))
            {
                throw new InvalidOperationException("Ya existe un producto con el mismo nombre.");
            }

            productos.Add(prod);
        }

        // metodo para listar todos los productos en un string
        public string ListarProductos()
        {
            if (productos.Count == 0)
            {
                return "No hay productos registrados.";
            }

            string resultado = "Productos registrados:\n";
            foreach (var prod in productos)
            {
                resultado += prod.ToString() + "\n";
            }
            return resultado;
        }

        // metodo para buscar un producto por su nombre
        public Producto BuscarProducto(string nombre)
        {
            return productos.FirstOrDefault(p => p.Nombre == nombre);
        }
    }
}
