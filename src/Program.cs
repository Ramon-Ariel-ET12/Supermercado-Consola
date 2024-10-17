using src.Models;

bool continuar = true;
var supermercado = new Supermercado("Coto", "Aldolfo Alsina 2256");
while (continuar)
{
    Console.WriteLine($"\nSupermercado: {supermercado.Nombre}, Direccion: {supermercado.Direccion}");
    Console.WriteLine("\n1. Salir");
    Console.WriteLine("2. Reservar espacio en la base de datos");
    Console.WriteLine("3. Gestionar Articulos");
    Console.WriteLine("4. Gestionar Articulos en stock");
    Console.WriteLine("5. Gestionar Articulos en venta");
    Console.WriteLine("6. Gestionar Cajas");
    Console.WriteLine("7. Gestionar Ventas");

    Console.Write("\nRespuesta: ");

    int Opciones = Convert.ToInt32(Console.ReadLine());
    switch (Opciones)
    {
        case 1:
            Console.WriteLine("\nNos vemos!");
            continuar = false;
            break;
        case 2:
            _ = new Supermercado();
            break;
        case 3:
            Supermercado.GestionarArticulo();
            break;
        case 4:
            Supermercado.GestionarArticuloStock();
            break;
        case 5:
        case 6:
        case 7:
        default:
            Console.WriteLine("\nPor favor, elija una de las opciones");
            Thread.Sleep(1000);
            break;
    }
}


Console.ReadKey();
