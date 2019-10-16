using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class GestorSimulacionUni
    {
        GeneradorNumerosAleatoreos GeneradorUnico = new GeneradorNumerosAleatoreos();
        //Camion camion = new Camion();
        BalanzaSvr balanza = new BalanzaSvr();
        //BalanzaSvr balanza2 = new BalanzaSvr();
        DarsenaSvr darsena1 = new DarsenaSvr();
        DarsenaSvr darsena2 = new DarsenaSvr();
        RecepcionSvr recepcion = new RecepcionSvr();

        public int cantCamionesAtendidos = 0;
        public int cantCamionesNOAtendidos = 0;
        public TimeSpan sumTiempoPredioCamion = new TimeSpan(0, 0, 0);

        public int cantCamionesAtendidosUni = 0;
        public int cantCamionesNOAtendidosUni = 0;
        public TimeSpan sumTiempoPredioCamionUni;

        TimeSpan reloj = new TimeSpan();
        TimeSpan relojInicio = new TimeSpan(5, 0, 0);
        TimeSpan relojFinDia = new TimeSpan(18, 0, 0);
        TimeSpan proximaLlegadaCamion = new TimeSpan(0, 0, 0);
        TimeSpan proximaRecepcion = new TimeSpan(0, 0, 0);
        TimeSpan proximaBalanza = new TimeSpan(0, 0, 0);
        TimeSpan proximaDarcena1 = new TimeSpan(0, 0, 0);
        TimeSpan proximaDarcena2 = new TimeSpan(0, 0, 0);
        TimeSpan proximaCalibracionDarcena1 = new TimeSpan(0, 0, 0);
        TimeSpan proximacalibracionDarcena2 = new TimeSpan(0, 0, 0);
        TimeSpan tiempoMinimo = new TimeSpan();
        TimeSpan seteoDeProximos = new TimeSpan(0, 0, 0);
        TimeSpan medioDia = new TimeSpan(12, 0, 0);

        int contadorDescargasDarcena1 = 0;
        int contadorDescargasDarcena2 = 0;

        //List<Camion> listaCamiones = new List<Camion>();
        Boolean servicioRealizado = false;

        // colas

        Queue<Camion> colaRecepcion = new Queue<Camion>();
        Queue<Camion> colaBalanza = new Queue<Camion>();
        Queue<Camion> colaDarcena = new Queue<Camion>();

        // bandera de simulacion de un dia
        string estadoSimulacion = "llegada camion";

        //lista camiones atendidos
        List<Camion> listaCamionesAtendidos = new List<Camion>();
        public List<Tuple<int, int>> resultados = new List<Tuple<int, int>>();

        // inicializar servidores
        public GestorSimulacionUni()
        {
            recepcion.setGenerador(ref GeneradorUnico);
            balanza.setGenerador(ref GeneradorUnico);
            darsena1.setGenerador(ref GeneradorUnico);
            darsena2.setGenerador(ref GeneradorUnico);
        }

        public void Simulacion30diasUni()
        {
            int cantDias = 30;
            for (int i = 0; i < cantDias; i++)
            {
                resultados.Add(SimulacionDiaUni(i + 1));
                estadoSimulacion = "llegada camion";
                //Mostrar cantidad de camiones atendidos y no atendidos de los 30 dias 

            }
            // Calcular PROMEDIO DE PERMANECIA de los camiones (en 30 dias)
            sumTiempoPredioCamionUni = calcularPromedio(listaCamionesAtendidos);
        }



        public Tuple<int, int> SimulacionDiaUni(int dia)
        {
            cantCamionesAtendidos = 0;
            cantCamionesNOAtendidos = 0;
            proximaLlegadaCamion = seteoDeProximos;
            reloj = new TimeSpan(5, 0, 0);
            Boolean bandera = true;


            while (reloj < relojFinDia || recepcion.estado == "ocupado" || colaBalanza.Count != 0 || balanza.estado == "ocupado" || colaDarcena.Count != 0 || darsena1.estado == "ocupado" || darsena2.estado == "ocupado")
            {

                servicioRealizado = false;
                if (contadorDescargasDarcena1 == 15)
                {
                    contadorDescargasDarcena1 = 0;
                    proximaCalibracionDarcena1 = reloj + darsena1.CalcularTiempoCalibracion(10, 1.2);
                    darsena1.estado = "calibrando";

                }
                if (contadorDescargasDarcena2 == 15)
                {
                    contadorDescargasDarcena2 = 0;
                    proximacalibracionDarcena2 = reloj + darsena2.CalcularTiempoCalibracion(10, 1.2);
                    darsena2.estado = "calibrando";

                }
                if (colaRecepcion.Count != 0 && recepcion.estado == "libre" && reloj < relojFinDia && reloj >= relojInicio)
                {
                    proximaRecepcion = reloj + recepcion.CalcularTiempoAtencion(3, 7);
                    recepcion.setCamionSiendoAtendido(colaRecepcion.Dequeue());
                    recepcion.getCamionSiendoAtendido().setHoraLlegada(reloj);
                    recepcion.getCamionSiendoAtendido().setEstado("Atendido en Recepcion");
                    recepcion.estado = "ocupado";

                }
                if (colaBalanza.Count != 0 && balanza.estado == "libre")
                {
                    proximaBalanza = reloj + balanza.CalcularTiempoPesaje(5, 7);
                    balanza.setCamionSiendoAtendido(colaBalanza.Dequeue());
                    balanza.getCamionSiendoAtendido().setEstado("Siendo Pesado");
                    balanza.estado = "ocupado";

                }
                if (colaDarcena.Count != 0 && darsena1.estado == "libre" && contadorDescargasDarcena1 < 15)
                {
                    proximaDarcena1 = reloj + darsena1.CalcularTiempoDescarga(15, 20);
                    darsena1.estado = "ocupado";

                    darsena1.setCamionSiendoAtendido(colaDarcena.Dequeue());
                    darsena1.getCamionSiendoAtendido().setEstado("Siendo Descargado D1");
                }
                if (colaDarcena.Count != 0 && darsena2.estado == "libre" && contadorDescargasDarcena2 < 15)
                {
                    proximaDarcena2 = reloj + darsena2.CalcularTiempoDescarga(15, 20);
                    darsena2.estado = "ocupado";

                    darsena2.setCamionSiendoAtendido(colaDarcena.Dequeue());
                    darsena2.getCamionSiendoAtendido().setEstado("Siendo Descargado D2");
                }
                if (estadoSimulacion == "llegada camion" && reloj >= relojInicio && reloj < relojFinDia)
                {
                    proximaLlegadaCamion = reloj + llegadaCamionUni(7, 8);

                }

                tiempoMinimo = minimo(proximaBalanza, proximaDarcena1, proximaDarcena2, proximaRecepcion, proximaLlegadaCamion, proximaCalibracionDarcena1, proximacalibracionDarcena2);

                if (tiempoMinimo == seteoDeProximos)
                {
                    reloj = medioDia;
                    servicioRealizado = true;
                    estadoSimulacion = "llegada camion";
                }


                if (tiempoMinimo == proximaLlegadaCamion && servicioRealizado == false)
                {
                    reloj = proximaLlegadaCamion;
                    estadoSimulacion = "llegada camion";
                    colaRecepcion.Enqueue(new Camion());
                    proximaLlegadaCamion = seteoDeProximos;
                    servicioRealizado = true;
                }
                if (tiempoMinimo == proximaRecepcion && servicioRealizado == false)
                {

                    reloj = proximaRecepcion;
                    estadoSimulacion = "fin atencion recepcion";
                    recepcion.estado = "libre";
                    proximaRecepcion = seteoDeProximos;
                    recepcion.getCamionSiendoAtendido().setGenerador(ref GeneradorUnico);
                    servicioRealizado = true;
                    if (recepcion.getCamionSiendoAtendido().getTipoCamion() == 1)
                    {
                        recepcion.getCamionSiendoAtendido().setEstado("En cola Descarga");
                        colaDarcena.Enqueue(recepcion.getCamionSiendoAtendido());
                    }
                    else
                    {
                        recepcion.getCamionSiendoAtendido().setEstado("En cola Pesaje");
                        colaBalanza.Enqueue(recepcion.getCamionSiendoAtendido());
                    }
                }

                if (tiempoMinimo == proximaBalanza && servicioRealizado == false)
                {

                    reloj = proximaBalanza;

                    estadoSimulacion = "fin atencion balanza";
                    balanza.estado = "libre";
                    colaDarcena.Enqueue(balanza.getCamionSiendoAtendido());
                    balanza.getCamionSiendoAtendido().setEstado("En cola Descarga");
                    proximaBalanza = seteoDeProximos;
                    servicioRealizado = true;

                }

                if (tiempoMinimo == proximaDarcena1 && servicioRealizado == false)
                {

                    reloj = proximaDarcena1;
                    estadoSimulacion = "fin atencion darcena1";
                    cantCamionesAtendidos++;
                    darsena1.estado = "libre";
                    listaCamionesAtendidos.Add(darsena1.getCamionSiendoAtendido());
                    darsena1.getCamionSiendoAtendido().setEstado("Fuera Sistema");
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    proximaDarcena1 = seteoDeProximos;
                    servicioRealizado = true;
                    contadorDescargasDarcena1++;

                }
                if (tiempoMinimo == proximaDarcena2 && servicioRealizado == false)
                {

                    reloj = proximaDarcena2;
                    estadoSimulacion = "fin atencion darcena2";
                    cantCamionesAtendidos++;
                    darsena2.estado = "libre";
                    listaCamionesAtendidos.Add(darsena2.getCamionSiendoAtendido());
                    darsena2.getCamionSiendoAtendido().setEstado("Fuera Sistema");
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    proximaDarcena2 = seteoDeProximos;
                    servicioRealizado = true;
                    contadorDescargasDarcena2++;

                }
                if (tiempoMinimo == proximaCalibracionDarcena1 && servicioRealizado == false)
                {
                    reloj = proximaCalibracionDarcena1;
                    estadoSimulacion = "fin calibracion darcena1";
                    proximaCalibracionDarcena1 = seteoDeProximos;
                    darsena1.estado = "libre";
                    servicioRealizado = true;
                }
                if (tiempoMinimo == proximacalibracionDarcena2 && servicioRealizado == false)
                {
                    reloj = proximacalibracionDarcena2;
                    estadoSimulacion = "fin calibracion darcena2";
                    proximacalibracionDarcena2 = seteoDeProximos;
                    darsena2.estado = "libre";
                    servicioRealizado = true;
                }



            }

            cantCamionesNOAtendidos = colaRecepcion.Count;
            return Tuple.Create(cantCamionesAtendidos, cantCamionesNOAtendidos);
            //sumTiempoPredioCamion = calcularPromedio(listaCamionesAtendidos);

        }

        private TimeSpan calcularPromedio(List<Camion> listaCamiones)
        {
            Double promedio = 0;
            for (int i = 1; i < listaCamiones.Count + 1; i++)
            {
                if (i == 1)
                {
                    promedio = GeneradorUnico.convertirEnDouble(listaCamiones[i - 1].TioempoAdentro()) / i;
                }
                else
                {
                    promedio = (i * promedio + GeneradorUnico.convertirEnDouble(listaCamiones[i - 1].TioempoAdentro())) / i;
                }
            }
            return GeneradorUnico.convertirSegundosHorasMinutosPromedio(promedio);
        }


        private TimeSpan llegadaCamionUni(double valorA, double valorB)
        {
            //Distribucion Exponencial Negativa

            double aleatorio = GeneradorUnico.GenerarAleatorio();

            double tiempoLlegada = valorA + aleatorio * (valorB - valorA);

            return GeneradorUnico.convertirSegundosHorasMinutos(tiempoLlegada);
        }

        private TimeSpan minimo(TimeSpan a, TimeSpan b, TimeSpan c, TimeSpan d, TimeSpan e, TimeSpan f, TimeSpan g)
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
            if (f > noGenerado)
            {
                numerosValidos.Add(f);
            }
            if (g > noGenerado)
            {
                numerosValidos.Add(g);
            }

            for (int i = 0; i < numerosValidos.Count(); i++)
            {
                if (i == 0)
                {
                    min = numerosValidos[i];
                }
                else if (numerosValidos[i] < min)
                {
                    min = numerosValidos[i];

                }
            }

            return min;
        }
    }
}
