using tiendita.almacen;
using tiendita.inventario;

//Menu principal con lo que el usuario interactua con el sistema
namespace tiendita.menu
{
    public class Menu
    {
        public static void tMenu()
        {
            string accion = "";
            Console.WriteLine("");
            do
            {
                Console.Clear();
                Console.WriteLine("------------------La tiendita-----------------");
                Console.WriteLine("  [A]   NUEVO INGRESO    │  [D]  ELIMINAR PRODUCTO");
                Console.WriteLine("  [B]   VER INVENTARIO   │  [E]      GENERAR VENTA");
                Console.WriteLine("  [C]   AJUSTAR STOCK    │  [S]             SALIR");
                Console.WriteLine("Seleccione una accion");
                accion = Console.ReadLine().Trim().ToUpper();

                switch (accion)
                {
                    case "A":
                            insertarProductos();
                        break;

                    case "B":
                            Operaciones.obtenerProductos();
                            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
                            Console.ReadKey();
                        break;

                    case "C":
                        Console.WriteLine("Elija una opcion \n1: Modificar stock \n2: actualizar stock");
                        int opcionU = int.Parse(Console.ReadLine());
                        if (opcionU == 1)
                        {
                            actualizarStock();
                        }
                        else
                        {
                            sumarStock();
                        }
                        break;

                    case "D":
                            eliminaraProducto();
                        break;

                    case "E":
                            Operaciones.alertaStock();
                            generarVentas();
                        break;

                    case "S":
                            Console.WriteLine("Haz salido del programa");
                        break;

                    default:
                            Console.WriteLine("Opcion no valida");
                        break;
                }
            }while (accion != "S");
        }
        static void insertarProductos()
        {
             while (true)
            {
                //Funcion para insertar todos los productos a la tiendita
                Console.WriteLine("si desea volver al menu principal escriba SI");
                //insertamos el nombre del producto
                Console.WriteLine("\nRegistro de nuevos productos");
                Console.WriteLine("Ingrese el nombre del producto");
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
                    continue;
                }
                else
                {
                    //ingresamos la cantidad y validamos
                    
                    int cantidad = 0;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Ingresa la cantidad del producto");
                            cantidad = int.Parse(Console.ReadLine().Trim());
                            if (cantidad > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error: el numero no puede ser menor a cero");
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error: no puede dejar el campo vacio o ingresar letras");
                        }
                    }                    
                    //validamos de que el usuario no deje el campo vacio o que sea numero
                    double precioU = 0;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Ingrese el precio del producto");
                            precioU = int.Parse(Console.ReadLine().Trim());
                            if (precioU > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error: el numero no puede ser menor a cero");
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error: no puede dejar el campo vacio o ingresar letras");
                        }
                    }
                }
            }
        }
        static void sumarStock()
        {
            string nombreProducto;
            while (true)
            {   
                Operaciones.alertaStock();
                Console.WriteLine("Ingrese el nombre del producto o SI para volver al menu");
                //Listamos los productos
                Operaciones.obtenerProductos();
                //ingresamos el nombre del producto
                nombreProducto = Console.ReadLine().Trim().ToUpper();
                if (nombreProducto == "SI")
                {
                    break;
                }
                else if (nombreProducto == "")
                {
                    Console.WriteLine("No puede dejar el campo producto vacio.");
                    continue;
                }
                if (Data.Productos.IndexOf(nombreProducto) == -1)
                {
                    Console.WriteLine("Este producto no existe ingrese uno valido");
                    continue;
                }
                int cantidad = 0;
                while (true)
                {
                    try
                    {
                        //agregamos la cantidad
                        Console.WriteLine("Inserte la cantidad del producto nuevo");
                        cantidad = int.Parse(Console.ReadLine().Trim());
                        //validamos que la cantidad sea mayor a cero
                        if (cantidad > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: La cantidad debe ser mayor a cero");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error: no puede ingresar letras o dejar el campo vacio.");
                    }
                }
            }     
        }
        static void actualizarStock()
        {
            string nombreProducto;
            while (true)
            {   
                Operaciones.alertaStock();
                Console.WriteLine("Ingrese el nombre del producto o SI para volver al menu");
                //Listamos los productos
                Operaciones.obtenerProductos();
                //ingresamos el nombre del producto
                nombreProducto = Console.ReadLine().Trim().ToUpper();
                if (nombreProducto == "SI")
                {
                    break;
                }
                else if (nombreProducto == "")
                {
                    Console.WriteLine("No puede dejar el campo producto vacio.");
                    continue;
                }
                if (Data.Productos.IndexOf(nombreProducto) == -1)
                {
                    Console.WriteLine("Este producto no existe ingrese uno valido");
                    continue;
                }
                //agregamos la cantidaf
                Console.WriteLine("Inserte la cantidad del producto nuevo");
                int cantidad = 0;
                while (true)
                {
                    try
                    {
                        cantidad = int.Parse(Console.ReadLine().Trim());
                        //validamos que la cantidad sea mayor a cero
                        if (cantidad > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: el precio debe ser mayor a cero");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error: no puede ingresar letras o dejar el campo vacio.");
                    }
                }
            }
        }
        static void eliminaraProducto()
        {
            Operaciones.obtenerProductos();
            Console.WriteLine("Elija el producto que desea eliminar");
            string nombreProducto = Console.ReadLine().Trim().ToUpper();
            while (nombreProducto.Length < 0)
            {
                Console.WriteLine("Error: No puede dejar el campo producto vacio");
                nombreProducto = Console.ReadLine().Trim().ToUpper();
            }
        }
        static void generarVentas()
        {
            Data.carritoProductos.Clear();
            Data.carritoCantidades.Clear();
            Data.carritosubtotales.Clear();
            while (true)
            {
                Operaciones.alertaStock();
                Console.WriteLine("--------Generar ventas-------");
                Console.WriteLine("Escriba el nombre del producto (o SI para salir)");
                Operaciones.obtenerProductos();
                string nombreProducto = Console.ReadLine().Trim().ToUpper();
                if (nombreProducto == "SI")
                {
                    break;
                }
                int indice = Data.Productos.IndexOf(nombreProducto);
                if (indice == -1)
                {
                    Console.WriteLine("El producto no existe");
                }
                Console.WriteLine($"Precio: {Data.precio[indice]:C2} | cantidad disponible: {Data.Stock[indice]:N0}");
                Console.WriteLine("Selecciona la cantidad a vender");               
                if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                {
                    if (Data.Stock[indice] >= cantidad)
                    {
                        double totalVenta = Operaciones.generarVentas(indice, cantidad);
                        Console.Clear();
                        Console.WriteLine("******************RECIBO DE VENTAS******************");
                        Console.WriteLine($"Fecha: {DateTime.Now:Now:dd/MM/yyyy}");
                        Console.WriteLine($"Hora: {DateTime.Now:hh/mm/ss}");
                        Console.WriteLine("**************************************");
                        Console.WriteLine($"Productos: {Data.Productos[indice]}");
                        Console.WriteLine($"Cantidad: {cantidad:N0}");
                        Console.WriteLine($"precio unitario: {Data.precio[indice]:C2}");
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine($"TOTAL: {totalVenta:C2}");
                        Console.WriteLine("Presione una tecla para contibuar");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Error: no hay stock suficiente");
                }
            }    
        }
    }
}