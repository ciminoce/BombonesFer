namespace Bombones.Windows.Formularios
{
    partial class frmDetalleVenta
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
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colProducto = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            panelCliente = new Panel();
            chkRegalo = new CheckBox();
            txtEstado = new TextBox();
            label4 = new Label();
            txtFecha = new TextBox();
            label2 = new Label();
            txtCliente = new TextBox();
            label3 = new Label();
            txtVentaNro = new TextBox();
            label1 = new Label();
            btnCerrar = new Button();
            txtTotal = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            panelCliente.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            splitContainer1.Panel1.Controls.Add(panelCliente);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtTotal);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(btnCerrar);
            splitContainer1.Size = new Size(800, 651);
            splitContainer1.SplitterDistance = 527;
            splitContainer1.TabIndex = 0;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colProducto, colCantidad, colPrecio, colTotal });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 120);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.RowTemplate.Height = 25;
            dgvDatos.Size = new Size(800, 407);
            dgvDatos.TabIndex = 1;
            // 
            // colProducto
            // 
            colProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProducto.HeaderText = "Producto";
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCantidad.HeaderText = "Cant.";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 60;
            // 
            // colPrecio
            // 
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPrecio.HeaderText = "P. Unit";
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Width = 67;
            // 
            // colTotal
            // 
            colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTotal.HeaderText = "P. Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 70;
            // 
            // panelCliente
            // 
            panelCliente.Controls.Add(chkRegalo);
            panelCliente.Controls.Add(txtEstado);
            panelCliente.Controls.Add(label4);
            panelCliente.Controls.Add(txtFecha);
            panelCliente.Controls.Add(label2);
            panelCliente.Controls.Add(txtCliente);
            panelCliente.Controls.Add(label3);
            panelCliente.Controls.Add(txtVentaNro);
            panelCliente.Controls.Add(label1);
            panelCliente.Dock = DockStyle.Top;
            panelCliente.Location = new Point(0, 0);
            panelCliente.Name = "panelCliente";
            panelCliente.Size = new Size(800, 120);
            panelCliente.TabIndex = 0;
            // 
            // chkRegalo
            // 
            chkRegalo.AutoSize = true;
            chkRegalo.CheckAlign = ContentAlignment.MiddleRight;
            chkRegalo.Location = new Point(97, 80);
            chkRegalo.Name = "chkRegalo";
            chkRegalo.Size = new Size(62, 19);
            chkRegalo.TabIndex = 2;
            chkRegalo.Text = "Regalo";
            chkRegalo.TextAlign = ContentAlignment.MiddleRight;
            chkRegalo.UseVisualStyleBackColor = true;
            // 
            // txtEstado
            // 
            txtEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtEstado.Location = new Point(664, 46);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(100, 23);
            txtEstado.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(593, 49);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 0;
            label4.Text = "Estado:";
            // 
            // txtFecha
            // 
            txtFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtFecha.Location = new Point(664, 17);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(100, 23);
            txtFecha.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(593, 20);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 0;
            label2.Text = "Fecha Vta.:";
            // 
            // txtCliente
            // 
            txtCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtCliente.Location = new Point(97, 43);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(460, 23);
            txtCliente.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 46);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 0;
            label3.Text = "Cliente: ";
            // 
            // txtVentaNro
            // 
            txtVentaNro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtVentaNro.Location = new Point(97, 14);
            txtVentaNro.Name = "txtVentaNro";
            txtVentaNro.ReadOnly = true;
            txtVentaNro.Size = new Size(100, 23);
            txtVentaNro.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 17);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Venta Nro.:";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(362, 36);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(91, 60);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txtTotal.Location = new Point(715, 2);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(82, 23);
            txtTotal.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(664, 5);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 2;
            label5.Text = "Total:";
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 651);
            Controls.Add(splitContainer1);
            Name = "frmDetalleVenta";
            Text = "frmDetalleVenta";
            Load += frmDetalleVenta_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            panelCliente.ResumeLayout(false);
            panelCliente.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panelCliente;
        private CheckBox chkRegalo;
        private TextBox txtEstado;
        private Label label4;
        private TextBox txtFecha;
        private Label label2;
        private TextBox txtCliente;
        private Label label3;
        private TextBox txtVentaNro;
        private Label label1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colTotal;
        private Button btnCerrar;
        private TextBox txtTotal;
        private Label label5;
    }
}