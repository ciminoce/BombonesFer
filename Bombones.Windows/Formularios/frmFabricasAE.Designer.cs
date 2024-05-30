namespace Bombones.Windows
{
    partial class frmFabricasAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFabricasAE));
            btnCancelar = new Button();
            btnOk = new Button();
            txtFabrica = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtDireccion = new TextBox();
            label3 = new Label();
            cboPaises = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(332, 167);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(17, 167);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(289, 54);
            btnOk.TabIndex = 3;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtFabrica
            // 
            txtFabrica.Location = new Point(95, 24);
            txtFabrica.MaxLength = 50;
            txtFabrica.Name = "txtFabrica";
            txtFabrica.Size = new Size(342, 23);
            txtFabrica.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 27);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 5;
            label1.Text = "Fábrica:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 65);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(95, 62);
            txtDireccion.MaxLength = 100;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(342, 23);
            txtDireccion.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 114);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 5;
            label3.Text = "País :";
            // 
            // cboPaises
            // 
            cboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaises.FormattingEnabled = true;
            cboPaises.Location = new Point(95, 106);
            cboPaises.Name = "cboPaises";
            cboPaises.Size = new Size(342, 23);
            cboPaises.TabIndex = 2;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmFabricaAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 268);
            Controls.Add(cboPaises);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(txtDireccion);
            Controls.Add(txtFabrica);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(486, 307);
            MinimumSize = new Size(486, 307);
            Name = "frmFabricaAE";
            Text = "frmFabricaAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancelar;
        private Button btnOk;
        private TextBox txtFabrica;
        private Label label1;
        private Label label2;
        private TextBox txtDireccion;
        private Label label3;
        private ComboBox cboPaises;
        private ErrorProvider errorProvider1;
    }
}