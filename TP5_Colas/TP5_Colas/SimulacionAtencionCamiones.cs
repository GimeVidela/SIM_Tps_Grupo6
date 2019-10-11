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
            GestorSimulacion gestor = new GestorSimulacion();
            gestor.SimulacionDia(1);
            //se ejecutara la simulacion de 30 dias con camiones en distro exponencial 
            //y se mostraran resultados en las grilla y en el textbox el promedio

        }
    }
}
