using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTienda
{
    internal class Caja
    {
        public void Cobrar(Carrito carrito)
        {
            // Obtener los productos del carrito
            List<Producto> productos = carrito.Lista;

            // Inicializar el total
            decimal total = 0;

            // Calcular el total sumando los precios de los productos considerando la cantidad
            foreach (var producto in productos)
            {
                total += producto.Precio * producto.Cantidad;
            }

            // Aplicar impuestos (por ejemplo, 16%)
            decimal impuesto = total * 0.16m;
            decimal totalConImpuesto = total + impuesto;

            // Mostrar el desglose de la cuenta
            Console.WriteLine("Total sin impuesto: $" + total.ToString("0.00"));
            Console.WriteLine("Impuesto (16%): $" + impuesto.ToString("0.00"));
            Console.WriteLine("Total a pagar: $" + totalConImpuesto.ToString("0.00"));

            // Pedir el monto a pagar
            Console.WriteLine("Ingrese el monto pagado:");
            decimal montoPagado = Convert.ToDecimal(Console.ReadLine());

            // Calcular el cambio
            if (montoPagado >= totalConImpuesto)
            {
                decimal cambio = montoPagado - totalConImpuesto;
                Console.WriteLine("Cambio: $" + cambio.ToString("0.00"));
            }
            else
            {
                Console.WriteLine("Monto insuficiente. Faltan $" + (totalConImpuesto - montoPagado).ToString("0.00"));
            }
        }
    }
}
