using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoDeTronos_DAL.manejadores;
using JuegoDeTronos_DAT.entidades;
using JuegoDeTronos_DAT.entidades_adaptadas;

namespace JuegoDeTronos_BL.logica
{
    class clsInserccionesBL
    {

        private clsInsercciones inserciones;
        public clsInserccionesBL()
        {


            inserciones = new clsInsercciones();

        }


        public void completarCombate(clsCombate combate, clsLuchadorClasificado contrincante1, clsLuchadorClasificado contrincante2)
        {

            if (contrincante1.espectacular != contrincante2.espectacular
                                                &&
                 contrincante1.sangriento != contrincante2.sangriento
                                                &&
                 contrincante1.vistorioso != contrincante2.vistorioso
            )
            {

                inserciones.insertarClasificacionCombate(combate, contrincante1, contrincante2);
            }



        }

    }
}
