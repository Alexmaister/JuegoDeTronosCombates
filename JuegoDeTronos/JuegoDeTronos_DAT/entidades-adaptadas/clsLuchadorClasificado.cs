using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoDeTronos_DAT.entidades;

namespace JuegoDeTronos_DAT.entidades_adaptadas
{
    public class clsLuchadorClasificado: clsLuchador
    {
        public int sangriento { get; set; }
        public int espectacular { get; set; }
        public int vistorioso { get; set; }

        public clsLuchadorClasificado(int id, String nombre, int idCasa) : base(id, nombre, idCasa)
        {

            this.sangriento = 0;
            this.espectacular = 0;
            this.vistorioso = 0;

        }

        public clsLuchadorClasificado(int id, String nombre, int idCasa, int sangriento, int espectacular, int victorioso) : base(id, nombre, idCasa)
        {

            this.sangriento = sangriento;
            this.espectacular = espectacular;
            this.vistorioso = vistorioso;

        }
    }
}
