namespace Bombones.Windows.Formularios
{
    partial class frmDetalleCtaCte
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
            groupBox1 = new GroupBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            label6 = new Label();
            textBox6 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            colFecha = new DataGridViewTextBoxColumn();
            colMovimiento = new DataGridViewTextBoxColumn();
            colDebe = new DataGridViewTextBoxColumn();
            colHaber = new DataGridViewTextBoxColumn();
            colSaldo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            splitContainer1.Panel2.Controls.Add(textBox6);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(button5);
            splitContainer1.Panel2.Controls.Add(button4);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Size = new Size(1022, 688);
            splitContainer1.SplitterDistance = 211;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(648, 173);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
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
            // textBox1
            // 
            textBox1.Location = new Point(74, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(476, 23);
            textBox1.TabIndex = 1;
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
            // textBox2
            // 
            textBox2.Location = new Point(74, 56);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(476, 23);
            textBox2.TabIndex = 1;
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
            // textBox3
            // 
            textBox3.Location = new Point(74, 92);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(476, 23);
            textBox3.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 129);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 0;
            label4.Text = "Pcia:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(74, 126);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(223, 23);
            textBox4.TabIndex = 1;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(413, 126);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(137, 23);
            textBox5.TabIndex = 1;
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
            // button1
            // 
            button1.Location = new Point(683, 29);
            button1.Name = "button1";
            button1.Size = new Size(181, 57);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colFecha, colMovimiento, colDebe, colHaber, colSaldo });
            dataGridView1.Location = new Point(29, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(734, 370);
            dataGridView1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(793, 22);
            button2.Name = "button2";
            button2.Size = new Size(181, 57);
            button2.TabIndex = 1;
            button2.Text = "button1";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(793, 119);
            button3.Name = "button3";
            button3.Size = new Size(181, 57);
            button3.TabIndex = 1;
            button3.Text = "button1";
            button3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(553, 410);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 0;
            label6.Text = "C.P.:";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(625, 407);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(137, 23);
            textBox6.TabIndex = 1;
            // 
            // button4
            // 
            button4.Location = new Point(29, 404);
            button4.Name = "button4";
            button4.Size = new Size(92, 57);
            button4.TabIndex = 1;
            button4.Text = "button1";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(159, 404);
            button5.Name = "button5";
            button5.Size = new Size(92, 57);
            button5.TabIndex = 1;
            button5.Text = "button1";
            button5.UseVisualStyleBackColor = true;
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
            // frmDetalleCtaCte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 688);
            Controls.Add(splitContainer1);
            Name = "frmDetalleCtaCte";
            Text = "frmDetalleCtaCte";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
        private Label label5;
        private Button button1;
        private TextBox textBox6;
        private Button button3;
        private Button button5;
        private Button button4;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label6;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colMovimiento;
        private DataGridViewTextBoxColumn colDebe;
        private DataGridViewTextBoxColumn colHaber;
        private DataGridViewTextBoxColumn colSaldo;
    }
}