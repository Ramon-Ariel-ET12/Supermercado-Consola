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

    public static void EliminarArticulo()
    {
        var context = new SuperMercadoDbContext();
        Console.Write("\nEscriba el codigo del articulo\nCodigo:");
        var codigo = Convert.ToInt32(Console.ReadLine());

        var articulo = context.Articulos.FirstOrDefault(x => x.Codigo == codigo);

        if (articulo == null)
        {
            Console.WriteLine("\nNo se encontró el articulo\n");
        }
        else
        {
            Console.WriteLine("\nSe eliminó correctamente\n");
        }

        context.RemoveRange(articulo);
        context.SaveChanges();
    }
    public static void ModificarArticulo()
    {
        var context = new SuperMercadoDbContext();
        Console.Write("\nEscriba el codigo del articulo\nCodigo:");
        var codigo = Convert.ToInt32(Console.ReadLine());

        var articulo = context.Articulos.FirstOrDefault(x => x.Codigo == codigo);

        if (articulo != null)
        {
            var table = new ConsoleTable("Codigo", "Nombre", "Descripcion", "Precio");
            table.AddRow(articulo.Codigo, articulo.Nombre, articulo.Descripcion, articulo.Precio);

            table.Write(Format.Minimal);
            Thread.Sleep(1000);

            Console.WriteLine("\nEn caso de que no quiera modificar la columna, no ingrese nada\n");
            Console.Write("Nombre:");
            var nombre = Console.ReadLine();
            Console.Write("Descripcion:");
            var descripcion = Console.ReadLine();
            Console.Write("Precio:");
            double.TryParse(Console.ReadLine(), out double precio);

            articulo.Nombre = nombre != "" ? nombre! : articulo.Nombre;
            articulo.Descripcion = descripcion != "" ? descripcion! : articulo.Descripcion;
            articulo.Precio = precio != 0 ? precio : articulo.Precio;

            var cambiado = new ConsoleTable("Codigo", "Nombre", "Descripcion", "Precio");
            cambiado.AddRow(articulo.Codigo, articulo.Nombre, articulo.Descripcion, articulo.Precio);

            cambiado.Write(Format.Minimal);
            Thread.Sleep(1000);
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("\nNo se encontró el articulo\n");
        }
    }

    public static void BuscarArticulos()
    {
        Console.WriteLine("\nPuedes buscar por código, nombre o precio");
        Console.Write("Buscar: ");
        var buscar = Console.ReadLine();

        var context = new SuperMercadoDbContext();
        var articulos = context.Articulos.Where(x => x.Codigo.ToString() == buscar).ToList();

        if (articulos.Count == 0)
        {
            Console.WriteLine($"\nNo se encontró: {buscar}");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine();

            var table = new ConsoleTable("Codigo", "Nombre", "   Descripcion   ", "Precio");
            foreach (var x in articulos)
            {
                table.AddRow(x.Codigo, x.Nombre, x.Descripcion, x.Precio);

            }

            table.Write(Format.Minimal);
            Thread.Sleep(1000);
        }
    }

    public static void TraerArticulos()
    {
        var context = new SuperMercadoDbContext();
        var articulos = context.Articulos.ToList();
        Console.WriteLine();
        var table = new ConsoleTable("Codigo", "Nombre", "   Descripcion   ", "Precio");
        foreach (var x in articulos)
        {
            table.AddRow(x.Codigo, x.Nombre, x.Descripcion, x.Precio);

        }

        table.Write(Format.Minimal);
        Thread.Sleep(1000);
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


        Console.WriteLine($"\nSe guardó exitosamente!\n");

        var table = new ConsoleTable("Codigo", "Nombre", "Descripcion", "Precio");
        table.AddRow(codigo, nombre, descripcion, precio);

        table.Write(Format.Minimal);
        Thread.Sleep(1000);
    }
}
