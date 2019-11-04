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
        public string estado = "Libre";
        private Camion camionSiendoAtendido;

        public void setGenerador(ref GeneradorNumerosAleatoreos generador)
        {
            this.generador = generador;
        }

        public void setCamionSiendoAtendido(Camion camionSiendoAtendido)
        {
            this.camionSiendoAtendido = camionSiendoAtendido;
        }
        public Camion getCamionSiendoAtendido()
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
            while (aleatorio1 == 0 || aleatorio2 == 0)
            {
                aleatorio1 = generador.GenerarAleatorio();
                aleatorio2 = generador.GenerarAleatorio();
            }

            double tiempo = media + varianza * Math.Sqrt(-2 * Math.Log(aleatorio1)) * (Math.Sin(2 * Math.PI * aleatorio2));

            return generador.convertirSegundosHorasMinutos(tiempo);
        }

        //-------------------------TP6--------------------------------------------

        public double CalcularK(double media, double varianza)
        {
            //Distribucion Normal
            double aleatorio1 = generador.GenerarAleatorio();
            double aleatorio2 = generador.GenerarAleatorio();
            while (aleatorio1 == 0 || aleatorio2 == 0)
            {
                aleatorio1 = generador.GenerarAleatorio();
                aleatorio2 = generador.GenerarAleatorio();
            }

            double k = media + varianza * Math.Sqrt(-2 * Math.Log(aleatorio1)) * (Math.Sin(2 * Math.PI * aleatorio2));
            return k;
        }

        public TimeSpan CalcularDescargaEuler(double litros)
        {
            //Constantes
            double lt = litros;
            double k = CalcularK(0.25,0.707);
            double h = 0.01;
            //Variables auxiliares
            double x = litros;
            double x1 = 0, x2 = 0; 

            do
            {
                //calculo de Euler
                x2 = -k * x1 - 20 * x;
                x = x + h * x1;
                x1 = x1 + h * x2;
                h = h++;

            } while (x > 1);

            return generador.convertirSegundosHorasMinutos(h);
        }
    }
}
