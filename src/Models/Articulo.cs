using ConsoleTables;
using src.Persistence;

namespace src.Models;

public class Articulo
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }

    public Articulo(int codigo, string nombre, string descripcion, double precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;
    }

    public static void BuscarArticulo()
    {
        Console.WriteLine("\nPuedes buscar por código, nombre o precio");
        Console.Write("Buscar: ");
        var buscar = Console.ReadLine();

        using (var context = new SuperMercadoDbContext())
        {
            var articulos = context.Articulos.ToList();
            Articulo articuloEncontrado = null;

            foreach (var articulo in articulos)
            {
                if (articulo.Codigo.ToString() == buscar ||
                    articulo.Nombre.Equals(buscar) ||
                    articulo.Precio.ToString() == buscar)
                {
                    articuloEncontrado = articulo;
                    break;
                }
            }

            if (articuloEncontrado == null)
            {
                Console.WriteLine($"\nNo se encontró: {buscar}");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine($"\nCódigo: {articuloEncontrado.Codigo}");
                Console.WriteLine($"Nombre: {articuloEncontrado.Nombre}");
                Console.WriteLine($"Descripción: {articuloEncontrado.Descripcion}");
                Console.WriteLine($"Precio: {articuloEncontrado.Precio}");
                Thread.Sleep(1000);
            }
        }
    }


    public static void CrearArticulo()
    {
        var context = new SuperMercadoDbContext();
        Console.Write("Codigo del articulo:");
        var codigo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nombre del articulo:");
        var nombre = Console.ReadLine();
        Console.Write("Descripcion del articulo:");
        var descripcion = Console.ReadLine();
        Console.Write("Precio del articulo:");
        var precio = Convert.ToDouble(Console.ReadLine());

        var nuevo = new Articulo(codigo, nombre, descripcion, precio);

        context.Articulos.Add(nuevo);
        context.SaveChanges();


        Console.WriteLine($"Se guardó exitosamente!");

        var table = new ConsoleTable("Codigo", "Nombre", "Descripcion", "Precio");
        table.AddRow(codigo, nombre, descripcion, precio);

        table.Write(Format.Alternative);
        Thread.Sleep(1000);
    }
}
