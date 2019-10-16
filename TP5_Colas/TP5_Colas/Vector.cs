using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5_Colas
{
    class Vector
    {
        public string reloj { set; get; }
        public string dia { set; get; }
        public string proximaLlegada { set; get; }
        public string proximaRecepcion { set; get; }
        public string estadoRecepcion { set; get; }
        public string proximaBalanza { set; get; }
        public string estadoBalanza { set; get; }
        public string proximaDescargaD1 { set; get; }
        public string estadoD1 { set; get; }
        public string proximaDescargaD2 { set; get; }
        public string estadoD2 { set; get; }

        //los datos de los camiones.
        private List<Camion> camionesEnVector;
    }
}
