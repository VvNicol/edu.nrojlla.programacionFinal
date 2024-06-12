using edu.nrojlla.programacion.Dtos;
using edu.nrojlla.programacion.Servicios;
using System.Reflection.Emit;
using System.Security.Cryptography;

namespace edu.nrojlla.programacion.Controlador
{
    /// <summary>
    /// Aplicacion de gestion de consultas
    /// <autor>nrojlla30042024</autor>
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Aplicacion
        /// </summary>
        public static List<CitasDtos> citaLista = new List<CitasDtos>();

        public static string citasFichero = $"{DateTime.Now.ToString("dd-MM-yyyy")} citas.txt";
        public static string logFichero = $"{DateTime.Now.ToString("dd-MM-yyyy")} log.txt";

        static void Main(string[] args)
        {
            MenuInterfaz mi = new MenuImplementacion();
            OperativaInterfaz oi = new OperativaImplementacion();
            FicherosInterfaz fi = new FicheroImplementacion();

            int opcionSeleccionada;
            bool esCerrado = false;

            try
            {
                fi.LeerYguardar();
                
                do
                {
                    opcionSeleccionada = mi.MenuPrincipal();
                    string mensaje = $"{DateTime.Now.ToString("dd/MM/yyy HH:mm:ss")} - Menu Inicial, opcion : {opcionSeleccionada} ";
                    switch (opcionSeleccionada)
                    {
                        case 0:
                            mensaje += "Cerrada";
                            esCerrado = true;
                            Console.WriteLine("Aplicacion cerrada");
                            break;
                        case 1:
                            mensaje += "Registro llegada";
                            oi.RegistroLlegada();
                            break;

                        case 2:
                            mensaje += "Listado Consultas";
                            mi.ListadoConsultas();
                            break;

                        default:
                            mensaje += "No valida";
                            Console.WriteLine("La opcion seleccionada no es valida");
                            break;
                    }
                    ficheroLogger(mensaje);

                } while (!esCerrado);

            }
            catch (Exception e) { Console.WriteLine("No se ha podido leer/escribir" + e.Message); }
        }
        private static void ficheroLogger(string mensaje)
        {
            try
            {
                using (StreamWriter log = new StreamWriter(logFichero, true))
                {
                    log.WriteLine(mensaje);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se ha podido leer/escribir: " + e.Message);
            }
        }
    }
}
