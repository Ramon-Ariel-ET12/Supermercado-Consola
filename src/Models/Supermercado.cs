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

        context.Database.ExecuteSqlRaw("DELETE FROM articulos;DELETE FROM articulostocks");
        for (int i = 1; i <= 5; i++)
        {
            VectorCaja.Add(new(i));
        }
        context.SaveChanges();
        Console.WriteLine("Espacio reservado!");
    }

    public void GestionarArticulo()
    {
        while (true)
        {
            Console.WriteLine("\n1. Buscar articulos");
            Console.WriteLine("2. Traer todos los articulos");
            Console.WriteLine("3. Modificar articulos");
            Console.WriteLine("4. Crear articulo");
            Console.WriteLine("5. Eliminar articulos");
            Console.WriteLine("6. Volver");

            Console.Write("\nRespuesta: ");

            var opciones = Convert.ToInt32(Console.ReadLine());
            switch (opciones)
            {
                case 1:
                    Articulo.BuscarArticulo();
                    break;
                case 4:
                    Articulo.CrearArticulo();
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