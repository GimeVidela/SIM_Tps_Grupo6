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

            //Validacion de texboxs
            int hora1 = Int32.Parse(hor1.Text);
            int hora2 = Int32.Parse(hor2.Text);
            int minu1 = Int32.Parse(min1.Text);
            int minu2 = Int32.Parse(min2.Text);
            int segu1 = Int32.Parse(seg1.Text);
            int segu2 = Int32.Parse(seg2.Text);
            long iter = long.Parse(iteraciones.Text);
     


            if ((hora1 >= 0 && hora1 <= 24) && (hora2 >= 0 && hora2 <= 24) && (minu1 >= 0 && minu1 <= 60) && (minu2 >= 0 && minu2 <= 60) && (segu1 >= 0 && segu1 <= 60) && (segu2 >= 0 && segu2 <= 60))
            {
                if (iter >= 5 && iter <= 500000)
                {
                    TimeSpan TiempoASimular = TimeSpan.Parse(hor1.Text + ":" + min1.Text + ":" + seg1.Text);
                    TimeSpan TiempoIniciociclos = TimeSpan.Parse(hor2.Text + ":" + min2.Text + ":" + seg2.Text);

                    if (TiempoASimular <= TiempoIniciociclos)
                    {
                        MessageBox.Show(" La hora ingresada que indicara la cantidad de iteraciones a mostrar debe estar dentro del rango del tiempo a simular ingresado.");

                    }
                    else
                    {
                        GestorSimulacionVectorEstado gestor = new GestorSimulacionVectorEstado(Convert.ToInt32(iteraciones.Text), TiempoASimular, TiempoIniciociclos);
                        grillaEstadisticas.DataSource = gestor.SimularVectorEstado();
                        ListaCamionesGrilla grillaCamiones = new ListaCamionesGrilla();
                        grillaCamiones.cargarGrilla( gestor.cargarTablaCamiones(gestor.listaCamionesAtendidos));
                        grillaCamiones.Show();

                    }
                }
                else
                {
                    MessageBox.Show("La cantidad ingresada de iteraciones no es correcta. Ingrese un valor entre 5 y 500000.");
                }
                 
            }
            else
            {
                MessageBox.Show("Ingrese parametros de horas, minutos y segundos válidos. Para hora entre 0 y 24, para minutos y segundos entre 0 y 60.");
            }

           
           

            //int fila = 0; 
            //GestorSimulacion gestor = new GestorSimulacion();
            //gestor.Simulacion30dias();
            //txtPromedio.Text = Convert.ToString( gestor.sumTiempoPredioCamion );
            //for (int i = 0; i < gestor.resultados.Count; i++)
            //{
            //    fila = grillaEstadisticas.Rows.Add();
            //    grillaEstadisticas.Rows[fila].Cells[0].Value = i+1;
            //    grillaEstadisticas.Rows[fila].Cells[1].Value = gestor.resultados[i].Item1;
            //    grillaEstadisticas.Rows[fila].Cells[2].Value = gestor.resultados[i].Item2;

            //}
            //se ejecutara la simulacion de 30 dias con camiones en distro exponencial 
            //y se mostraran resultados en las grilla y en el textbox el promedio

        }
    }
}
