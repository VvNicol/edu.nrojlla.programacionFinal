using edu.nrojlla.programacion.Controlador;
using edu.nrojlla.programacion.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.nrojlla.programacion.Utils
{
    /// <summary>
    /// utilidades
    /// <autor>nrojlla30042024</autor>
    /// </summary>
    internal class Utils
    {
        private void constructorVacio()
        {
            CitasDtos nuevo = new CitasDtos();

            Console.WriteLine("Ingrese nombre");
            string nombre = Console.ReadLine();

            nuevo.NombrePaciente = nombre;

            Console.WriteLine("Ingrese fecha (dd-mm-yyyy)");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            nuevo.FechaHoraCita = date;

            Program.citaLista.Add(nuevo);

        }
    }
}
