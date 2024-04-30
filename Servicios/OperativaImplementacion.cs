using edu.nrojlla.programacion.Controlador;
using edu.nrojlla.programacion.Dtos;

namespace edu.nrojlla.programacion.Servicios
{
    /// <summary>
    /// Operativa detalle metodos
    /// <autor>nrojlla30042024</autor>
    /// </summary>
    internal class OperativaImplementacion : OperativaInterfaz
    {
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

                        Console.WriteLine("DNI válido");
                        esValidoDni = true;

                    }
                    else
                    {
                        esValidoDni = false;
                        Console.WriteLine("No es valido Intentelo otravez");
                    }

                } while (!esValidoDni);  
                verificarConsulta();
            }
            catch (Exception) { throw; }
        }
        /// <summary>
        ///     Verificar la consulta
        /// </summary>
        private void verificarConsulta()
        {
            try
            {
                foreach (var cli in Program.dniCitasDictionary)
                {
                    foreach(CitasDtos cliDtos in Program.citaLista)
                    {
                        Console.WriteLine(cliDtos.ToString("espere", "turno"));
                        break; 
                    }

                   break;
                }
            }
            catch (Exception) { throw; }
        }
    }
}