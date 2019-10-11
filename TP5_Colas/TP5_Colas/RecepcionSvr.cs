using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    public class RecepcionSvr
    {
        private GeneradorNumerosAleatoreos generador;
        public string estado = "libre"; 

       public void setGenerador(ref GeneradorNumerosAleatoreos generador)
        {
            this.generador = generador;
        }

        public TimeSpan CalcularTiempoAtencion( double valorA, double valorB)
        {
            //Distribucion Uniforme
            double aleatorio = generador.GenerarAleatorio();

            double tiempo = valorA + aleatorio *(valorB - valorA);

            return generador.convertirSegundosHorasMinutos(tiempo);
        }
    }
}
