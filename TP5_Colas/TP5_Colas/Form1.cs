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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void batallaNavalModoAutomaticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulacionAtencionCamiones pantalla = new SimulacionAtencionCamiones();
            pantalla.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void puntoDComparaciónDeSimlacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PuntoD pant = new PuntoD();
            pant.Show();
        }
    }
}
