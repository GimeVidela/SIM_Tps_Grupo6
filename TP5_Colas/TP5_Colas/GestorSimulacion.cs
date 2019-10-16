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
        DarsenaSvr darsena1 = new DarsenaSvr();
        DarsenaSvr darsena2 = new DarsenaSvr();
        RecepcionSvr recepcion = new RecepcionSvr();

        public int cantCamionesAtendidos = 0;
        public int cantCamionesNOAtendidos = 0;
        public TimeSpan sumTiempoPredioCamion = new TimeSpan(0, 0, 0);

        public int cantCamionesAtendidosUni = 0;
        public int cantCamionesNOAtendidosUni = 0;
        public TimeSpan sumTiempoPredioCamionUni = new TimeSpan(0, 0, 0);

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
        TimeSpan medioDia = new TimeSpan(12, 0, 0);
        TimeSpan error = new TimeSpan(16, 0, 0);

        int contadorDescargasDarcena1 = 0;
        int contadorDescargasDarcena2 = 0;

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
        public GestorSimulacion()
        {
            recepcion.setGenerador(ref GeneradorUnico);
            balanza.setGenerador(ref GeneradorUnico);
            darsena1.setGenerador(ref GeneradorUnico);
            darsena2.setGenerador(ref GeneradorUnico);
        }

        //Simular 30 dias
        public void Simulacion30dias()
        {
            int cantDias = 30;
            for (int i = 0; i < cantDias; i++)
            {
                resultados.Add( SimulacionDia(i+1));
                estadoSimulacion = "llegada camion";
                
            }
            // Calcular PROMEDIO DE PERMANECIA de los camiones (en 30 dias)
            sumTiempoPredioCamion = calcularPromedio(listaCamionesAtendidos);
        }

        //Simular 1 dia
        public Tuple<int,int> SimulacionDia(int dia)
        {
            cantCamionesAtendidos = 0;
            cantCamionesNOAtendidos = 0;
            proximaLlegadaCamion = seteoDeProximos;
            Boolean bandera = true;

            //Validacion si es primer dia 
            if (dia == 1)
            {
                //Primer dia de simulacion empieza a simular a partir de la llegada del primer camion a las 12 hs
                reloj = new TimeSpan(12, 0, 0);

            }
            else
            {
               // cualquier dia que no sea el primero se empieza a simular el proceso apartir de las 5 hs
                reloj = new TimeSpan(5, 0, 0);
            }
            //Mientras el reloj sea menor a la hora 18, o el recepcionista este ocupado, o la cola de balanza sea distinta de cero, o la balanza este ocupada, 
            //o la cola de la balanza sea distinta de cero o algunas de las darcenas esten ocupadas se ejecutara lo siguiente
            while (reloj < relojFinDia ||recepcion.estado == "ocupado" || colaBalanza.Count != 0 || balanza.estado == "ocupado" || colaDarcena.Count != 0 || darsena1.estado == "ocupado" || darsena2.estado == "ocupado")
            {

                servicioRealizado = false;
                //Si la darcena 1 llega a descargar 15 camiones se la calibra
                if (contadorDescargasDarcena1 == 15)
                {
                    //Se calcula el tiempo de calibracion y el estado de la darsena es calinbrando
                    contadorDescargasDarcena1 = 0;
                    proximaCalibracionDarcena1 = reloj + darsena1.CalcularTiempoCalibracion(10, 1.2);
                    darsena1.estado = "calibrando";

                }
                //Si la darcena 2 llega a descargar 15 camiones se la calibra
                if (contadorDescargasDarcena2 == 15)
                {
                    //Se calcula el tiempo de calibracion y el estado de la darsena es calinbrando
                    contadorDescargasDarcena2 = 0;
                    proximacalibracionDarcena2 = reloj + darsena2.CalcularTiempoCalibracion(10, 1.2);
                    darsena2.estado = "calibrando";

                }
                // si la cola de recepcion es distinta de cero y el recepcionista esta libre y el reloj esta entre el inicio del dia y el final del dia
                if (colaRecepcion.Count != 0 && recepcion.estado == "libre" && reloj < relojFinDia && reloj >= relojInicio)
                {
                    //un camion empieza a ser atendido y el recepcionista pasa a estar ocupado
                    proximaRecepcion = reloj + recepcion.CalcularTiempoAtencion(3, 7);
                    recepcion.setCamionSiendoAtendido(colaRecepcion.Dequeue());
                    recepcion.getCamionSiendoAtendido().setHoraLlegada(reloj);
                    recepcion.getCamionSiendoAtendido().setEstado("Atendido en Recepcion");
                    recepcion.estado = "ocupado";

                }
                //si la cola de balanzas es distinta de cero y el estado d ela balanza es libre
                if (colaBalanza.Count != 0 && balanza.estado == "libre")
                {
                    //un camion de la cola de la baanza pasa  a pesarse y la balanza pasa a estar ocupada
                    proximaBalanza = reloj + balanza.CalcularTiempoPesaje(5, 7);
                    balanza.setCamionSiendoAtendido(colaBalanza.Dequeue());
                    balanza.getCamionSiendoAtendido().setEstado("Siendo Pesado");
                    balanza.estado = "ocupado";

                }
                //si la cola de la darsena1 es distinta de cero y la darsena esta en estado libre y el contador de darsenas es menor a 15
                if (colaDarcena.Count != 0 && darsena1.estado == "libre" && contadorDescargasDarcena1 < 15 )
                {
                    //se pasa a darsena un camion y la darsena pasa a estar ocupada
                    proximaDarcena1 = reloj + darsena1.CalcularTiempoDescarga(15, 20);
                    darsena1.estado = "ocupado";
                    darsena1.setCamionSiendoAtendido(colaDarcena.Dequeue());
                    darsena1.getCamionSiendoAtendido().setEstado("Siendo Descargado D1");
                }
                //si la cola de la darsen2 es distinta de cero y la darsena esta en estado libre y el contador de darsenas es menor a 15
                if (colaDarcena.Count != 0 && darsena2.estado == "libre" && contadorDescargasDarcena2 < 15)
                {
                    //se pasa a darsena un camion y la darsena pasa a estar ocupada
                    proximaDarcena2 = reloj + darsena2.CalcularTiempoDescarga(15, 20);
                    darsena2.estado = "ocupado";

                    darsena2.setCamionSiendoAtendido(colaDarcena.Dequeue());
                    darsena2.getCamionSiendoAtendido().setEstado("Siendo Descargado D2");
                }
                // si el estado se simulacion es igual a llegada camion y el reloj se encuentra entre las 12 y 18 hs
                if (estadoSimulacion == "llegada camion" && reloj >= medioDia && reloj < relojFinDia)
                {
                    //se calcula la prosima llegada de un camion 
                    proximaLlegadaCamion = reloj + llegadaCamion(7.5);

                }
                

                // se determina el tiempo minimo el cual indicara el proximo evento a realizarse
                tiempoMinimo = minimo(proximaBalanza, proximaDarcena1, proximaDarcena2, proximaRecepcion, proximaLlegadaCamion, proximaCalibracionDarcena1, proximacalibracionDarcena2);

                //si el tiempo minimo es igual a seteodeproximos
                if(tiempoMinimo == seteoDeProximos)
                {
                    // setea el reloj en 12 hs, realiza la llegada de un camion 
                    reloj = medioDia;
                    servicioRealizado = true;
                    estadoSimulacion = "llegada camion";
                }
                // si el reloj es menor a 12 hs y tiempo minimo mayor a 12hs y proxima llegada = seteo proximos
                if(reloj <= medioDia && tiempoMinimo >= medioDia && proximaLlegadaCamion == seteoDeProximos && servicioRealizado == false)
                {
                    //llegada de camion
                    proximaLlegadaCamion = medioDia + llegadaCamion(7.5);
                    servicioRealizado = true;
                }
                // si el tiempo minimo es proxima llegada de camion y el servicio realizado falso
                if (tiempoMinimo == proximaLlegadaCamion && servicioRealizado == false)
                {
                    //reloj iguak a proxima lllegada de camion se encola en recepcion un camion
                    reloj = proximaLlegadaCamion;
                    estadoSimulacion = "llegada camion";
                    colaRecepcion.Enqueue(new Camion());//el constructor deberia setear el estado en cola recepcion
                    proximaLlegadaCamion = seteoDeProximos;
                    servicioRealizado = true;
                }
                //si el tiempo minimo es igual a proxima recepcion y servicio falso
                if (tiempoMinimo == proximaRecepcion && servicioRealizado == false)
                {
                    //reloj igual a recepcion , recepcionista libre , se en cola el camion a darsenas si es propio o va  a la cola se pesaje si es externo
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
                        colaBalanza.Enqueue(recepcion.getCamionSiendoAtendido());
                        recepcion.getCamionSiendoAtendido().setEstado("En cola Pesaje");
                    }
                }
                //si tiempo minimo igual a proximabalanza y servicio falso
                if (tiempoMinimo == proximaBalanza && servicioRealizado == false)
                {
                    //reloj igual a proxma balanza, fin de atencion de balanza, balanza en estado libre, se encola el camion a la cola de darsenas
                    reloj = proximaBalanza;

                    estadoSimulacion = "fin atencion balanza";
                    balanza.estado = "libre";
                    colaDarcena.Enqueue(balanza.getCamionSiendoAtendido());
                    balanza.getCamionSiendoAtendido().setEstado("En cola Descarga");
                    proximaBalanza = seteoDeProximos;
                    servicioRealizado = true;

                }
               //si el tiempo igual a proxima darsena1 y servicio falso
                if (tiempoMinimo == proximaDarcena1 && servicioRealizado == false)
                {
                    //reloj igual proxima darsena 1, fin de atencion en darsena 1, darsena1 libre
                    //finalizacion de atencion de un camion, el servicio realizado es true, se incrementa el contador de darsenas
                    reloj = proximaDarcena1;
                    estadoSimulacion = "fin atencion darcena1";
                    cantCamionesAtendidos++;
                    darsena1.estado = "libre";
                    listaCamionesAtendidos.Add( darsena1.getCamionSiendoAtendido() );
                    darsena1.getCamionSiendoAtendido().setEstado("Fuera Sistema");
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    proximaDarcena1 = seteoDeProximos;
                    servicioRealizado = true;
                    contadorDescargasDarcena1++;

                }
                //si el tiempo igual a proxima darsena2 y servicio falso
                if (tiempoMinimo == proximaDarcena2 && servicioRealizado == false)
                {
                    //reloj igual proxima darsena 2, fin de atencion en darsena 2, darsena1 libre
                    //finalizacion de atencion de un camion, el servicio realizado es true, se incrementa el contador de darsenas
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
                // fin de calibracion de darsena 1 queda en estado libre
                if (tiempoMinimo == proximaCalibracionDarcena1 && servicioRealizado == false)
                {
                    reloj = proximaCalibracionDarcena1;
                    estadoSimulacion = "fin calibracion darcena1";
                    proximaCalibracionDarcena1 = seteoDeProximos;
                    darsena1.estado = "libre";
                    servicioRealizado = true;
                }
                // fin de calibracion de darsena 2 queda en estado libre
                if (tiempoMinimo == proximacalibracionDarcena2 && servicioRealizado == false)
                {
                    reloj = proximacalibracionDarcena2;
                    estadoSimulacion = "fin calibración darcena2";
                    proximacalibracionDarcena2 = seteoDeProximos;
                    darsena2.estado = "libre";
                    servicioRealizado = true;
                }


            }
            cantCamionesNOAtendidos = colaRecepcion.Count;
            return Tuple.Create(cantCamionesAtendidos, cantCamionesNOAtendidos);
            
        }

        public Tuple<int, int> SimulacionDiaUni(int dia)
        {
            cantCamionesAtendidos = 0;
            cantCamionesNOAtendidos = 0;
            proximaLlegadaCamion = seteoDeProximos;
            //empieza la llegada y atencion de cmaiones a partir de las 5hs
            reloj = new TimeSpan(5, 0, 0);
            //Mientras el reloj sea menor a la hora 18, o el recepcionista este ocupado, o la cola de balanza sea distinta de cero, o la balanza este ocupada, 
            //o la cola de la balanza sea distinta de cero o algunas de las darcenas esten ocupadas se ejecutara lo siguiente

            while (reloj < relojFinDia || recepcion.estado == "ocupado" || colaBalanza.Count != 0 || balanza.estado == "ocupado" || colaDarcena.Count != 0 || darsena1.estado == "ocupado" || darsena2.estado == "ocupado")
            {
                servicioRealizado = false;
                //Si la darcena 1 llega a descargar 15 camiones se la calibra
                if (contadorDescargasDarcena1 == 15)
                {
                    //Se calcula el tiempo de calibracion y el estado de la darsena es calinbrando
                    contadorDescargasDarcena1 = 0;
                    proximaCalibracionDarcena1 = reloj + darsena1.CalcularTiempoCalibracion(10, 1.2);
                    darsena1.estado = "calibrando";

                }
                //Si la darcena 2 llega a descargar 15 camiones se la calibra
                if (contadorDescargasDarcena2 == 15)
                {
                    //Se calcula el tiempo de calibracion y el estado de la darsena es calinbrando
                    contadorDescargasDarcena2 = 0;
                    proximacalibracionDarcena2 = reloj + darsena2.CalcularTiempoCalibracion(10, 1.2);
                    darsena2.estado = "calibrando";

                }
                // si la cola de recepcion es distinta de cero y el recepcionista esta libre y el reloj esta entre el inicio del dia y el final del dia
                if (colaRecepcion.Count != 0 && recepcion.estado == "libre" && reloj < relojFinDia && reloj >= relojInicio)
                {
                    //un camion empieza a ser atendido y el recepcionista pasa a estar ocupado
                    proximaRecepcion = reloj + recepcion.CalcularTiempoAtencion(3, 7);
                    recepcion.setCamionSiendoAtendido(colaRecepcion.Dequeue());
                    recepcion.getCamionSiendoAtendido().setHoraLlegada(reloj);
                    recepcion.estado = "ocupado";

                }
                //si la cola de balanzas es distinta de cero y el estado d ela balanza es libre
                if (colaBalanza.Count != 0 && balanza.estado == "libre")
                {
                    //un camion de la cola de la baanza pasa  a pesarse y la balanza pasa a estar ocupada
                    proximaBalanza = reloj + balanza.CalcularTiempoPesaje(5, 7);
                    balanza.setCamionSiendoAtendido(colaBalanza.Dequeue());
                    balanza.estado = "ocupado";

                }
                //si la cola de la darsena1 es distinta de cero y la darsena esta en estado libre y el contador de darsenas es menor a 15
                if (colaDarcena.Count != 0 && darsena1.estado == "libre" && contadorDescargasDarcena1 < 15)
                {
                    //se pasa a darsena un camion y la darsena pasa a estar ocupada
                    proximaDarcena1 = reloj + darsena1.CalcularTiempoDescarga(15, 20);
                    darsena1.estado = "ocupado";

                    darsena1.setCamionSiendoAtendido(colaDarcena.Dequeue());
                }
                //si la cola de la darsena2 es distinta de cero y la darsena esta en estado libre y el contador de darsenas es menor a 15
                if (colaDarcena.Count != 0 && darsena2.estado == "libre" && contadorDescargasDarcena2 < 15)
                {
                    //se pasa a darsena un camion y la darsena pasa a estar ocupada
                    proximaDarcena2 = reloj + darsena2.CalcularTiempoDescarga(15, 20);
                    darsena2.estado = "ocupado";

                    darsena2.setCamionSiendoAtendido(colaDarcena.Dequeue());
                }
                // si el estado se simulacion es igual a llegada camion 
                if (estadoSimulacion == "llegada camion" )
                {
                    //se calcula la prosima llegada de un camion con distribucion normal
                    proximaLlegadaCamion = reloj + llegadaCamionUni(7, 8);

                }

                // se determina el tiempo minimo el cual indicara el proximo evento a realizarse
                tiempoMinimo = minimo(proximaBalanza, proximaDarcena1, proximaDarcena2, proximaRecepcion, proximaLlegadaCamion, proximaCalibracionDarcena1, proximacalibracionDarcena2);

                //si el tiempo minimo es igual a seteodeprosimos
                if (tiempoMinimo == seteoDeProximos)
                {
                    reloj = medioDia;
                    servicioRealizado = true;
                    estadoSimulacion = "llegada camion";
                }

                // si el tiempo minimo es proxima llegada de camion y el servicio realizado falso 
                if (tiempoMinimo == proximaLlegadaCamion && servicioRealizado == false)
                {
                    //llegada de camion
                    reloj = proximaLlegadaCamion;
                    estadoSimulacion = "llegada camion";
                    colaRecepcion.Enqueue(new Camion());
                    proximaLlegadaCamion = seteoDeProximos;
                    servicioRealizado = true;
                }
                 //si el tiempo minimo es igual a proxima recepcion y servicio falso
                if (tiempoMinimo == proximaRecepcion && servicioRealizado == false)
                {
                    //reloj iguak a proxima lllegada de camion se encola en recepcion un camion
                    reloj = proximaRecepcion;
                    estadoSimulacion = "fin atencion recepcion";
                    recepcion.estado = "libre";
                    proximaRecepcion = seteoDeProximos;
                    recepcion.getCamionSiendoAtendido().setGenerador(ref GeneradorUnico);
                    servicioRealizado = true;
                    if (recepcion.getCamionSiendoAtendido().getTipoCamion() == 1)
                    {
                        colaDarcena.Enqueue(recepcion.getCamionSiendoAtendido());
                    }
                    else
                    {
                        colaBalanza.Enqueue(recepcion.getCamionSiendoAtendido());
                    }
                }
                //si tiempo minimo igual a proximabalanza y servicio falso
                if (tiempoMinimo == proximaBalanza && servicioRealizado == false)
                {
                    //reloj igual a proxma balanza, fin de atencion de balanza, balanza en estado libre, se encola el camion a la cola de darsenas
                    reloj = proximaBalanza;

                    estadoSimulacion = "fin atencion balanza";
                    balanza.estado = "libre";
                    colaDarcena.Enqueue(balanza.getCamionSiendoAtendido());
                    proximaBalanza = seteoDeProximos;
                    servicioRealizado = true;

                }
                //si el tiempo igual a proxima darsena1 y servicio falso
                if (tiempoMinimo == proximaDarcena1 && servicioRealizado == false)
                {
                    //reloj igual proxima darsena 1, fin de atencion en darsena 1, darsena1 libre
                    //finalizacion de atencion de un camion, el servicio realizado es true, se incrementa el contador de darsenas
                    reloj = proximaDarcena1;
                    estadoSimulacion = "fin atencion darcena1";
                    cantCamionesAtendidos++;
                    darsena1.estado = "libre";
                    listaCamionesAtendidos.Add(darsena1.getCamionSiendoAtendido());
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    proximaDarcena1 = seteoDeProximos;
                    servicioRealizado = true;
                    contadorDescargasDarcena1++;

                }
                //si el tiempo igual a proxima darsena2 y servicio falso
                if (tiempoMinimo == proximaDarcena2 && servicioRealizado == false)
                {
                    //reloj igual proxima darsena 1, fin de atencion en darsena 2, darsena2 libre
                    //finalizacion de atencion de un camion, el servicio realizado es true, se incrementa el contador de darsenas
                    reloj = proximaDarcena2;
                    estadoSimulacion = "fin atencion darcena2";
                    cantCamionesAtendidos++;
                    darsena2.estado = "libre";
                    listaCamionesAtendidos.Add(darsena2.getCamionSiendoAtendido());
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    proximaDarcena2 = seteoDeProximos;
                    servicioRealizado = true;
                    contadorDescargasDarcena2++;

                }
                // fin de calibracion de darsena 1 queda en estado libre
                if (tiempoMinimo == proximaCalibracionDarcena1 && servicioRealizado == false)
                {
                    reloj = proximaCalibracionDarcena1;
                    estadoSimulacion = "fin calibracion darcena1";
                    proximaCalibracionDarcena1 = seteoDeProximos;
                    darsena1.estado = "libre";
                    servicioRealizado = true;
                }
                // fin de calibracion de darsena 2 queda en estado libre
                if (tiempoMinimo == proximacalibracionDarcena2 && servicioRealizado == false)
                {
                    reloj = proximacalibracionDarcena2;
                    estadoSimulacion = "fin calibracion darcena2";
                    proximacalibracionDarcena2 = seteoDeProximos;
                    darsena2.estado = "libre";
                    servicioRealizado = true;
                }

            }
            //se cuentan los camiones que quedaron sin atender en el dia
            cantCamionesNOAtendidos = colaRecepcion.Count;
            return Tuple.Create(cantCamionesAtendidos, cantCamionesNOAtendidos);

        }

        private TimeSpan calcularPromedio(List<Camion> listaCamiones)
        {
            //se calcula el tiempo promedio del tiempo de los camiones atendidos desde 
            //que los atiende el recepcionista hasta que finaliza la descarga del combustible en darsenas
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

        private TimeSpan llegadaCamion(double lambda)
        {
            //Distribucion Exponencial Negativa

            double aleatorio = GeneradorUnico.GenerarAleatorio();

            double tiempoLlegada = -lambda * Math.Log(1 - aleatorio);

            return GeneradorUnico.convertirSegundosHorasMinutos(tiempoLlegada);
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
            //se valida cual es el tiempo minimo dentro de las variables pasados por parametros
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
                if(i == 0 )
                {
                    min = numerosValidos[i];
                }
                else if(numerosValidos[i] < min )
                {
                    min = numerosValidos[i];

                }
            }
            //devuelve el valor minimo
            return min;
        }
    }
}
