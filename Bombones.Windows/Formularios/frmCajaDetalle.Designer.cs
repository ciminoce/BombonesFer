namespace Bombones.Windows.Formularios
{
    partial class frmCajaDetalle
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
            txtStock = new TextBox();
            label7 = new Label();
            txtPrecioVta = new TextBox();
            label6 = new Label();
            groupBox3 = new GroupBox();
            picImagen = new PictureBox();
            chkSuspendido = new CheckBox();
            txtCaja = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            dgvDatos = new DataGridView();
            colBombon = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            btnCerrar = new Button();
            label2 = new Label();
            txtDescripcion = new TextBox();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImagen).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // txtStock
            // 
            txtStock.Enabled = false;
            txtStock.Location = new Point(107, 160);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(86, 23);
            txtStock.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 163);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 30;
            label7.Text = "Stock:";
            // 
            // txtPrecioVta
            // 
            txtPrecioVta.Enabled = false;
            txtPrecioVta.Location = new Point(107, 131);
            txtPrecioVta.Name = "txtPrecioVta";
            txtPrecioVta.Size = new Size(86, 23);
            txtPrecioVta.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 131);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 0;
            label6.Text = "P. Vta.:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(picImagen);
            groupBox3.Location = new Point(536, 23);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(182, 174);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = " Imágen ";
            // 
            // picImagen
            // 
            picImagen.Location = new Point(17, 21);
            picImagen.Name = "picImagen";
            picImagen.Size = new Size(152, 139);
            picImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            picImagen.TabIndex = 0;
            picImagen.TabStop = false;
            // 
            // chkSuspendido
            // 
            chkSuspendido.AutoSize = true;
            chkSuspendido.Location = new Point(105, 206);
            chkSuspendido.Name = "chkSuspendido";
            chkSuspendido.Size = new Size(88, 19);
            chkSuspendido.TabIndex = 25;
            chkSuspendido.Text = "Suspendido";
            chkSuspendido.UseVisualStyleBackColor = true;
            // 
            // txtCaja
            // 
            txtCaja.Enabled = false;
            txtCaja.Location = new Point(107, 23);
            txtCaja.MaxLength = 120;
            txtCaja.Name = "txtCaja";
            txtCaja.Size = new Size(412, 23);
            txtCaja.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 26);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 22;
            label1.Text = "Caja:";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDatos);
            panel1.Location = new Point(41, 263);
            panel1.Name = "panel1";
            panel1.Size = new Size(677, 203);
            panel1.TabIndex = 33;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colBombon, colCantidad });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowTemplate.Height = 25;
            dgvDatos.Size = new Size(677, 203);
            dgvDatos.TabIndex = 0;
            // 
            // colBombon
            // 
            colBombon.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBombon.HeaderText = "Bombón";
            colBombon.Name = "colBombon";
            colBombon.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(643, 472);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 45);
            btnCerrar.TabIndex = 34;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 55);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 22;
            label2.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Enabled = false;
            txtDescripcion.Location = new Point(107, 52);
            txtDescripcion.MaxLength = 120;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(412, 73);
            txtDescripcion.TabIndex = 24;
            // 
            // frmCajaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 529);
            Controls.Add(txtPrecioVta);
            Controls.Add(btnCerrar);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(txtStock);
            Controls.Add(label7);
            Controls.Add(groupBox3);
            Controls.Add(chkSuspendido);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Controls.Add(txtCaja);
            Controls.Add(label1);
            Name = "frmCajaDetalle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCajaDetalle";
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picImagen).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtStock;
        private Label label7;
        private TextBox txtPrecioVta;
        private Label label6;
        private GroupBox groupBox3;
        private PictureBox picImagen;
        private CheckBox chkSuspendido;
        private TextBox txtCaja;
        private Label label1;
        private Panel panel1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colBombon;
        private DataGridViewTextBoxColumn colCantidad;
        private Button btnCerrar;
        private Label label2;
        private TextBox txtDescripcion;
    }
}