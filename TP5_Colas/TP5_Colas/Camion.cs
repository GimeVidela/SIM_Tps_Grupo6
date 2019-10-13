using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class Camion
    {
        int tipoCamnion = 0;
        TimeSpan horaLlegada;
        TimeSpan horaSalida = new TimeSpan();
        private GeneradorNumerosAleatoreos generador;

        public void setGenerador(ref GeneradorNumerosAleatoreos generador)
        {
            this.generador = generador;
            tipoCamnion = calcularTipoCamion();
        }
        public void setHoraLlegada (TimeSpan horaLlegadaCamion)
        {
            this.horaLlegada = horaLlegadaCamion;
        }


        public void setHoraSalida(TimeSpan hora)
        {
            horaSalida = hora;
        }
        public TimeSpan TioempoAdentro()
        {
            //Metodo que calcula estadi del camion desde que es atendido hasta que descarga el combustible en darsena
            TimeSpan tiempoAdentroDelComplejo;
            tiempoAdentroDelComplejo = horaSalida - horaLlegada;
            return tiempoAdentroDelComplejo;
        }

        public int getTipoCamion()
        {
            return tipoCamnion;
        }

        private int calcularTipoCamion()
        {
            // metodo que determina si el camion es propio o externo
            int tipo = 0;
            Double aleatorio = generador.GenerarAleatorio();
            if (aleatorio < 0.35)
            {
                tipo = 1; // CAMION PROPIO
            }
            else
            {
                tipo = 2; // CAMION EXTERNO
            }
            return tipo;
        }
    }
}
