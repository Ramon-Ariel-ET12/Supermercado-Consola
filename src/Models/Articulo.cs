namespace src.Models;

class Articulo
{
    private int codigo;
    private string nombre;
    private double precio;

    public Articulo(int codigo)
    {
        this.codigo = codigo;
    }

    public Articulo(int codigo, string nombre)
    {
        this.codigo = codigo;
        this.nombre = nombre;
    }
    public Articulo(int codigo, double precio)
    {
        this.codigo = codigo;
        this.precio = precio;
    }

    public Articulo(int codigo, string nombre, double precio)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.precio = precio;
    }

    public int CODIGO
    {
        get { return this.codigo; }
    }

    public string NOMBRE
    {
        get { return this.nombre; }
        set { this.nombre = value; }
    }

    public double PRECIO
    {
        get { return this.precio; }
        set { this.precio = value; }
    }
}
