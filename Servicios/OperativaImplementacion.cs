using edu.nrojlla.programacion.Controlador;
using edu.nrojlla.programacion.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace edu.nrojlla.programacion.Servicios
{
    /// <summary>
    /// Operativa detalle metodos
    /// <autor>nrojlla30042024</autor>
    /// </summary>
    internal class OperativaImplementacion : OperativaInterfaz
    {
        public void MostrarConsultas(string especialidad)
        {
            try
            {
                DateTime date = SolicitudFecha();

                var consultas = Program.citaLista.Where(v => v.Consulta == especialidad && v.FechaHoraCita.Date == date.Date).ToList();
                consultas = consultas.OrderBy(v=>v.NombrePaciente).ToList();

                if (consultas.Count() > 0)
                {   
                    Console.WriteLine("------------------------------");
                    foreach (CitasDtos cita in consultas)
                    {
                        
                        Console.WriteLine($"Nombre completo: {cita.ApellidosPaciente} {cita.NombrePaciente} , Hora: {cita.FechaHoraCita:HH:mm}");
                    }
                }
                else
                {
                    Console.WriteLine("No hay consultas para la fecha especificada");
                }

            }
            catch (Exception ex) { throw; }
            
        }
        public void ImprimirConsultas(string especialidad)
        {
            try
            {
                DateTime date = SolicitudFecha();
                string citaConAsistencia = $"citasConAsistencia-{DateTime.Now.ToString("dd-MM-yyyy")}.txt";
                var consultas = Program.citaLista.Where(v => v.Consulta == especialidad && v.FechaHoraCita.Date == date.Date && v.EsAtendido == true).ToList();
                consultas = consultas.OrderBy(v => v.NombrePaciente).ToList();

                if (consultas.Count() > 0)
                {
                    Console.WriteLine("------------------------------");
                    foreach (CitasDtos cita in consultas)
                    {
                        using(StreamWriter sw = new StreamWriter(citaConAsistencia,true))
                        {
                            sw.WriteLine($"Nombre completo: {cita.ApellidosPaciente} {cita.NombrePaciente} , Hora: {cita.FechaHoraCita:HH:mm} , Especialidad : {cita.Consulta}");
                        }
                        
                    }
                    Console.WriteLine("Se ha generado el informe");
                }
                else
                {
                    Console.WriteLine("No hay datos disponibles para la especialidad y fecha indicada");
                }

            }
            catch (Exception ex) { throw; }
        }

        private DateTime SolicitudFecha()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Elija una fecha (dd-mm-yyyy):");
                    DateTime fecha = DateTime.Parse(Console.ReadLine());
                    return fecha;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Fecha inválida. Por favor, intente de nuevo.");
                }
            }
        }

        public void RegistroLlegada()
        {
            try
            {
                string dniPaciente;
                bool esValidoDni = false;

                do
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("Ingrese su dni (8 digitos)");
                    int dniDigitos = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese la letra de su dni (ej: z)");
                    char letraDni = Convert.ToChar(Console.ReadLine().ToUpper());

                    int[] resto = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 };
                    char[] letras = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

                    int divisor = 23;
                    int operacion = dniDigitos % divisor;

                    int posicionResto = resto[operacion];

                    if (letraDni == letras[posicionResto])
                    {
                        esValidoDni = true;
                        dniPaciente = $"{dniDigitos}{letraDni}";  
                        verificarConsulta(dniPaciente);
                    }
                    else
                    {
                        esValidoDni = false;
                        Console.WriteLine("No es valido Intentelo otravez");
                    }

                } while (!esValidoDni);


            }
            catch (Exception) { throw; }
        }
        /// <summary>
        ///     Verificar la consulta
        /// </summary>
        private void verificarConsulta(string dniPaciente)
        {
            try
            {
                var citasPaciente = Program.citaLista.Where(v => v.DniPaciente == dniPaciente).ToList();

                if (citasPaciente.Count > 0)
                {
                    foreach (CitasDtos cita in citasPaciente)
                    {
                        Console.WriteLine(cita.ToString("espere"));
                    }
                }
                else
                {
                    Console.WriteLine("Usted no tiene cita con los especialistas");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        
    }
}