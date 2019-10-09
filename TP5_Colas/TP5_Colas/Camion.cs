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
        //TimeSpan horaLLegada = 0:00 ;

        private int calcularTipoCamion()
        {
            int tipo = 0;
            Random rand = new Random();
            float aleatorio = rand.Next(0, 1);
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

        private TimeSpan llegadaCamionExponencial(double lambda)
        {
            //Distribucion Exponencial Negativa
            TimeSpan llegada = new TimeSpan();
            Random rand = new Random();
            double aleatorio = rand.Next(0, 1);
            long tiempoLlegada = 0;
            tiempoLlegada = (long)-lambda * (long)Math.Log(1 - aleatorio);

            llegada = new TimeSpan(tiempoLlegada);
            return llegada;
        }


        private TimeSpan llegadaCamionUniforme(double valorA, double valorB)
        {
            //Distribucion Uniforme
            TimeSpan llegada = new TimeSpan();
            Random rand = new Random();
            double aleatorio = rand.Next(0, 1);
            long tiempoLlegada = 0;
            tiempoLlegada = (long)valorA + (long)aleatorio * (long)(valorB - valorA);

            llegada = new TimeSpan(tiempoLlegada);
            return llegada;
        }
    }
}
