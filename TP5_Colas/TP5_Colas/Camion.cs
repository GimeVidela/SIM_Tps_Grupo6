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
        double aleatorio;
        TimeSpan horaLlegada;
        TimeSpan horaSalida = new TimeSpan();
        private GeneradorNumerosAleatoreos generador;
        public string estadoActual = "";
        //public TimeSpan horaDelEstado;
        public int numeroCamion;
        private List<string> estados = new List<string>();
        private List<string> tiempos = new List<string>();

        public Tuple<List<string>, List<string>> conocerEstados()
        {
            return Tuple.Create(this.estados, this.tiempos);
        }

        public void agregarEstado(string estado, TimeSpan reloj)
        {
            if(estado == "cola darcena" && estados[estados.Count - 1] == "fin atencion recepcion")
            {
                this.estados.Add("");
                this.tiempos.Add("");

                this.estados.Add("");
                this.tiempos.Add("");

            }
            this.estados.Add(estado);
            this.tiempos.Add(Convert.ToString(reloj));
        }

        public void setGenerador(ref GeneradorNumerosAleatoreos generador)
        {
            this.generador = generador;
            this.aleatorio = calcularTipoCamion();
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

        public double getTipoAleatorio()
        {
            return aleatorio;
        }

        private double calcularTipoCamion()
        {

            Double aleatorio = Math.Round(generador.GenerarAleatorio(), 3);
            if (aleatorio < 0.35)
            {
                tipoCamnion = 1; // CAMION PROPIO
            }
            else
            {
                tipoCamnion = 2; // CAMION EXTERNO
            }
            return aleatorio;
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
