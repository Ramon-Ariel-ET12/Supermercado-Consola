namespace src.Models;

class Caja
{
    private int numero;
    private List <Venta> listaVenta;

    public Caja(int numero)
    {
        this.numero = numero;

        this.listaVenta = new List <Venta> ();
    }

    public int NUMERO
    {
        get { return this.numero; }
    }

    public double MONTO
    {
        get { return this.CalcularMonto(); }
    }

    public List <Venta> LISTA_VENTA
    {
        get { return this.listaVenta; }
    }

    private double CalcularMonto()
    {
        double monto;
        
        monto = 0.0;

        foreach (Venta venta in listaVenta)
        {
            monto += venta.MONTO;
        }

        return monto;
    }
}
