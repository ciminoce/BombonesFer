using Ninject;
using System.Reflection;

namespace Bombones.IoC
{
    // Inversion of Control
    // Dependency Injection
    public static class DI
    {
        // Clase proporcionada por Ninject que representa el contenedor IoC
        private static StandardKernel _kernel;
        
        public static void Inicialize(string connectionString)  // Inicialia el contenedor IoC
        {
            // Crea una nueva instancia de StandardKernel pasando una instancia
            // de la clase Bindings al constructor. Toma como parámetro la cadena de conexión

            _kernel = new StandardKernel(new Bindings (connectionString));

            // Se buscan e incorporan automáticamente las configuraciones de vinculación definidas
            // en las clases que heredan de NinjectModule dentro del ensamblado actual.
            _kernel.Load(Assembly.GetExecutingAssembly());
        }
        // Método genérico público llamado create que se utiliza para obtener
        // instancias resueltas del contenedor IoC para el tipo T. 
        public static T Create<T>()
        {
            // Utiliza el método Get<T>() proporcionado por Ninject para obtener la instancia.
            return _kernel.Get<T>();
        }
    }
}
