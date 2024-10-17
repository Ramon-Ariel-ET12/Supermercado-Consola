namespace src.Models;

public class Venta
{
    public int IdVenta { get; set; }
    public int NroTicket { get; set; }
    public DateTime Fecha { get; set; }
    public List<ArticuloVenta> ListaArticuloVenta { get; set; } = [];
}
