using edu.nrojlla.programacion.Controlador;

namespace edu.nrojlla.programacion.Servicios
{
    /// <summary>
    /// Menus
    /// <autor>nrojlla30042024</autor>
    /// </summary>
    internal class MenuImplementacion : MenuInterfaz
    {
        FicherosInterfaz fi = new FicheroImplementacion();
        public void ListadoConsultas()
        {
            int opcionSeleccionada;
            bool esCerrado = false;
            try
            {
                do
                {
                    opcionSeleccionada = MenuListadoConsultas();
                    switch (opcionSeleccionada)
                    {
                        case 0:
                            esCerrado = true;
                            break;
                        case 1:

                            fi.RegistroLlegada();

                            break;

                        case 2:
                          // mi.ListadoConsultas();
                            break;

                        default:
                            Console.WriteLine("La opcion seleccionada no es valida");
                            break;
                    }


                } while (!esCerrado);

            }catch (Exception) { throw; }

        }

        /// <summary>
        /// Vista menu de consultas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private int MenuListadoConsultas()
        {
            try
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Menu Listado De Consultas");
                Console.WriteLine("0.Volver");
                Console.WriteLine("1.Mostrar Consultas");
                Console.WriteLine("2.Imprimir Consultas");
                Console.WriteLine("---------------------");
                int opcionElegida = Convert.ToInt32(Console.ReadLine());
                return opcionElegida;

            }
            catch (Exception) { throw; }
        }

        public int MenuPrincipal()
        {
            try
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Menu Principal Citas");
                Console.WriteLine("0.Cerrar aplicacion");
                Console.WriteLine("1.Registro de llegada");
                Console.WriteLine("2.Listado de consultas");
                Console.WriteLine("---------------------");
                int opcionElegida = Convert.ToInt32(Console.ReadLine());
                return opcionElegida;

            }catch (Exception) { throw; }
        }
    }
}