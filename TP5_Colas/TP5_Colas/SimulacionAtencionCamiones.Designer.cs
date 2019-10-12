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
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_simular = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.grillaEstadisticas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaEstadisticas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(712, 511);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 190);
            this.textBox1.TabIndex = 29;
            // 
            // btn_simular
            // 
            this.btn_simular.Location = new System.Drawing.Point(80, 231);
            this.btn_simular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(100, 28);
            this.btn_simular.TabIndex = 30;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Promedio de Estadia de Camiones:";
            // 
            // txtPromedio
            // 
            this.txtPromedio.Location = new System.Drawing.Point(16, 320);
            this.txtPromedio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.Size = new System.Drawing.Size(124, 22);
            this.txtPromedio.TabIndex = 33;
            this.txtPromedio.Text = "Promedio";
            // 
            // grillaEstadisticas
            // 
            this.grillaEstadisticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaEstadisticas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.grillaEstadisticas.Location = new System.Drawing.Point(280, 14);
            this.grillaEstadisticas.Name = "grillaEstadisticas";
            this.grillaEstadisticas.RowHeadersWidth = 51;
            this.grillaEstadisticas.RowTemplate.Height = 24;
            this.grillaEstadisticas.Size = new System.Drawing.Size(532, 441);
            this.grillaEstadisticas.TabIndex = 34;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Dia";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Camiones Atendidos";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Camiones No Atendidos";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // SimulacionAtencionCamiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 554);
            this.Controls.Add(this.grillaEstadisticas);
            this.Controls.Add(this.txtPromedio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SimulacionAtencionCamiones";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}