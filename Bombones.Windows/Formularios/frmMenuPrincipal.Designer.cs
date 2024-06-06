namespace Bombones.Windows
{
    partial class frmMenuPrincipal
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
            btnRellenos = new Button();
            btnChocolates = new Button();
            btnNueces = new Button();
            btnPaises = new Button();
            btnFabricas = new Button();
            btnBombones = new Button();
            btnCajas = new Button();
            btnVentas = new Button();
            btnCtaCte = new Button();
            SuspendLayout();
            // 
            // btnRellenos
            // 
            btnRellenos.Location = new Point(24, 24);
            btnRellenos.Name = "btnRellenos";
            btnRellenos.Size = new Size(139, 123);
            btnRellenos.TabIndex = 0;
            btnRellenos.Text = "Tipos de Relleno";
            btnRellenos.UseVisualStyleBackColor = true;
            btnRellenos.Click += btnRellenos_Click;
            // 
            // btnChocolates
            // 
            btnChocolates.Location = new Point(205, 24);
            btnChocolates.Name = "btnChocolates";
            btnChocolates.Size = new Size(139, 123);
            btnChocolates.TabIndex = 0;
            btnChocolates.Text = "Tipos de Chocolate";
            btnChocolates.UseVisualStyleBackColor = true;
            btnChocolates.Click += btnChocolates_Click;
            // 
            // btnNueces
            // 
            btnNueces.Location = new Point(400, 24);
            btnNueces.Name = "btnNueces";
            btnNueces.Size = new Size(139, 123);
            btnNueces.TabIndex = 0;
            btnNueces.Text = "Tipos de Nuez";
            btnNueces.UseVisualStyleBackColor = true;
            btnNueces.Click += btnNueces_Click;
            // 
            // btnPaises
            // 
            btnPaises.Location = new Point(608, 24);
            btnPaises.Name = "btnPaises";
            btnPaises.Size = new Size(139, 123);
            btnPaises.TabIndex = 0;
            btnPaises.Text = "Países";
            btnPaises.UseVisualStyleBackColor = true;
            btnPaises.Click += btnPaises_Click;
            // 
            // btnFabricas
            // 
            btnFabricas.Location = new Point(24, 194);
            btnFabricas.Name = "btnFabricas";
            btnFabricas.Size = new Size(139, 123);
            btnFabricas.TabIndex = 0;
            btnFabricas.Text = "Fábricas";
            btnFabricas.UseVisualStyleBackColor = true;
            btnFabricas.Click += btnFabricas_Click;
            // 
            // btnBombones
            // 
            btnBombones.Location = new Point(205, 194);
            btnBombones.Name = "btnBombones";
            btnBombones.Size = new Size(139, 123);
            btnBombones.TabIndex = 0;
            btnBombones.Text = "Bombones";
            btnBombones.UseVisualStyleBackColor = true;
            btnBombones.Click += btnBombones_Click;
            // 
            // btnCajas
            // 
            btnCajas.Location = new Point(400, 194);
            btnCajas.Name = "btnCajas";
            btnCajas.Size = new Size(139, 123);
            btnCajas.TabIndex = 0;
            btnCajas.Text = "Cajas";
            btnCajas.UseVisualStyleBackColor = true;
            btnCajas.Click += btnCajas_Click;
            // 
            // btnVentas
            // 
            btnVentas.Location = new Point(24, 363);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(139, 123);
            btnVentas.TabIndex = 0;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnCtaCte
            // 
            btnCtaCte.Location = new Point(205, 363);
            btnCtaCte.Name = "btnCtaCte";
            btnCtaCte.Size = new Size(139, 123);
            btnCtaCte.TabIndex = 0;
            btnCtaCte.Text = "Cta.Cte.";
            btnCtaCte.UseVisualStyleBackColor = true;
            btnCtaCte.Click += btnCtaCte_Click;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 551);
            Controls.Add(btnCtaCte);
            Controls.Add(btnVentas);
            Controls.Add(btnCajas);
            Controls.Add(btnBombones);
            Controls.Add(btnFabricas);
            Controls.Add(btnPaises);
            Controls.Add(btnNueces);
            Controls.Add(btnChocolates);
            Controls.Add(btnRellenos);
            Name = "frmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnRellenos;
        private Button btnChocolates;
        private Button btnNueces;
        private Button btnPaises;
        private Button btnFabricas;
        private Button btnBombones;
        private Button btnCajas;
        private Button btnVentas;
        private Button btnCtaCte;
    }
}