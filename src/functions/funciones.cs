using tiendita.almacen;

namespace tiendita.Funciones
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
            if (indice >= 0)
            {
                Data.Stock[indice] += (cantidad);

                guardarDatos();
                return ("¡Stock actualizado!"); 
            }
            return ("El producto no existe");
        }
        
        //Si se requiere actualizar stock manualmente.
        public static string actualizarStock(string nombreProducto, int cantidad)
        {
            
            int indice = Data.Productos.IndexOf(nombreProducto);
            if (indice >= 0)
            {
                Data.Stock[indice] = (cantidad);
            }
            guardarDatos();
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
                guardarDatos();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"¡ALERTA !{i + 1,-5} {Data.Productos[i]} {Data.Stock[i]}");
                        Console.ResetColor();
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

            guardarDatos();
            return total;
        }
       
       //funcion para buscar productos
        public static void buscarProducto(string nombreProducto)
        {
            int indice = Data.Productos.IndexOf(nombreProducto);
            if (indice >= 0)
            {
                Console.WriteLine($"Producto encontrado: {Data.Productos[indice]} | Cantidad: {Data.Stock[indice]:N0} | Precio: {Data.precio[indice]:C2}");
            }
            else
            {
                Console.WriteLine("El producto no existe");
            }
        }

        //funcion para guardar los datos en el archivo de texto
        public static void guardarDatos()
        {
            using (StreamWriter writer = new StreamWriter("inventario.txt"))
            {
                for (int i = 0; i < Data.Productos.Count; i++)
                {
                    writer.WriteLine($"{Data.Productos[i]},{Data.Stock[i]},{Data.precio[i]}");
                }
            }
        }

        public static void cargarDatos()
        {
            if (File.Exists("inventario.txt"))
            {
                Data.Productos.Clear();
                Data.Stock.Clear();
                Data.precio.Clear();

                string[] lineas = File.ReadAllLines("inventario.txt");
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(',');
                    if (partes.Length == 3)
                    {
                        Data.Productos.Add(partes[0]);
                        Data.Stock.Add(int.Parse(partes[1]));
                        Data.precio.Add(double.Parse(partes[2]));
                    }
                }
            }
        }   
    }
}