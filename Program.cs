using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de Carrito para almacenar los productos.
            Carrito carrito = new Carrito();
            string continuar = "si";

            // Bucle para agregar productos al carrito
            while (continuar.ToLower() == "si")
            {
                // Variables para almacenar la información del producto
                string nombre = "";
                int cantidad = 0;
                decimal precio = 0;

                // Solicitar al usuario la información del producto
                Console.WriteLine("Ingrese Nombre Del Producto:");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Cantidad:");
                cantidad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese Precio:");
                precio = Convert.ToDecimal(Console.ReadLine());

                // Crear un nuevo objeto Producto con la información proporcionada
                Producto prod = new Producto
                {
                    Nombre = nombre,
                    Cantidad = cantidad,
                    Precio = precio
                };

                // Agregar el producto al carrito
                carrito.AgregarProducto(prod);

                // Preguntar si desea agregar otro producto
                Console.WriteLine("¿Desea agregar otro producto? (si/no)");
                continuar = Console.ReadLine();
            }

            // Confirmación del resumen y posibilidad de modificar el carrito
            bool resumenConfirmado = false;
            while (!resumenConfirmado)
            {
                // Mostrar el resumen del carrito al usuario
                Console.WriteLine("\n--- Resumen de tu carrito ---");
                carrito.MostrarCarrito();

                // Preguntar al usuario si está de acuerdo con su compra
                Console.WriteLine("\n¿Está de acuerdo con su compra? (si/no)");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta == "si")
                {
                    // Si el usuario está de acuerdo, confirmar el resumen
                    resumenConfirmado = true;
                }
                else
                {
                    // Preguntar al usuario si desea agregar o quitar productos
                    Console.WriteLine("¿Desea agregar o quitar productos? (agregar/quitar)");
                    string accion = Console.ReadLine().ToLower();

                    if (accion == "agregar")
                    {
                        // Solicitar información del nuevo producto a agregar
                        string nombre = "";
                        int cantidad = 0;
                        decimal precio = 0;

                        Console.WriteLine("Ingrese Nombre Del Producto:");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese Cantidad:");
                        cantidad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese Precio:");
                        precio = Convert.ToDecimal(Console.ReadLine());

                        // Crear y agregar el nuevo producto al carrito
                        Producto prod = new Producto
                        {
                            Nombre = nombre,
                            Cantidad = cantidad,
                            Precio = precio
                        };
                        carrito.AgregarProducto(prod);
                    }
                    else if (accion == "quitar")
                    {
                        // Solicitar el nombre del producto a quitar
                        Console.WriteLine("Ingrese el nombre del producto que desea quitar:");
                        string productoAQuitar = Console.ReadLine();
                        carrito.QuitarProducto(productoAQuitar);
                    }
                }
            }

            // Preguntar al usuario el método de pago
            Console.WriteLine("\n¿Desea pagar con efectivo o tarjeta? (efectivo/tarjeta)");
            string metodoPago = Console.ReadLine().ToLower();

            // Proceder al cobro según el método de pago seleccionado
            Caja caja = new Caja();
            if (metodoPago == "efectivo")
            {
                caja.CobrarEfectivo(carrito);
            }
            else if (metodoPago == "tarjeta")
            {
                caja.CobrarTarjeta(carrito);
            }
            else
            {
                // Manejar un método de pago no válido
                Console.WriteLine("Método de pago no válido. Por favor, reinicie el proceso.");
            }

            // Esperar a que el usuario presione una tecla antes de cerrar
            Console.ReadLine();
        }
    }
}