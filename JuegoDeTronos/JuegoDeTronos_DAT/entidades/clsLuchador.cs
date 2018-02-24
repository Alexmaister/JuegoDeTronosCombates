using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeTronos_DAT.entidades
{
    public class clsLuchador : clsVMBase
    {
        private int _id;
        private String _nombre;
        private int _id_casa;
        public int id { get {
                return this._id;
            }
        set { this._id = value;
                NotifyPropertyChanged("id");
            }
        }
        public String nombre { get { return this._nombre; }
            set {
                this._nombre = value;
                NotifyPropertyChanged("nombre");

            }
        }

        public int id_casa { get { return this._id_casa; }
        set { this._id_casa = value;
                NotifyPropertyChanged("id_casa");
            }
        }

        public clsLuchador(int id, String nombre, int id_casa)
        {

            this.id = id; this.nombre = nombre; this.id_casa = id_casa;
        }

        public clsLuchador()
        {
        }
    }
}
