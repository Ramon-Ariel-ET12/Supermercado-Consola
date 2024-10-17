using src.Persistence;

namespace src.Models;

public class ArticuloVenta
{
    public int IdArticuloVenta { get; set; }
    public Articulo Articulo { get; set; }
    public int Cantidad { get; set; }
    
}
