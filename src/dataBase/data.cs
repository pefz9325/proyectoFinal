namespace tiendita.almacen
{
    public class Data
    {
        ///Estas listas representan la base de datos estos datos son de persistencia
        public static List<string> Productos = new List<string>();
        public static List<int> Stock = new List<int>();
        public static List<double> precio = new List<double>();

        //listas para el carrito de compras son datos temporales para almacenar los productos que el cliente desea comprar
        public static List<string> carritoProductos = new List<string>();
        public static List<int> carritoCantidades = new List<int>();
        public static List<double> carritosubtotales = new List<double>();
    }
}