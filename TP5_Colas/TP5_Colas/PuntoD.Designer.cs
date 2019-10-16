namespace TP5_Colas
{
    partial class PuntoD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoD));
            this.tbx_PromExpo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_simular = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.grillaDistrExpo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grillaDistrUni = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_PromUni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_Conclusion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDistrExpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDistrUni)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_PromExpo
            // 
            this.tbx_PromExpo.Location = new System.Drawing.Point(390, 436);
            this.tbx_PromExpo.Name = "tbx_PromExpo";
            this.tbx_PromExpo.Size = new System.Drawing.Size(94, 20);
            this.tbx_PromExpo.TabIndex = 39;
            this.tbx_PromExpo.Text = "Promedio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Promedio de Estadia de Camiones:";
            // 
            // btn_simular
            // 
            this.btn_simular.Location = new System.Drawing.Point(61, 237);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(75, 23);
            this.btn_simular.TabIndex = 36;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 190);
            this.textBox1.TabIndex = 35;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1059, 433);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 34;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // grillaDistrExpo
            // 
            this.grillaDistrExpo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaDistrExpo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.grillaDistrExpo.Location = new System.Drawing.Point(216, 41);
            this.grillaDistrExpo.Margin = new System.Windows.Forms.Padding(2);
            this.grillaDistrExpo.Name = "grillaDistrExpo";
            this.grillaDistrExpo.RowHeadersWidth = 51;
            this.grillaDistrExpo.RowTemplate.Height = 24;
            this.grillaDistrExpo.Size = new System.Drawing.Size(451, 383);
            this.grillaDistrExpo.TabIndex = 40;
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
            // grillaDistrUni
            // 
            this.grillaDistrUni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaDistrUni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.grillaDistrUni.Location = new System.Drawing.Point(681, 41);
            this.grillaDistrUni.Margin = new System.Windows.Forms.Padding(2);
            this.grillaDistrUni.Name = "grillaDistrUni";
            this.grillaDistrUni.RowHeadersWidth = 51;
            this.grillaDistrUni.RowTemplate.Height = 24;
            this.grillaDistrUni.Size = new System.Drawing.Size(453, 383);
            this.grillaDistrUni.TabIndex = 41;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Dia";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Camiones Atendidos";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Camiones No Atendidos";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(678, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Promedio de Estadia de Camiones:";
            // 
            // tbx_PromUni
            // 
            this.tbx_PromUni.Location = new System.Drawing.Point(855, 436);
            this.tbx_PromUni.Name = "tbx_PromUni";
            this.tbx_PromUni.Size = new System.Drawing.Size(94, 20);
            this.tbx_PromUni.TabIndex = 43;
            this.tbx_PromUni.Text = "Promedio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(213, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(427, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "Llegada de Camiones en Distribución Exponencial Negativa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(678, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(337, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Llegada de Camiones en Distribución Uniforme:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Conclusión:";
            // 
            // tbx_Conclusion
            // 
            this.tbx_Conclusion.Location = new System.Drawing.Point(16, 295);
            this.tbx_Conclusion.Multiline = true;
            this.tbx_Conclusion.Name = "tbx_Conclusion";
            this.tbx_Conclusion.Size = new System.Drawing.Size(178, 129);
            this.tbx_Conclusion.TabIndex = 47;
            // 
            // PuntoD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 461);
            this.Controls.Add(this.tbx_Conclusion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_PromUni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grillaDistrUni);
            this.Controls.Add(this.grillaDistrExpo);
            this.Controls.Add(this.tbx_PromExpo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSalir);
            this.Name = "PuntoD";
            this.Text = "Simulación de Atención Camiones EPEC (Distr. Normal)";
            ((System.ComponentModel.ISupportInitialize)(this.grillaDistrExpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDistrUni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_PromExpo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView grillaDistrExpo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView grillaDistrUni;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_PromUni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_Conclusion;
    }
}