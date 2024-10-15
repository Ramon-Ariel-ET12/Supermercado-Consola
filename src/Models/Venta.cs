namespace src.Models;

class Venta
{
    private int nroTicket;
    private DateTime fecha;
    private List <ArticuloVenta> listaArticuloVenta;

    public Venta(int nroTicket, DateTime fecha)
    {
        this.nroTicket = nroTicket;
        this.fecha = fecha;

        this.listaArticuloVenta = new List<ArticuloVenta>(); ;
    }

    public int NRO_TICKET
    {
        get { return this.nroTicket; }
    }

    public DateTime FECHA
    {
        get { return this.fecha; }
    }

    public double MONTO
    {
        get { return this.CalcularMonto(); }
    }

    public List <ArticuloVenta> LISTA_ARTICULO_VENTA
    {
        get { return this.listaArticuloVenta; }
    }

    private double CalcularMonto()
    {
        double monto;


        monto = 0.0;

        foreach (ArticuloVenta articuloVenta in listaArticuloVenta)
        {
            monto += articuloVenta.MONTO;
        }

        return monto;
    }
}
