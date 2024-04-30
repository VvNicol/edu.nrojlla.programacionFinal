namespace edu.nrojlla.programacion.Servicios
{
    /// <summary>
    /// Biblioteca de menus 
    /// </summary>
    /// <autor>nrojlla30042024</autor>
    internal interface MenuInterfaz
    {
        /// <summary>
        ///  operaciones del listado de consulas
        /// </summary>
        void ListadoConsultas();
        /// <summary>
        /// Vista menu principal
        /// </summary>
        /// <returns>int</returns>
        int MenuPrincipal();
    }
}