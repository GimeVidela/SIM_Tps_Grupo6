using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class BalanzaSvr
    {
        private GeneradorNumerosAleatoreos generador;
        public string estado = "Libre";
        private Camion camionSiendoAtendido;

        public void setCamionSiendoAtendido(Camion camionSiendoAtendido)
        {
            this.camionSiendoAtendido = camionSiendoAtendido;
        }
        public Camion getCamionSiendoAtendido()
        {
            return camionSiendoAtendido;
        }

        public void setGenerador(ref GeneradorNumerosAleatoreos generador)
        {
            this.generador = generador;
        }
        public TimeSpan CalcularTiempoPesaje(double valorA, double valorB)
        {
            //Distribucion Uniforme
            double aleatorio = generador.GenerarAleatorio();

            double tiempo = valorA + aleatorio * (valorB - valorA);

            return generador.convertirSegundosHorasMinutos(tiempo);
        }

    
    }
}
