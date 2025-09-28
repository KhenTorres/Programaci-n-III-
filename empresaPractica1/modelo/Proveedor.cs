using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.modelo
{
    internal class Proveedor
    {
        // se almacena el nombre del proveedor
        public string Nombre { get; set; }

        // se almacena el contacto del proveedor (solo 8 dígitos numéricos)
        public string Contacto { get; set; }

        // se construye un proveedor con todos sus datos
        public Proveedor(string nombre, string contacto)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del proveedor no puede estar vacío.");

            // validacion de contacto
            if (string.IsNullOrWhiteSpace(contacto) || contacto.Length != 8 || !contacto.All(char.IsDigit))
                throw new ArgumentException("El contacto debe tener exactamente 8 dígitos numéricos.");

            Nombre = nombre;
            Contacto = contacto;
        }

        // se devuelve una representacion de texto del proveedor
        public override string ToString()
        {
            return $"Proveedor: {Nombre}, Contacto: {Contacto}";
        }
    }
}    