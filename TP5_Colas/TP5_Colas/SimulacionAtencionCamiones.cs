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
            if (diasASimular.Text != "" && hor2.Text != "" && min2.Text != "" && seg2.Text != "" && iteraciones.Text != "")
            {
                if (diasASimular.Text.Any(x => !char.IsNumber(x)) || hor2.Text.Any(x => !char.IsNumber(x)) || min2.Text.Any(x => !char.IsNumber(x)) || seg2.Text.Any(x => !char.IsNumber(x)) || iteraciones.Text.Any(x => !char.IsNumber(x)))
                {
                    MessageBox.Show("Solo ingrese valores numéricos");
                }
                else
                {
                    //Validacion de texboxs
                    int dias = Convert.ToInt32(diasASimular.Text);
                    int hora2 = Int32.Parse(hor2.Text);
                    int minu2 = Int32.Parse(min2.Text);
                    int segu2 = Int32.Parse(seg2.Text);
                    long iter = long.Parse(iteraciones.Text);

                    if (dias > 0 && (hora2 >= 0 && hora2 <= 24) && (minu2 >= 0 && minu2 <= 60) && (segu2 >= 0 && segu2 <= 60))
                    {
                        if (iter >= 5 && iter <= 500000)
                        {
                            TimeSpan TiempoASimular = TimeSpan.Parse(dias * 24 + ":" + "0" + ":" + "0");
                            TimeSpan TiempoIniciociclos = TimeSpan.Parse(hor2.Text + ":" + min2.Text + ":" + seg2.Text);

                            if (TiempoASimular <= TiempoIniciociclos)
                            {
                                MessageBox.Show(" La hora ingresada que indicara la cantidad de iteraciones a mostrar debe estar dentro del rango del tiempo a simular ingresado.");

                            }
                            else
                            {
                                GestorSimulacionVectorEstado gestor = new GestorSimulacionVectorEstado(Convert.ToInt32(iteraciones.Text), dias, TiempoIniciociclos);
                                grillaEstadisticas.DataSource = gestor.SimularVectorEstado();
                                ListaCamionesGrilla grillaCamiones = new ListaCamionesGrilla();
                                grillaCamiones.cargarGrilla(gestor.cargarTablaCamiones(gestor.listaCamionesAtendidos));
                                grillaCamiones.Show();
                                txtPromedio.Text = Convert.ToString(gestor.sumTiempoPredioCamion);
                                lblResultado.Text = "Cantidad de camiones atendidos: " + Convert.ToString(gestor.totalCamionesGlobal()) + ". Camiones NO atendidos: " + Convert.ToString(gestor.totalNoCamionesGlobal()) + ".-";
                                lblResultado.Visible = true;

                                //ListaCamionesGrilla grillaCamiones2 = new ListaCamionesGrilla();
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
                    //GestorSimulacion gestor2 = new GestorSimulacion();
                    //gestor2.Simulacion30dias();
                    //txtPromedio.Text = Convert.ToString(gestor2.sumTiempoPredioCamion);
                    //for (int i = 0; i < gestor2.resultados.Count; i++)
                    //{
                    //    fila = grillaEstadisticas.Rows.Add();
                    //    grillaEstadisticas.Rows[fila].Cells[0].Value = i + 1;
                    //    grillaEstadisticas.Rows[fila].Cells[1].Value = gestor2.resultados[i].Item1;
                    //    grillaEstadisticas.Rows[fila].Cells[2].Value = gestor2.resultados[i].Item2;

                    //}
                    // se ejecutara la simulacion de 30 dias con camiones en distro exponencial
                    // y se mostraran resultados en las grilla y en el textbox el promedio
                }
            }
            else
            {
                MessageBox.Show("Ningún campo debe estar vacío");
            }
        }
    }
}
