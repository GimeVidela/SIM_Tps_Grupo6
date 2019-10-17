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
            this.hor1 = new System.Windows.Forms.TextBox();
            this.min1 = new System.Windows.Forms.TextBox();
            this.seg1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.btnSalir.Location = new System.Drawing.Point(1065, 511);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 28;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 14);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 190);
            this.textBox1.TabIndex = 29;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // btn_simular
            // 
            this.btn_simular.Location = new System.Drawing.Point(66, 401);
            this.btn_simular.Margin = new System.Windows.Forms.Padding(4);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(100, 28);
            this.btn_simular.TabIndex = 8;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 444);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Promedio de Estadia de Camiones:";
            // 
            // txtPromedio
            // 
            this.txtPromedio.Location = new System.Drawing.Point(19, 483);
            this.txtPromedio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.Size = new System.Drawing.Size(124, 22);
            this.txtPromedio.TabIndex = 33;
            this.txtPromedio.Text = "Promedio";
            // 
            // grillaEstadisticas
            // 
            this.grillaEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaEstadisticas.Location = new System.Drawing.Point(317, 14);
            this.grillaEstadisticas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grillaEstadisticas.Name = "grillaEstadisticas";
            this.grillaEstadisticas.RowHeadersWidth = 51;
            this.grillaEstadisticas.RowTemplate.Height = 24;
            this.grillaEstadisticas.Size = new System.Drawing.Size(849, 491);
            this.grillaEstadisticas.TabIndex = 34;
            // 
            // iteraciones
            // 
            this.iteraciones.Location = new System.Drawing.Point(176, 294);
            this.iteraciones.Name = "iteraciones";
            this.iteraciones.Size = new System.Drawing.Size(120, 22);
            this.iteraciones.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tiempo a simular";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Iteraciones a mostrar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 350);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "A partir de la hora";
            // 
            // hor1
            // 
            this.hor1.Location = new System.Drawing.Point(176, 242);
            this.hor1.Name = "hor1";
            this.hor1.Size = new System.Drawing.Size(24, 22);
            this.hor1.TabIndex = 1;
            // 
            // min1
            // 
            this.min1.Location = new System.Drawing.Point(224, 242);
            this.min1.Name = "min1";
            this.min1.Size = new System.Drawing.Size(24, 22);
            this.min1.TabIndex = 2;
            // 
            // seg1
            // 
            this.seg1.Location = new System.Drawing.Point(272, 241);
            this.seg1.Name = "seg1";
            this.seg1.Size = new System.Drawing.Size(24, 22);
            this.seg1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 348);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 17);
            this.label9.TabIndex = 49;
            this.label9.Text = ":";
            // 
            // seg2
            // 
            this.seg2.Location = new System.Drawing.Point(272, 344);
            this.seg2.Name = "seg2";
            this.seg2.Size = new System.Drawing.Size(24, 22);
            this.seg2.TabIndex = 7;
            // 
            // min2
            // 
            this.min2.Location = new System.Drawing.Point(224, 345);
            this.min2.Name = "min2";
            this.min2.Size = new System.Drawing.Size(24, 22);
            this.min2.TabIndex = 6;
            // 
            // hor2
            // 
            this.hor2.Location = new System.Drawing.Point(176, 345);
            this.hor2.Name = "hor2";
            this.hor2.Size = new System.Drawing.Size(24, 22);
            this.hor2.TabIndex = 5;
            // 
            // SimulacionAtencionCamiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 545);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.seg2);
            this.Controls.Add(this.min2);
            this.Controls.Add(this.hor2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.seg1);
            this.Controls.Add(this.min1);
            this.Controls.Add(this.hor1);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox hor1;
        private System.Windows.Forms.TextBox min1;
        private System.Windows.Forms.TextBox seg1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox seg2;
        private System.Windows.Forms.TextBox min2;
        private System.Windows.Forms.TextBox hor2;
    }
}