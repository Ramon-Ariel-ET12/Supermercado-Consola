using ConsoleTables;
using src.Persistence;

namespace src.Models;

public class ArticuloStock
{
    public int IdArticuloStock { get; set; }
    public Articulo Articulo { get; set; }
    public int Cantidad { get; set; }

    public ArticuloStock(){}
    public ArticuloStock(Articulo articulo, int cantidad)
    {
        Articulo = articulo;
        Cantidad = cantidad;
    }

    public static void CrearArticuloStock()
    {
        var context = new SuperMercadoDbContext();
        Console.Write("Codigo del articulo:");
        var codigo = Convert.ToInt32(Console.ReadLine());
        Console.Write("Cantidad:");
        var cantidad = Convert.ToInt32(Console.ReadLine());

        var existe = context.Articulos.FirstOrDefault(x => x.Codigo == codigo);
        if (existe == null)
        {
            Console.WriteLine("\nNo se encontró\n");
            Thread.Sleep(1000);
            return;
        }
        
        var nuevo = new ArticuloStock(existe, cantidad);

        context.ArticuloStocks.Add(nuevo);
        context.SaveChanges();


        Console.WriteLine($"\nSe guardó exitosamente!\n");

        var table = new ConsoleTable("Codigo", "Nombre", "Precio", "Stock");
        table.AddRow(codigo, existe.Nombre, existe.Precio, nuevo.Cantidad);

        table.Write(Format.Minimal);
        Thread.Sleep(1000);
    }
}
