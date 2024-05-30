using Bombones.Comun;
using Bombones.Comun.Interfaces;
using Bombones.Comun.IRepositorios;
using Bombones.Comun.IServicios;
using Bombones.Datos.Fabricas;
using Bombones.Datos.Repositorios;
using Bombones.Servicios.Datos.Fabricas;
using Bombones.Servicios.Servicios;
using Ninject.Modules;
using System.Data;
using System.Data.SqlClient;

namespace Bombones.IoC
{
    public class Bindings : NinjectModule
    {
        private readonly string _connectionString;

        public Bindings(string connectionString)    // Constructor
        {
            _connectionString = connectionString;   // Recibe una cadena y la guarda en _connectionString
        }

        public override void Load()
        {
            // Vincula la interfaz con la implementación concreta
            // Cuando se solicita una instancia IRepositorioPais, el IoC proporciona una instancia RepositorioPais
            Bind<IRepositorioTiposDeChocolates>().To<RepositorioTiposDeChocolates>();
            Bind<IServiciosTiposDeChocolates>().To<ServiciosTiposDeChocolates>();

            Bind<IRepositorioTiposDeRellenos>().To<RepositorioTiposDeRellenos>();
            Bind<IServiciosTiposDeRellenos>().To<ServiciosTiposDeRellenos>();

            Bind<IRepositorioTiposDeNueces>().To<RepositorioTiposDeNueces>();
            Bind<IServiciosTiposDeNueces>().To<ServiciosTiposDeNueces>();

            Bind<IRepositorioFabricas>().To<RepositorioFabricas>();
            Bind<IServiciosFabricas>().To<ServiciosFabricas>();

            Bind<IRepositorioPaises>().To<RepositorioPaises>();
            Bind<IServiciosPaises>().To<ServiciosPaises>();


            Bind<IRepositorioDetallesCajas>().To<RepositorioDetallesCajas>();

            Bind<IRepositorioVentas>().To<RepositorioVentas>();
            Bind<IServiciosVentas>().To<ServiciosVentas>();

            Bind<IRepositorioProductos>().To<RepositorioProductos>();
            Bind<IServiciosProductos>().To<ServiciosProductos>();

            Bind<IRepositorioClientes>().To<RepositorioClientes>();
            Bind<IServiciosClientes>().To<ServiciosClientes>();

            Bind<IRepositorioDetallesVentas>().To<RepositorioDetallesVentas>();

            Bind<IDbConnectionFactory>().To<SqlConnectionFactory>().WithConstructorArgument(_connectionString);
            Bind<IDbCommandFactory>().To<SqlCommandFactory>();
            Bind<IDbConnection>().To<SqlConnection>();
        }
    }
}
