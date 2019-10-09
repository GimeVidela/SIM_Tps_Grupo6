using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class BalanzaSvr
    {
        private TimeSpan CalcularTiempoPesaje(double valorA, double valorB)
        {
            //Distribucion Uniforme
            TimeSpan tiempoPesaje = new TimeSpan();
            Random rand = new Random();
            float aleatorio = rand.Next(0, 1);
            long tiempo = (long)valorA + (long)aleatorio * (long)(valorB - valorA);

            tiempoPesaje = new TimeSpan(tiempo);
            return tiempoPesaje;
        }
    }
}
