using empresaPractica1.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.modelo
{
    internal class OrdenCompra
    {
        // se almacena el numero unico de la orden
        public int NumeroOrden { get; set; }

        // se almacena el proveedor relacionado con la orden
        public Proveedor Proveedor { get; set; }

        // se almacenan los items de la orden
        public List<ItemOrden> Items { get; set; }

        // se definen los estados posibles de una orden
        internal enum EstadoOrden
        {
            Creada,
            Recibida,
            Cancelada
        }

        // se almacena el estado de la orden
        public EstadoOrden Estado { get; set; }

        // se construye una orden con numero y proveedor
        public OrdenCompra(int numeroOrden, Proveedor proveedor)
        {
            if (numeroOrden <= 0)
                throw new ArgumentException("El número de orden debe ser mayor a cero.");
            if (proveedor == null)
                throw new ArgumentException("El proveedor no puede ser nulo.");

            NumeroOrden = numeroOrden;
            Proveedor = proveedor;
            Items = new List<ItemOrden>();
            Estado = EstadoOrden.Creada;
        }

        // se agrega un item a la orden, sumando si ya existe
        public void AgregarItem(Producto producto, int cantidad)
        {
            var existente = Items.FirstOrDefault(i => i.Producto.Nombre == producto.Nombre);
            if (existente != null)
            {
                existente.Cantidad += cantidad; // se actualiza la cantidad
            }
            else
            {
                Items.Add(new ItemOrden(producto, cantidad));
            }
        }

        // se calcula el total de la orden
        public decimal CalcularTotal()
        {
            return Items.Sum(i => i.Producto.Precio * i.Cantidad);
        }

        // se devuelve una representacion de texto de la orden
        public override string ToString()
        {
            return $"Orden #{NumeroOrden} - Proveedor: {Proveedor.Nombre} - Estado: {Estado} - Total: {CalcularTotal():C}";
        }
    }
}