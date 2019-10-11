using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace TP5_Colas
{
   public class GestorSimulacion
    {
        GeneradorNumerosAleatoreos GeneradorUnico = new GeneradorNumerosAleatoreos();
        //Camion camion = new Camion();
        BalanzaSvr balanza = new BalanzaSvr();
        //BalanzaSvr balanza2 = new BalanzaSvr();
        DarsenaSvr darsena1 = new DarsenaSvr();
        DarsenaSvr darsena2 = new DarsenaSvr();
        RecepcionSvr recepcion = new RecepcionSvr();

        int cantCamionesAtendidos = 0;
        int cantCamionesNOAtendidos = 0;
        long sumTiempoPredioCamion = 0;

        TimeSpan reloj = new TimeSpan();
        TimeSpan relojInicio = new TimeSpan(5,0,0);
        TimeSpan relojFinDia = new TimeSpan(18,0,0);
        TimeSpan proximaLlegadaCamion = new TimeSpan(0, 0, 0);
        TimeSpan proximaRecepcion = new TimeSpan(0, 0, 0);
        TimeSpan proximaBalanza = new TimeSpan(0, 0, 0);
        TimeSpan proximaDarcena1 = new TimeSpan(0, 0, 0);
        TimeSpan proximaDarcena2 = new TimeSpan(0, 0, 0);
        TimeSpan proximaCalibracionDarcena1 = new TimeSpan(0, 0, 0);
        TimeSpan proximacalibracionDarcena2 = new TimeSpan(0, 0, 0);
        TimeSpan tiempoMinimo = new TimeSpan();
        TimeSpan seteoDeProximos = new TimeSpan(0, 0, 0);

        //List<Camion> listaCamiones = new List<Camion>();


        // colas

        Queue<Camion> colaRecepcion = new Queue<Camion>();
        Queue<Camion> colaBalanza = new Queue<Camion>();
        Queue<Camion> colaDarcena = new Queue<Camion>();

        // bandera de simulacion de un dia
        string estadoSimulacion = "llegada camion";

        //lista camiones atendidos
        List<Camion> listaCamionesAtendidos = new List<Camion>();

        // inicializar servidores
        public GestorSimulacion()
        {
            recepcion.setGenerador(ref GeneradorUnico);
            balanza.setGenerador(ref GeneradorUnico);
            darsena1.setGenerador(ref GeneradorUnico);
            darsena2.setGenerador(ref GeneradorUnico);
        }

        //Simular 30 dias
        private void Simulacion30dias()
        {
            int cantDias = 30;
            for (int i = 0; i < cantDias; i++)
            {
                SimulacionDia(i);
                //Mostrar cantidad de camiones atendidos y no atendidos de los 30 dias 
                // Calcular PROMEDIO DE PERMANECIA de los camiones (en 30 dias)
            }

        }
        //Simular 1 dia

        public void SimulacionDia(int dia)
        {

            //Validacion si es primer dia 
            if (dia == 1)
            {
                reloj = new TimeSpan(12, 0, 0);
                colaRecepcion.Enqueue(new Camion(reloj));

            }
            else
            {
                reloj = new TimeSpan(5, 0, 0);
            }
            while (reloj < relojFinDia)
            {

                if (colaRecepcion.Count != 0 && recepcion.estado == "libre")
                {
                    proximaRecepcion = reloj + recepcion.CalcularTiempoAtencion(3, 7);
                    recepcion.estado = "ocupado";
                }
                if (colaBalanza.Count != 0 && balanza.estado == "libre")
                {
                    proximaBalanza = reloj + balanza.CalcularTiempoPesaje(5, 7);
                    balanza.estado = "ocupado";
                }
                if (colaDarcena.Count != 0 && darsena1.estado == "libre" )
                {
                    proximaDarcena1 = reloj + darsena1.CalcularTiempoDescarga(15, 20);
                    darsena1.estado = "ocupado";
                    darsena1.setCamionSiendoAtendido(colaDarcena.Dequeue());
                }
                if (colaDarcena.Count != 0 && darsena2.estado == "libre" )
                {
                    proximaDarcena2 = reloj + darsena2.CalcularTiempoDescarga(15, 20);
                    darsena2.estado = "ocupado";
                    darsena2.setCamionSiendoAtendido(colaDarcena.Dequeue());
                }
                if (estadoSimulacion == "llegada camion")
                {
                    proximaLlegadaCamion = reloj + llegadaCamion(7.5);
                }

                tiempoMinimo = minimo(proximaBalanza, proximaDarcena1, proximaDarcena2, proximaRecepcion, proximaLlegadaCamion);

                if (tiempoMinimo == proximaLlegadaCamion)
                {
                    reloj = proximaLlegadaCamion;
                    estadoSimulacion = "llegada camion";
                    colaRecepcion.Enqueue(new Camion(reloj));
                    proximaLlegadaCamion = seteoDeProximos;
                }
                if (tiempoMinimo == proximaRecepcion)
                {
                    reloj = proximaRecepcion;
                    estadoSimulacion = "fin atencion recepcion";
                    recepcion.estado = "libre";
                    proximaRecepcion = seteoDeProximos;
                    colaRecepcion.Peek().setGenerador(ref GeneradorUnico);
                    if (colaRecepcion.Peek().getTipoCamion() == 1)
                    {
                        colaDarcena.Enqueue(colaRecepcion.Dequeue());
                    }
                    else
                    {
                        colaBalanza.Enqueue(colaRecepcion.Dequeue());
                    }
                }
                if (tiempoMinimo == proximaBalanza)
                {
                    reloj = proximaBalanza;
                    estadoSimulacion = "fin atencion balanza";
                    balanza.estado = "libre";
                    colaDarcena.Enqueue(colaBalanza.Dequeue());
                    proximaBalanza = seteoDeProximos;
                }
                if (tiempoMinimo == proximaDarcena1)
                {
                    reloj = proximaDarcena1;
                    estadoSimulacion = "fin atencion darcena1";
                    cantCamionesAtendidos++;
                    darsena1.estado = "libre";
                    listaCamionesAtendidos.Add( darsena1.getCamionSiendoAtendido() );
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    proximaDarcena1 = seteoDeProximos;
                }
                if (tiempoMinimo == proximaDarcena2)
                {
                    reloj = proximaDarcena2;
                    estadoSimulacion = "fin atencion darcena2";
                    cantCamionesAtendidos++;
                    darsena1.estado = "libre";
                    listaCamionesAtendidos.Add(darsena2.getCamionSiendoAtendido());
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    proximaDarcena2 = seteoDeProximos;
                }


            }
        }

        private TimeSpan llegadaCamion(double lambda)
        {
            //Distribucion Exponencial Negativa

            double aleatorio = GeneradorUnico.GenerarAleatorio();

            double tiempoLlegada = -lambda * Math.Log(1 - aleatorio);

            return GeneradorUnico.convertirSegundosHorasMinutos(tiempoLlegada);
        }

        private TimeSpan minimo(TimeSpan a, TimeSpan b, TimeSpan c, TimeSpan d, TimeSpan e)
        {
            TimeSpan min = new TimeSpan(0, 0, 0);
            TimeSpan noGenerado = new TimeSpan(0, 0, 0);
            List<TimeSpan> numerosValidos = new List<TimeSpan>();


            if (a > noGenerado)
            {
                numerosValidos.Add(a);
            }
            if (b > noGenerado)
            {
                numerosValidos.Add(b);
            }
            if (c > noGenerado)
            {
                numerosValidos.Add(c);
            }
            if (d > noGenerado)
            {
                numerosValidos.Add(d);
            }
            if (e > noGenerado)
            {
                numerosValidos.Add(e);
            }

            for(int i = 0; i < numerosValidos.Count(); i++)
            {
                if(i == 0 )
                {
                    min = numerosValidos[i];
                }
                else if(numerosValidos[i] < min )
                {
                    min = numerosValidos[i];

                }
            }

            return min;
        }
    }
}
