using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP5_Colas
{
    public partial class SimulacionAtencionCamiones : Form
    {
        public SimulacionAtencionCamiones()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            grillaEstadisticas.Rows.Clear();


            int fila = 0; 
            GestorSimulacion gestor = new GestorSimulacion();
            gestor.Simulacion30dias();
            txtPromedio.Text = Convert.ToString( gestor.sumTiempoPredioCamion );
            for (int i = 0; i < gestor.resultados.Count; i++)
            {
                fila = grillaEstadisticas.Rows.Add();
                grillaEstadisticas.Rows[fila].Cells[0].Value = i+1;
                grillaEstadisticas.Rows[fila].Cells[1].Value = gestor.resultados[i].Item1;
                grillaEstadisticas.Rows[fila].Cells[2].Value = gestor.resultados[i].Item2;
                
            }
            //se ejecutara la simulacion de 30 dias con camiones en distro exponencial 
            //y se mostraran resultados en las grilla y en el textbox el promedio

        }
    }
}
