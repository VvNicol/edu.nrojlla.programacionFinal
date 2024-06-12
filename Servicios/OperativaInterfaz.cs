namespace edu.nrojlla.programacion.Servicios
{
    /// <summary>
    /// Bbiblioteca de las funcionalidades
    /// </summary>
    /// <autor>nrojlla30042024</autor>
    internal interface OperativaInterfaz
    {
        void ImprimirConsultas(string consulta);
        void MostrarConsultas(string consulta);


        /// <summary>
        /// Operacion del registro de llegada
        /// </summary>
        void RegistroLlegada();
    }
}