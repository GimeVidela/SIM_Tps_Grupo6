﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TP5_Colas
{
    class GestorSimulacionVectorEstado
    {
        DataTable tablaCamiones = new DataTable();
        public DataTable tablaProximosCamiones = new DataTable();
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
        public TimeSpan sumTiempoPredioCamionUni = new TimeSpan(0, 0, 0);

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
        int tiempoASimular;
        TimeSpan tiempoDeComienzoDeIteraciones;
        int iteraciones;
        Boolean IteracionesCompletadas = false;
        int dia = 1;
        DataTable vectorEstado = new DataTable();
        int contadorDeIteraciones;
        TimeSpan tiempoSimulado;
        TimeSpan relojAnterior;
        Camion ultimoCamion;
        Camion ningunCamion = new Camion();
        int contadorDeIteracionesRealizadas = 0;
        int contadorDeCamiones = 1;
        string tipoDeCamionUltimo;
        string camionSiendoAtendidoEnRecepcion = "";
        string camionSiendoAtendidoEnBalanza = "";
        string camionSiendoAtendidoEnDarcena1 = "";
        string camionSiendoAtendidoEnDarcena2 = "";
        int totalCamionesAtendidosGlobal;
        int totalCamionesNoAtendidosGlobal;

        int contadorDescargasDarcena1 = 0;
        int contadorDescargasDarcena2 = 0;

        //List<Camion> listaCamiones = new List<Camion>();
        Boolean servicioRealizado = false;
        Boolean banderaCierreDePuertas = false;
        Boolean banderaAperturaDePuertas = false;

        int ultimoNumeroCamion;


        TimeSpan ultimoValorLLegadaCamion = new TimeSpan(5, 0, 0);
        TimeSpan valorValorLLegadaCamion = new TimeSpan(5, 0, 0);

        // colas

        Queue<Camion> colaRecepcion = new Queue<Camion>();
        Queue<Camion> colaBalanza = new Queue<Camion>();
        Queue<Camion> colaDarcena = new Queue<Camion>();

        // bandera de simulacion de un dia
        string estadoSimulacion = "llegada camion";

        //lista camiones atendidos
        public List<Camion> listaCamionesAtendidos = new List<Camion>();
        public List<Tuple<int, int>> resultados = new List<Tuple<int, int>>();

        // inicializar servidores
        public GestorSimulacionVectorEstado(int iteraciones, int tiempoASimular, TimeSpan tiempoInicioSimulacion)
        {
            recepcion.setGenerador(ref GeneradorUnico);
            balanza.setGenerador(ref GeneradorUnico);
            darsena1.setGenerador(ref GeneradorUnico);
            darsena2.setGenerador(ref GeneradorUnico);

            recepcion.setCamionSiendoAtendido(ningunCamion);
            balanza.setCamionSiendoAtendido(ningunCamion);
            darsena1.setCamionSiendoAtendido(ningunCamion);
            darsena2.setCamionSiendoAtendido(ningunCamion);



            this.iteraciones = iteraciones;
            this.tiempoASimular = tiempoASimular;
            this.tiempoDeComienzoDeIteraciones = tiempoInicioSimulacion;

            tablaProximosCamiones.Columns.Add("proximo camion");

            vectorEstado.Columns.Add("Día");
            vectorEstado.Columns.Add("Reloj");
            vectorEstado.Columns.Add("Evento");
            vectorEstado.Columns.Add("Camión");
            vectorEstado.Columns.Add("Aleatorio Tipo Camión");
            vectorEstado.Columns.Add("Tipo Camión");
            vectorEstado.Columns.Add("Próxima Llegada Camión");
            vectorEstado.Columns.Add("Recepción");
            vectorEstado.Columns.Add("Cola Recepción");
            vectorEstado.Columns.Add("Camión Siendo Atendido Recepción");
            vectorEstado.Columns.Add("Estado Recepción");
            vectorEstado.Columns.Add("Próxima Recepción");
            vectorEstado.Columns.Add("Balanza");
            vectorEstado.Columns.Add("Cola Balanza");
            vectorEstado.Columns.Add("Camión Siendo Atendido Balanza");
            vectorEstado.Columns.Add("Estado Balanza");
            vectorEstado.Columns.Add("Próxima Balanza");
            vectorEstado.Columns.Add("Cola Dársena");
            vectorEstado.Columns.Add("Dársena1");
            vectorEstado.Columns.Add("Camión Siendo Atendido Dársena1");
            vectorEstado.Columns.Add("Estado Dársena1");
            vectorEstado.Columns.Add("Próxima Fin Dársena1");
            vectorEstado.Columns.Add("Contador Dársena1");
            vectorEstado.Columns.Add("Tiempo Calibración Dársena1");
            vectorEstado.Columns.Add("Dársena2");
            vectorEstado.Columns.Add("Camión Siendo Atendido Dársena2");
            vectorEstado.Columns.Add("Estado Dársena2");
            vectorEstado.Columns.Add("Próxima Fin Dársena2");
            vectorEstado.Columns.Add("Contador Dársena2");
            vectorEstado.Columns.Add("Tiempo Calibración Dársena2");
            vectorEstado.Columns.Add("Contadores");
            vectorEstado.Columns.Add("Cantidad Camiones Atendidos");
            vectorEstado.Columns.Add("Cantidad Camiones NO Atendidos");
            vectorEstado.Columns.Add("Promedio de Estandia de Camión");

        }

        //Simular 30 dias
        public DataTable SimularVectorEstado()
        {
            while(IteracionesCompletadas == false && tiempoASimular >= dia)
            {
                resultados.Add(SimulacionDia(dia));
                int auxiliarContador = resultados.LastOrDefault().Item1;
                totalCamionesAtendidosGlobal += auxiliarContador;

                int auxiliarContadorNoAtendidos = resultados.LastOrDefault().Item2;
                totalCamionesNoAtendidosGlobal += auxiliarContadorNoAtendidos;
                dia++;
            }
            if(contadorDeIteracionesRealizadas < iteraciones)
            {
                MessageBox.Show("No se completaron las iteraciones deseadas en los días simulados. Cantidad de iteraciones: " + contadorDeIteracionesRealizadas);
            }
            sumTiempoPredioCamion = calcularPromedio(listaCamionesAtendidos);

            //for (int i = 0; i < resultados.Count(); i++)
            //{
                
            //    //int auxiliarContador = int.Parse(resultados[i].Item1.ToString());

            //    int auxiliarContador = resultados[i].Item1;
            //    totalCamionesAtendidosGlobal += auxiliarContador;

            //    int auxiliarContadorNoAtendidos = int.Parse(resultados[i].Item2.ToString());
            //    totalCamionesNoAtendidosGlobal += auxiliarContadorNoAtendidos;


            //}



            return vectorEstado;
        }

        public int totalCamionesGlobal()
        {
            return totalCamionesAtendidosGlobal;
        }

        public int totalNoCamionesGlobal()
        {
            return totalCamionesNoAtendidosGlobal;
        }

        //public void Simulacion30dias()
        //{
        //    int cantDias = 30;
        //    for (int i = 0; i < cantDias; i++)
        //    {
        //        resultados.Add(SimulacionDia(i + 1));
        //        estadoSimulacion = "llegada camion";
        //        //Mostrar cantidad de camiones atendidos y no atendidos de los 30 dias 

        //    }
        //    // Calcular PROMEDIO DE PERMANECIA de los camiones (en 30 dias)
        //    sumTiempoPredioCamion = calcularPromedio(listaCamionesAtendidos);
        //}

        public Tuple<int, int> SimulacionDia(int dia)
        {
            cantCamionesAtendidos = 0;
            cantCamionesNOAtendidos = 0;
            proximaLlegadaCamion = seteoDeProximos;
            // Boolean bandera = true;
            banderaAperturaDePuertas = false;
            banderaCierreDePuertas = false;
            //Validacion si es primer dia 
            if (dia == 1)
            {
                reloj = new TimeSpan(12, 0, 0);
               // tiempoSimulado = tiempoSimulado -reloj;
                //colaRecepcion.Enqueue(new Camion(reloj));

            }
            else
            {
                reloj = new TimeSpan(5, 0, 0);
                estadoSimulacion = "apertura de puertas";
                //tiempoSimulado = tiempoSimulado - reloj;
            }
            while (reloj < relojFinDia || recepcion.estado == "ocupado" || colaBalanza.Count != 0 || balanza.estado == "ocupado" || colaDarcena.Count != 0 || darsena1.estado == "ocupado" || darsena2.estado == "ocupado")
            {

                servicioRealizado = false;
                relojAnterior = reloj;
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
                    recepcion.getCamionSiendoAtendido().agregarEstado("en recepcion", reloj);
                    recepcion.estado = "ocupado";

                }
                if (colaBalanza.Count != 0 && balanza.estado == "libre")
                {
                    proximaBalanza = reloj + balanza.CalcularTiempoPesaje(5, 7);
                    balanza.setCamionSiendoAtendido(colaBalanza.Dequeue());
                    balanza.getCamionSiendoAtendido().agregarEstado("en balanza", reloj);
                    balanza.estado = "ocupado";

                }
                if (colaDarcena.Count != 0 && darsena1.estado == "libre" && contadorDescargasDarcena1 < 15)
                {
                    proximaDarcena1 = reloj + darsena1.CalcularTiempoDescarga(15, 20);
                    darsena1.estado = "ocupado";
                    

                    darsena1.setCamionSiendoAtendido(colaDarcena.Dequeue());
                    darsena1.getCamionSiendoAtendido().agregarEstado("en darcena1", reloj);
                }
                if (colaDarcena.Count != 0 && darsena2.estado == "libre" && contadorDescargasDarcena2 < 15)
                {
                    proximaDarcena2 = reloj + darsena2.CalcularTiempoDescarga(15, 20);
                    darsena2.estado = "ocupado";

                    darsena2.setCamionSiendoAtendido(colaDarcena.Dequeue());
                    darsena2.getCamionSiendoAtendido().agregarEstado("en darcena2", reloj);
                }
                if (estadoSimulacion == "llegada camion" && reloj >= medioDia && reloj < relojFinDia)
                {
                    proximaLlegadaCamion = reloj + llegadaCamion(7.5);
                    valorValorLLegadaCamion = proximaLlegadaCamion - reloj;

                }
                if(proximaLlegadaCamion > relojFinDia)
                {
                    proximaLlegadaCamion = seteoDeProximos;
                }

                generarVectorEstado(dia);

                tiempoMinimo = minimo(proximaBalanza, proximaDarcena1, proximaDarcena2, proximaRecepcion, proximaLlegadaCamion, proximaCalibracionDarcena1, proximacalibracionDarcena2);

                if(tiempoMinimo >= relojFinDia && banderaCierreDePuertas == false)
                {
                    estadoSimulacion = "cierre de las puertas";
                    reloj = relojFinDia;
                    servicioRealizado = true;
                    banderaCierreDePuertas = true;
                }


                if (tiempoMinimo == seteoDeProximos)
                {
                    reloj = medioDia;
                    servicioRealizado = true;
                    estadoSimulacion = "llegada camion";
                }
                if (reloj <= medioDia && tiempoMinimo >= medioDia && proximaLlegadaCamion == seteoDeProximos && servicioRealizado == false)
                {
                    proximaLlegadaCamion = medioDia + llegadaCamion(7.5);
                    servicioRealizado = true;
                }

                if (tiempoMinimo == proximaLlegadaCamion && servicioRealizado == false)
                {
                    reloj = proximaLlegadaCamion;
                    estadoSimulacion = "llegada camion";
                    colaRecepcion.Enqueue(new Camion(contadorDeCamiones));
                    colaRecepcion.Last().setGenerador(ref GeneradorUnico);
                    contadorDeCamiones++;
                    ultimoCamion = colaRecepcion.Last();
                    proximaLlegadaCamion = seteoDeProximos;
                    servicioRealizado = true;
                    colaRecepcion.Last().agregarEstado("en cola recepcion", reloj);
                }
                if (tiempoMinimo == proximaRecepcion && servicioRealizado == false)
                {

                    reloj = proximaRecepcion;
                    estadoSimulacion = "fin atencion recepcion";
                    recepcion.estado = "libre";
                    proximaRecepcion = seteoDeProximos;
                    recepcion.getCamionSiendoAtendido().agregarEstado("fin atencion recepcion", reloj);
                    //recepcion.getCamionSiendoAtendido().setGenerador(ref GeneradorUnico);
                     
                    servicioRealizado = true;
                    if (recepcion.getCamionSiendoAtendido().getTipoCamion() == 1)
                    {
                        colaDarcena.Enqueue(recepcion.getCamionSiendoAtendido());
                        ultimoCamion = colaDarcena.Last();
                        colaDarcena.Last().agregarEstado("en cola darcena", reloj);
                    }
                    else
                    {
                        colaBalanza.Enqueue(recepcion.getCamionSiendoAtendido());
                        ultimoCamion = colaBalanza.Last();
                        colaBalanza.Last().agregarEstado("en cola balanza", reloj);
                    }
                    recepcion.setCamionSiendoAtendido(ningunCamion);
                }

                if (tiempoMinimo == proximaBalanza && servicioRealizado == false)
                {

                    reloj = proximaBalanza;

                    estadoSimulacion = "fin atencion balanza";
                    balanza.estado = "libre";

                    balanza.getCamionSiendoAtendido().agregarEstado("fin atencion balanza", reloj);
                   
                    colaDarcena.Enqueue(balanza.getCamionSiendoAtendido());
                    ultimoCamion = colaDarcena.Last();
                    proximaBalanza = seteoDeProximos;
                    servicioRealizado = true;
                    balanza.setCamionSiendoAtendido(ningunCamion);
                    colaDarcena.Last().agregarEstado("en cola darcena", reloj);

                }

                if (tiempoMinimo == proximaDarcena1 && servicioRealizado == false)
                {

                    reloj = proximaDarcena1;
                    estadoSimulacion = "fin atencion darcena1";
                    cantCamionesAtendidos++;
                    darsena1.estado = "libre";

                   // darsena1.getCamionSiendoAtendido().agregarEstado("fin atencion darcena 1", reloj);

                    listaCamionesAtendidos.Add(darsena1.getCamionSiendoAtendido());
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].agregarEstado("fin atencion darcena 1", reloj);
                    ultimoCamion = darsena1.getCamionSiendoAtendido();
                    proximaDarcena1 = seteoDeProximos;
                    servicioRealizado = true;
                    contadorDescargasDarcena1++;
                    darsena1.setCamionSiendoAtendido(ningunCamion);


                }
                if (tiempoMinimo == proximaDarcena2 && servicioRealizado == false)
                {

                    reloj = proximaDarcena2;
                    estadoSimulacion = "fin atencion darcena2";
                    cantCamionesAtendidos++;
                    darsena2.estado = "libre";

                    //darsena2.getCamionSiendoAtendido().agregarEstado("fin atencion darcena 2", reloj);

                    listaCamionesAtendidos.Add(darsena2.getCamionSiendoAtendido());
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].agregarEstado("fin atencion darcena 2", reloj);
                    ultimoCamion = darsena2.getCamionSiendoAtendido();
                    proximaDarcena2 = seteoDeProximos;
                    servicioRealizado = true;
                    contadorDescargasDarcena2++;
                    darsena2.setCamionSiendoAtendido(ningunCamion);

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

                tiempoSimulado = tiempoSimulado + reloj - relojAnterior;

                if(contadorDeIteracionesRealizadas == iteraciones)
                {
                    cantCamionesNOAtendidos = colaRecepcion.Count;
                    IteracionesCompletadas = true;
                    return Tuple.Create(cantCamionesAtendidos, cantCamionesNOAtendidos);
                }


            }
            generarVectorEstado(dia);

            estadoSimulacion = "fin del dia";
            
            cantCamionesNOAtendidos = colaRecepcion.Count;

            generarVectorEstado(dia);

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

        private TimeSpan llegadaCamion(double lambda)
        {
            //Distribucion Exponencial Negativa

            double aleatorio = GeneradorUnico.GenerarAleatorio();

            double tiempoLlegada = ((-lambda )* Math.Log(1 - aleatorio));

            return GeneradorUnico.convertirSegundosHorasMinutos(tiempoLlegada);
        }

        private TimeSpan llegadaCamionUni(double valorA, double valorB)
        {
            //Distribucion Exponencial Negativa

            double aleatorio = GeneradorUnico.GenerarAleatorio();

            double tiempoLlegada = valorA + aleatorio * (valorB - valorA);

            return GeneradorUnico.convertirSegundosHorasMinutos(tiempoLlegada);
        }
        private string CamionesEnCola(Queue<Camion> colaCamiones)
        {
            string cadena = "";
            if(colaCamiones.Count == 0)
            {
                return "-";
            }
            else
            {
                foreach(Camion i in colaCamiones )
                {
                    cadena = cadena + i.numeroCamion + "_";
                }
                return cadena;
            }
        }

        public DataTable cargarTablaCamiones (List<Camion> listaCamionesFinalizados )
        {
            tablaCamiones.Columns.Add("estado camion");
            tablaCamiones.Columns.Add("reloj");
            foreach(Camion i in listaCamionesFinalizados)
            {
                tablaCamiones.Rows.Add("estado camion " + i.numeroCamion, "reloj");
                    for( int j=0; j<i.conocerEstados().Item1.Count ; j++)
                {
                    tablaCamiones.Rows.Add(i.conocerEstados().Item1[j], i.conocerEstados().Item2[j]);


                }
                tablaCamiones.Rows.Add("", "");
            }
            return tablaCamiones;
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
        private void generarVectorEstado(int dia)
        {
            if (tiempoDeComienzoDeIteraciones < tiempoSimulado)
            {
                
                if (ultimoCamion.getTipoCamion() == 1)
                {
                    tipoDeCamionUltimo = "propio";
                }
                else
                {
                    tipoDeCamionUltimo = "externo";
                }
                if (recepcion.getCamionSiendoAtendido().numeroCamion != 0)
                {
                    camionSiendoAtendidoEnRecepcion = Convert.ToString(recepcion.getCamionSiendoAtendido().numeroCamion);
                }
                else
                {
                    camionSiendoAtendidoEnRecepcion = "";
                }
                if (balanza.getCamionSiendoAtendido().numeroCamion != 0)
                {
                    camionSiendoAtendidoEnBalanza = Convert.ToString(balanza.getCamionSiendoAtendido().numeroCamion);
                }
                else
                {
                    camionSiendoAtendidoEnBalanza = "";
                }
                if (darsena1.getCamionSiendoAtendido().numeroCamion != 0)
                {
                    camionSiendoAtendidoEnDarcena1 = Convert.ToString(darsena1.getCamionSiendoAtendido().numeroCamion);
                }
                else
                {
                    camionSiendoAtendidoEnDarcena1 = "";
                }
                if (darsena2.getCamionSiendoAtendido().numeroCamion != 0)
                {
                    camionSiendoAtendidoEnDarcena2 = Convert.ToString(darsena2.getCamionSiendoAtendido().numeroCamion);
                }
                else
                {
                    camionSiendoAtendidoEnDarcena2 = "";
                }
                if (estadoSimulacion == "cierre de las puertas" || estadoSimulacion == "apertura de puertas" || estadoSimulacion == "fin del dia" || estadoSimulacion == "fin calibracion darcena1" || estadoSimulacion == "fin calibracion darcena2")
                {
                    vectorEstado.Rows.Add(dia, reloj, estadoSimulacion, "", "", "",proximaLlegadaCamion, null, CamionesEnCola(colaRecepcion), camionSiendoAtendidoEnRecepcion, recepcion.estado, proximaRecepcion, null, CamionesEnCola(colaBalanza), camionSiendoAtendidoEnBalanza, balanza.estado, proximaBalanza, CamionesEnCola(colaDarcena), null, camionSiendoAtendidoEnDarcena1, darsena1.estado, proximaDarcena1, contadorDescargasDarcena1, proximaCalibracionDarcena1, null, camionSiendoAtendidoEnDarcena2, darsena2.estado, proximaDarcena2, contadorDescargasDarcena2, proximacalibracionDarcena2, null,cantCamionesAtendidos,cantCamionesNOAtendidos,calcularPromedio(listaCamionesAtendidos));
                }
                else
                {
                    vectorEstado.Rows.Add(dia,reloj, estadoSimulacion, ultimoCamion.numeroCamion,ultimoCamion.getTipoAleatorio(), tipoDeCamionUltimo,proximaLlegadaCamion, null, CamionesEnCola(colaRecepcion), camionSiendoAtendidoEnRecepcion, recepcion.estado, proximaRecepcion, null, CamionesEnCola(colaBalanza), camionSiendoAtendidoEnBalanza, balanza.estado, proximaBalanza, CamionesEnCola(colaDarcena), null, camionSiendoAtendidoEnDarcena1, darsena1.estado, proximaDarcena1, contadorDescargasDarcena1, proximaCalibracionDarcena1, null, camionSiendoAtendidoEnDarcena2, darsena2.estado, proximaDarcena2, contadorDescargasDarcena2, proximacalibracionDarcena2, null, cantCamionesAtendidos, cantCamionesNOAtendidos, calcularPromedio(listaCamionesAtendidos));
                }
                contadorDeIteracionesRealizadas++;
                if (tablaProximosCamiones.Rows.Count != 0)
                {
                    if (proximaLlegadaCamion != ultimoValorLLegadaCamion)
                    {
                        tablaProximosCamiones.Rows.Add(valorValorLLegadaCamion);
                        ultimoValorLLegadaCamion = proximaLlegadaCamion;
                    }
                }
                else
                {
                    tablaProximosCamiones.Rows.Add(valorValorLLegadaCamion);
                    ultimoValorLLegadaCamion = proximaLlegadaCamion;
                }
                
            }
        }


    }
}
