using tiendita.almacen;

namespace tiendita.Funciones
{
    public class Operaciones
    {
        //Metododos para gestionar todos los datos de la tiendita

        //funcion para ingresar productos
        public static void insertarProductos()
        {
            int cantidad;
            while (true)
            {
                Console.Clear();
                //Funcion para insertar todos los productos a la tiendita
                Console.WriteLine("si desea volver al menu principal escriba SI");
                //insertamos el nombre del producto
                Console.WriteLine("\nRegistro de nuevos productos");
                Console.WriteLine("Ingrese el nombre del producto");
                Console.WriteLine("Nombre del producto: ");
                string nombreProducto = Console.ReadLine().Trim().ToUpper();
                //Metodo para salir del menu de registro de productos
                if (nombreProducto == "SI")
                {
                    break;
                }
                //si inserta un valor vacio
                while (nombreProducto.Length == 0 )
                {
                    Console.WriteLine("No puede dejar el campo vacio");
                    nombreProducto = Console.ReadLine().Trim().ToUpper();
                }
                //validamos que el producto no exista
                if (Data.Productos.Contains(nombreProducto))
                {
                    Console.WriteLine("Error: El producto ya existe en la lista.");
                    Console.ReadKey();
                    continue;
                }
                else
                
                {
                    //ingresamos la cantidad y validamos
                    Console.WriteLine("Ingrese la cantidad del producto");
                    Console.Write("Cantidad: ");
                    while (!int.TryParse(Console.ReadLine().Trim(), out cantidad) || cantidad <= 0)
                    {
                        Console.WriteLine("Error: el numero no puede ser menor a cero ni tener letras");      
                    }
                }                    
                //validamos de que el usuario no deje el campo vacio y que sea numero
                double precioU;
                System.Console.Write("Precio unitario: ");
                while (!double.TryParse(Console.ReadLine().Trim(), out precioU) || precioU <= 0)
                {
                     Console.WriteLine("Error: el numero no puede ser menor a cero ni tener letras");
                }
                //agregamos los datos a las listas
                Data.Productos.Add(nombreProducto);
                Data.Stock.Add(cantidad);
                Data.precio.Add(precioU);
                guardarDatos();
                Console.WriteLine("Presione cualquier tecla para volver a registra otro.....");
                Console.ReadKey();
            }
        }
        
        //Funcion para sumar un stock si vienen 20 productos se suman no se sobrescriben
        public static void sumarStock()
        {
            while (true)
            {   
                Console.Clear();
                Console.WriteLine("Ingrese el nombre del producto para ingresar el stock\no 'SI' para volver al menu");
                //Listamos los productos
                obtenerProductos();
                //ingresamos el nombre del producto
                Console.Write("Nombre del producto: ");
                string nombreProducto = Console.ReadLine().Trim().ToUpper();
                if (nombreProducto == "SI")
                {
                    break;
                }
                else if (nombreProducto.Length == 0)
                {
                    Console.WriteLine("No puede dejar el campo producto vacio.");
                    continue;
                }
                if (Data.Productos.IndexOf(nombreProducto) == -1)
                {
                    Console.WriteLine("Este producto no existe ingrese uno valido");
                    Console.ReadKey();
                    continue;
                }
                int cantidad;
                //agregamos la cantidad
                Console.WriteLine("Inserte la cantidad del producto nuevo");
                Console.WriteLine("Cantidad a sumar: ");
                while(!int.TryParse(Console.ReadLine().Trim(), out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Error: el numero no puede ser menor a cero ni tener letras");
                }
            
                int indice = Data.Productos.IndexOf(nombreProducto);
                if (indice >= 0)
                {
                    Data.Stock[indice] += cantidad;
                    guardarDatos();
                    Console.WriteLine("¡Stock actualizado!");
                    Console.ReadKey();
                }
            }
        }

        //Si se requiere actualizar stock manualmente.
        public static void actualizarStock() //hay que arreglarlo
        {
           while (true)
            {   
                Console.Clear();
                Console.WriteLine("Ingrese el nombre del producto para modificar el stock\no 'SI' para volver al menu");
                //Listamos los productos
                obtenerProductos();
                //ingresamos el nombre del producto
                Console.Write("Nombre del producto: ");
                string nombreProducto = Console.ReadLine().Trim().ToUpper();
                if (nombreProducto == "SI")
                {
                    break;
                }
                else if (nombreProducto.Length == 0)
                {
                    Console.WriteLine("No puede dejar el campo producto vacio.");
                    continue;
                }
                if (Data.Productos.IndexOf(nombreProducto) == -1)
                {
                    Console.WriteLine("Este producto no existe ingrese uno valido");
                    Console.ReadKey();
                    continue;
                }
                int cantidad;
                //agregamos la cantidad
                Console.WriteLine("Inserte la cantidad del producto nuevo");
                Console.WriteLine("Cantidad a establecer: ");
                while(!int.TryParse(Console.ReadLine().Trim(), out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Error: el numero no puede ser menor a cero ni tener letras");
                }
            
                int indice = Data.Productos.IndexOf(nombreProducto);
                if (indice >= 0)
                {
                    Data.Stock[indice] = cantidad;
                    guardarDatos();
                    Console.WriteLine("¡Stock actualizado!");
                    Console.ReadKey();
                }
            }
        }
            
        //Funcion para eliminar productos
        public static void eliminaraProducto()
        {
            while (true)
            {
                Console.WriteLine("Elija el producto que desea eliminar");
                Console.WriteLine("Si desea volver al menu principal escriba SI");
                obtenerProductos();
                Console.WriteLine("Producto a eliminar: ");
                string nombreProducto = Console.ReadLine().Trim().ToUpper();
                if (nombreProducto == "SI")
                {
                    break;  
                } 

                while (nombreProducto.Length == 0)
                {
                    Console.WriteLine("Error: No puede dejar el campo producto vacio");
                    nombreProducto = Console.ReadLine().Trim().ToUpper();
                }
                bool resultado = Data.Productos.Contains(nombreProducto) == true; 
                if (resultado)
                {           
                    int indice = Data.Productos.IndexOf(nombreProducto);
                    if (indice >= 0)
                    {
                        Data.Productos.RemoveAt(indice);
                        Data.Stock.RemoveAt(indice);
                        Data.precio.RemoveAt(indice);
                        Console.WriteLine("Producto eliminado con exito"); 
                        guardarDatos();
                        Console.ReadKey();
                    }
                }       
                else
                {
                Console.WriteLine("El producto no existe");
                }
            }
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
                Console.WriteLine($"{"Producto",-15} {"Cantidad",-10}");
                for (int i = 0; i < Data.Stock.Count; i++)
                {
                    if (Data.Stock[i] <= 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{Data.Productos[i],-15} {Data.Stock[i],-10:N0}");
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
        public static void generarVentas()
        {
            Data.carritoProductos.Clear();
            Data.carritoCantidades.Clear();
            Data.carritosubtotales.Clear();
            Console.Clear();
            string nombreProducto;
            while (true)
            {
                Console.WriteLine("--------Generar ventas-------");
                Console.WriteLine("Escriba el nombre del producto (o SI para salir)");
                do
                {
                    alertaStock();
                    obtenerProductos();
                    Console.WriteLine("Nombre del producto: ");
                    nombreProducto = Console.ReadLine().Trim().ToUpper();

                    if (nombreProducto == "SI")
                    {
                        break;
                    }

                    int indice = Data.Productos.IndexOf(nombreProducto);
                    if (indice == -1)
                    {
                        Console.WriteLine("El producto no existe");
                        Console.ReadKey();
                        continue;
                    }
                    Console.WriteLine($"Precio: {Data.precio[indice]:C2} | cantidad disponible: {Data.Stock[indice]:N0}");
                    Console.WriteLine("\nSelecciona la cantidad a vender");
                    Console.Write("Cantidad: ");              
                    if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                    {
                        if (Data.Stock[indice] >= cantidad)
                        {
                            double subtotal = Data.precio[indice] * cantidad;
                            Data.carritoProductos.Add(Data.Productos[indice]);
                            Data.carritoCantidades.Add(cantidad);
                            Data.carritosubtotales.Add(subtotal);
                            Data.Stock[indice] -= cantidad;
                            Console.WriteLine("Agregado al carrito");
                        }
                        else
                        {
                            Console.WriteLine("Error: no hay stock suficiente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: cantidad inválida");
                    }
                    Console.WriteLine("Si desea finalizar la venta escriba SI, si desea agregar otro producto presione enter");
                    nombreProducto = Console.ReadLine().Trim().ToUpper();
                }while (nombreProducto != "SI");    

                if (Data.carritoProductos.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("-------factura de venta-------");
                    Console.WriteLine($"{"Producto",-10} {"Cantidad",-10} {"Subtotal",-10}");
                    Console.WriteLine($"Fecha: {DateTime.Now: dd/MM/yyyy HH:mm:ss}");
                    Console.WriteLine($"{"Cant":,-7} {"Precio":,-20} {"Subtotal":,-10}");
                    double totalFinal = 0;
                    for (int i = 0; i < Data.carritoProductos.Count; i++)
                    {
                        Console.WriteLine($"{Data.carritoProductos[i],-20} {Data.carritoCantidades[i],-7:N0} {Data.carritosubtotales[i],-10:C2}");
                        totalFinal += Data.carritosubtotales[i];
                    }
                    Console.WriteLine($"\nTotal a pagar: {totalFinal:C2}\n");
                    guardarDatos();
                }
                else
                {
                    Console.WriteLine("No se ha realizado ninguna venta"); Console.ReadKey();
                }
                Console.WriteLine("Si desea volver al menu principal escriba MENU, o presione enter para realizar otra venta");
                string respuestaU = Console.ReadLine().Trim().ToUpper();
                if (respuestaU == "MENU")
                {
                    break;
                }
            }

        }
       
         //funcion para buscar productos
        public static void buscarProducto()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------Buscar productos----------------");
                Console.WriteLine("Ingrese el nombre del producto a buscar o si para salir");
                string nombreProducto = Console.ReadLine().Trim().ToUpper();
                if (nombreProducto == "SI")
                {
                    break;
                }
                while (nombreProducto.Length == 0)
                {
                    Console.WriteLine("No puede dejar el campo producto vacio");
                    nombreProducto = Console.ReadLine().Trim().ToUpper();
                } 
                int indice = Data.Productos.IndexOf(nombreProducto);
                if (indice >= 0)
                {
                    Console.WriteLine($"Producto encontrado: {Data.Productos[indice]} | Cantidad: {Data.Stock[indice]:N0} | Precio: {Data.precio[indice]:C2}");
                }
                else
                {
                    Console.WriteLine($"El producto {nombreProducto} no existe en el inventario");
                }
                Console.WriteLine("\nPresione cualquier tecla para buscar otro producto o volver al menu principal");
                Console.ReadKey();
            }
        }

        //funcion para guardar los datos en el archivo de texto
        public static void guardarDatos()
        {
            using (StreamWriter writer = new StreamWriter("inventario.txt"))
            {
                for (int i = 0; i < Data.Productos.Count; i++)
                {
                    writer.WriteLine($"Producto: {Data.Productos[i]}, Cantidad: {Data.Stock[i]}, Precio: {Data.precio[i]}");
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