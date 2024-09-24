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
            Carrito Carrito = new Carrito();
            
            string Nombre = "";
            int Cantidad = 0;
            decimal Precio = 0;
            Console.WriteLine("Ingrese Nombre Del Producto");
            Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Cantidad");
            Cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese Precio");
            Precio = Convert.ToDecimal(Console.ReadLine());

            Producto Prod = new Producto();
            Prod.Nombre = Nombre;
            Prod.Cantidad = Cantidad;
            Prod.Precio = Precio;
            Carrito.AgregarProducto(Prod);

            Caja caja = new Caja();
            caja.Cobrar(Carrito);

            Carrito.MostrarCarrito();
            Console.ReadLine();
        }
    }
}