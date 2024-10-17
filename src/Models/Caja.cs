namespace src.Models;

public class Caja
{
    public int Numero { get; set; }
    public List<Venta> ListaVenta { get; set; } = [];
    public Caja(int numero)
    {
        Numero = numero;
    }
}
