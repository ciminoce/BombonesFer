﻿namespace Bombones.Windows.Formularios
{
    partial class frmBombonAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBombonAE));
            label1 = new Label();
            txtBombon = new TextBox();
            groupBox1 = new GroupBox();
            cboNueces = new ComboBox();
            cboRellenos = new ComboBox();
            cboChocolates = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            txtPrecioVta = new TextBox();
            txtPrecioCosto = new TextBox();
            label6 = new Label();
            label5 = new Label();
            groupBox3 = new GroupBox();
            picImagen = new PictureBox();
            btnBuscarImagen = new Button();
            label7 = new Label();
            txtStock = new TextBox();
            chkSuspendido = new CheckBox();
            btnCancelar = new Button();
            btnOk = new Button();
            label8 = new Label();
            txtDescripcion = new TextBox();
            label9 = new Label();
            txtNivelDeReposicion = new TextBox();
            label10 = new Label();
            cboFabricas = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 24);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Bombón:";
            // 
            // txtBombon
            // 
            txtBombon.Location = new Point(121, 21);
            txtBombon.MaxLength = 120;
            txtBombon.Name = "txtBombon";
            txtBombon.Size = new Size(412, 23);
            txtBombon.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboNueces);
            groupBox1.Controls.Add(cboRellenos);
            groupBox1.Controls.Add(cboChocolates);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(58, 158);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(379, 123);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = " Ingredientes ";
            // 
            // cboNueces
            // 
            cboNueces.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNueces.FormattingEnabled = true;
            cboNueces.Location = new Point(99, 88);
            cboNueces.Name = "cboNueces";
            cboNueces.Size = new Size(211, 23);
            cboNueces.TabIndex = 1;
            // 
            // cboRellenos
            // 
            cboRellenos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRellenos.FormattingEnabled = true;
            cboRellenos.Location = new Point(99, 57);
            cboRellenos.Name = "cboRellenos";
            cboRellenos.Size = new Size(211, 23);
            cboRellenos.TabIndex = 1;
            // 
            // cboChocolates
            // 
            cboChocolates.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChocolates.FormattingEnabled = true;
            cboChocolates.Location = new Point(99, 24);
            cboChocolates.Name = "cboChocolates";
            cboChocolates.Size = new Size(211, 23);
            cboChocolates.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 91);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 0;
            label4.Text = "Nuez:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 60);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 0;
            label3.Text = "Relleno:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 27);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 0;
            label2.Text = "Chocolate:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPrecioVta);
            groupBox2.Controls.Add(txtPrecioCosto);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(58, 311);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(379, 67);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = " Precios ";
            // 
            // txtPrecioVta
            // 
            txtPrecioVta.Location = new Point(262, 25);
            txtPrecioVta.Name = "txtPrecioVta";
            txtPrecioVta.Size = new Size(100, 23);
            txtPrecioVta.TabIndex = 1;
            // 
            // txtPrecioCosto
            // 
            txtPrecioCosto.Location = new Point(81, 23);
            txtPrecioCosto.Name = "txtPrecioCosto";
            txtPrecioCosto.Size = new Size(100, 23);
            txtPrecioCosto.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(194, 27);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 0;
            label6.Text = "P. Vta.:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 25);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 0;
            label5.Text = "P. Costo:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(picImagen);
            groupBox3.Location = new Point(469, 158);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(185, 188);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = " Imágen ";
            // 
            // picImagen
            // 
            picImagen.Location = new Point(17, 21);
            picImagen.Name = "picImagen";
            picImagen.Size = new Size(152, 152);
            picImagen.TabIndex = 0;
            picImagen.TabStop = false;
            // 
            // btnBuscarImagen
            // 
            btnBuscarImagen.Image = Properties.Resources.Buscar;
            btnBuscarImagen.Location = new Point(472, 352);
            btnBuscarImagen.Name = "btnBuscarImagen";
            btnBuscarImagen.Size = new Size(182, 49);
            btnBuscarImagen.TabIndex = 5;
            btnBuscarImagen.Text = "Buscar";
            btnBuscarImagen.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBuscarImagen.UseVisualStyleBackColor = true;
            btnBuscarImagen.Click += btnBuscarImagen_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(65, 387);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 6;
            label7.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(110, 384);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(86, 23);
            txtStock.TabIndex = 7;
            // 
            // chkSuspendido
            // 
            chkSuspendido.AutoSize = true;
            chkSuspendido.Location = new Point(550, 21);
            chkSuspendido.Name = "chkSuspendido";
            chkSuspendido.Size = new Size(88, 19);
            chkSuspendido.TabIndex = 8;
            chkSuspendido.Text = "Suspendido";
            chkSuspendido.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(471, 437);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(139, 437);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 10;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(50, 53);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 0;
            label8.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(121, 50);
            txtDescripcion.MaxLength = 256;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(412, 91);
            txtDescripcion.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(219, 389);
            label9.Name = "label9";
            label9.Size = new Size(114, 15);
            label9.TabIndex = 6;
            label9.Text = "Nivel de Reposición:";
            // 
            // txtNivelDeReposicion
            // 
            txtNivelDeReposicion.Location = new Point(351, 384);
            txtNivelDeReposicion.Name = "txtNivelDeReposicion";
            txtNivelDeReposicion.Size = new Size(86, 23);
            txtNivelDeReposicion.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(72, 290);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 0;
            label10.Text = "Fábrica:";
            // 
            // cboFabricas
            // 
            cboFabricas.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFabricas.FormattingEnabled = true;
            cboFabricas.Location = new Point(157, 287);
            cboFabricas.Name = "cboFabricas";
            cboFabricas.Size = new Size(211, 23);
            cboFabricas.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmBombonAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 516);
            Controls.Add(cboFabricas);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(label10);
            Controls.Add(chkSuspendido);
            Controls.Add(txtNivelDeReposicion);
            Controls.Add(label9);
            Controls.Add(txtStock);
            Controls.Add(label7);
            Controls.Add(btnBuscarImagen);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txtDescripcion);
            Controls.Add(label8);
            Controls.Add(txtBombon);
            Controls.Add(label1);
            Name = "frmBombonAE";
            Text = "frmBombonAE";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picImagen).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBombon;
        private GroupBox groupBox1;
        private ComboBox cboNueces;
        private ComboBox cboRellenos;
        private ComboBox cboChocolates;
        private Label label4;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private TextBox txtPrecioVta;
        private TextBox txtPrecioCosto;
        private Label label6;
        private Label label5;
        private GroupBox groupBox3;
        private PictureBox picImagen;
        private Button btnBuscarImagen;
        private Label label7;
        private TextBox txtStock;
        private CheckBox chkSuspendido;
        private Button btnCancelar;
        private Button btnOk;
        private Label label8;
        private TextBox txtDescripcion;
        private Label label9;
        private TextBox txtNivelDeReposicion;
        private Label label10;
        private ComboBox cboFabricas;
        private ErrorProvider errorProvider1;
        private OpenFileDialog openFileDialog1;
    }
}