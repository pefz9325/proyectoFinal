using tiendita.almacen;
using tiendita.Funciones;

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
                Console.WriteLine("  [C]   AJUSTAR STOCK    │  [F]    BUSCAR PRODUCTO");
                Console.WriteLine("             [S]    SALIR DEL PROGRAMA            ");
                Console.WriteLine("Seleccione una accion");
                accion = Console.ReadLine().Trim().ToUpper();

                switch (accion)
                {
                    case "A":
                            insertarProductos();
                            Operaciones.guardarDatos();
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
                            Operaciones.guardarDatos();
                        }
                        else
                        {
                            sumarStock();
                            Operaciones.guardarDatos();
                        }
                        break;

                    case "D":
                            Operaciones.obtenerProductos();
                            eliminaraProducto();
                        break;

                    case "E":
                            Operaciones.alertaStock();
                            generarVentas();
                            Operaciones.guardarDatos();
                        break;
                    case "F":
                            buscarProducto();
                            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
                            Console.ReadKey();
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
        //Esta es la parte interactiva con el usuario para insertar productos a la tiendita
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
                            precioU = double.Parse(Console.ReadLine().Trim());
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
                    //guardamos los productos
                    string respuesta = Operaciones.insertarProductos(nombreProducto, cantidad, precioU);
                    Console.WriteLine(respuesta);
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
                string respuesta = Operaciones.sumarStock(nombreProducto, cantidad);
                Console.WriteLine(respuesta);
                Console.WriteLine("Presione cualquier tecla para volver al menu principal");
                Console.ReadKey();
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
                string respuesta = Operaciones.actualizarStock(nombreProducto, cantidad);
                Console.WriteLine(respuesta);
            }
            
        }
        static void eliminaraProducto()
        {
            Console.Clear();
            Operaciones.obtenerProductos();
            Console.WriteLine("Elija el producto que desea eliminar");
            string nombreProducto = Console.ReadLine().Trim().ToUpper();
            while (nombreProducto.Length == 0)
            {
                Console.WriteLine("Error: No puede dejar el campo producto vacio");
                nombreProducto = Console.ReadLine().Trim().ToUpper();
            }
            bool resultado = Operaciones.eliminaraProducto(nombreProducto);
            if (resultado)
            {
                Console.WriteLine("Producto eliminado con exito");
            }
            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
            Console.ReadKey();
        }
        static void generarVentas()
        {
            Data.carritoProductos.Clear();
            Data.carritoCantidades.Clear();
            Data.carritosubtotales.Clear();
            while (true)
            {
                Console.Clear();
                Operaciones.alertaStock();
                Console.WriteLine("--------Generar ventas-------");
                Operaciones.obtenerProductos();

                Console.WriteLine("Escriba el nombre del producto (o SI para salir)");
                string nombreProducto = Console.ReadLine().Trim().ToUpper();

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
                if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                {
                    if (Data.Stock[indice] >= cantidad)
                    {
                        double subtotal = Operaciones.generarVentas(indice, cantidad);

                       Data.carritoProductos.Add(Data.Productos[indice]);
                       Data.carritoCantidades.Add(cantidad);
                       Data.carritosubtotales.Add(subtotal);
                       Console.WriteLine("Agregado al carrito");
                    }
                    else
                    {
                        Console.WriteLine("Error: no hay stock suficiente");
                    }
                }
                Console.WriteLine("\nPresiona una tecla para continuar....");
                Console.ReadKey();
                
            }
            if (Data.carritoProductos.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("-------FACTURA DE VENTAS-------");
                Console.WriteLine($"Fecha: {DateTime.Now: dd/MM/yyyy}  | {DateTime.Now: hh:mm:ss}");

                double totalFinal = 0;
                for (int i = 0; i < Data.carritoCantidades.Count; i++)
                {
                    Console.WriteLine($"{Data.carritoCantidades[i],-7:N0} {Data.carritoProductos[i],-20} {Data.carritosubtotales[i],-10:C2}");
                    totalFinal += Data.carritosubtotales[i];
                }
                Console.WriteLine("\n-------------------------------");
                Console.WriteLine($"Total a pagar: {totalFinal:C2}");
            }
            else
            {
                Console.WriteLine("No se han agregado productos al carrito.");
            }
            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
            Console.ReadKey();   
        }
        //funcion para buscar productos
         static void buscarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto a buscar");
            string nombreProducto = Console.ReadLine().Trim().ToUpper();
            while (nombreProducto.Length == 0)
            {
                Console.WriteLine("No puede dejar el campo producto vacio");
                nombreProducto = Console.ReadLine().Trim().ToUpper();
            } 
            Operaciones.buscarProducto(nombreProducto);
            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
            Console.ReadKey(); 
        }
    }   
}