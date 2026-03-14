using tiendita.almacen;

namespace tiendita.inventario
{
    public class Operaciones
    {
        //Metododos para gestionar todos los datos de la tiendita

        //funcion para ingresar productos
        public static string insertarProductos(string nombreProducto, int cantidad, double precioU)
        {
            //Guardamso la informacion
            Data.Productos.Add(nombreProducto);
            Data.Stock.Add(cantidad);
            Data.precio.Add(precioU);
            return ("Producto registrado con exito");
        }

        //Funcion para sumar un stock si vienen 20 productos se suman no se sobrescriben
        public static string sumarStock(string nombreProducto, int cantidad)
        {
            int indice = Data.Productos.IndexOf(nombreProducto);
            if (indice > 0)
            {
                Data.Stock[indice] += (cantidad);
            }
            return ("¡Ingreso procesado!");   
        }

        //Si se requiere actualizar stock manualmente.
        public static string actualizarStock(string nombreProducto, int cantidad)
        {
            
            int indice = Data.Productos.IndexOf(nombreProducto);
            if (indice > 0)
            {
                Data.Stock[indice] = (cantidad);
            }   
            return ("¡Ajustes realizado!");
        } 
            
        //Funcion para eliminar productos
        public static bool eliminaraProducto(string nombreProducto)
        {
            int indice = Data.Productos.IndexOf(nombreProducto);
            if (indice >= 0)
            {
                Data.Productos.RemoveAt(indice);
                Data.Stock.RemoveAt(indice);
                Data.precio.RemoveAt(indice);
                Console.WriteLine("Producto eliminado con exito");
                return true;
            }
            Console.WriteLine("El producto no existe");
            return false;
        }

        //Aviso si el stock esta en el minimo permitido
        public static void alertaStock()
        {
            bool alertaStock = false;
            foreach (int cantidad in Data.Stock)
            {
                if (cantidad <= 5)
                {
                    alertaStock = true;
                }
            }
            if (alertaStock)
            {
                Console.WriteLine("¡Alerta stock baja!");
                Console.WriteLine($"{"ID",-5} {"Producto",-15} {"Cantidad",-10}");
                for (int i = 0; i < Data.Stock.Count; i++)
                {
                    if (Data.Stock[i] <= 5)
                    {
                        Console.WriteLine($"{i + 1,-5} {Data.Productos[i],-15} {Data.Stock[i],-10:N0}");
                    }
                }
                Console.WriteLine("La cantidad del producto es minima se recomienda reabastecer");
            }
        }

        //Metodo para obteber productos
        public static void obtenerProductos()
        {
            Console.WriteLine($"{"ID",-5} {"Producto",-15} {"Cantidad",-10:N0} {"Precio",-10:C2}");
            for (int i = 0; i < Data.Stock.Count; i++)
            {
                Console.WriteLine($"{i+1,-5} {Data.Productos[i],-15} {Data.Stock[i],-10:N0} {Data.precio[i],-10:C2}");
            }
        }    

        //funcion para generar ventas    
        public static double generarVentas(int indice, int cantidad)
        {
            Data.Stock[indice] -= cantidad;

            double total = Data.precio[indice] * cantidad;

            return total;
        }
    }
}