using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeTronos_DAT.entidades
{
    public class clsCasa
    {
        public int id { get; }
        public String nombre { get; }

        public clsCasa(int id, String nombre)
        {

            this.id = id;
            this.nombre = nombre;
        }

    }
}
