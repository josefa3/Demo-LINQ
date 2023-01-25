using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidates
{
    public class DataList
    {
         private static List<Cliente> _listaClientes = new List<Cliente>()
        {
            new Cliente(){ID=1, Name="Carlos", FechaNacimiento=new DateTime(1987, 10, 15)},
            new Cliente(){ID=2, Name="Ana", FechaNacimiento=new DateTime(1990, 09, 10)},
            new Cliente(){ID=3, Name="Javier", FechaNacimiento=new DateTime(1966, 01, 05)},
            new Cliente(){ID=4, Name="Maria", FechaNacimiento=new DateTime(1940, 12, 20)},
            new Cliente(){ID=5, Name="Nelso", FechaNacimiento=new DateTime(1970, 05, 25)},
        };

        private static List<Producto> _listaProductos = new List<Producto>()
        {
            new Producto(){ID= 1, Descripcion= "Boligrafo", Precio=20 },
            new Producto(){ID= 2, Descripcion= "Tijeras", Precio=50 },
            new Producto(){ID= 3, Descripcion= "Cuaderno Grande", Precio=30 },
            new Producto(){ID= 4, Descripcion= "Cuaderno small", Precio=25 },
            new Producto(){ID= 5, Descripcion= "Escarcha", Precio=5 },
            new Producto(){ID= 6, Descripcion= "Pega", Precio=15 },
            new Producto(){ID= 7, Descripcion= "Cinta Adhesiva", Precio=10 },
            new Producto(){ID= 8, Descripcion= "Grapadora", Precio=80 },
            new Producto(){ID= 9, Descripcion= "Mochila", Precio=200 },
            new Producto(){ID= 10, Descripcion= "Colores", Precio=60 },
            new Producto(){ID= 11, Descripcion= "Tiza", Precio=16 },
        };

        private static List<Pedido> _listaPedidos = new List<Pedido>()
        {
            new Pedido(){ID=1 ,FechaPedido= new DateTime(2022, 01, 05)},
            new Pedido(){ID=2 ,FechaPedido= new DateTime(2022, 01,15)},
            new Pedido(){ID=3 ,FechaPedido= new DateTime(2022, 01, 20)},
            new Pedido(){ID=4 ,FechaPedido= new DateTime(2022, 01, 29)},
            new Pedido(){ID=5 ,FechaPedido= new DateTime(2022, 01, 30)},
            new Pedido(){ID=6 ,FechaPedido= new DateTime(2022, 02, 08)},
            new Pedido(){ID=7 ,FechaPedido= new DateTime(2022, 02, 16)},
            new Pedido(){ID=8 ,FechaPedido= new DateTime(2022, 02, 17)},
            new Pedido(){ID=9 ,FechaPedido= new DateTime(2022, 02, 18)},
            new Pedido(){ID=10 ,FechaPedido= new DateTime(2022, 02, 25)},
            new Pedido(){ID=11 ,FechaPedido= new DateTime(2022, 03, 09)},
            new Pedido(){ID=12 ,FechaPedido= new DateTime(2022, 03, 15)},
        };

        private static List<LineaPedido> _listaLineaPedidos = new List<LineaPedido>()
        {
            new LineaPedido(){ID=1, IdPedido=1, IdProducto=1, Cantidad=3},
            new LineaPedido(){ID=2, IdPedido=1, IdProducto=3, Cantidad=4},
            new LineaPedido(){ID=3, IdPedido=1, IdProducto=5, Cantidad=1},
            new LineaPedido(){ID=4, IdPedido=1, IdProducto=7, Cantidad=10},
            new LineaPedido(){ID=5, IdPedido=2, IdProducto=9, Cantidad=2},
            new LineaPedido(){ID=6, IdPedido=12, IdProducto=1, Cantidad=8},
            new LineaPedido(){ID=7, IdPedido=11, IdProducto=10, Cantidad=9},
            new LineaPedido(){ID=8, IdPedido=10, IdProducto=5, Cantidad=3},
            new LineaPedido(){ID=9, IdPedido=9, IdProducto=8, Cantidad=7},
            new LineaPedido(){ID=10, IdPedido=8, IdProducto=11, Cantidad=11},
            new LineaPedido(){ID=11, IdPedido=7, IdProducto=2, Cantidad=4},
            new LineaPedido(){ID=12, IdPedido=6, IdProducto=3, Cantidad=6},
            new LineaPedido(){ID=13, IdPedido=5, IdProducto=4, Cantidad=15},
            new LineaPedido(){ID=14, IdPedido=4, IdProducto=5, Cantidad=25},
            new LineaPedido(){ID=15, IdPedido=3, IdProducto=6, Cantidad=9},
            new LineaPedido(){ID=16, IdPedido=12, IdProducto=8, Cantidad=12},
            new LineaPedido(){ID=17, IdPedido=10, IdProducto=7, Cantidad=40},
            new LineaPedido(){ID=18, IdPedido=11, IdProducto=9, Cantidad=30},
            new LineaPedido(){ID=19, IdPedido=9, IdProducto=5, Cantidad=23},
            new LineaPedido(){ID=20, IdPedido=7, IdProducto=6, Cantidad=32},
            new LineaPedido(){ID= 21, IdPedido=8, IdProducto=3, Cantidad=14},
            new LineaPedido(){ID= 22, IdPedido=5, IdProducto=4, Cantidad=41},
            new LineaPedido(){ID= 23, IdPedido=6, IdProducto=8, Cantidad=7},
            new LineaPedido(){ID= 24, IdPedido=4, IdProducto=7, Cantidad=9},
        };

        public static List<Cliente> ListaClientes { get { return _listaClientes; } }
        public static List<Producto> ListaProductos { get { return _listaProductos; } }
        public static List<Pedido> ListaPedidos { get { return _listaPedidos; } }
        public static List<LineaPedido> ListaLineaPedidos { get { return _listaLineaPedidos; } }
    }
}
