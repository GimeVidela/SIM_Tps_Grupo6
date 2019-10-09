using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class DarsenaSvr
    {
        private TimeSpan CalcularTiempoDescarga(double valorA, double valorB)
        {
            //Distribucion Uniforme
            TimeSpan tiempoDescarga = new TimeSpan();
            Random rand = new Random();
            float aleatorio = rand.Next(0, 1);

            long tiempo = (long)valorA + (long)aleatorio * (long)(valorB - valorA);

            tiempoDescarga = new TimeSpan(tiempo);
            return tiempoDescarga;
        }

        private TimeSpan CalcularTiempoCalibracion(double media, double varianza)
        {
            //Distribucion Normal
            TimeSpan tiempoCalibracion = new TimeSpan();
            Random rand = new Random();
            float aleatorio1 = rand.Next(0, 1);
            float aleatorio2 = rand.Next(0, 1);

            long tiempo = (long)Math.Sqrt(-2*Math.Log(aleatorio1)) * (long)(Math.Sin(2*Math.PI*aleatorio2));

            tiempoCalibracion = new TimeSpan(tiempo);
            return tiempoCalibracion;
        }
    }
}
