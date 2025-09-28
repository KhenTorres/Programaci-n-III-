using empresaPractica1.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.servicio
{
    internal class InventarioServicio
    {
        // se almacena la instancia del inventario
        private Inventario inventario;

        // se construye el servicio con un inventario nuevo
        public InventarioServicio()
        {
            inventario = new Inventario();
        }

        // se agrega un producto al inventario
        public void AgregarProducto(Producto producto, int cantidad)
        {
            inventario.AgregarProducto(producto, cantidad);
        }

        // se remueve un producto del inventario
        public void RemoverProducto(Producto producto, int cantidad)
        {
            inventario.RemoverProducto(producto, cantidad);
        }

        // se obtiene la cantidad de un producto
        public int ConsultarStock(string nombreProducto)
        {
            return inventario.ObtenerCantidad(nombreProducto);
        }

        // se muestra el inventario completo en texto
        public string MostrarInventario()
        {
            return inventario.ToString();
        }
    }
}
