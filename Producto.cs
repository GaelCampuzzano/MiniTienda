using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTienda
{
    internal class Producto
    {
        // Propiedad que representa el nombre del producto
        public string Nombre { get; set; }

        // Propiedad que representa el precio del producto
        public decimal Precio { get; set; }

        // Propiedad que representa la cantidad del producto a llevar
        public int Cantidad { get; set; }
    }
}