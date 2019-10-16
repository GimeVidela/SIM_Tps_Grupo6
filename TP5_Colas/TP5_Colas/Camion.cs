using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class Camion
    {
        int tipoCamnion;
        TimeSpan horaLlegada;
        TimeSpan horaSalida = new TimeSpan();
        private GeneradorNumerosAleatoreos generador;
        public string estadoActual = "";
        //public TimeSpan horaDelEstado;
        public int numeroCamion;

        public void setGenerador(ref GeneradorNumerosAleatoreos generador)
        {
            this.generador = generador;
            calcularTipoCamion();
        }
        public void setHoraLlegada (TimeSpan horaLlegadaCamion)
        {
            this.horaLlegada = horaLlegadaCamion;
        }


        public Camion(int numeroCamion = 0)
        {
            this.numeroCamion = numeroCamion;

        }


        public void setHoraSalida(TimeSpan hora)
        {
            horaSalida = hora;
        }
        public TimeSpan TioempoAdentro()
        {
            TimeSpan tiempoAdentroDelComplejo;
            tiempoAdentroDelComplejo = horaSalida - horaLlegada;
            return tiempoAdentroDelComplejo;
        }

        public int getTipoCamion()
        {
           return tipoCamnion;
        }

        private void calcularTipoCamion()
        {
            
            Double aleatorio = generador.GenerarAleatorio();
            if (aleatorio < 0.35)
            {
                tipoCamnion = 1; // CAMION PROPIO
            }
            else
            {
                tipoCamnion = 2; // CAMION EXTERNO
            }
          
        }

    //    private TimeSpan llegadaCamionExponencial(double lambda)
    //    {
    //        //Distribucion Exponencial Negativa
    //        TimeSpan llegada = new TimeSpan();
    //        Random rand = new Random();
    //        double aleatorio = rand.Next(0, 1);
    //        long tiempoLlegada = 0;
    //        tiempoLlegada = (long)-lambda * (long)Math.Log(1 - aleatorio);

    //        llegada = new TimeSpan(tiempoLlegada);
    //        return llegada;
    //    }


    //    private TimeSpan llegadaCamionUniforme(double valorA, double valorB)
    //    {
    //        //Distribucion Uniforme
    //        TimeSpan llegada = new TimeSpan();
    //        Random rand = new Random();
    //        double aleatorio = rand.Next(0, 1);
    //        long tiempoLlegada = 0;
    //        tiempoLlegada = (long)valorA + (long)aleatorio * (long)(valorB - valorA);

    //        llegada = new TimeSpan(tiempoLlegada);
    //        return llegada;
    //    }
    }
}
