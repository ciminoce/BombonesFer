namespace Bombones.Windows.Formularios
{
    partial class frmDetalleCtasCtes
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
            button1 = new Button();
            groupBox1 = new GroupBox();
            txtCodPostal = new TextBox();
            txtTelefono = new TextBox();
            txtLocalidad = new TextBox();
            txtDireccion = new TextBox();
            txtCliente = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtSaldo = new TextBox();
            button3 = new Button();
            btnCancelar = new Button();
            btnOK = new Button();
            button2 = new Button();
            dgvDatos = new DataGridView();
            colFecha = new DataGridViewTextBoxColumn();
            colMovimiento = new DataGridViewTextBoxColumn();
            colDebe = new DataGridViewTextBoxColumn();
            colHaber = new DataGridViewTextBoxColumn();
            colSaldo = new DataGridViewTextBoxColumn();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtSaldo);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(btnCancelar);
            splitContainer1.Panel2.Controls.Add(btnOK);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(dgvDatos);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Size = new Size(1084, 676);
            splitContainer1.SplitterDistance = 217;
            splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(701, 29);
            button1.Name = "button1";
            button1.Size = new Size(181, 57);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCodPostal);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(txtLocalidad);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(txtCliente);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(30, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(648, 173);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // txtCodPostal
            // 
            txtCodPostal.Location = new Point(413, 126);
            txtCodPostal.Name = "txtCodPostal";
            txtCodPostal.ReadOnly = true;
            txtCodPostal.Size = new Size(137, 23);
            txtCodPostal.TabIndex = 1;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(74, 126);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.ReadOnly = true;
            txtTelefono.Size = new Size(223, 23);
            txtTelefono.TabIndex = 1;
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(74, 92);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.ReadOnly = true;
            txtLocalidad.Size = new Size(476, 23);
            txtLocalidad.TabIndex = 1;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(74, 56);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.ReadOnly = true;
            txtDireccion.Size = new Size(476, 23);
            txtDireccion.TabIndex = 1;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(74, 22);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(476, 23);
            txtCliente.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(341, 129);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 0;
            label5.Text = "C.P.:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 129);
            label4.Name = "label4";
            label4.Size = new Size(24, 15);
            label4.TabIndex = 0;
            label4.Text = "Tel:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 95);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 0;
            label3.Text = "Localidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 59);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 0;
            label2.Text = "Dirección:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 25);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(666, 393);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.ReadOnly = true;
            txtSaldo.Size = new Size(137, 23);
            txtSaldo.TabIndex = 4;
            txtSaldo.TextChanged += txtSaldo_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(834, 105);
            button3.Name = "button3";
            button3.Size = new Size(181, 57);
            button3.TabIndex = 5;
            button3.Text = "button1";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(200, 390);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(92, 57);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "button1";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(70, 390);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(92, 57);
            btnOK.TabIndex = 7;
            btnOK.Text = "button1";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(834, 8);
            button2.Name = "button2";
            button2.Size = new Size(181, 57);
            button2.TabIndex = 8;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colFecha, colMovimiento, colDebe, colHaber, colSaldo });
            dgvDatos.Location = new Point(70, 8);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowTemplate.Height = 25;
            dgvDatos.Size = new Size(734, 370);
            dgvDatos.TabIndex = 2;
            // 
            // colFecha
            // 
            colFecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 63;
            // 
            // colMovimiento
            // 
            colMovimiento.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMovimiento.HeaderText = "Movimiento";
            colMovimiento.Name = "colMovimiento";
            colMovimiento.ReadOnly = true;
            // 
            // colDebe
            // 
            colDebe.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDebe.HeaderText = "Debe";
            colDebe.Name = "colDebe";
            colDebe.ReadOnly = true;
            colDebe.Width = 59;
            // 
            // colHaber
            // 
            colHaber.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colHaber.HeaderText = "Haber";
            colHaber.Name = "colHaber";
            colHaber.ReadOnly = true;
            colHaber.Width = 64;
            // 
            // colSaldo
            // 
            colSaldo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colSaldo.HeaderText = "Saldo";
            colSaldo.Name = "colSaldo";
            colSaldo.ReadOnly = true;
            colSaldo.Width = 61;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(594, 396);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 3;
            label6.Text = "Saldo";
            // 
            // frmDetalleCtasCtes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 676);
            Controls.Add(splitContainer1);
            Name = "frmDetalleCtasCtes";
            Text = "frmDetalleCtasCtes";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button1;
        private GroupBox groupBox1;
        private TextBox txtCodPostal;
        private TextBox txtTelefono;
        private TextBox txtLocalidad;
        private TextBox txtDireccion;
        private TextBox txtCliente;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSaldo;
        private Button button3;
        private Button btnCancelar;
        private Button btnOK;
        private Button button2;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colMovimiento;
        private DataGridViewTextBoxColumn colDebe;
        private DataGridViewTextBoxColumn colHaber;
        private DataGridViewTextBoxColumn colSaldo;
        private Label label6;
    }
}