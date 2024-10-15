namespace src.Models;

class Supermercado
{
    private const int CAJAS = 5;
    private string nombre;
    private string direccion;
    private List <Articulo> listaArticulo;
    private List <ArticuloStock> listaArticuloStock;
    private Caja [] vectorCaja;

    private void ReservarEspacioMemoria()
    {
        this.listaArticulo = new List <Articulo> ();
        this.listaArticuloStock = new List <ArticuloStock> ();

        this.vectorCaja = new Caja[CAJAS];

        for (int caja = 0 ; caja < CAJAS ; caja++)
        {
            this.vectorCaja[caja] = new Caja(caja + 1);
        }

        return;
    }

    public Supermercado()
    {
        this.ReservarEspacioMemoria();
    }

    public Supermercado(string nombre, string direccion)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.ReservarEspacioMemoria();
    }

    public string NOMBRE
    {
        get { return this.nombre; }
        set { this.nombre = value; }
    }

    public string DIRECCION
    {
        get { return this.direccion; }
        set { this.direccion = value; }
    }
    public List<Articulo> LISTA_ARTICULO
    {
        get { return this.listaArticulo; }
    }

    public List<ArticuloStock> LISTA_ARTICULO_STOCK
    {
        get { return this.listaArticuloStock; }
    }

    public Caja [] VECTOR_CAJA
    {
        get { return this.vectorCaja; }
    }

    public Articulo BuscarArticulo(int codigo)
    {
        foreach (Articulo articulo in this.listaArticulo)
        {
            if (articulo.CODIGO == codigo)
            {
                return articulo;
            }
        }

        return null;
    }
    
    public Articulo BuscarArticulo(string nombre)
    {
        foreach (Articulo articulo in this.listaArticulo)
        {
            if (articulo.NOMBRE == nombre)
            {
                return articulo;
            }
        }

        return null;
    }

    public ArticuloStock BuscarArticuloStock(Articulo articulo)
    {
        foreach (ArticuloStock articuloStock in this.listaArticuloStock)
        {
            if (articuloStock.ARTICULO == articulo)
            {
                return articuloStock;
            }
        }

        return null;
    }

    public ArticuloStock BuscarArticuloStock(string nombre)
    {
        Articulo articulo;

        articulo = this.BuscarArticulo(nombre);

        if (articulo != null)
        {
            foreach (ArticuloStock articuloStock in this.listaArticuloStock)
            {
                if (articuloStock.ARTICULO == articulo)
                {
                    return articuloStock;
                }
            }
        }

        return null;
    }

    public void IngresarListaArticulo()
    {
        this.IngresarListaArticuloEstatico();

        return;
    }

    public void IngresarListaArticuloDinamico()
    {
        int codigo;
        string nombre;
        double precio;
        Articulo articulo;
        int cantidad;
        ArticuloStock articuloStock;
        Boolean fin;
        char continua;

        fin = true;
        Console.WriteLine("Ingresar los datos del articulo\n");
        
        do
        {
            Console.Write("Ingrese codigo: ");
            codigo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese nombre: ");
            nombre = Console.ReadLine();

            Console.Write("Ingrese precio: ");
            precio = Convert.ToDouble(Console.ReadLine());

            articulo = new Articulo(codigo, nombre, precio);

            this.listaArticulo.Add(articulo);

            Console.Write("Ingrese cantidad: ");
            cantidad = Convert.ToInt32(Console.ReadLine());

            articuloStock = new ArticuloStock(articulo, cantidad);

            this.listaArticuloStock.Add(articuloStock);

            Console.Write("Continua (S/N): ");
            continua = Convert.ToChar(Console.ReadLine());

            if ((continua == 'N') || (continua == 'n'))
            {
                fin = false;
            }

        } while (fin == true);

        return;
    }

    public void IngresarListaArticuloEstatico()
    {
        int codigo;
        string nombre;
        double precio;
        Articulo articulo;
        int cantidad;
        ArticuloStock articuloStock;

        codigo = 2323;
        nombre = "Leche";
        precio = Convert.ToDouble("63,14");

        articulo = new Articulo(codigo, nombre, precio);

        this.listaArticulo.Add(articulo);

        cantidad = 30;

        articuloStock = new ArticuloStock(articulo, cantidad);

        this.listaArticuloStock.Add(articuloStock);

        codigo = 4545;
        nombre = "Manteca";
        precio = Convert.ToDouble("87,23");

        articulo = new Articulo(codigo, nombre, precio);

        this.listaArticulo.Add(articulo);

        cantidad = 45;

        articuloStock = new ArticuloStock(articulo, cantidad);

        this.listaArticuloStock.Add(articuloStock);

        codigo = 1212;
        nombre = "Jugo";
        precio = Convert.ToDouble("52,28");

        articulo = new Articulo(codigo, nombre, precio);

        this.listaArticulo.Add(articulo);

        cantidad = 92;

        articuloStock = new ArticuloStock(articulo, cantidad);

        this.listaArticuloStock.Add(articuloStock);
        
        return;
    }

    public void IngresarVentaDia()
    {
        this.IngresarArticuloVentaDiaEstatico();

        return;
    }

    public void IngresarArticuloVentaDiaDinamico()
    {
        int nroTicket;
        int dd;
        string dia;
        int mm; 
        string mes;
        int aa;
        string anio;
        DateTime fecha;
        string ff;
        Venta venta;
        string nombre;
        int caja;
        int cantidad;
        Articulo articulo;
        ArticuloStock articuloStock;
        ArticuloVenta articuloVenta;
        Boolean fin;
        char continua;

        fin = true;
        Console.WriteLine("Ingresar los datos de la venta\n");

        do
        {
            Console.Write("Ingrese nroTicket: ");
            nroTicket = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese dia: ");
            dd = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese mes: ");
            mm = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese año: ");
            aa = Convert.ToInt32(Console.ReadLine());
            
            dia = Convert.ToString(dd);
            mes = Convert.ToString(mm);
            anio = Convert.ToString(aa);

            ff = dia + "/" + mes + "/" + anio;

            fecha = Convert.ToDateTime(ff);

            venta = new Venta(nroTicket, fecha);

            Console.Write("Ingrese articulo: ");
            nombre = Console.ReadLine();

            articulo = this.BuscarArticulo(nombre);

            if (articulo != null)
            {
                articuloStock = this.BuscarArticuloStock(articulo);

                if (articuloStock != null)
                {
                    Console.Write("Ingrese numero de caja: ");
                    caja = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese cantidad del articulo: ");
                    cantidad = Convert.ToInt32(Console.ReadLine()); 
                    
                    articuloStock.CANTIDAD -= cantidad;

                    articuloVenta = new ArticuloVenta(articulo, cantidad);

                    venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                    this.vectorCaja[caja - 1].LISTA_VENTA.Add(venta);
                }
            }

            Console.Write("Continua (S/N): ");
            continua = Convert.ToChar(Console.ReadLine());

            if ((continua == 'N') || (continua == 'n'))
            {
                fin = false;
            }

        } while (fin == true);

        return;
    }

    public void IngresarArticuloVentaDiaEstatico()
    {
        int nroTicket;
        DateTime fecha;
        Venta venta;
        int caja;
        int cantidad;
        Articulo articulo;
        ArticuloStock articuloStock;
        ArticuloVenta articuloVenta;

        caja = 1;
        nroTicket = 34262;
        fecha = Convert.ToDateTime("15/08/2019");

        venta = new Venta(nroTicket, fecha);

        articulo = this.BuscarArticulo("Leche");

        if (articulo != null)
        {
            articuloStock = this.BuscarArticuloStock(articulo);

            if (articuloStock != null)
            {
                cantidad = 3;

                articuloStock.CANTIDAD -= cantidad;

                articuloVenta = new ArticuloVenta(articulo, cantidad);

                venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                articulo = this.BuscarArticulo("Manteca");

                if (articulo != null)
                {
                    articuloStock = this.BuscarArticuloStock(articulo);

                    if (articuloStock != null)
                    {
                        cantidad = 2;

                        articuloStock.CANTIDAD -= cantidad;

                        articuloVenta = new ArticuloVenta(articulo, cantidad);

                        venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                        this.vectorCaja[caja - 1].LISTA_VENTA.Add(venta);
                    }
                }
            }
        }

        nroTicket = 5421;
        fecha = Convert.ToDateTime("15/08/2019");

        venta = new Venta(nroTicket, fecha);

        articulo = this.BuscarArticulo("Leche");

        if (articulo != null)
        {
            articuloStock = this.BuscarArticuloStock(articulo);

            if (articuloStock != null)
            {
                caja = 1;
                cantidad = 2;

                articuloStock.CANTIDAD -= cantidad;

                articuloVenta = new ArticuloVenta(articulo, cantidad);

                venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                this.vectorCaja[caja - 1].LISTA_VENTA.Add(venta);
            }
        }

        nroTicket = 1423;
        fecha = Convert.ToDateTime("15/08/2019");

        venta = new Venta(nroTicket, fecha);

        articulo = this.BuscarArticulo("Leche");

        if (articulo != null)
        {
            articuloStock = this.BuscarArticuloStock(articulo);

            if (articuloStock != null)
            {
                caja = 3;
                cantidad = 4;

                articuloStock.CANTIDAD -= cantidad;

                articuloVenta = new ArticuloVenta(articulo, cantidad);

                venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                this.vectorCaja[caja - 1].LISTA_VENTA.Add(venta);
            }
        }

        nroTicket = 978;
        fecha = Convert.ToDateTime("15/08/2019");

        venta = new Venta(nroTicket, fecha);

        articulo = this.BuscarArticulo("Manteca");

        if (articulo != null)
        {
            articuloStock = this.BuscarArticuloStock(articulo);

            if (articuloStock != null)
            {
                caja = 2;
                cantidad = 2;

                articuloStock.CANTIDAD -= cantidad;

                articuloVenta = new ArticuloVenta(articulo, cantidad);

                venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                this.vectorCaja[caja - 1].LISTA_VENTA.Add(venta);
            }
        }

        nroTicket = 1075;
        fecha = Convert.ToDateTime("15/08/2019");

        venta = new Venta(nroTicket, fecha);

        articulo = this.BuscarArticulo("Manteca");

        if (articulo != null)
        {
            articuloStock = this.BuscarArticuloStock(articulo);

            if (articuloStock != null)
            {
                caja = 2;
                cantidad = 1;

                articuloStock.CANTIDAD -= cantidad;

                articuloVenta = new ArticuloVenta(articulo, cantidad);

                venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                this.vectorCaja[caja - 1].LISTA_VENTA.Add(venta);
            }
        }

        nroTicket = 1123;
        fecha = Convert.ToDateTime("15/08/2019");

        venta = new Venta(nroTicket, fecha);

        articulo = this.BuscarArticulo("Manteca");

        if (articulo != null)
        {
            articuloStock = this.BuscarArticuloStock(articulo);

            if (articuloStock != null)
            {
                caja = 4;
                cantidad = 2;

                articuloStock.CANTIDAD -= cantidad;

                articuloVenta = new ArticuloVenta(articulo, cantidad);

                venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                this.vectorCaja[caja - 1].LISTA_VENTA.Add(venta);
            }
        }

        nroTicket = 1251;
        fecha = Convert.ToDateTime("15/08/2019");

        venta = new Venta(nroTicket, fecha);

        articulo = this.BuscarArticulo("Jugo");

        if (articulo != null)
        {
            articuloStock = this.BuscarArticuloStock(articulo);

            if (articuloStock != null)
            {
                caja = 1;
                cantidad = 2;

                articuloStock.CANTIDAD -= cantidad;

                articuloVenta = new ArticuloVenta(articulo, cantidad);

                venta.LISTA_ARTICULO_VENTA.Add(articuloVenta);

                this.vectorCaja[caja - 1].LISTA_VENTA.Add(venta);
            }
        }

        return;
    }

    public void MostrarListaArticulo()
    {
        Console.WriteLine("");

        foreach (Articulo articulo in this.listaArticulo)
        {
            Console.WriteLine("Codigo: {0} - articulo: {1} - precio: {2:F2} ", articulo.CODIGO, articulo.NOMBRE, articulo.PRECIO);
        }

        return;
    }

    public void MostrarListaArticuloStock()
    {
        Console.WriteLine("");

        foreach (ArticuloStock articuloStock in this.listaArticuloStock)
        {
            Console.WriteLine("Articulo: {0} - cantidad: {1}", articuloStock.ARTICULO.NOMBRE, articuloStock.CANTIDAD);
        }

        return;
    }

    public void MostrarMontoCaja()
    {
        Console.WriteLine("");

        for (int indice = 0 ; indice < CAJAS ; indice++)
        {
            Console.WriteLine("Caja: {0} - monto: {1:F2}", this.vectorCaja[indice].NUMERO, this.vectorCaja[indice].MONTO);
        }

        return;
    }

    public void MostrarCantidadArticuloVendidoCaja()
    {
        int total = 0;

        Console.WriteLine("");

        for (int caja = 0; caja < CAJAS; caja++)
        {
            Console.WriteLine("Caja: {0}", this.vectorCaja[caja].NUMERO);

            foreach (Venta venta in this.vectorCaja[caja].LISTA_VENTA)
            {
                total = 0;

                Console.WriteLine("NroTicket: {0}", venta.NRO_TICKET);

                foreach (ArticuloVenta articuloVenta in venta.LISTA_ARTICULO_VENTA)
                {
                    Console.WriteLine("Articulo: {0} - nombre: {1} - cantidad: {2}", articuloVenta.ARTICULO.CODIGO, articuloVenta.ARTICULO.NOMBRE, articuloVenta.CANTIDAD);

                    total += articuloVenta.CANTIDAD;
                }

                Console.WriteLine("NroTicket: {0} - Cantidad total de articulo: {1}", venta.NRO_TICKET, total);
            }
        }

        return;
    }

    public void MostrarMontoTotal()
    {
        double monto;

        monto = 0.0;

        for (int indice = 0; indice < CAJAS; indice++)
        {
            monto += this.vectorCaja[indice].MONTO;
        }

        Console.WriteLine("");

        Console.WriteLine("Monto Total Supermercado: {0:F2}", monto);

        return;
    }
}
