using empresaPractica1.modelo;
using empresaPractica1.servicio;
using empresaPractica1.validacion;
using System;

namespace empresaPractica1.Menu
{
    internal class MenuPrincipal
    {
        // se crean instancias de servicios y validacion para usar en todo el menu
        private ProveedorServicio proveedorServicio = new ProveedorServicio();
        private ProductoServicio productoServicio = new ProductoServicio();
        private OrdenCompraServicio ordenServicio = new OrdenCompraServicio();
        private InventarioServicio inventarioServicio = new InventarioServicio();
        private Validacion validacion = new Validacion();

        // metodo que muestra el menu y controla el flujo
        public void MostrarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear(); // limpia la pantalla al mostrar el menu

                // se muestra el menu principal
                Console.WriteLine("\n=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Registrar proveedor");
                Console.WriteLine("2. Registrar producto");
                Console.WriteLine("3. Crear orden de compra");
                Console.WriteLine("4. Listar proveedores");
                Console.WriteLine("5. Listar productos");
                Console.WriteLine("6. Listar ordenes");
                Console.WriteLine("7. Gestionar inventario");
                Console.WriteLine("8. Salir");

                // se lee la opcion del usuario con validacion
                int opcion = validacion.LeerOpcion("Seleccione una opción: ", 1, 8);

                switch (opcion)
                {
                    case 1:
                        RegistrarProveedor();
                        break;
                    case 2:
                        RegistrarProducto();
                        break;
                    case 3:
                        CrearOrden();
                        break;
                    case 4:
                        ListarProveedores();
                        break;
                    case 5:
                        ListarProductos();
                        break;
                    case 6:
                        ListarOrdenes();
                        break;
                    case 7:
                        GestionarInventario();
                        break;
                    case 8:
                        // se termina el programa
                        continuar = false;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                }
            }
        }

        // se registra un proveedor nuevo
        private void RegistrarProveedor()
        {
            Console.Clear(); // limpia la pantalla antes de la accion
            string nombre = validacion.LeerTexto("Ingrese nombre del proveedor: ");
            string contacto = validacion.LeerContacto("Ingrese contacto del proveedor (8 dígitos): ");

            Proveedor prov = new Proveedor(nombre, contacto);
            try
            {
                proveedorServicio.AgregarProveedor(prov);
                Console.WriteLine("\nProveedor registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // se registra un producto nuevo
        private void RegistrarProducto()
        {
            Console.Clear(); // limpia la pantalla antes de la accion
            string nombre = validacion.LeerTexto("Ingrese nombre del producto: ");
            decimal precio = validacion.LeerDecimal("Ingrese precio del producto: ");

            Producto prod = new Producto(nombre, precio);
            try
            {
                productoServicio.AgregarProducto(prod);
                Console.WriteLine("\nProducto registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // se crea una orden de compra
        private void CrearOrden()
        {
            Console.Clear(); // limpia la pantalla antes de la accion
            int numero = validacion.LeerEntero("Ingrese numero de orden: ");

            Console.WriteLine("Seleccione un proveedor:");
            string nombreProv = validacion.LeerTexto("Nombre del proveedor: ");
            Proveedor prov = proveedorServicio.BuscarProveedor(nombreProv);

            if (prov == null)
            {
                Console.WriteLine("\nProveedor no encontrado.");
                Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                Console.ReadKey();
                return;
            }

            try
            {
                OrdenCompra orden = ordenServicio.CrearOrden(numero, prov);
                Console.WriteLine("\nOrden creada correctamente.");
                Console.WriteLine(orden.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // se listan todos los proveedores
        private void ListarProveedores()
        {
            Console.Clear(); // limpia la pantalla antes de la accion
            Console.WriteLine(proveedorServicio.ListarProveedores());
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // se listan todos los productos
        private void ListarProductos()
        {
            Console.Clear(); // limpia la pantalla antes de la accion
            Console.WriteLine(productoServicio.ListarProductos());
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // se listan todas las ordenes
        private void ListarOrdenes()
        {
            Console.Clear(); // limpia la pantalla antes de la accion
            Console.WriteLine(ordenServicio.ListarOrdenes());
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }

        // se gestiona inventario (solo mostrar y agregar productos)
        private void GestionarInventario()
        {
            Console.Clear(); // limpia la pantalla antes de la accion
            Console.WriteLine("\n=== GESTION DE INVENTARIO ===");
            Console.WriteLine("1. Mostrar inventario");
            Console.WriteLine("2. Agregar stock a producto");

            int opcion = validacion.LeerOpcion("Seleccione una opción: ", 1, 2);

            if (opcion == 1)
            {
                Console.WriteLine("\n" + inventarioServicio.MostrarInventario());
            }
            else if (opcion == 2)
            {
                string nombre = validacion.LeerTexto("Ingrese nombre del producto: ");
                Producto prod = productoServicio.BuscarProducto(nombre);

                if (prod == null)
                {
                    Console.WriteLine("\nProducto no encontrado.");
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    return;
                }

                int cantidad = validacion.LeerEntero("Ingrese cantidad a agregar: ");
                inventarioServicio.AgregarProducto(prod, cantidad);
                Console.WriteLine("\nStock agregado correctamente.");
            }

            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}