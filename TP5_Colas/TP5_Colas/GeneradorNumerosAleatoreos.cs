using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    public class GeneradorNumerosAleatoreos
    {
        double primerValor, x1, x2;
        public double GenerarAleatorio()
        {

            while (primerValor == x2)
            {
                Random aleatorio = new Random();
                primerValor = aleatorio.Next(0, 9998);
                x1 = primerValor;
            }

            x2 = (67 * x1 + 71) % 9999;
            x1 = x2;
            return x2 / 10000;


        }

        public TimeSpan convertirSegundosHorasMinutos(double minutos)
        {
            int segundos = Convert.ToInt32(minutos * 60);
            int hor, min, seg;
            hor = (segundos / 3600);
            min = ((segundos - hor * 3600) / 60);
            seg = segundos - (hor * 3600 + min * 60);
            return TimeSpan.Parse(hor + ":" + min + ":" + seg);
        }

    }
}
