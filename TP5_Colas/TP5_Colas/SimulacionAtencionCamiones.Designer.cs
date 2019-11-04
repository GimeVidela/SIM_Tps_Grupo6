namespace TP5_Colas
{
    partial class SimulacionAtencionCamiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulacionAtencionCamiones));
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_simular = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.grillaEstadisticas = new System.Windows.Forms.DataGridView();
            this.iteraciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.diasASimular = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.seg2 = new System.Windows.Forms.TextBox();
            this.min2 = new System.Windows.Forms.TextBox();
            this.hor2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(799, 415);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 28;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 11);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 155);
            this.textBox1.TabIndex = 29;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // btn_simular
            // 
            this.btn_simular.Location = new System.Drawing.Point(76, 319);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(75, 23);
            this.btn_simular.TabIndex = 8;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Promedio de Estadia de Camiones:";
            // 
            // txtPromedio
            // 
            this.txtPromedio.Location = new System.Drawing.Point(57, 380);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.Size = new System.Drawing.Size(94, 20);
            this.txtPromedio.TabIndex = 33;
            this.txtPromedio.Text = "Promedio";
            // 
            // grillaEstadisticas
            // 
            this.grillaEstadisticas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grillaEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaEstadisticas.Location = new System.Drawing.Point(238, 11);
            this.grillaEstadisticas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grillaEstadisticas.Name = "grillaEstadisticas";
            this.grillaEstadisticas.RowHeadersWidth = 51;
            this.grillaEstadisticas.RowTemplate.Height = 24;
            this.grillaEstadisticas.Size = new System.Drawing.Size(637, 399);
            this.grillaEstadisticas.TabIndex = 34;
            // 
            // iteraciones
            // 
            this.iteraciones.Location = new System.Drawing.Point(132, 239);
            this.iteraciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iteraciones.Name = "iteraciones";
            this.iteraciones.Size = new System.Drawing.Size(91, 20);
            this.iteraciones.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 201);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tiempo a simular";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 241);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Iteraciones a mostrar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 284);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "A partir de la hora";
            // 
            // diasASimular
            // 
            this.diasASimular.Location = new System.Drawing.Point(132, 197);
            this.diasASimular.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.diasASimular.Name = "diasASimular";
            this.diasASimular.Size = new System.Drawing.Size(55, 20);
            this.diasASimular.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(190, 283);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 282);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = ":";
            // 
            // seg2
            // 
            this.seg2.Location = new System.Drawing.Point(204, 280);
            this.seg2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.seg2.Name = "seg2";
            this.seg2.Size = new System.Drawing.Size(19, 20);
            this.seg2.TabIndex = 7;
            // 
            // min2
            // 
            this.min2.Location = new System.Drawing.Point(168, 280);
            this.min2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.min2.Name = "min2";
            this.min2.Size = new System.Drawing.Size(19, 20);
            this.min2.TabIndex = 6;
            // 
            // hor2
            // 
            this.hor2.Location = new System.Drawing.Point(132, 280);
            this.hor2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hor2.Name = "hor2";
            this.hor2.Size = new System.Drawing.Size(19, 20);
            this.hor2.TabIndex = 5;
            // 
            // SimulacionAtencionCamiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 443);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.seg2);
            this.Controls.Add(this.min2);
            this.Controls.Add(this.hor2);
            this.Controls.Add(this.diasASimular);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iteraciones);
            this.Controls.Add(this.grillaEstadisticas);
            this.Controls.Add(this.txtPromedio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Name = "SimulacionAtencionCamiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulación de Atención Camiones EPEC (Distr. Exp. Negativa)";
            ((System.ComponentModel.ISupportInitialize)(this.grillaEstadisticas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPromedio;
        private System.Windows.Forms.DataGridView grillaEstadisticas;
        private System.Windows.Forms.TextBox iteraciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox diasASimular;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox seg2;
        private System.Windows.Forms.TextBox min2;
        private System.Windows.Forms.TextBox hor2;
    }
}