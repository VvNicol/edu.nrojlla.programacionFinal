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
        /// <summary>
        /// Guarda el dni para luego buscarlo
        /// </summary>
        public static void GuardarDniDictionary()
        {
            foreach (CitasDtos dni in Program.citaLista)
            {
                if (!Program.dniCitasDictionary.ContainsKey(dni.DniPaciente))
                {
                    Program.dniCitasDictionary.Add(dni.DniPaciente, dni);
                }
            }
            foreach (CitasDtos consulta in Program.citaLista)
            {
                if (!Program.dniCitasDictionary.ContainsKey(consulta.Consulta))
                {
                    Program.dniCitasDictionary.Add(consulta.Consulta, consulta);
                }
            }
        }
    }
}
