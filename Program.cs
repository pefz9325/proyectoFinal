using System;
using System.Collections.Generic;
using System.Globalization;

namespace tiendita
{
    class Program
    {
        //Listas para guardar todos los datos de la tienda
        static List<string> Productos = new List<string> { "MANZANA", "PAPA", "ZANAHORIA" };
        static List<int> Stock = new List<int> { 20, 41, 60 };
        static List<Double> precio = new List<double> { 25.3, 45.5, 45.2 };

        static void Main()
        {
            string accion = "";
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

                    case "B":                        obtenerProductos();
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
                            obtenerProductos();
                            eliminaraProducto();
                        break;

                    case "E":
                            obtenerProductos();
                            generarVentas();
                        break;

                    case "S":
                            Console.WriteLine("Haz salido del programa");
                        break;

                    default:
                            Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (accion != "S");
        }
        //Metododos para gestionar todos los datos de la tiendita
        //funcion para ingresar productos
        static void insertarProductos()
        {
            while (true)
            {
                //Funcion para insertar todos los productos a la tiendita
                Console.WriteLine("si desea volver al menu principal escriba SI");
                //insertamos el nombre del producto
                Console.WriteLine("\nRegistro de nuevos productos\n");
                Console.WriteLine("Ingrese el nombre del producto");
                string nombreProducto = Console.ReadLine().Trim().ToUpper();
                //Metodo para salir del menu de registro de productos
                if (nombreProducto == "SI")
                {
                    break;
                }
                //si inserta un valor vacio
                while (nombreProducto == "")
                {
                    Console.WriteLine("Debe ingresar un valor al nombre producto");
                    nombreProducto = Console.ReadLine().Trim().ToUpper();
                }
                //validamos que el producto no exista
                if (Productos.Contains(nombreProducto))
                {
                    Console.WriteLine("Error: El producto ya existe en la lista.");
                    continue;
                }
                else
                {
                    //ingresamos la cantidad
                    Console.WriteLine("Ingresa la cantidad del producto");
                    int cantidad = int.Parse(Console.ReadLine());
                    while (cantidad <= 0)
                    {
                        Console.WriteLine("Debe ingresar una cantidad mayor a cero");
                        cantidad = int.Parse(Console.ReadLine());
                    }
                    //ingresamos el precio
                    Console.WriteLine("Ingrese el precio del producto");
                    double precioU = double.Parse(Console.ReadLine());
                    //validamos de que el usuario no deje el campo vacio o que sea numero
                    while (precioU <=0)
                    {
                        Console.WriteLine("Debe ingresar un precio valido y mayor a cero");
                        precioU = double.Parse(Console.ReadLine());
                    }
                    //Guardamso la informacion
                    Productos.Add(nombreProducto);
                    Stock.Add(cantidad);
                    precio.Add(precioU);
                    Console.WriteLine("Productos guardado exitosamente.");  
                }
            }
        }

        //Funcion para sumar un stock si vienen 20 productos se suman no se sobrescriben
        static void sumarStock()
        {
            while (true)
            {
                string nombreProducto;
                try
                {
                Console.WriteLine("Ingrese el nombre del poroducto para agregar la cantidad de productos");
                Console.WriteLine("si desea volver al menu principal escriba SI");
                nombreProducto = Console.ReadLine().Trim().ToUpper();

                if (nombreProducto == "SI")
                {
                    return;
                }
                while (nombreProducto == "" || Productos.IndexOf(nombreProducto) == -1)
                {
                    if (nombreProducto == "")
                    {
                        Console.WriteLine("No puede dejar el campo producto vacio");
                        nombreProducto = Console.ReadLine().Trim().ToUpper();
                    }
                    else
                    {
                        Console.WriteLine("Este producto no existe, ingrese uno valido");
                        obtenerProductos();
                        nombreProducto = Console.ReadLine().Trim().ToUpper();
                    }
                }
                }
                catch (Exception)
                {
                    Console.WriteLine("Se registro una anomalia intentelo de nuevo");
                    continue;
                }
                int indice = Productos.IndexOf(nombreProducto);

                if (indice >= 0)
                {
                    Console.WriteLine("Inserte la cantidad del producto nuevo");
                    int nuevaCantidad = int.Parse(Console.ReadLine());
                    Stock[indice] += (nuevaCantidad);
                    Console.WriteLine("¡Stock actualizado!");
                }
            }
        }

        //Si se requiere actualizar stock manualmente.
        static void actualizarStock()
        {
            //Para actualizar manualmente el stock
            Console.WriteLine("Ingrese el nombre del poroducto para modificar la cantidad de productos");
            string nombreProducto = Console.ReadLine().Trim().ToUpper();
            while (nombreProducto == "" || Productos.IndexOf(nombreProducto) == -1)
            {
                if (nombreProducto == "")
                {
                    Console.WriteLine("No puede dejar el campo producto vacio");
                    nombreProducto = Console.ReadLine().Trim().ToUpper();
                }
                else
                {
                    Console.WriteLine("Este producto no existe.");
                     nombreProducto = Console.ReadLine().Trim().ToUpper();
                }
            }
            int indice = Productos.IndexOf(nombreProducto);

            if (indice >= 0)
            {
                Console.WriteLine("modifique la cantidad del producto");
                int nuevaCantidad = int.Parse(Console.ReadLine());
                Stock[indice] = (nuevaCantidad);
            }
        }

        //Funcion para eliminar productos
        static bool eliminaraProducto()
        {
            Console.WriteLine("Elija el producto que desea eliminar");
            string nombreLimpio = Console.ReadLine().Trim().ToUpper();
            int indice = Productos.IndexOf(nombreLimpio);
            if (indice >= 0)
            {
                Productos.RemoveAt(indice);
                Stock.RemoveAt(indice);
                precio.RemoveAt(indice);
                Console.WriteLine("Producto eliminado con exito");
                return true;
            }
            System.Console.WriteLine("El producto no existe");
            return false;
        }

        //Aviso si el stock esta en el minimo permitido

        static void alertaStock()
        {
            bool alertaStock = false;
            foreach (int cantidad in Stock)
            {
                if (cantidad <= 5)
                {
                    alertaStock = true;
                }
            }
            if (alertaStock)
            {
                Console.WriteLine("¡Alerta stock baja!");
                Console.WriteLine($"{"ID",-15} {"Producto",-15} {"Cantidad",-10}");
                for (int i = 0; i < Stock.Count; i++)
                {
                    if (Stock[i] <= 5)
                    {
                        Console.WriteLine($"{i + 1,-5} {Productos[i],-15} {Stock[i],-10:N0}");
                    }
                }
                Console.WriteLine("La cantidad del producto es minima se recomienda reabastecer");
            }
        }

        //Metodo para obteber productos
        static void obtenerProductos()
        {
            Console.WriteLine($"{"ID",-5} {"Producto",-15} {"Cantidad",-10:N0} {"Precio",-10:C2}");
            for (int i = 0; i < Stock.Count; i++)
            {
                Console.WriteLine($"{i+1,-5} {Productos[i],-15} {Stock[i],-10:N0} {precio[i],-10:C2}");
            }
        }
        //generar ventas
        static double generarVentas()
        {
            while (true)
            {
                alertaStock();
                Console.WriteLine("Escribe 'SI' para salir al menu o busque un producto");
                int cantidadAVender;

                Console.WriteLine("Seleccione el producto");
                string nombreLimpio = Console.ReadLine().Trim().ToUpper();
                if (nombreLimpio == "SI")
                {
                    break;
                }
                int indice = Productos.IndexOf(nombreLimpio); 
                if (indice == -1)
                {
                    Console.WriteLine("El producto no existe");
                    continue;
                }
                Console.WriteLine("Selecciona la cantidad a vender");
                cantidadAVender = int.Parse(Console.ReadLine());
                if (Stock[indice] >= cantidadAVender)
                {
                    DateTime hoy = DateTime.Today;
                    Stock[indice] -= cantidadAVender;
                    double total = precio[indice] * cantidadAVender;
                    Console.WriteLine("dd/MM/yyyy");
                    Console.WriteLine("hh:mm:ss");
                    Console.WriteLine($"\npProducto: {Productos[indice]}");
                    Console.WriteLine($"Cantidad a vender: {cantidadAVender:N0}");
                    Console.WriteLine($"Precio unitario: {precio[indice]}");
                    Console.WriteLine($"Total a pagar: {total:C2}");
                    return total;
                }
                else
                {
                    Console.WriteLine("Error: El producto no existe o no hay cantidad suficiente");
                }
            }
            Console.WriteLine("La venta no se ha procesado");
            return -1;
        }
    }
}