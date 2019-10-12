using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class DarsenaSvr
    {
        private GeneradorNumerosAleatoreos generador;
        public string estado = "libre";
        private Camion camionSiendoAtendido;

        public void setGenerador(ref GeneradorNumerosAleatoreos generador)
        {
            this.generador = generador;
        }

        public void setCamionSiendoAtendido( Camion camionSiendoAtendido)
        {
            this.camionSiendoAtendido = camionSiendoAtendido;
        }
        public  Camion getCamionSiendoAtendido()
        {
            return camionSiendoAtendido;
        }
        public TimeSpan CalcularTiempoDescarga(double valorA, double valorB)
        {
            //Distribucion Uniforme
            double aleatorio = generador.GenerarAleatorio();

            double tiempo = valorA + aleatorio * (valorB - valorA);

            return generador.convertirSegundosHorasMinutos(tiempo);
        }

        public TimeSpan CalcularTiempoCalibracion(double media, double varianza)
        {
            //Distribucion Normal
            double aleatorio1 = generador.GenerarAleatorio();
            double aleatorio2 = generador.GenerarAleatorio();

            double tiempo = media + varianza * Math.Sqrt(-2*Math.Log(aleatorio1)) * (Math.Sin(2*Math.PI*aleatorio2));

            return generador.convertirSegundosHorasMinutos(tiempo);
        }
    }
}
