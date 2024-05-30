using Bombones.Comun.IServicios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Windows.Classes;
using Bombones.Windows.Helpers;
using Bombones.Windows.UsersControls;

namespace Bombones.Windows.Formularios
{
    public partial class frmVentasAE : Form
    {
        private readonly IServiciosVentas _serviciosVentas;
        private readonly IServiciosProductos _serviciosProductos;
        private TipoProducto tipoProducto = TipoProducto.Todos;
        private List<ProductoListDto>? lista;   // Lista con todos los productos
        private List<ProductoListDto>? listaFiltrada;   // Lista con los productos luego de aplicado el filtro
        private ContextMenuStrip? cm;
        private Venta ? venta;  // Variable para devolver la venta a otro form
        public frmVentasAE(IServiciosVentas serviciosVentas, IServiciosProductos serviciosProductos)
        {
            InitializeComponent();
            _serviciosVentas = serviciosVentas;
            _serviciosProductos = serviciosProductos;
        }

        private void frmVentasAE_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
            InicializarContextMenu();
        }

        private void InicializarContextMenu()
        {
            cm = new ContextMenuStrip();
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Borrar");
            deleteItem.Click += DeleteItem_Click;
            cm.Items.Add(deleteItem);

            ToolStripMenuItem editItem = new ToolStripMenuItem("Editar");
            editItem.Click += EditItem_Click;
            cm.Items.Add(editItem);

            ToolStripMenuItem exitItem = new ToolStripMenuItem("Salir");
            editItem.Click += ExitItem_Click;
            cm.Items.Add(exitItem);
        }

        private void ExitItem_Click(object? sender, EventArgs e)
        {
            return;
        }

        private void EditItem_Click(object? sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];

            if (r.Tag != null)
            {
                ItemCarrito itemSeleccionado = (ItemCarrito)r.Tag;
                string cantidadInput = CantidadInputBox("Ingrese la cantidad de compra:");

                TipoProducto tipoProductoItem = itemSeleccionado.BombonId != null ? TipoProducto.Bombon
                        : TipoProducto.Caja;

                var productoId = itemSeleccionado.BombonId ?? itemSeleccionado.CajaId;

                if (productoId != null)
                {
                    ActualizarUcProducto(tipoProductoItem, productoId.Value, -itemSeleccionado.Cantidad);
                    _serviciosProductos.ActualizarEnPedido(tipoProductoItem, productoId.Value,
                        -itemSeleccionado.Cantidad);
                }

            }

        }

        private void DeleteItem_Click(object? sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];

            if (r.Tag != null)
            {
                ItemCarrito itemSeleccionado = (ItemCarrito)r.Tag;
                DialogResult dr = MessageBox.Show("Desea borrar el item seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    CarritoDeCompras.GetCarrito().QuitarItem(itemSeleccionado);
                    ActualizarTotales();

                    GridHelper.MostrarDatosEnGrilla<ItemCarrito>
                        (CarritoDeCompras.GetCarrito().GetItems(), dgvDatos);

                    TipoProducto tipoProductoItem = itemSeleccionado.BombonId != null ? TipoProducto.Bombon
                            : TipoProducto.Caja;

                    var productoId = itemSeleccionado.BombonId ?? itemSeleccionado.CajaId;

                    if (productoId != null)
                    {
                        ActualizarUcProducto(tipoProductoItem, productoId.Value, itemSeleccionado.Cantidad);
                        _serviciosProductos.ActualizarEnPedido(tipoProductoItem, productoId.Value,
                            -itemSeleccionado.Cantidad);
                    }
                }
            }
        }

        private void MostrarProductosEnLayout(List<ProductoListDto>? lista)
        {
            flpProductos.Controls.Clear();
            if (lista is not null)
            {
                foreach (var producto in lista)
                {
                    var ucProducto = new ucProducto();
                    SetearUcProducto(ucProducto, producto);
                    AgregarUcProducto(ucProducto);
                }
            }
        }

        private void AgregarUcProducto(ucProducto ucProducto)
        {
            flpProductos.Controls.Add(ucProducto);
        }

        private void SetearUcProducto(ucProducto ucProducto, ProductoListDto producto)
        {
            ucProducto.ProductoId = producto.ProductoId;
            ucProducto.TipoProducto = producto.TipoProducto;
            ucProducto.Nombre = producto.Nombre;
            ucProducto.Precio = producto.Precio;

            ucProducto.Stock = producto.Stock - producto.EnPedido;

            ucProducto.Imagen = producto.Imagen ?? string.Empty;
            ucProducto.Suspendido = producto.Suspendido;
            ucProducto.TipoProducto = producto.TipoProducto;            
            ucProducto.btnAgregar.Tag = producto;

            ucProducto.btnAgregar.Click += BtnAgregar_Click;

        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            if (sender is not null)
            {
                Button button = (Button)sender;
                if (button.Tag is not null)
                {
                    ProductoListDto productoDto = (ProductoListDto)button.Tag;
                    string cantidadInput = CantidadInputBox("Ingrese la cantidad de compra:");

                    if (!string.IsNullOrEmpty(cantidadInput) &&
                        int.TryParse(cantidadInput, out int cantidad) &&
                        cantidad <= productoDto.Stock - productoDto.EnPedido)
                    {
                        ItemCarrito itemCarrito = new ItemCarrito
                        {
                            Nombre = productoDto.Nombre,
                            Precio = productoDto.Precio,
                            Cantidad = cantidad
                        };

                        if (productoDto.TipoProducto == TipoProducto.Bombon)
                        {
                            itemCarrito.BombonId = productoDto.ProductoId;
                        }
                        else if (productoDto.TipoProducto == TipoProducto.Caja)
                        {
                            itemCarrito.CajaId = productoDto.ProductoId;
                        }

                        _serviciosProductos.ActualizarEnPedido(productoDto.TipoProducto,
                            productoDto.ProductoId, cantidad);
                        CarritoDeCompras.GetCarrito()?.AgregarItem(itemCarrito);
                        var lista = CarritoDeCompras.GetCarrito().GetItems();

                        if (lista is not null)
                        {
                            GridHelper.MostrarDatosEnGrilla<ItemCarrito>(lista, dgvDatos);
                            ActualizarTotales();

                        }
                        ActualizarUcProducto(productoDto.TipoProducto, productoDto.ProductoId, -cantidad);
                    }
                    else
                    {
                        MessageBox.Show("Cantidad superior al stock", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private string CantidadInputBox(string mensaje)
        {
            string userInput = string.Empty;
            bool validInput = false;
            while (!validInput)
            {
                userInput = Microsoft.VisualBasic.Interaction.InputBox(mensaje, "Cantidad de compra", "1", 800, 600);
                if (string.IsNullOrEmpty(userInput) || !int.TryParse(userInput, out int cantidad)
                    || cantidad <= 0)
                {
                    validInput = false;
                    MessageBox.Show("Cantidad no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    validInput = true;
                }
            }
            return userInput;
        }

        private void ActualizarUcProducto(TipoProducto tipo, int productoId, int cantidad)
        {
            ActualizarProductoEnLista(tipo, productoId, cantidad);


            var ucProducto = flpProductos.
                Controls.OfType<ucProducto>().
                FirstOrDefault(uc => uc.ProductoId == productoId &&
                uc.TipoProducto == tipo);

            if (ucProducto != null)
            {
                ucProducto.ActualizarStock(cantidad);

                ucProducto.Refresh();
            }
        }

        // Método para mantener actualizada la lista que no está filtrada
        private void ActualizarProductoEnLista(TipoProducto tipoProducto, int productoId, int cantidad)
        {
            var productoListDto = lista?.FirstOrDefault(p => p.TipoProducto == tipoProducto &&
                p.ProductoId == productoId);

            if (productoListDto is not null)
            {
                productoListDto.Stock += cantidad;
                productoListDto.EnPedido -= cantidad;

                var ucProducto = flpProductos.
                    Controls.OfType<ucProducto>().
                    FirstOrDefault(uc => uc.ProductoId == productoId &&
                    uc.TipoProducto == tipoProducto);

                if (ucProducto is not null)
                {
                    ucProducto.btnAgregar.Tag = productoListDto;

                }
            }
        }

        private void ActualizarTotales()
        {
            lblCantidad.Text = CarritoDeCompras.GetCarrito().GetCantidad().ToString();
            lblTotal.Text = CarritoDeCompras.GetCarrito().GetTotal().ToString("C");
        }

        private void RecargarGrilla()
        {
            try
            {
                //TODO: Se cambió acá
                lista = _serviciosProductos.GetLista(tipoProducto);
                //listaFiltrada = lista;
                MostrarProductosEnLayout(lista);//cambie a lista
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Manejo Filtros
        private void rbtBombones_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtBombones.Checked)
            {
                //TODO: Se cambió acá, le pido la lista fitrada al repo
                tipoProducto = TipoProducto.Bombon;
                //listaFiltrada = lista?.Where(p => p.TipoProducto == tipoProducto).ToList();
                lista=_serviciosProductos.GetLista(TipoProducto.Bombon);
                MostrarProductosEnLayout(lista);
            }
        }

        private void rbtCajas_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCajas.Checked)
            {
                //TODO: Se cambió acá, le pido la lista fitrada al repo

                tipoProducto = TipoProducto.Caja;
                //listaFiltrada = lista?.Where(p => p.TipoProducto == tipoProducto).ToList();
                lista=_serviciosProductos.GetLista(TipoProducto.Caja);
                MostrarProductosEnLayout(lista);
            }
        }
        private void rbtTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTodos.Checked)
            {
                //TODO: Se cambió acá, le pido la lista fitrada al repo

                tipoProducto = TipoProducto.Todos;
                //listaFiltrada = lista;
                lista=_serviciosProductos.GetLista(TipoProducto.Todos);
                MostrarProductosEnLayout(lista);
            }
        }
        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarCompra();
            DialogResult = DialogResult.Cancel;
        }

        private void dgvDatos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dgvDatos.ClearSelection();
                    dgvDatos.Rows[e.RowIndex].Selected = true;
                    dgvDatos.ContextMenuStrip = cm;
                    cm?.Show(dgvDatos, e.Location);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                frmSeleccionarCliente frm = new frmSeleccionarCliente() { Text = "Seleccionar Cliente que compra" };
                DialogResult dr = frm.ShowDialog(this);

                if (dr == DialogResult.Cancel)
                {
                    CancelarCompra();
                    return;
                }
                Cliente? cliente = frm.GetCliente();
                //TODO: ojo consumidor final
                if (cliente is not null)
                {
                    venta = new Venta()
                    {
                        FechaVenta = DateTime.Today,
                        EstadoVenta = EstadoVenta.Completada,
                        Regalo = false,
                        ClienteId = cliente.ClienteId,
                        Cliente= cliente,
                        Total = CarritoDeCompras.GetCarrito().GetTotal()
                    };

                    if (CarritoDeCompras.GetCarrito().GetItems() is not null)
                    {
                        List<DetalleVenta> detalleVentas = new List<DetalleVenta>();

                        foreach (var itemEnCarrito in CarritoDeCompras.GetCarrito().GetItems())
                        {
                            if (itemEnCarrito is not null)
                            {
                                DetalleVenta dv = new DetalleVenta()
                                {
                                    BombonId = itemEnCarrito.BombonId,
                                    CajaId = itemEnCarrito.CajaId,
                                    Cantidad = itemEnCarrito.Cantidad,
                                    Precio = itemEnCarrito.Precio
                                };
                                detalleVentas.Add(dv);
                            }
                        }
                        venta.Detalles = detalleVentas;
                        CarritoDeCompras.GetCarrito().VaciarCarrito();
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private void CancelarCompra()
        {
            List<ItemCarrito>? items = CarritoDeCompras.GetCarrito().GetItems();

            if (items != null)
            {
                foreach (var item in items)
                {
                    TipoProducto tipoProductoItem = item.BombonId != null ? TipoProducto.Bombon
                        : TipoProducto.Caja;
                    var productoId = item.BombonId ?? item.CajaId;

                    if (productoId != null)
                    {
                        _serviciosProductos.ActualizarEnPedido(tipoProductoItem, productoId.Value, -item.Cantidad);
                    }
                }
            }
            CarritoDeCompras.GetCarrito().VaciarCarrito();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (CarritoDeCompras.GetCarrito().GetCantidad() == 0)
            {
                valido = false;
                errorProvider1.SetError(lblCantidad, "Debe ingresar al menos un ítem!!!");
            }
            return valido;
        }

        public Venta? GetVenta()
        {
            return venta;
        }
    }
}
