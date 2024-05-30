using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.IoC;

namespace Bombones.Windows.Helpers
{
    public static class CombosHelper
    {
        // Al pasar cbo como referencia y no como valor, se le permite al método modificarlo
        public static void CargarComboPaises(ref ComboBox cbo)  
        {
            var servicioPais = DI.Create<IServiciosPaises>(); // Crea un objeto IServiciosPais
            var lista = servicioPais.GetLista();    // Trae una lista y la guarda en lista
            var defaultPais = new Pais()    // Le pasa un país por defecto (lo primero que va a mostrar el ComboBox)
            {
                PaisId = 0,     // Atributos del objeto Pais
                NombrePais = "Seleccione País"
            };
            lista.Insert(0, defaultPais);   // Lo agrega a la primera posición de la lista
            cbo.DataSource = lista; // Le indica de donde debe tomar los datos
            cbo.DisplayMember = "NombrePais";   // Le indica cuál de los datos mostrar (el nombre) 
            cbo.ValueMember = "PaisId";   // Le indica que reserve la id
            cbo.SelectedIndex = 0;  // Muestra por defecto el primer elemento de la lista 
        }

        public static void CargarComboTiposDeChocolate(ref ComboBox cbo)
        {
            var servicio = DI.Create<IServiciosTiposDeChocolates>(); // Crea un objeto IServiciosPais
            var lista = servicio.GetLista();    // Trae una lista y la guarda en lista
            var defaultChocolate = new TipoDeChocolate()    // Le pasa un país por defecto (lo primero que va a mostrar el ComboBox)
            {
                TipoDeChocolateId = 0,     // Atributos del objeto Pais
                Descripcion = "Seleccione Chocolate"
            };
            lista.Insert(0, defaultChocolate);   // Lo agrega a la primera posición de la lista
            cbo.DataSource = lista; // Le indica de donde debe tomar los datos
            cbo.DisplayMember = "Descripcion";   // Le indica cuál de los datos mostrar (el nombre) 
            cbo.ValueMember = "TipoDeChocolateId";   // Le indica que reserve la id
            cbo.SelectedIndex = 0;  // Muestra por defecto el primer elemento de la lista 

        }

        public static void CargarComboTiposDeRelleno(ref ComboBox cbo)
        {
            var servicio = DI.Create<IServiciosTiposDeRellenos>(); // Crea un objeto IServiciosPais
            var lista = servicio.GetLista();    // Trae una lista y la guarda en lista
            var defaultRelleno = new TipoDeRelleno()    // Le pasa un país por defecto (lo primero que va a mostrar el ComboBox)
            {
                TipoDeRellenoId = 0,     // Atributos del objeto Pais
                Descripcion = "Seleccione Relleno"
            };
            lista.Insert(0, defaultRelleno);   // Lo agrega a la primera posición de la lista
            cbo.DataSource = lista; // Le indica de donde debe tomar los datos
            cbo.DisplayMember = "Descripcion";   // Le indica cuál de los datos mostrar (el nombre) 
            cbo.ValueMember = "TipoDeRellenoId";   // Le indica que reserve la id
            cbo.SelectedIndex = 0;  // Muestra por defecto el primer elemento de la lista 
        }

        public static void CargarComboTiposDeNueces(ref ComboBox cbo)
        {
            var servicio = DI.Create<IServiciosTiposDeNueces>(); // Crea un objeto IServiciosPais
            var lista = servicio.GetLista();    // Trae una lista y la guarda en lista
            var defaultNuez = new TipoDeNuez()    // Le pasa un país por defecto (lo primero que va a mostrar el ComboBox)
            {
                TipoDeNuezId = 0,     // Atributos del objeto Pais
                Descripcion = "Seleccione Nuez"
            };
            lista.Insert(0, defaultNuez);   // Lo agrega a la primera posición de la lista
            cbo.DataSource = lista; // Le indica de donde debe tomar los datos
            cbo.DisplayMember = "Descripcion";   // Le indica cuál de los datos mostrar (el nombre) 
            cbo.ValueMember = "TipoDeNuezId";   // Le indica que reserve la id
            cbo.SelectedIndex = 0;  // Muestra por defecto el primer elemento de la lista 
        }

        public static void CargarComboFabricas(ref ComboBox cbo)
        {
            var servicio = DI.Create<IServiciosFabricas>(); // Crea un objeto IServiciosPais
            var lista = servicio.GetFabricas();    // Trae una lista y la guarda en lista
            var defaultFabrica = new Fabrica()    // Le pasa un país por defecto (lo primero que va a mostrar el ComboBox)
            {
                FabricaId = 0,     // Atributos del objeto Pais
                NombreFabrica = "Seleccione Fábrica"
            };
            lista.Insert(0, defaultFabrica);   // Lo agrega a la primera posición de la lista
            cbo.DataSource = lista; // Le indica de donde debe tomar los datos
            cbo.DisplayMember = "NombreFabrica";   // Le indica cuál de los datos mostrar (el nombre) 
            cbo.ValueMember = "FabricaId";   // Le indica que reserve la id
            cbo.SelectedIndex = 0;  // Muestra por defecto el primer elemento de la lista 
        }

        public static void CargarComboBombones(ref ComboBox cbo)
        {
            var servicio = DI.Create<IServiciosProductos>(); // Crea un objeto IServiciosPais
            var lista = servicio.GetBombonesCombo();    // Trae una lista y la guarda en lista
            var defaultBombon = new ProductoComboDto()    // Le pasa un país por defecto (lo primero que va a mostrar el ComboBox)
            {
                BombonId = 0,     // Atributos del objeto Pais
                NombreBombon = "Seleccione Bombón"
            };
            lista.Insert(0, defaultBombon);   // Lo agrega a la primera posición de la lista
            cbo.DataSource = lista; // Le indica de donde debe tomar los datos
            cbo.DisplayMember = "NombreBombon";   // Le indica cuál de los datos mostrar (el nombre) 
            cbo.ValueMember = "BombonId";   // Le indica que reserve la id
            cbo.SelectedIndex = 0;  // Muestra por defecto el primer elemento de la lista 
        }
        public static void CargarComboClientes(ref ComboBox cbo)
        {
            var servicio = DI.Create<IServiciosClientes>(); 
            var lista = servicio.GetLista();     
            var defaultCliente = new Cliente()    
            {
                ClienteId = 999999,    
                Apellido = "Consumidor ",
                Nombre = "Final"
            };
            lista.Insert(0, defaultCliente);  
            cbo.DataSource = lista; 
            cbo.DisplayMember = "ApeNombre";  
            cbo.ValueMember = "ClienteId";   
            cbo.SelectedIndex = 0;  
        }
    }
}
