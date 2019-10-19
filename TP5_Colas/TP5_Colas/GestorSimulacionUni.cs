using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace TP5_Colas
{
    class GestorSimulacionUni
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

        int contadorDescargasDarcena1 = 0;
        int contadorDescargasDarcena2 = 0;

        //List<Camion> listaCamiones = new List<Camion>();
        Boolean servicioRealizado = false;
        Boolean banderaCierreDePuertas = false;
        Boolean banderaAperturaDePuertas = false;


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
        public GestorSimulacionUni(int iteraciones, int tiempoASimular, TimeSpan tiempoInicioSimulacion)
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

            vectorEstado.Columns.Add("Dia");
            vectorEstado.Columns.Add("Reloj");
            vectorEstado.Columns.Add("Evento");
            vectorEstado.Columns.Add("Camion");
            vectorEstado.Columns.Add("Tipo Camion");
            vectorEstado.Columns.Add("Proxima llegada camion");
            vectorEstado.Columns.Add("Recepcion");
            vectorEstado.Columns.Add("Cola Recepcion");
            vectorEstado.Columns.Add("Camion Siendo Atendido Recepcion");
            vectorEstado.Columns.Add("Estado Recepcion");
            vectorEstado.Columns.Add("Proxima Recepcion");
            vectorEstado.Columns.Add("Balanza");
            vectorEstado.Columns.Add("Cola Balanza");
            vectorEstado.Columns.Add("Camion Siendo Atendido Balanza");
            vectorEstado.Columns.Add("Estado Balanza");
            vectorEstado.Columns.Add("Proxima Balanza");
            vectorEstado.Columns.Add("Cola Darcena");
            vectorEstado.Columns.Add("Darcena1");
            vectorEstado.Columns.Add("Camion Siendo Atendido Darcena1");
            vectorEstado.Columns.Add("Estado Darcena1");
            vectorEstado.Columns.Add("Proxima Darcena1");
            vectorEstado.Columns.Add("Darcena2");
            vectorEstado.Columns.Add("Camion Siendo Atendido Darcena2");
            vectorEstado.Columns.Add("Estado Darcena2");
            vectorEstado.Columns.Add("Proxima Darcena2");
            vectorEstado.Columns.Add("contadores");
            vectorEstado.Columns.Add("cantidad camiones atendidos");
            vectorEstado.Columns.Add("cantidad camiones no atendidos");
            vectorEstado.Columns.Add("promedio de estancia de camion");

        }

        public DataTable SimularVectorEstado()
        {
            while (IteracionesCompletadas == false && tiempoASimular >= dia)
            {
                resultados.Add(SimulacionDiaUni(dia));
                dia++;
            }
            if (contadorDeIteracionesRealizadas < iteraciones)
            {
                MessageBox.Show("no se completaron las iteraciones deseadas en los dias sumulados. Cantidad de iteraciones: " + contadorDeIteracionesRealizadas);
            }
            sumTiempoPredioCamion = calcularPromedio(listaCamionesAtendidos);
            return vectorEstado;
        }

        //public void Simulacion30diasUni()
        //{
        //    int cantDias = 30;
        //    for (int i = 0; i < cantDias; i++)
        //    {
        //        resultados.Add(SimulacionDiaUni(i + 1));
        //        estadoSimulacion = "llegada camion";
        //        //Mostrar cantidad de camiones atendidos y no atendidos de los 30 dias 

        //    }
        //    // Calcular PROMEDIO DE PERMANECIA de los camiones (en 30 dias)
        //    sumTiempoPredioCamionUni = calcularPromedio(listaCamionesAtendidos);
        //}



        public Tuple<int, int> SimulacionDiaUni(int dia)
        {
            cantCamionesAtendidos = 0;
            cantCamionesNOAtendidos = 0;
            proximaLlegadaCamion = seteoDeProximos;
            reloj = new TimeSpan(5, 0, 0);
           // Boolean bandera = true;
            banderaAperturaDePuertas = false;
            banderaCierreDePuertas = false;
            estadoSimulacion = "apertura de puertas";
            proximaLlegadaCamion = reloj + llegadaCamionUni(7, 8);


            while (reloj < relojFinDia || recepcion.estado == "ocupado" || colaBalanza.Count != 0 || balanza.estado == "ocupado" || colaDarcena.Count != 0 || darsena1.estado == "ocupado" || darsena2.estado == "ocupado")
            {

                servicioRealizado = false;
                relojAnterior = reloj;

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
                if (estadoSimulacion == "llegada camion" && reloj >= relojInicio && reloj < relojFinDia)
                {
                    proximaLlegadaCamion = reloj + llegadaCamionUni(7, 8);

                }

                if (proximaLlegadaCamion > relojFinDia)
                {
                    proximaLlegadaCamion = seteoDeProximos;
                }

                generarVectorEstado(dia);

                tiempoMinimo = minimo(proximaBalanza, proximaDarcena1, proximaDarcena2, proximaRecepcion, proximaLlegadaCamion, proximaCalibracionDarcena1, proximacalibracionDarcena2);


                if (tiempoMinimo >= relojFinDia && banderaCierreDePuertas == false)
                {
                    estadoSimulacion = "cierre de las puertas";
                    reloj = relojFinDia;
                    servicioRealizado = true;
                    banderaCierreDePuertas = true;
                }

                //if (tiempoMinimo == seteoDeProximos)
                //{
                //    reloj = medioDia;
                //    servicioRealizado = true;
                //    estadoSimulacion = "llegada camion";
                //}
                

                realizarAccion();

                //if (tiempoMinimo == proximaLlegadaCamion && servicioRealizado == false)
                //{
                //    reloj = proximaLlegadaCamion;
                //    estadoSimulacion = "llegada camion";
                //    colaRecepcion.Enqueue(new Camion(contadorDeCamiones));
                //    colaRecepcion.Peek().setGenerador(ref GeneradorUnico);
                //    contadorDeCamiones++;
                //    ultimoCamion = colaRecepcion.Peek();
                //    proximaLlegadaCamion = seteoDeProximos;
                //    servicioRealizado = true;
                //    colaRecepcion.Peek().agregarEstado("en cola recepcion", reloj);
                //}
                //if (tiempoMinimo == proximaRecepcion && servicioRealizado == false)
                //{

                //    reloj = proximaRecepcion;
                //    estadoSimulacion = "fin atencion recepcion";
                //    recepcion.estado = "libre";
                //    proximaRecepcion = seteoDeProximos;
                //    recepcion.getCamionSiendoAtendido().setGenerador(ref GeneradorUnico);
                //    recepcion.getCamionSiendoAtendido().agregarEstado("fin atencion recepcion", reloj);
                //    servicioRealizado = true;
                //    if (recepcion.getCamionSiendoAtendido().getTipoCamion() == 1)
                //    {
                //        colaDarcena.Enqueue(recepcion.getCamionSiendoAtendido());
                //        ultimoCamion = colaDarcena.Peek();
                //        colaDarcena.Peek().agregarEstado("en cola darcena", reloj);
                //    }
                //    else
                //    {
                //        colaBalanza.Enqueue(recepcion.getCamionSiendoAtendido());
                //        ultimoCamion = colaBalanza.Peek();
                //        colaBalanza.Peek().agregarEstado("en cola balanza", reloj);
                //    }
                //    recepcion.setCamionSiendoAtendido(ningunCamion);
                //}

                //if (tiempoMinimo == proximaBalanza && servicioRealizado == false)
                //{

                //    reloj = proximaBalanza;

                //    estadoSimulacion = "fin atencion balanza";
                //    balanza.estado = "libre";
                //    balanza.getCamionSiendoAtendido().agregarEstado("fin atencion balanza", reloj);
                //    colaDarcena.Enqueue(balanza.getCamionSiendoAtendido());
                //    ultimoCamion = colaDarcena.Peek();
                //    proximaBalanza = seteoDeProximos;
                //    servicioRealizado = true;
                //    balanza.setCamionSiendoAtendido(ningunCamion);
                //    colaDarcena.Peek().agregarEstado("en cola darcena", reloj);

                //}

                //if (tiempoMinimo == proximaDarcena1 && servicioRealizado == false)
                //{

                //    reloj = proximaDarcena1;
                //    estadoSimulacion = "fin atencion darcena1";
                //    cantCamionesAtendidos++;
                //    darsena1.estado = "libre";
                //    listaCamionesAtendidos.Add(darsena1.getCamionSiendoAtendido());
                //    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);

                //    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].agregarEstado("fin atencion darcena 1", reloj);

                //    proximaDarcena1 = seteoDeProximos;
                //    servicioRealizado = true;
                //    contadorDescargasDarcena1++;
                //    ultimoCamion = darsena1.getCamionSiendoAtendido();
                //    darsena1.setCamionSiendoAtendido(ningunCamion);

                //}
                //if (tiempoMinimo == proximaDarcena2 && servicioRealizado == false)
                //{

                //    reloj = proximaDarcena2;
                //    estadoSimulacion = "fin atencion darcena2";
                //    cantCamionesAtendidos++;
                //    darsena2.estado = "libre";
                //    listaCamionesAtendidos.Add(darsena2.getCamionSiendoAtendido());
                //    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                //    listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].agregarEstado("fin atencion darcena 2", reloj);
                //    proximaDarcena2 = seteoDeProximos;
                //    servicioRealizado = true;
                //    contadorDescargasDarcena2++;
                //    ultimoCamion = darsena2.getCamionSiendoAtendido();
                //    darsena2.setCamionSiendoAtendido(ningunCamion);

                //}
                //if (tiempoMinimo == proximaCalibracionDarcena1 && servicioRealizado == false)
                //{
                //    reloj = proximaCalibracionDarcena1;
                //    estadoSimulacion = "fin calibracion darcena1";
                //    proximaCalibracionDarcena1 = seteoDeProximos;
                //    darsena1.estado = "libre";
                //    servicioRealizado = true;
                //}
                //if (tiempoMinimo == proximacalibracionDarcena2 && servicioRealizado == false)
                //{
                //    reloj = proximacalibracionDarcena2;
                //    estadoSimulacion = "fin calibracion darcena2";
                //    proximacalibracionDarcena2 = seteoDeProximos;
                //    darsena2.estado = "libre";
                //    servicioRealizado = true;
                //}

                tiempoSimulado = tiempoSimulado + reloj - relojAnterior;

                if (contadorDeIteracionesRealizadas == iteraciones)
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

        //private TimeSpan llegadaCamion(double lambda)
        //{
        //    //Distribucion Exponencial Negativa

        //    double aleatorio = GeneradorUnico.GenerarAleatorio();

        //    double tiempoLlegada = -lambda * Math.Log(1 - aleatorio);

        //    return GeneradorUnico.convertirSegundosHorasMinutos(tiempoLlegada);
        //}

        public DataTable cargarTablaCamiones(List<Camion> listaCamionesFinalizados)
        {
            tablaCamiones.Columns.Add("estado camion");
            tablaCamiones.Columns.Add("reloj");
            foreach (Camion i in listaCamionesFinalizados)
            {
                tablaCamiones.Rows.Add("estado camion " + i.numeroCamion, "reloj");
                for (int j = 0; j < i.conocerEstados().Item1.Count; j++)
                {
                    tablaCamiones.Rows.Add(i.conocerEstados().Item1[j], i.conocerEstados().Item2[j]);


                }
                tablaCamiones.Rows.Add("", "");
            }
            return tablaCamiones;
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

        private void generarVectorEstado(int dia)
        {
            if (tiempoDeComienzoDeIteraciones < tiempoSimulado)
            {
                estadoSimulacion = estadoSimulacion;
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
                if (estadoSimulacion == "cierre de las puertas" || estadoSimulacion == "apertura de puertas" || estadoSimulacion == "fin del dia")
                {
                    vectorEstado.Rows.Add(dia, reloj, estadoSimulacion, "", "", proximaLlegadaCamion, null, CamionesEnCola(colaRecepcion), camionSiendoAtendidoEnRecepcion, recepcion.estado, proximaRecepcion, null, CamionesEnCola(colaBalanza), camionSiendoAtendidoEnBalanza, balanza.estado, proximaBalanza, CamionesEnCola(colaDarcena), null, camionSiendoAtendidoEnDarcena1, darsena1.estado, proximaDarcena1, null, camionSiendoAtendidoEnDarcena2, darsena2.estado, proximaDarcena2, null, cantCamionesAtendidos, cantCamionesNOAtendidos, calcularPromedio(listaCamionesAtendidos));
                }
                else
                {
                    vectorEstado.Rows.Add(dia, reloj, estadoSimulacion, ultimoCamion.numeroCamion, tipoDeCamionUltimo, proximaLlegadaCamion, null, CamionesEnCola(colaRecepcion), camionSiendoAtendidoEnRecepcion, recepcion.estado, proximaRecepcion, null, CamionesEnCola(colaBalanza), camionSiendoAtendidoEnBalanza, balanza.estado, proximaBalanza, CamionesEnCola(colaDarcena), null, camionSiendoAtendidoEnDarcena1, darsena1.estado, proximaDarcena1, null, camionSiendoAtendidoEnDarcena2, darsena2.estado, proximaDarcena2, null, cantCamionesAtendidos, cantCamionesNOAtendidos, calcularPromedio(listaCamionesAtendidos));
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
            else
            {
                vectorEstado.Rows.Add(dia, reloj, estadoSimulacion, "", "", proximaLlegadaCamion, null, CamionesEnCola(colaRecepcion), camionSiendoAtendidoEnRecepcion, recepcion.estado, proximaRecepcion, null, CamionesEnCola(colaBalanza), camionSiendoAtendidoEnBalanza, balanza.estado, proximaBalanza, CamionesEnCola(colaDarcena), null, camionSiendoAtendidoEnDarcena1, darsena1.estado, proximaDarcena1, null, camionSiendoAtendidoEnDarcena2, darsena2.estado, proximaDarcena2, null, cantCamionesAtendidos, cantCamionesNOAtendidos, calcularPromedio(listaCamionesAtendidos));
            }
        }

        private string CamionesEnCola(Queue<Camion> colaCamiones)
        {
            string cadena = "";
            if (colaCamiones.Count == 0)
            {
                return "-";
            }
            else
            {
                foreach (Camion i in colaCamiones)
                {
                    cadena = cadena + i.numeroCamion + "_";
                }
                return cadena;
            }
        }


        private void realizarAccion()
        {
            if (tiempoMinimo == proximaLlegadaCamion && servicioRealizado == false)
            {
                reloj = proximaLlegadaCamion;
                estadoSimulacion = "llegada camion";
                colaRecepcion.Enqueue(new Camion(contadorDeCamiones));
                colaRecepcion.Peek().setGenerador(ref GeneradorUnico);
                contadorDeCamiones++;
                ultimoCamion = colaRecepcion.Peek();
                proximaLlegadaCamion = seteoDeProximos;
                servicioRealizado = true;
                colaRecepcion.Peek().agregarEstado("en cola recepcion", reloj);
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
                    ultimoCamion = colaDarcena.Peek();
                    colaDarcena.Peek().agregarEstado("en cola darcena", reloj);
                }
                else
                {
                    colaBalanza.Enqueue(recepcion.getCamionSiendoAtendido());
                    ultimoCamion = colaBalanza.Peek();
                    colaBalanza.Peek().agregarEstado("en cola balanza", reloj);
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
                ultimoCamion = colaDarcena.Peek();
                proximaBalanza = seteoDeProximos;
                servicioRealizado = true;
                balanza.setCamionSiendoAtendido(ningunCamion);
                colaDarcena.Peek().agregarEstado("en cola darcena", reloj);

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
        }
    }
}
