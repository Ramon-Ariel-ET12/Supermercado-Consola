using src.Persistence;

namespace src.Models;

public class ArticuloStock
{
    public int IdArticuloStock { get; set; }
    public Articulo Articulo { get; set; }
    public int Cantidad { get; set; }

}
