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
    public partial class ListaCamionesGrilla : Form
    {
        public ListaCamionesGrilla()
        {
            InitializeComponent();
        }

        private void ListaCamionesGrilla_Load(object sender, EventArgs e)
        {

        }
        public void cargarGrilla(DataTable tablaCamiones)
        {
            GrillaListaCamiones.DataSource = tablaCamiones;
        }
    }
}
