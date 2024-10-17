using Microsoft.EntityFrameworkCore;
using src.Persistence;

namespace src.Models;

public class Supermercado
{
    public int IdSuperMercado { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public List<Articulo> ListaArticulo { get; set; } = [];
    public List<ArticuloStock> ListaArticuloStock { get; set; } = [];
    public List<Caja> VectorCaja { get; set; } = [];

    public Supermercado()
    {
        ReservarEspacioMemoria();
    }
    public Supermercado(string nombre, string direccion)
    {
        Nombre = nombre;
        Direccion = direccion;
        ReservarEspacioMemoria();
    }
    private void ReservarEspacioMemoria()
    {
        var context = new SuperMercadoDbContext();

        ListaArticulo = [];
        ListaArticuloStock = [];
        VectorCaja = [];


        context.Database.ExecuteSqlRaw("DELETE FROM Articulos;DELETE FROM ArticuloStocks;DELETE FROM Cajas");
        for (int i = 1; i <= 5; i++)
        {
            context.Cajas.Add(new(i));
        }
        context.SaveChanges();
        Console.WriteLine("Espacio reservado!");
        Thread.Sleep(1000);
    }

    public static void GestionarArticulo()
    {
        while (true)
        {
            Console.WriteLine("\n1. Crear articulo");
            Console.WriteLine("2. Traer todos los articulos");
            Console.WriteLine("3. Buscar articulos");
            Console.WriteLine("4. Modificar articulos");
            Console.WriteLine("5. Eliminar articulos");
            Console.WriteLine("6. Volver");

            Console.Write("\nRespuesta: ");

            var opciones = Convert.ToInt32(Console.ReadLine());
            switch (opciones)
            {
                case 1:
                    Articulo.CrearArticulo();
                    break;
                case 2:
                    Articulo.TraerArticulos();
                    break;
                case 3:
                    Articulo.BuscarArticulos();
                    break;
                case 4:
                    Articulo.ModificarArticulo();
                    break;
                case 5:
                    Articulo.EliminarArticulo();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Por favor, eliga una opcion");
                    break;
            }
        }
    }

    public static void GestionarArticuloStock()
    {
        while (true)
        {
            Console.WriteLine("\n1. Crear articulo en stock");
            Console.WriteLine("2. Traer todos los articulos en stock");
            Console.WriteLine("3. Buscar articulos en stock");
            Console.WriteLine("4. Modificar articulos en stock");
            Console.WriteLine("5. Eliminar articulos en stock");
            Console.WriteLine("6. Volver");

            Console.Write("\nRespuesta: ");

            var opciones = Convert.ToInt32(Console.ReadLine());
            switch (opciones)
            {
                case 1:
                    ArticuloStock.CrearArticuloStock();
                    break;
                case 2:
                    //ArticuloStock.TraerArticuloStocks();
                    break;
                case 3:
                    //ArticuloStock.BuscarArticuloStocks();
                    break;
                case 4:
                    //ArticuloStock.ModificarArticuloStock();
                    break;
                case 5:
                    //ArticuloStock.EliminarArticuloStock();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Por favor, eliga una opcion");
                    break;
            }
        }
    }
}