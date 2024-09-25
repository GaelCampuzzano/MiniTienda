using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTienda
{
    internal class Carrito
    {
        // Lista que contiene los productos agregados al carrito
        public List<Producto> Lista { get; set; } = new List<Producto>();

        // Método para agregar un producto al carrito
        public void AgregarProducto(Producto producto)
        {
            Lista.Add(producto); // Agregar el producto a la lista
        }

        // Método para quitar un producto del carrito según su nombre
        public void QuitarProducto(string nombre)
        {
            // Buscar el producto en la lista por su nombre, ignorando mayúsculas/minúsculas
            Producto producto = Lista.FirstOrDefault(p => p.Nombre.ToLower() == nombre.ToLower());
            if (producto != null)
            {
                // Preguntar cuántos productos desea quitar
                Console.WriteLine($"Actualmente tienes {producto.Cantidad} de {nombre}. ¿Cuántos deseas quitar?");
                int cantidadAQuitar = Convert.ToInt32(Console.ReadLine());

                // Verificar si la cantidad a quitar es válida
                if (cantidadAQuitar > producto.Cantidad)
                {
                    Console.WriteLine($"No puedes quitar más de {producto.Cantidad}. Intenta nuevamente.");
                }
                else
                {
                    // Reducir la cantidad del producto
                    producto.Cantidad -= cantidadAQuitar;

                    // Si la cantidad llega a cero, eliminar el producto de la lista
                    if (producto.Cantidad == 0)
                    {
                        Lista.Remove(producto);
                        Console.WriteLine($"Se ha eliminado el producto {nombre} del carrito.");
                    }
                    else
                    {
                        Console.WriteLine($"Ahora tienes {producto.Cantidad} de {nombre} en el carrito.");
                    }
                }
            }
            else
            {
                // Mensaje si no se encuentra el producto en el carrito
                Console.WriteLine($"No se encontró el producto {nombre} en el carrito.");
            }
        }

        // Método para mostrar los productos en el carrito
        public void MostrarCarrito()
        {
            // Verificar si el carrito está vacío
            if (Lista.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
            }
            else
            {
                // Recorrer la lista de productos y mostrar su información
                for (int p = 0; p < Lista.Count; p++)
                {
                    Console.WriteLine($"Nombre: {Lista[p].Nombre}, " +
                                      $"Cantidad: {Lista[p].Cantidad}, " +
                                      $"Precio: {Lista[p].Precio}, " +
                                      $"Total: {Lista[p].Cantidad * Lista[p].Precio}");
                }
            }
        }
    }
}