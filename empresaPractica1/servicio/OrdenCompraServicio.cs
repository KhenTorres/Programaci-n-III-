using empresaPractica1.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.servicio
{
    internal class OrdenCompraServicio
    {
        // se almacena la lista de ordenes creadas
        private List<OrdenCompra> ordenes;

        // se construye el servicio inicializando la lista vacia
        public OrdenCompraServicio()
        {
            ordenes = new List<OrdenCompra>();
        }

        // se crea y registra una nueva orden
        public OrdenCompra CrearOrden(int numeroOrden, Proveedor proveedor)
        {
            if (ordenes.Any(o => o.NumeroOrden == numeroOrden))
                throw new InvalidOperationException("Ya existe una orden con ese número.");

            var nuevaOrden = new OrdenCompra(numeroOrden, proveedor);
            ordenes.Add(nuevaOrden);
            return nuevaOrden;
        }

        // se busca una orden por numero
        public OrdenCompra BuscarOrden(int numeroOrden)
        {
            return ordenes.FirstOrDefault(o => o.NumeroOrden == numeroOrden);
        }

        // se listan todas las ordenes en formato texto
        public string ListarOrdenes()
        {
            if (ordenes.Count == 0)
                return "No hay órdenes registradas.";

            string resultado = "Órdenes de Compra:\n";
            foreach (var orden in ordenes)
            {
                resultado += orden.ToString() + "\n";
            }
            return resultado;
        }
    }
}