using tiendita.Funciones;
namespace inicio
{
    class Program
    {
        static void Main()
        {
            Operaciones.cargarDatos();
            tiendita.menu.Menu.tMenu();
        }
    }
}