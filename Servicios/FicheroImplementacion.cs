using edu.nrojlla.programacion.Dtos;
using edu.nrojlla.programacion.Servicios;

namespace edu.nrojlla.programacion.Controlador
{
    internal class FicheroImplementacion : FicherosInterfaz
    {
        public void LeerYguardar()
        {

            try
            {
                if (!File.Exists(Program.citasFichero))
                {
                    using (StreamWriter st = new StreamWriter(Program.citasFichero))
                    {
                        st.WriteLine("12345678Z;Alfonso;Fernández García;Psicologia;29-04-2024 12:30:00;true");
                        st.WriteLine("13121432R;Marta;Fernández Fernández;Psicologia;29-04-2024 13:00:00;false");
                        st.WriteLine("17165912O;Pedro;Collado Puente;Fisioterapia;30-04-2024 11:00:00;false");
                        st.WriteLine("37165912P;Laura;Quintero García;Psicologia;29-04-2024 13:30:00;true");
                        st.WriteLine("17165912O;Pedro;Collado Puente;Fisioterapia;29-04-2024 11:00:00;false");
                        st.WriteLine("37165912P;Laura;Quintero García;Psicologia;25-04-2024 13:30:00;false");
                    }
                }
                else
                {
                    using (StreamReader sr = new StreamReader(Program.citasFichero))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            string[] partes = linea.Split(';');

                            CitasDtos citasAgregar = new CitasDtos(partes[0], partes[1], partes[2], partes[3], DateTime.Parse(partes[4]), bool.Parse(partes[5]));
                            Program.citaLista.Add(citasAgregar);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los ficheros: " + ex.Message);
            }

        }

        public void ListadoConsultas()
        {
            try
            {
                bool buscar = false;
                foreach (CitasDtos citas in Program.citaLista)
                {
                    buscar = true;
                    Console.WriteLine(citas.ToString("imprimirConsultas"));
                }
                if (!buscar) { Console.WriteLine("No es posible imprimir las consultas"); }
            }
            catch (Exception ex) { Console.WriteLine("Ha ocurrido un error" + ex.Message); }

        }
    }
}