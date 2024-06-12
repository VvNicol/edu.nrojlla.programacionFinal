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
        OperativaInterfaz oi = new OperativaImplementacion();
        /// <summary>
        /// guardar fichero
        /// </summary>
        /// <param name="mensaje"></param>
        private static void ficheroLogger(string mensaje)
        {
            try
            {
                using (StreamWriter log = new StreamWriter(Program.logFichero, true))
                {
                    log.WriteLine(mensaje);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se ha podido leer/escribir: " + e.Message);
            }
        }
        //TODO: Hace falta el menu ciclico en los subsmenus
        public void ListadoConsultas()
        {
            int opcionSeleccionada;
            bool esCerrado = false;
            try
            {
                do
                {
                    opcionSeleccionada = MenuListadoConsultas();
                    string mensaje = $"{DateTime.Now.ToString("dd/MM/yyy HH:mm:ss")} - Listado consultas, opcion : {opcionSeleccionada} : ";
  
                    switch (opcionSeleccionada)
                    {
                        case 0:
                            mensaje += "Volver";
                            esCerrado = true;
                            break;
                        case 1:

                            int opcionConsulta = MenuEspecialidad();
                            mensaje += "Menu tipo consultas: ";
                            switch (opcionConsulta)
                            {
                                case 0:
                                    mensaje += "Volver";
                                    esCerrado = true;
                                    break;
                                case 1:
                                    mensaje += "Psicologia";
                                    string consulta = "Psicologia";
                                    oi.MostrarConsultas(consulta);
                                    break;
                                case 2:
                                    mensaje += "Traumatologia";
                                    consulta = "Traumatologia";
                                    oi.MostrarConsultas(consulta);
                                    break;
                                case 3:
                                    mensaje += "Fisioterapia";
                                    consulta = "Fisioterapia";
                                    oi.MostrarConsultas(consulta);
                                    break;
                                default:
                                    mensaje += "No valida";
                                    Console.WriteLine("La opcion seleccionada no es valida");
                                    break;
                            }

                            break;

                        case 2:
                            opcionConsulta = MenuEspecialidad();
                            mensaje += "Menu tipo consultas: ";
                            switch (opcionConsulta)
                            {
                                case 0:
                                    mensaje += "Volver";
                                    esCerrado = true;
                                    break;
                                case 1:
                                    mensaje += "Psicologia";
                                    string consulta = "Psicologia";
                                    oi.ImprimirConsultas(consulta);
                                    break;
                                case 2:
                                    mensaje += "Traumatologia";
                                    consulta = "Traumatologia";
                                    oi.ImprimirConsultas(consulta);
                                    break;
                                case 3:
                                    mensaje += "Fisioterapia";
                                    consulta = "Fisioterapia";
                                    oi.ImprimirConsultas(consulta);
                                    break;
                                default:
                                    mensaje += "No valida";
                                    Console.WriteLine("La opcion seleccionada no es valida");
                                    break;
                            }
;
                            break;
                      
                    }
                    ficheroLogger(mensaje);

                } while (!esCerrado);

            }
            catch (Exception) { throw; }

        }

        private int MenuEspecialidad()
        {
            try
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Especialidad");
                Console.WriteLine("0.Volver");
                Console.WriteLine("1.Psicologia");
                Console.WriteLine("2.Traumatologia");
                Console.WriteLine("3.Fisioterapia");
                Console.WriteLine("---------------------");
                int opcionElegida = Convert.ToInt32(Console.ReadLine());
                return opcionElegida;

            }
            catch (Exception) { throw; }
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

            }
            catch (Exception) { throw; }
        }
    }
}