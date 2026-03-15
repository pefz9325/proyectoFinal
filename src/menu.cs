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
                    Operaciones.insertarProductos();
                    break;

                    case "B":
                    Operaciones.obtenerProductos();
                    Console.WriteLine("Presione cualquier tecla para volver al menu principal");
                    Console.ReadKey();
                    break;

                    case "C":
                    Console.WriteLine("Elija una opcion \n1: Modificar stock \n2: sumar stock");
                    int opcionU = int.Parse(Console.ReadLine());
                    if (opcionU == 1)
                    {
                        Operaciones.actualizarStock();
                    }
                    else
                    {
                        Operaciones.sumarStock();
                    }
                    break;

                    case "D":
                    Operaciones.eliminaraProducto();
                    break;

                    case "E":
                    Operaciones.generarVentas();
                    break;
                    case "F":
                    Operaciones.buscarProducto();
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
    }   
}