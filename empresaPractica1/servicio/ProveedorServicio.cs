using empresaPractica1.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.servicio
{
    internal class ProveedorServicio
    {
        // se almacena la lista de proveedores registrados
        private List<Proveedor> proveedores;

        // se construye el servicio inicializando la lista vacia
        public ProveedorServicio()
        {
            proveedores = new List<Proveedor>();
        }

        // se agrega un proveedor validando duplicados
        public void AgregarProveedor(Proveedor proveedor)
        {
            if (proveedor == null)
                throw new ArgumentException("El proveedor no puede ser nulo.");

            if (proveedores.Any(p => p.Nombre == proveedor.Nombre))
                throw new InvalidOperationException("Ya existe un proveedor con el mismo nombre.");

            proveedores.Add(proveedor);
        }

        // se busca un proveedor por nombre
        public Proveedor BuscarProveedor(string nombre)
        {
            return proveedores.FirstOrDefault(p => p.Nombre == nombre);
        }

        // se listan todos los proveedores en formato texto
        public string ListarProveedores()
        {
            if (proveedores.Count == 0)
                return "No hay proveedores registrados.";

            string resultado = "Lista de Proveedores:\n";
            foreach (var prov in proveedores)
            {
                resultado += prov.ToString() + "\n";
            }
            return resultado;
        }
    }
}