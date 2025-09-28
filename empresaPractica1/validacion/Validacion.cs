using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empresaPractica1.validacion
{
    internal class Validacion
    {
        // se valida que un string no sea nulo ni vacio
        public string LeerTexto(string mensaje)
        {
            string entrada;
            do
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                { 
                    Console.WriteLine("El texto no puede estar vacío, intente de nuevo.");
                }

            } while (string.IsNullOrWhiteSpace(entrada));

            return entrada;
        }

        // se valida que un entero sea ingresado correctamente
        public int LeerEntero(string mensaje)
        {
            int numero;
            bool esValido;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = int.TryParse(entrada, out numero);

                if (!esValido)
                {
                    Console.WriteLine("Debe ingresar un número entero válido.");
                }

            } while (!esValido);

            return numero;
        }

        // se valida que un decimal sea ingresado correctamente
        public decimal LeerDecimal(string mensaje)
        {
            decimal numero;
            bool esValido;
            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esValido = decimal.TryParse(entrada, out numero);

                if (!esValido || numero <= 0)
                {
                    Console.WriteLine("Debe ingresar un número decimal válido mayor que cero.");
                }

            } while (!esValido || numero <= 0);

            return numero;
        }

        // se valida que una opcion de menu este dentro de un rango
        public int LeerOpcion(string mensaje, int min, int max)
        {
            int opcion;
            do
            {
                opcion = LeerEntero(mensaje);

                if (opcion < min || opcion > max)
                {
                    Console.WriteLine($"Debe ingresar un número entre {min} y {max}.");
                }

            } while (opcion < min || opcion > max);

            return opcion;
        }
        public string LeerContacto(string mensaje)
        {
            string entrada;
            do
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada) || entrada.Length != 8 || !entrada.All(char.IsDigit))
                {
                    Console.WriteLine("El contacto debe tener exactamente 8 dígitos numéricos. Intente de nuevo.");
                    entrada = null;
                }

            } while (entrada == null);

            return entrada;
        }
    }
}