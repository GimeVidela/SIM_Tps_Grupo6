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
        string estadoSimulacion = "Llegada Camión";

        //lista camiones atendidos
        public List<Camion> listaCamionesAtendidos = new List<Camion>();
        public List<Tuple<int, int>> resultados = new List<Tuple<int, int>>();

        int totalCamionesAtendidosGlobal;
        int totalCamionesNoAtendidosGlobal;

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

            tablaProximosCamiones.Columns.Add("Próximo Camión");

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
            vectorEstado.Columns.Add("Próximo Fin Recepción");
            vectorEstado.Columns.Add("Balanza");
            vectorEstado.Columns.Add("Cola Balanza");
            vectorEstado.Columns.Add("Camión Siendo Atendido Balanza");
            vectorEstado.Columns.Add("Estado Balanza");
            vectorEstado.Columns.Add("Próximo Fin Balanza");
            vectorEstado.Columns.Add("Litros de Combustible");
            vectorEstado.Columns.Add("Cola Dársena");
            vectorEstado.Columns.Add("Dársena1");
            vectorEstado.Columns.Add("Camión Siendo Atendido Dársena1");
            vectorEstado.Columns.Add("Estado Dársena1");
            vectorEstado.Columns.Add("Próximo Fin Dársena1");
            vectorEstado.Columns.Add("Contador Dársena1");
            vectorEstado.Columns.Add("Tiempo Calibración Dársena1");
            vectorEstado.Columns.Add("Dársena2");
            vectorEstado.Columns.Add("Camión Siendo Atendido Dársena2");
            vectorEstado.Columns.Add("Estado Dársena2");
            vectorEstado.Columns.Add("Próximo Fin Dársena2");
            vectorEstado.Columns.Add("Contador Dársena2");
            vectorEstado.Columns.Add("Tiempo Calibración Dársena2");
            vectorEstado.Columns.Add("Contadores");
            vectorEstado.Columns.Add("Cantidad Camiones Atendidos");
            vectorEstado.Columns.Add("Cantidad Camiones NO Atendidos");
            vectorEstado.Columns.Add("Promedio de Estandia de Camión");

        }

        public DataTable SimularVectorEstado()
        {
            while (IteracionesCompletadas == false && tiempoASimular >= dia)
            {
                resultados.Add(SimulacionDiaUni(dia));
                int auxiliarContador = resultados.LastOrDefault().Item1;
                totalCamionesAtendidosGlobal += auxiliarContador;

                int auxiliarContadorNoAtendidos = resultados.LastOrDefault().Item2;
                totalCamionesNoAtendidosGlobal += auxiliarContadorNoAtendidos;
                dia++;
            }
            if (contadorDeIteracionesRealizadas < iteraciones)
            {
                MessageBox.Show("No se completaron las iteraciones deseadas en los días sumulados. Cantidad de iteraciones: " + contadorDeIteracionesRealizadas);
            }
            sumTiempoPredioCamion = calcularPromedio(listaCamionesAtendidos);
            return vectorEstado;
        }

        public Tuple<int, int> SimulacionDiaUni(int dia)
        {
            cantCamionesAtendidos = 0;
            cantCamionesNOAtendidos = 0;
            proximaLlegadaCamion = seteoDeProximos;
            reloj = new TimeSpan(5, 0, 0);
           // Boolean bandera = true;
            banderaAperturaDePuertas = false;
            banderaCierreDePuertas = false;
            estadoSimulacion = "Apertura de Puertas";
            proximaLlegadaCamion = reloj + llegadaCamionUni(7, 8);


            while (reloj < relojFinDia || recepcion.estado == "Ocupado" || colaBalanza.Count != 0 || balanza.estado == "Ocupado" || colaDarcena.Count != 0 || darsena1.estado == "Ocupado" || darsena2.estado == "Ocupado")
            {

                servicioRealizado = false;
                relojAnterior = reloj;

                servicioRealizado = false;
                if (contadorDescargasDarcena1 == 15)
                {
                    contadorDescargasDarcena1 = 0;
                    proximaCalibracionDarcena1 = reloj + darsena1.CalcularTiempoCalibracion(10, 1.2);
                    darsena1.estado = "Calibrando";

                }
                if (contadorDescargasDarcena2 == 15)
                {
                    contadorDescargasDarcena2 = 0;
                    proximacalibracionDarcena2 = reloj + darsena2.CalcularTiempoCalibracion(10, 1.2);
                    darsena2.estado = "Calibrando";

                }
                if (colaRecepcion.Count != 0 && recepcion.estado == "Libre" && reloj < relojFinDia && reloj >= relojInicio)
                {
                    proximaRecepcion = reloj + recepcion.CalcularTiempoAtencion(3, 7);
                    recepcion.setCamionSiendoAtendido(colaRecepcion.Dequeue());
                    recepcion.getCamionSiendoAtendido().setHoraLlegada(reloj);
                    recepcion.getCamionSiendoAtendido().agregarEstado("En Recepción", reloj);
                    recepcion.estado = "Ocupado";

                }
                if (colaBalanza.Count != 0 && balanza.estado == "Libre")
                {
                    proximaBalanza = reloj + balanza.CalcularTiempoPesaje(5, 7);
                    balanza.setCamionSiendoAtendido(colaBalanza.Dequeue());
                    balanza.getCamionSiendoAtendido().agregarEstado("En Balanza", reloj);
                    balanza.estado = "Ocupado";

                }
                if (colaDarcena.Count != 0 && darsena1.estado == "Libre" && contadorDescargasDarcena1 < 15)
                {
                    if (ultimoCamion.getTipoCamion() == 1)
                    {
                        proximaDarcena1 = reloj + darsena1.CalcularTiempoDescarga(15, 20);
                    }
                    else // TP6
                    {
                        proximaDarcena1 = reloj + darsena1.CalcularDescargaEuler(ultimoCamion.getPeso());
                    }
                    darsena1.estado = "Ocupado";

                    darsena1.setCamionSiendoAtendido(colaDarcena.Dequeue());
                    darsena1.getCamionSiendoAtendido().agregarEstado("En Dársena1", reloj);
                }
                if (colaDarcena.Count != 0 && darsena2.estado == "Libre" && contadorDescargasDarcena2 < 15)
                {
                    if (ultimoCamion.getTipoCamion() == 1)
                    {
                        proximaDarcena2 = reloj + darsena2.CalcularTiempoDescarga(15, 20);
                    }
                    else //TP6
                    {
                        proximaDarcena2 = reloj + darsena2.CalcularDescargaEuler(ultimoCamion.getPeso());
                    }
                    darsena2.estado = "Ocupado";

                    darsena2.setCamionSiendoAtendido(colaDarcena.Dequeue());
                    darsena2.getCamionSiendoAtendido().agregarEstado("En Dársena2", reloj);
                }
                if (estadoSimulacion == "Llegada Camión" && reloj >= relojInicio && reloj < relojFinDia)
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
                    estadoSimulacion = "Cierre de las Puertas";
                    reloj = relojFinDia;
                    servicioRealizado = true;
                    banderaCierreDePuertas = true;
                }

                realizarAccion();

                tiempoSimulado = tiempoSimulado + reloj - relojAnterior;

                if (contadorDeIteracionesRealizadas == iteraciones)
                {
                    cantCamionesNOAtendidos = colaRecepcion.Count;
                    IteracionesCompletadas = true;
                    return Tuple.Create(cantCamionesAtendidos, cantCamionesNOAtendidos);
                }

            }

            generarVectorEstado(dia);

            estadoSimulacion = "Fin del Día";

            cantCamionesNOAtendidos = colaRecepcion.Count;

            generarVectorEstado(dia);

            return Tuple.Create(cantCamionesAtendidos, cantCamionesNOAtendidos);
            //sumTiempoPredioCamion = calcularPromedio(listaCamionesAtendidos);

        }

        public int totalCamionesGlobal()
        {
            return totalCamionesAtendidosGlobal;
        }

        public int totalNoCamionesGlobal()
        {
            return totalCamionesNoAtendidosGlobal;
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

        public DataTable cargarTablaCamiones(List<Camion> listaCamionesFinalizados)
        {
            tablaCamiones.Columns.Add("Estado de Camión");
            tablaCamiones.Columns.Add("Reloj");
            foreach (Camion i in listaCamionesFinalizados)
            {
                tablaCamiones.Rows.Add("Estado de Camión " + i.numeroCamion, "Reloj");
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

                if (ultimoCamion.getTipoCamion() == 1)
                {
                    tipoDeCamionUltimo = "Propio";
                }
                else
                {
                    tipoDeCamionUltimo = "Externo";
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
                if (estadoSimulacion == "Cierre de las Puertas" || estadoSimulacion == "Apertura de Puertas" || estadoSimulacion == "Fin del Día" || estadoSimulacion == "Fin Calibración Dársena1" || estadoSimulacion == "Fin Calibración Dársena2")
                {
                    vectorEstado.Rows.Add(dia, reloj, estadoSimulacion, "", "", "", proximaLlegadaCamion, null, CamionesEnCola(colaRecepcion), camionSiendoAtendidoEnRecepcion, recepcion.estado, proximaRecepcion, null, CamionesEnCola(colaBalanza), camionSiendoAtendidoEnBalanza, balanza.estado, proximaBalanza, ultimoCamion.getPeso(), CamionesEnCola(colaDarcena), null, camionSiendoAtendidoEnDarcena1, darsena1.estado, proximaDarcena1, contadorDescargasDarcena1, proximaCalibracionDarcena1, null, camionSiendoAtendidoEnDarcena2, darsena2.estado, proximaDarcena2, contadorDescargasDarcena2, proximacalibracionDarcena2, null, cantCamionesAtendidos, cantCamionesNOAtendidos, calcularPromedio(listaCamionesAtendidos));
                   }
                else
                {
                    vectorEstado.Rows.Add(dia, reloj, estadoSimulacion, ultimoCamion.numeroCamion, ultimoCamion.getTipoAleatorio(), tipoDeCamionUltimo, proximaLlegadaCamion, null, CamionesEnCola(colaRecepcion), camionSiendoAtendidoEnRecepcion, recepcion.estado, proximaRecepcion, null, CamionesEnCola(colaBalanza), camionSiendoAtendidoEnBalanza, balanza.estado, proximaBalanza, ultimoCamion.getPeso(), CamionesEnCola(colaDarcena), null, camionSiendoAtendidoEnDarcena1, darsena1.estado, proximaDarcena1, contadorDescargasDarcena1, proximaCalibracionDarcena1, null, camionSiendoAtendidoEnDarcena2, darsena2.estado, proximaDarcena2, contadorDescargasDarcena2, proximacalibracionDarcena2, null, cantCamionesAtendidos, cantCamionesNOAtendidos, calcularPromedio(listaCamionesAtendidos));
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
                vectorEstado.Rows.Add(dia, reloj, estadoSimulacion, "", "","", proximaLlegadaCamion, null, CamionesEnCola(colaRecepcion), camionSiendoAtendidoEnRecepcion, recepcion.estado, proximaRecepcion, null, CamionesEnCola(colaBalanza), camionSiendoAtendidoEnBalanza, balanza.estado, proximaBalanza, null, CamionesEnCola(colaDarcena), null, camionSiendoAtendidoEnDarcena1, darsena1.estado, proximaDarcena1, contadorDescargasDarcena1,proximaCalibracionDarcena1, null, camionSiendoAtendidoEnDarcena2, darsena2.estado, proximaDarcena2, contadorDescargasDarcena2, proximacalibracionDarcena2, null, cantCamionesAtendidos, cantCamionesNOAtendidos, calcularPromedio(listaCamionesAtendidos));
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
                estadoSimulacion = "Llegada Camión";
                colaRecepcion.Enqueue(new Camion(contadorDeCamiones));
                colaRecepcion.Last().setGenerador(ref GeneradorUnico);
                contadorDeCamiones++;
                ultimoCamion = colaRecepcion.Last();
                proximaLlegadaCamion = seteoDeProximos;
                servicioRealizado = true;
                colaRecepcion.Last().agregarEstado("En Cola Recepción", reloj);
            }
            if (tiempoMinimo == proximaRecepcion && servicioRealizado == false)
            {

                reloj = proximaRecepcion;
                estadoSimulacion = "Fin Atención Recepción";
                recepcion.estado = "Libre";
                proximaRecepcion = seteoDeProximos;
                recepcion.getCamionSiendoAtendido().agregarEstado("Fin Atención Recepción", reloj);
                //recepcion.getCamionSiendoAtendido().setGenerador(ref GeneradorUnico);

                servicioRealizado = true;
                if (recepcion.getCamionSiendoAtendido().getTipoCamion() == 1)
                {
                    colaDarcena.Enqueue(recepcion.getCamionSiendoAtendido());
                    ultimoCamion = colaDarcena.Last();
                    colaDarcena.Last().agregarEstado("En Cola Dársena", reloj);
                }
                else
                {
                    colaBalanza.Enqueue(recepcion.getCamionSiendoAtendido());
                    ultimoCamion = colaBalanza.Last();
                    colaBalanza.Last().agregarEstado("En Cola Balanza", reloj);
                }
                recepcion.setCamionSiendoAtendido(ningunCamion);
            }

            if (tiempoMinimo == proximaBalanza && servicioRealizado == false)
            {

                reloj = proximaBalanza;

                estadoSimulacion = "Fin Atención Balanza";
                balanza.estado = "Libre";

                balanza.getCamionSiendoAtendido().agregarEstado("Fin Atención Balanza", reloj);

                colaDarcena.Enqueue(balanza.getCamionSiendoAtendido());
                ultimoCamion = colaDarcena.Last();
                proximaBalanza = seteoDeProximos;
                servicioRealizado = true;
                balanza.setCamionSiendoAtendido(ningunCamion);
                colaDarcena.Last().agregarEstado("En Cola Dársena", reloj);

            }

            if (tiempoMinimo == proximaDarcena1 && servicioRealizado == false)
            {

                reloj = proximaDarcena1;
                estadoSimulacion = "Fin Atención Dársena1";
                cantCamionesAtendidos++;
                darsena1.estado = "Libre";

                // darsena1.getCamionSiendoAtendido().agregarEstado("Fin Atención Dársena1", reloj);

                listaCamionesAtendidos.Add(darsena1.getCamionSiendoAtendido());
                listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].agregarEstado("Fin Atención Dársena1", reloj);
                ultimoCamion = darsena1.getCamionSiendoAtendido();
                proximaDarcena1 = seteoDeProximos;
                servicioRealizado = true;
                contadorDescargasDarcena1++;
                darsena1.setCamionSiendoAtendido(ningunCamion);


            }
            if (tiempoMinimo == proximaDarcena2 && servicioRealizado == false)
            {

                reloj = proximaDarcena2;
                estadoSimulacion = "Fin Atención Dársena2";
                cantCamionesAtendidos++;
                darsena2.estado = "Libre";

                //darsena2.getCamionSiendoAtendido().agregarEstado("Fin Atención Dársena2", reloj);

                listaCamionesAtendidos.Add(darsena2.getCamionSiendoAtendido());
                listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].setHoraSalida(reloj);
                listaCamionesAtendidos[listaCamionesAtendidos.Count - 1].agregarEstado("Fin Atención Dársena2", reloj);
                ultimoCamion = darsena2.getCamionSiendoAtendido();
                proximaDarcena2 = seteoDeProximos;
                servicioRealizado = true;
                contadorDescargasDarcena2++;
                darsena2.setCamionSiendoAtendido(ningunCamion);

            }
            if (tiempoMinimo == proximaCalibracionDarcena1 && servicioRealizado == false)
            {
                reloj = proximaCalibracionDarcena1;
                estadoSimulacion = "Fin Calibración Dársena1";
                proximaCalibracionDarcena1 = seteoDeProximos;
                darsena1.estado = "Libre";
                servicioRealizado = true;
            }
            if (tiempoMinimo == proximacalibracionDarcena2 && servicioRealizado == false)
            {
                reloj = proximacalibracionDarcena2;
                estadoSimulacion = "Fin Calibración Dársena2";
                proximacalibracionDarcena2 = seteoDeProximos;
                darsena2.estado = "Libre";
                servicioRealizado = true;
            }
        }
    }
}
