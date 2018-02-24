using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoDeTronos_BL.logica;
using JuegoDeTronos_DAT.entidades;
using JuegoDeTronos_DAL.manejadores;
using System.Collections.ObjectModel;

namespace JuegoDeTronos_BL.logica
{
    public class clsListadosBL
    {
        private clsListados listados;
        public clsListadosBL()
        {

            listados = new clsListados();

        }

        /// <summary>
        /// Funcion que devolvera un listado de combates de la base de datos
        /// </summary>
        /// <returns>Lista de combates</returns>        
        public ObservableCollection<clsCombate> obtenerCombates()
        {
            ObservableCollection<clsCombate> combates=new ObservableCollection<clsCombate>();
            

            foreach (clsCombate c in listados.obtenerCombates())
            {
                combates.Add(c);

            }
            return combates;
        }

        /// <summary>
        /// Funcion que devolvera el listados de luchadores de la base de datos
        /// </summary>
        /// <returns>Lista de luchadores</returns>
        public ObservableCollection<clsLuchador> obtenerLuchadores()
        {
            ObservableCollection<clsLuchador> luchadores = new ObservableCollection<clsLuchador>();
            foreach (clsLuchador l in listados.obtenerLuchadores())
            {
                luchadores.Add(l);

            }


            return luchadores;
        }
        /// <summary>
        /// Funcion que obtendra la lista de casa de la base de datos
        /// </summary>
        /// <returns>Lista de casas</returns>
        public List<clsCasa> obtenerCasas()
        {

            return listados.obtenerCasas();
        }

        /// <summary>
        /// Funcion que obtendra la lista de nombre de categorias de premios de la base de datos
        /// </summary>
        /// <returns>Lista de nombre de categorias(String)</returns>
        public List<String> obtenerCategorias()
        {

            return listados.obtenerCategoriasPremio();
        }
    }
}
