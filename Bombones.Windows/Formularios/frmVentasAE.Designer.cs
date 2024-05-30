namespace Bombones.Windows.Formularios
{
    partial class frmVentasAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVentasAE));
            splitContainer1 = new SplitContainer();
            flpProductos = new FlowLayoutPanel();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            rbtCajas = new RadioButton();
            rbtTodos = new RadioButton();
            rbtBombones = new RadioButton();
            dgvDatos = new DataGridView();
            colProducto = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            panelTotales = new Panel();
            lblTotal = new Label();
            label4 = new Label();
            lblCantidad = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCancelar = new Button();
            btnOk = new Button();
            panelCarrito = new Panel();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            panelTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flpProductos);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvDatos);
            splitContainer1.Panel2.Controls.Add(panelTotales);
            splitContainer1.Panel2.Controls.Add(panelCarrito);
            splitContainer1.Size = new Size(1163, 730);
            splitContainer1.SplitterDistance = 738;
            splitContainer1.TabIndex = 0;
            // 
            // flpProductos
            // 
            flpProductos.AutoScroll = true;
            flpProductos.Dock = DockStyle.Fill;
            flpProductos.Location = new Point(0, 88);
            flpProductos.Name = "flpProductos";
            flpProductos.Size = new Size(738, 642);
            flpProductos.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.IndianRed;
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(738, 88);
            panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtCajas);
            groupBox1.Controls.Add(rbtTodos);
            groupBox1.Controls.Add(rbtBombones);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(43, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(286, 58);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seleccione";
            // 
            // rbtCajas
            // 
            rbtCajas.AutoSize = true;
            rbtCajas.Location = new Point(213, 22);
            rbtCajas.Name = "rbtCajas";
            rbtCajas.Size = new Size(52, 19);
            rbtCajas.TabIndex = 0;
            rbtCajas.Text = "Cajas";
            rbtCajas.UseVisualStyleBackColor = true;
            rbtCajas.CheckedChanged += rbtCajas_CheckedChanged;
            // 
            // rbtTodos
            // 
            rbtTodos.AutoSize = true;
            rbtTodos.Checked = true;
            rbtTodos.Location = new Point(22, 22);
            rbtTodos.Name = "rbtTodos";
            rbtTodos.Size = new Size(57, 19);
            rbtTodos.TabIndex = 0;
            rbtTodos.TabStop = true;
            rbtTodos.Text = "Todos";
            rbtTodos.UseVisualStyleBackColor = true;
            rbtTodos.CheckedChanged += rbtTodos_CheckedChanged;
            // 
            // rbtBombones
            // 
            rbtBombones.AutoSize = true;
            rbtBombones.Location = new Point(102, 22);
            rbtBombones.Name = "rbtBombones";
            rbtBombones.Size = new Size(84, 19);
            rbtBombones.TabIndex = 0;
            rbtBombones.Text = "Bombones";
            rbtBombones.UseVisualStyleBackColor = true;
            rbtBombones.CheckedChanged += rbtBombones_CheckedChanged;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colProducto, colPrecio, colCantidad, colTotal });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 88);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowTemplate.Height = 25;
            dgvDatos.Size = new Size(421, 521);
            dgvDatos.TabIndex = 2;
            dgvDatos.CellMouseDown += dgvDatos_CellMouseDown;
            // 
            // colProducto
            // 
            colProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProducto.HeaderText = "Producto";
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
            // 
            // colPrecio
            // 
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPrecio.HeaderText = "P. Unit.";
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Width = 70;
            // 
            // colCantidad
            // 
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCantidad.HeaderText = "Cant.";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 60;
            // 
            // colTotal
            // 
            colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 57;
            // 
            // panelTotales
            // 
            panelTotales.Controls.Add(lblTotal);
            panelTotales.Controls.Add(label4);
            panelTotales.Controls.Add(lblCantidad);
            panelTotales.Controls.Add(label3);
            panelTotales.Controls.Add(label2);
            panelTotales.Controls.Add(btnCancelar);
            panelTotales.Controls.Add(btnOk);
            panelTotales.Dock = DockStyle.Bottom;
            panelTotales.Location = new Point(0, 609);
            panelTotales.Name = "panelTotales";
            panelTotales.Size = new Size(421, 121);
            panelTotales.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.Location = new Point(380, 12);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(24, 15);
            lblTotal.TabIndex = 14;
            lblTotal.Text = "$ 0";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(337, 12);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 15;
            label4.Text = "Total:";
            // 
            // lblCantidad
            // 
            lblCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantidad.Location = new Point(272, 12);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(14, 15);
            lblCantidad.TabIndex = 16;
            lblCantidad.Text = "0";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(223, 12);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 17;
            label3.Text = "Cant.:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(38, 12);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 18;
            label2.Text = "Totales:";
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(225, 55);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(104, 54);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(95, 55);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(104, 54);
            btnOk.TabIndex = 5;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // panelCarrito
            // 
            panelCarrito.BackColor = Color.IndianRed;
            panelCarrito.Dock = DockStyle.Top;
            panelCarrito.Location = new Point(0, 0);
            panelCarrito.Name = "panelCarrito";
            panelCarrito.Size = new Size(421, 88);
            panelCarrito.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmVentasAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1163, 730);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(1179, 769);
            Name = "frmVentasAE";
            Text = "frmVentasAE";
            Load += frmVentasAE_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            panelTotales.ResumeLayout(false);
            panelTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panelTotales;
        private Panel panelCarrito;
        private DataGridView dgvDatos;
        private Button btnCancelar;
        private Button btnOk;
        private FlowLayoutPanel flpProductos;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colTotal;
        private Label lblTotal;
        private Label label4;
        private Label lblCantidad;
        private Label label3;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton rbtCajas;
        private RadioButton rbtBombones;
        private RadioButton rbtTodos;
        private ErrorProvider errorProvider1;
    }
}