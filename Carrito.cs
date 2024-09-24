using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTienda
{
    internal class Carrito
    {
        public List<Producto> Lista { get; set; } = new List<Producto>();
        public void AgregarProducto(Producto Producto)
        {
            Lista.Add(Producto);
        }

        public void MostrarCarrito()
        {
            for (int p = 0; p < Lista.Count; p++)
            {
                Console.WriteLine($"Nombre: {Lista[p].Nombre}," +
                    $"Cantidad: {Lista[p].Cantidad}," +
                    $"Precio: {Lista[p].Precio}," +
                    $"Total: {Lista[p].Cantidad * Lista[p].Precio}");
            }
        }
    }
}