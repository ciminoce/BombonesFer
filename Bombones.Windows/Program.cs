using Bombones.IoC;
using System.Configuration;
using System.Globalization;

namespace Bombones.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var appCulture = CultureInfo.CreateSpecificCulture("es-AR");
            CultureInfo.DefaultThreadCurrentCulture = appCulture;
            // Obtiene la conexión desde el archivo de configuración
            var connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();

            DI.Inicialize(connectionString);   // Carga todas las definiciones del inyector
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMenuPrincipal());
        }
    }
}