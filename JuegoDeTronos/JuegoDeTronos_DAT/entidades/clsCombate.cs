using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeTronos_DAT.entidades
{
    public class clsCombate : clsVMBase
    {
        private int _id;
        private DateTime _fecha_combate;
        public int id { get {

                return this._id;
            }

        set {
                this._id = value;
                NotifyPropertyChanged("id");
            }
        }
        public DateTime fecha_combate { get {
               return this._fecha_combate;
            }
        set { this._fecha_combate = value;
                NotifyPropertyChanged("fecha_combate");
            }
        }

        public clsCombate(int id, DateTime fecha_combate)
        {

            this.id = id; this.fecha_combate = fecha_combate;
        }
    }
}
