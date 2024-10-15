namespace src.Models;

class ArticuloVenta
{
    private Articulo articulo;
    private int cantidad;

    public ArticuloVenta(Articulo articulo, int cantidad)
    {
        this.articulo = articulo;
        this.cantidad = cantidad;
    }

    public Articulo ARTICULO
    {
        get { return this.articulo; }
    }

    public int CANTIDAD
    {
        get { return this.cantidad; }
        set { this.cantidad = value; }
    }

    public double MONTO
    {
        get { return this.CalcularMonto();}
    }

    private double CalcularMonto()
    {
        return this.articulo.PRECIO * this.cantidad;
    }
}
