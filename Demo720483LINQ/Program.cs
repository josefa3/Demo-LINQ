// See https://aka.ms/new-console-template for more information

////LINQ para hacer consultas a estructuras de datos, como por ejemplo a este arreglo, a objetos en memoria, capa EntityFramework o ORM, bases de datos, documentos xml
//string[] juegos = { "Carcason", "Elang", "Jungle Speed", "Los Colonos de Caton", "Zoombies" };

////todas las consulta con LINQ se hacen usando for in y where
//var consulta = from j in juegos //el arreglo de juegos se guarda en j
//               where j.StartsWith("J") //.StartWith q los juegos empiecen por la palabra
//               orderby j ascending //me ordena el contenido de j ascendentemente
//               select j;  //q me haga todo eso en j

////para sustraer dicha informacion
//foreach (string elemento in consulta)
//{
//    Console.WriteLine(elemento);
//}

////se crea una lista estatica de la clase Juego
////se tuvo que quitar el static porq daba error
////IEnumarable me sirve para hacer una consulta de Juego
//IEnumerable<Juego> juegos = new List<Juego>()
//{
//    new Juego{Id=1, Name="Carcassome", MinJugadores=2, MaxJugadores=8},
//    new Juego{Id=2, Name="Colonos de Catan", MinJugadores=2, MaxJugadores=8},
//    new Juego{Id=3, Name="Jungle Speed", MinJugadores=1, MaxJugadores=4},
//    new Juego{Id=4, Name="Black Stories", MinJugadores=2, MaxJugadores=100},
//    new Juego{Id=5, Name="Zoombies", MinJugadores=3, MaxJugadores=10}
//};

////empiezo con mi sentencia LINQ y agarro mi variable de rango j, que guarde la lista juegos, despues con in le tengo que guardar la fuente de datos
//List<Juego> consulta = (from j in juegos //lo que esta en Juegos me lo guarde en j
//where j.MaxJugadores > 4  //donde j tenga los MaxJugarores mayor a 4
//orderby j.Name ascending //me ordena j ascendentemente por nombre
//select j).ToList(); //debo usar los parentesis y aca se tuvo que convertir a ToList porque use IEnumerable

//List<Juego> resultado = consulta;

//foreach (Juego j in resultado)
//{
//Console.WriteLine("{0} {1}. De {2} a {3} Jugadores",
//                    j.Name,
//                    j.Id,
//                    j.MinJugadores,
//                    j.MaxJugadores);
//}


//llamo a Entidates para poder vincularlo
using Entidates;
using System.Linq;

////******SELECCION SIMPLE*******

//var listaNombreClientes = from c in DataList.ListaClientes
//                          select c;

////si quiero que me traiga un solo registro coloco select c.Name, por ejemplo; y eso va a estar en la variable cliene del foreach
////para traer dos datos LINQ no me lo permite, con un tipo implicito: pero lo puedo hacer trayendo la clase select new Cliente {Name = c.Name, FechaNacimiento = c.FechaNacimiento}
////tipos anonimos select new {Name = c.Name, FechaNacimiento = c.FechaNacimiento}

//foreach (var cliente in listaNombreClientes)
//{
//    Console.WriteLine("{0}: {1}", cliente.Name, cliente.FechaNacimiento);
//}

///*******MULTI SELECCIONES******* RELACIONAR VARIOS OBJETOS EN UNA SENTENCIA LINQ

//var listaPedidosClientes = from c in DataList.ListaClientes
//                   from p in DataList.ListaPedidos
//                   where p.IdCliente == c.ID
//                   select new
//                   {
//                       NumeroPedido = p.ID,
//                       FechaPedido = p.FechaPedido,
//                       Cliente = c.Name
//                   };


////cuando la informacion esta en memoria y hay muchos datos se debe usar join
//var listaPedidosClientes = from c in DataList.ListaClientes
//                           join p in DataList.ListaPedidos on c.ID equals p.IdCliente
//                           select new
//                           {
//                               NumeroPedido = p.ID,
//                               FechaPedido = p.FechaPedido,
//                               Cliente = c.Name
//                           };

//foreach (var pedidoCliente in listaPedidosClientes)
//{
//    Console.WriteLine("El pedido {0} enviado en {1} pertenece a {2}", pedidoCliente.NumeroPedido, pedidoCliente.FechaPedido, pedidoCliente.Cliente);
//}

///******AGRUPAR ELEMENTOS*******
///devuelve un listado de agrupaciones compuestio por una llave y un objeto implicito
//var agrupacion = from p in DataList.ListaPedidos
//                 group p by p.IdCliente into grupo
//                 select grupo;

//foreach (var grupo in agrupacion)
//{
//    Console.WriteLine("Id Cliente: " + grupo.Key); //seria el IdCliente

//    //para traer toda la informacion que esta agrupada
//    foreach (var objetoagrupado in grupo)
//    {
//        Console.WriteLine("Pedido Nro: " + objetoagrupado.ID + ": " + objetoagrupado.FechaPedido);
//    }
//    Console.WriteLine();
//}

//******AGRUPAR MAS DE UN CAMPO*****
//var agrupacion = from p in DataList.ListaPedidos
//                 join c in DataList.ListaClientes on p.IdCliente equals c.ID
//                 group p by new
//                 {
//                     p.IdCliente,
//                     c.Name,
//                 } into grupo
//                 select grupo;
//foreach (var grupo in agrupacion)
//{
//    Console.WriteLine("Nombre del Cliente: ", grupo.Key.Name + "(ID: )", grupo.Key.IdCliente);
//    foreach (var objetoAgrupado in grupo)
//    {
//        Console.WriteLine("Pedido Numero: ", objetoAgrupado.ID + ": " + objetoAgrupado.FechaPedido);
//    }
//    Console.WriteLine();
//}

//el resultado es una IEnumerable que es un tipo de dato que solo se utiliza para consultas

////*****Cuando quiero que me devuelva 5 cantidad de registros******
//var consulta = (from producto in DataList.ListaProductos
//                select producto).Take(5);
//foreach (var prod in consulta)
//{
//    Console.WriteLine("El producto {0} su precio es: {1}", prod.Descripcion, prod.Precio);
//}

///****Misma consulta pero con una lambda*****
//var consulta = DataList.ListaProductos.Take(5);

//*****Para saltar x cantidad de registros
//var consulta =(from producto in DataList.ListaProductos
//               select producto).Skip(8);

//*****la misma anterior version lambda
//var consulta = DataList.ListaProductos.Skip(8);

//foreach (var prod in consulta)
//{
//    Console.WriteLine("El producto {0} con el ID {1} su precio es: {2}", prod.Descripcion, prod.ID, prod.Precio);
//}

//********** siguiente clase **********

//uso de group. se agrupa la linea de pedidos por su IdPedidos y con Count puedo saber la cantidad de lineas de pedidos
//var consulta = from lineaPedido in DataList.ListaLineaPedidos
//               group lineaPedido by lineaPedido.IdPedido into grupo
//               select new
//               {
//                   IdPedido = grupo.Key,
//                   NumPedidos = grupo.Count()
//               };
//foreach (var ped in consulta)
//{
//    Console.WriteLine("El pedido {0} consta de {1} lineas de pedidos",
//                        ped.IdPedido, ped.NumPedidos);
//}

//para saber la cantidad de lineas de pedido por clientes. En consola veo el total de pedidos realizados por cliente
//var consulta = from pedido in DataList.ListaPedidos
//               select pedido.IdCliente;
//Console.WriteLine("Existe un total de {0} pedidos realizados por cliente", consulta.Count());

////Distinct
//var consulta = from pedido in DataList.ListaPedidos
//               select pedido.IdCliente;
//Console.WriteLine("Existe un total de {0} clientes distintos que han realizado un pedido", consulta.Distinct().Count());

//Seleccionar todos los pedidios por Id del cliente
//var consultaLambda = DataList.ListaPedidos.Select(pedido => pedido.IdCliente); //el pedidio va a apuntar al id del cliente
//Console.WriteLine("Existe un total de {0} pedidos realizados por cliente", consultaLambda.Count()); //saber la cantidad de pedidos realizados por un cliente
//Console.WriteLine("Existe un total de {0} clientes distintos que han realizado un pedido", consultaLambda.Distinct().Count());

//Cantidad de lineas de ventas con sus precio y la suma total de esas lineas
//var consulta = (from lineaPedido in DataList.ListaLineaPedidos
//               join producto in DataList.ListaProductos
//               on lineaPedido.IdProducto equals producto.ID
//               select lineaPedido.Cantidad * producto.Precio).ToList();
//float resultadoTotal = consulta.Sum();

//int i = 1;
//foreach (var valor in consulta)
//{
//    Console.WriteLine("Cantidad obtenida en la linea de venta {0}: {1}", i++, valor);
//}
//Console.WriteLine("Total de ingresos: {0}", resultadoTotal);

// para obtener el precio unitario, nombre de producto, candidad de productos y el total
//var consulta = (from lineaPedido in DataList.ListaLineaPedidos
//               join producto in DataList.ListaProductos
//               on lineaPedido.IdProducto equals producto.ID
//               select new
//               {
//                   NombreProducto = producto.Descripcion,
//                   PrecioUnitario = producto.Precio,
//                   Unidades = lineaPedido.Cantidad,
//                   PrecioTotal = lineaPedido.Cantidad * producto.Precio
//               }).ToList();
//float resultadoTotal = consulta.Sum(elemento => elemento.PrecioTotal);
//float valorMaximo = consulta.Max(elemento => elemento.PrecioTotal); //Para saber el valor maximo
//float valorMinimo = consulta.Min(elemento => elemento.PrecioTotal); //Para saber el valor minimo
//float valorMedio = consulta.Average(elemento => elemento.PrecioTotal); //Para saber el valor promedio de venta


//foreach (var elemento in consulta)
//{
//    Console.WriteLine("Producto: {0}; {1} dolares x {2} = {3}",
//                        elemento.NombreProducto,
//                        elemento.PrecioUnitario,
//                        elemento.Unidades,
//                        elemento.PrecioTotal);
//}
//Console.WriteLine("Total: {0}", resultadoTotal);
//Console.WriteLine("La mayor venta ha sido de {0} dolares", valorMaximo);
//Console.WriteLine("La menor venta ha sido de {0} dolares", valorMinimo);
//Console.WriteLine("El valor promedio de venta ha sido de {0} dolares", valorMedio);

//hacer consultas
//esta va a arrojar toda la informacion de los clientes
//var consulta = from cliente in DataList.ListaClientes
//               orderby cliente.Name ascending //decending
//               select cliente; //.Reverse() para revertir el orden
//foreach (var cliente in consulta)
//{
//    Console.WriteLine("ID: {0}; Nombre: {1}; Fecha de nacimiento: {2}",
//                        cliente.ID,
//                        cliente.Name,
//                        cliente.FechaNacimiento);
//}


//var consultaAsc = DataList.ListaClientes.OrderBy(c => c.Name).ToList();
//foreach (var cliente in consultaAsc)
//{
//    Console.WriteLine("ID: {0}; Nombre: {1}; Fecha de nacimiento: {2}",
//                        cliente.ID,
//                        cliente.Name,
//                        cliente.FechaNacimiento);
//}


//var consultaDesc = DataList.ListaClientes.OrderByDescending(c => c.Name).ToList();
//foreach (var cliente in consultaDesc)
//{
//    Console.WriteLine("ID: {0}; Nombre: {1}; Fecha de nacimiento: {2}",
//                        cliente.ID,
//                        cliente.Name,
//                        cliente.FechaNacimiento);
//}


//Consulta de ordenacion multiple
//primero ordena por pedido.id y luego por producto.id
//var consultaPedido = from linea in DataList.ListaLineaPedidos
//                     orderby linea.IdPedido, linea.IdProducto
//                     select linea;
//foreach (var linea in consultaPedido)
//{
//    Console.WriteLine("Pedido: {0}; Producto: {1}; Cantidad: {2}",
//                        linea.ID,
//                        linea.IdProducto,
//                        linea.Cantidad);
//}

////ordena pedido de manera descendente y producto de manera ascendente
//var consultaPedidoDesc = from linea in DataList.ListaLineaPedidos
//                     orderby linea.IdPedido descending, linea.IdProducto
//                     select linea;
//foreach (var linea in consultaPedidoDesc)
//{
//    Console.WriteLine("Pedido: {0}; Producto: {1}; Cantidad: {2}",
//                        linea.ID,
//                        linea.IdProducto,
//                        linea.Cantidad);
//}

//Consulta a varias clases para ordenarlas
var consultaGroup = from linea in DataList.ListaLineaPedidos
                    join producto in DataList.ListaProductos
                    on linea.IdProducto equals producto.ID
                    group new { linea, producto } by linea.IdPedido into grupoLineaProducto //agrupo el producto por el pedido y le doy un nombre a ese grupo nuevo que estoy creando grupoLineaProducto
                    select new
                    {
                        IdPedido = grupoLineaProducto.Key, //q es la Key?????
                        ValorTotal = grupoLineaProducto.Sum(lineaProducto => lineaProducto.producto.Precio)
                    };

//var consultaGroup1 = consultaGroup.Where(elemento => elemento.ValorTotal > 100); //me trae a los productos mayores a 20
//foreach (var valor in consultaGroup1)
//{
//    Console.WriteLine("ID.Pedido: {0}; Valor: {1}", valor.IdPedido, valor.ValorTotal);
//}
//Console.WriteLine("-----------------------------------Mayor a 100-----------------------------------");

//var consultaGroup2 = consultaGroup.Where(elemento => elemento.ValorTotal < 100 && elemento.ValorTotal > 30); //me trae a los productos mayores a 20 y menores de 10
//foreach (var valor in consultaGroup2)
//{
//    Console.WriteLine("ID.Pedido: {0}; Valor: {1}", valor.IdPedido, valor.ValorTotal);

//}
//Console.WriteLine("-------------------------------------Menor a 100 y mayor a 30---------------------------------");

//var consultaGroup3 = consultaGroup.Where(elemento => elemento.ValorTotal < 30); //me trae a los productos menores a 10
//foreach (var valor in consultaGroup3)
//{
//    Console.WriteLine("ID.Pedido: {0}; Valor: {1}", valor.IdPedido, valor.ValorTotal);
//}
//Console.WriteLine("-----------------------------Menor a 30-----------------------");


///////**********Operacion conjuntista//////////
//var consultaUnion = consultaGroup1.Union(consultaGroup2).Union(consultaGroup3);
//foreach (var valor in consultaUnion)
//{
//    Console.WriteLine("ID.Pedido: {0}; Valor: {1}", valor.IdPedido, valor.ValorTotal);
//}
//Console.WriteLine("-----------------------------UNION-----------------------"); //une los elementos sin repetir elementos comunes 

//var consultaConcat = consultaGroup1.Concat(consultaGroup2).Concat(consultaGroup3);
//foreach (var valor in consultaConcat)
//{
//    Console.WriteLine("ID.Pedido: {0}; Valor: {1}", valor.IdPedido, valor.ValorTotal);
//}
//Console.WriteLine("-----------------------------CONCAT-----------------------"); //concatena las uniones y repite cada vez q aparece un elemento comun

//var consultaInterseccion1 = consultaGroup1.Intersect(consultaGroup2);
//foreach (var valor in consultaInterseccion1)
//{
//    Console.WriteLine("ID.Pedido: {0}; Valor: {1}", valor.IdPedido, valor.ValorTotal);
//}

//var consultaInterseccion2 = consultaGroup2.Intersect(consultaGroup3);
//foreach (var valor in consultaInterseccion2)
//{
//    Console.WriteLine("ID.Pedido: {0}; Valor: {1}", valor.IdPedido, valor.ValorTotal);
//}

//Console.WriteLine("-----------------------------Interseccion-----------------------"); //elementos comunes a ambos conjunto de elementos

//var consultaDiferencia = consultaGroup1.Except(consultaGroup2);
//foreach (var valor in consultaDiferencia)
//{
//    Console.WriteLine("ID.Pedido: {0}; Valor: {1}", valor.IdPedido, valor.ValorTotal);
//}

//Console.WriteLine("-----------------------------Except-----------------------"); //elementos diferentes entre las dos consultas

bool existe = DataList.ListaLineaPedidos.Any(linea => linea.IdProducto == 3); //Pregunto con any si existe algun producto igual a 3

Console.WriteLine("Existe algun producto igual a 3? : {0}",existe);
Console.WriteLine("-----------------------------Any-----------------------");


bool existeAll = DataList.ListaLineaPedidos.All(linea => linea.Cantidad > 0); //Pregunto con all si hay productos que su cantidad sea mayor a cero

Console.WriteLine("Productos con cantidades mayor a 0? {0}", existeAll);
Console.WriteLine("-----------------------------All-----------------------");

var numeros = Enumerable.Range(1, 1000);
foreach (var numero in numeros)
{
    Console.Write("{0}, ", numero); //imprime los numeros del 1 al 1000
}
Console.WriteLine("-----------------------------Range-----------------------");

Cliente cliente = DataList.ListaClientes[0];
var repeticion = Enumerable.Repeat(cliente, 10); //me trae todo lo que esta en el cliente hasta 10 veces, se repite la cantidad de veces que le diga, por ejemplo, 10
foreach (var c in repeticion)
{
    Console.WriteLine("ID: {0}; Nombre: {1}", c.ID, c.Name);
}
Console.WriteLine("-----------------------------Repeat-----------------------");



Console.Read();

public class Juego
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MinJugadores { get; set; }
    public int MaxJugadores { get; set; }


}
