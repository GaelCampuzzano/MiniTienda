using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTienda
{
    internal class Caja
    {
        // Método para procesar el pago en efectivo
        public void CobrarEfectivo(Carrito carrito)
        {
            // Obtener la lista de productos del carrito
            List<Producto> productos = carrito.Lista;
            // Calcular el total a pagar incluyendo impuestos
            decimal total = CalcularTotalConImpuesto(productos);

            // Mostrar el desglose de la cuenta
            MostrarDesglose(total);

            // Pedir al usuario que ingrese el monto pagado en efectivo
            Console.WriteLine("Ingrese el monto pagado en efectivo:");
            decimal montoPagado = Convert.ToDecimal(Console.ReadLine());

            // Calcular el cambio a devolver o verificar si falta dinero
            if (montoPagado >= total)
            {
                // Calcular el cambio
                decimal cambio = montoPagado - total;
                Console.WriteLine("Cambio: $" + cambio.ToString("0.00"));
            }
            else
            {
                // Informar al usuario si el monto es insuficiente
                Console.WriteLine("Monto insuficiente. Faltan $" + (total - montoPagado).ToString("0.00"));
            }
        }

        // Método para procesar el pago con tarjeta
        public void CobrarTarjeta(Carrito carrito)
        {
            // Obtener la lista de productos del carrito
            List<Producto> productos = carrito.Lista;
            // Calcular el total a pagar incluyendo impuestos
            decimal total = CalcularTotalConImpuesto(productos);

            // Mostrar el desglose de la cuenta
            MostrarDesglose(total);

            // Simulación de procesamiento de pago con tarjeta
            Console.WriteLine("Procesando pago con tarjeta...");
            Console.WriteLine("Pago completado. No se requiere cambio.");
        }

        // Método privado para calcular el total a pagar incluyendo impuestos
        private decimal CalcularTotalConImpuesto(List<Producto> productos)
        {
            decimal total = 0;

            // Sumar los precios de los productos considerando la cantidad
            foreach (var producto in productos)
            {
                total += producto.Precio * producto.Cantidad;
            }

            // Calcular y aplicar el impuesto (por ejemplo, 16%)
            decimal impuesto = total * 0.16m;
            return total + impuesto; // Retornar el total más el impuesto
        }

        // Método privado para mostrar el desglose del total a pagar
        private void MostrarDesglose(decimal total)
        {
            // Calcular el subtotal dividiendo el total por 1.16
            decimal subtotal = total / 1.16m;
            // Calcular el impuesto restando el subtotal del total
            decimal impuesto = total - subtotal;

            // Mostrar el desglose de los valores al usuario
            Console.WriteLine("Total sin impuesto: $" + subtotal.ToString("0.00"));
            Console.WriteLine("Impuesto (16%): $" + impuesto.ToString("0.00"));
            Console.WriteLine("Total a pagar: $" + total.ToString("0.00"));
        }
    }
}