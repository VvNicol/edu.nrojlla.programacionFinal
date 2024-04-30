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

        public static Dictionary<string,CitasDtos> dniCitasDictionary = new Dictionary<string, CitasDtos> ();
        public static Dictionary<string,CitasDtos> dniConsultaDictionary = new Dictionary<string, CitasDtos> ();

        public static DateTime dateTime = DateTime.Now;
        public static string formato = $"{dateTime.ToString("dd-MM-yyyy")}";
        public static string citasFichero = $"{formato} citas.txt";
        public static string logFichero = $"{formato} log.txt";

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
                Utils.Utils.GuardarDniDictionary();

                do
                {
                   using (StreamWriter lg = new StreamWriter(logFichero,true))

                    opcionSeleccionada = mi.MenuPrincipal();

                    switch (opcionSeleccionada)
                    {
                        case 0:
                            esCerrado=true;
                            
                            break;
                        case 1:
                             oi.RegistroLlegada();
                            break;

                        case 2:
                            mi.ListadoConsultas();
                            break;
                                
                        default:
                            Console.WriteLine("La opcion seleccionada no es valida");
                            break;
                    }


                }while (!esCerrado);

            }
            catch (Exception e) { Console.WriteLine("No se ha podido leer/escribir" + e.Message); return; }
        }
    }
}
