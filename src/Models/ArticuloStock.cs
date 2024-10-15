namespace src.Models;

class ArticuloStock
{
    private Articulo articulo;
    private int cantidad;

    public ArticuloStock(Articulo articulo, int cantidad)
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
}
