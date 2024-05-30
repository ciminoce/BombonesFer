namespace Bombones.Windows
{
    partial class frmFiltrarPorPais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltrarPorPais));
            cboPaises = new ComboBox();
            btnCancelar = new Button();
            btnOk = new Button();
            label3 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboPaises
            // 
            cboPaises.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaises.FormattingEnabled = true;
            cboPaises.Location = new Point(65, 33);
            cboPaises.Name = "cboPaises";
            cboPaises.Size = new Size(380, 23);
            cboPaises.TabIndex = 8;
            cboPaises.SelectedIndexChanged += cboPaises_SelectedIndexChanged;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.Cancelar;
            btnCancelar.Location = new Point(340, 102);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 54);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.Image = (Image)resources.GetObject("btnOk.Image");
            btnOk.Location = new Point(65, 102);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(249, 54);
            btnOk.TabIndex = 9;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 41);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 11;
            label3.Text = "País :";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmFiltrarPorPais
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 180);
            Controls.Add(cboPaises);
            Controls.Add(btnCancelar);
            Controls.Add(btnOk);
            Controls.Add(label3);
            Name = "frmFiltrarPorPais";
            Text = "frmFiltrarPorPais";
            Load += frmFiltrarPorPais_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboPaises;
        private Button btnCancelar;
        private Button btnOk;
        private Label label3;
        private ErrorProvider errorProvider1;
    }
}