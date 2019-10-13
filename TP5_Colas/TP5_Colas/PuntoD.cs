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
    public partial class PuntoD : Form
    {
        public PuntoD()
        {
            InitializeComponent();
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            grillaDistrExpo.Rows.Clear();
            grillaDistrUni.Rows.Clear();

            //Simulacion con distribucion exponencial
            int fila = 0;
            GestorSimulacion gestor = new GestorSimulacion();
            gestor.Simulacion30dias();
            tbx_PromExpo.Text = Convert.ToString(gestor.sumTiempoPredioCamion);
            for (int i = 0; i < gestor.resultados.Count; i++)
            {
                fila = grillaDistrExpo.Rows.Add();
                grillaDistrExpo.Rows[fila].Cells[0].Value = i + 1;
                grillaDistrExpo.Rows[fila].Cells[1].Value = gestor.resultados[i].Item1;
                grillaDistrExpo.Rows[fila].Cells[2].Value = gestor.resultados[i].Item2;
            }

            //Simulacion con distribucion uniforme
            int fila2 = 0;
            GestorSimulacionUni gestor2 = new GestorSimulacionUni();
            gestor2.Simulacion30diasUni();
            tbx_PromUni.Text = Convert.ToString(gestor2.sumTiempoPredioCamionUni);
            for (int j = 0; j < gestor2.resultados.Count; j++)
            {
                fila2 = grillaDistrUni.Rows.Add();
                grillaDistrUni.Rows[fila2].Cells[0].Value = j + 1;
                grillaDistrUni.Rows[fila2].Cells[1].Value = gestor2.resultados[j].Item1;
                grillaDistrUni.Rows[fila2].Cells[2].Value = gestor2.resultados[j].Item2;
            }

            //Completar conclusion
            TimeSpan promUni = gestor2.sumTiempoPredioCamionUni;
            TimeSpan promExpo = gestor.sumTiempoPredioCamion;
            if (promUni < promExpo)
            {
                tbx_Conclusion.Text = "El promedio de estadia de camiones dentro del proceso, desde que es atendido po el recepcionista hasta uqe termina la descarga del combustible, es menor cuando la llegada de camiones se produce apartir de las 5:00 hs. (Apertura de Planta) en Distribución Uniforme entre 7 y 8 minutos.";
            }
            else
            {
                tbx_Conclusion.Text = "El promedio de estadia de camiones dentro del proceso, desde que es atendido po el recepcionista hasta uqe termina la descarga del combustible, es menor cuando la llegada de camiones se produce apartir de las 12:00 hs. en Distribución Exponencial Negativa de 7,5 minutos.";
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
