using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class GestorSimulacion
    {
        
        Camion camion = new Camion();
        BalanzaSvr balanza1 = new BalanzaSvr();
        BalanzaSvr balanza2 = new BalanzaSvr();
        DarsenaSvr darsena1 = new DarsenaSvr();
        DarsenaSvr darsena2 = new DarsenaSvr();
        RecepcionSvr recepcion = new RecepcionSvr();

        int cantCamionesAtendidos = 0;
        int cantCamionesNOAtendidos = 0;
        long sumTiempoPredioCamion = 0;

        TimeSpan reloj = new TimeSpan();
        TimeSpan relojInicio = new TimeSpan(5,0,0);
        TimeSpan relojFinDia = new TimeSpan(18,0,0);

        //Simular 30 dias

        private void Simulacion30dias()
        {
            int cantDias = 30;
            for (int i = 0; i < cantDias; i++)
            {
                SimulacionDia();
                //Mostrar cantidad de camiones atendidos y no atendidos de los 30 dias 
                // Calcular PROMEDIO DE PERMANECIA de los camiones (en 30 dias)
            }

        }
        //Simular 1 dia

        private void SimulacionDia()
        {
            //Apertura de puertas a las 5:00 hs
            reloj = relojInicio;

            //Validacion si es primer dia 

            //LLega Primer camion 12hs empieza cola camiones a ser atendidos

            // Camiones son atendidos se valida si es PROPIO se va a DARSENAS si es EXTERNO se va a BALANZA
            // Contar camiones que descargaron
            // Sumarizar tiempo en el predio del camion (desde que fue atendido hasta que termino la descarga)

            // Los camiones dejan de llegar a  las 18hs

            // Los camiones que no fueron atendidos se suman a camiones NOATENDIDOS

            // Imprimir Cantidad de camiones atendidos y Cantidad de camiones NO atendidos en el dia

            // Calcular Promedio de estadia de camiones del DIA
    
        }

    }
}
