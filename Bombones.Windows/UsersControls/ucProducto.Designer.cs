namespace Bombones.Windows.UsersControls
{
    partial class ucProducto
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            picImagen = new PictureBox();
            lblProducto = new Label();
            lblPrecio = new Label();
            btnAgregar = new Button();
            lblStock = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)picImagen).BeginInit();
            SuspendLayout();
            // 
            // picImagen
            // 
            picImagen.Location = new Point(21, 19);
            picImagen.Name = "picImagen";
            picImagen.Size = new Size(100, 122);
            picImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            picImagen.TabIndex = 0;
            picImagen.TabStop = false;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblProducto.Location = new Point(22, 153);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(58, 15);
            lblProducto.TabIndex = 1;
            lblProducto.Text = "Producto";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecio.Location = new Point(136, 19);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(42, 15);
            lblPrecio.TabIndex = 1;
            lblPrecio.Text = "Precio";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(70, 185);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 43);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblStock.Location = new Point(175, 51);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 1;
            lblStock.Text = "Stock";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(136, 51);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Stock:";
            // 
            // ucProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnAgregar);
            Controls.Add(label1);
            Controls.Add(lblStock);
            Controls.Add(lblPrecio);
            Controls.Add(lblProducto);
            Controls.Add(picImagen);
            Name = "ucProducto";
            Size = new Size(227, 240);
            Load += ucProducto_Load;
            MouseLeave += ucProducto_MouseLeave;
            MouseHover += ucProducto_MouseHover;
            ((System.ComponentModel.ISupportInitialize)picImagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picImagen;
        private Label lblProducto;
        private Label lblPrecio;
        public Label lblStock;
        private Label label1;
        public Button btnAgregar;
    }
}
