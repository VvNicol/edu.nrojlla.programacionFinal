using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.nrojlla.programacion.Dtos
{
    internal class CitasDtos
    {
        long idCitas;
        string dniPaciente = "aaaaa";
        string nombrePaciente = "aaaaa";
        string apellidosPaciente = "aaaaa";
        string consulta = "aaaaa";
        DateTime fechaHoraCita = new DateTime(9999, 12, 31, 00, 00, 00);
        bool esAtendido = false;

        override
        public string ToString()
        {
            string vistaFichero = $"{DniPaciente};{nombrePaciente};{apellidosPaciente};{fechaHoraCita};{esAtendido}";
            return vistaFichero;
        }
        public string ToString(string imprimirConsultas)
        {
            string nombreImprimirConsultas =
                $"---------------------------------------------------\n" +
                $"Nombre: {nombrePaciente} {apellidosPaciente};\n" +
                $"Fecha y hora: {fechaHoraCita}\n" +
                $"Consulta: {consulta}" +
                $"--------------------------------------------------";
                               
            return nombreImprimirConsultas;
        }
        public string ToString(string espere, string turno)
        {
            string salaEspera = $"Espere su turno para la consulta de {consulta} en la sala de espera. Su especialista le avisara";

            return salaEspera;
        }

        public CitasDtos()
        {
        }

        public CitasDtos(string dniPaciente, string nombrePaciente, string apellidosPaciente, string consulta, DateTime fechaHoraCita, bool esAtendido)
        {
            this.dniPaciente = dniPaciente;
            this.nombrePaciente = nombrePaciente;
            this.apellidosPaciente = apellidosPaciente;
            this.consulta = consulta;
            this.fechaHoraCita = fechaHoraCita;
            this.esAtendido = esAtendido;
        }

        public long IdCitas { get => idCitas; set => idCitas = value; }
        public string NombrePaciente { get => nombrePaciente; set => nombrePaciente = value; }
        public string Consulta { get => consulta; set => consulta = value; }
        public DateTime FechaHoraCita { get => fechaHoraCita; set => fechaHoraCita = value; }
        public bool EsAtendido { get => esAtendido; set => esAtendido = value; }
        public string DniPaciente { get => dniPaciente; set => dniPaciente = value; }
    }
}
