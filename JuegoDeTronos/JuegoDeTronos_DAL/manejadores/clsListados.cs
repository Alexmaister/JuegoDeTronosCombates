using JuegoDeTronos_DAL.conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoDeTronos_DAT.entidades;

namespace JuegoDeTronos_DAL.manejadores
{
    public class clsListados
    {
        clsMyConnection miconexion;
        SqlConnection conexion;
        SqlCommand commando;
        SqlDataReader lector;

        public clsListados()
        {
            miconexion = new clsMyConnection();
            conexion = miconexion.getConnection();
            commando = new SqlCommand();
            
        }

        /// <summary>
        /// Funcion que obtendra la lista de casa de la base de datos
        /// </summary>
        /// <returns>Lista de casas</returns>
        public List<clsCasa> obtenerCasas()
        {

            List<clsCasa> casas = new List<clsCasa>();

            try
            {
               
                commando.CommandText = "SELECT idCasa,nombreCasa from dbo.casas";
                commando.Connection = conexion;
                lector = commando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        casas.Add(new clsCasa((int)lector["idCasa"], (String)lector["nombreCasa"]));
                    }
                }

            }
            catch (SqlException exception)
            {

                throw exception;

            }
            finally
            {
                lector.Close();
               
            }

            return casas;
        }



        /// <summary>
        /// Funcion que devolvera el listados de luchadores de la base de datos
        /// </summary>
        /// <returns>Lista de luchadores</returns>
        public List<clsLuchador> obtenerLuchadores()
        {

            List<clsLuchador> luchadores = new List<clsLuchador>();

            try
            {
               
                commando.CommandText = "SELECT idLuchador,nombreLuchador,idCasa from dbo.luchadores";
                commando.Connection = conexion;
                lector = commando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        luchadores.Add(new clsLuchador((int)lector["idLuchador"], (String)lector["nombreLuchador"], (int)lector["idCasa"]));
                    }
                }

            }
            catch (SqlException exception)
            {

                throw exception;

            }
            finally
            {
                lector.Close();
               
            }

            return luchadores;

        }


        /// <summary>
        /// Funcion que devolvera la lista de combates de la base de datos
        /// </summary>
        /// <returns>Lista de combates</returns>
        public List<clsCombate> obtenerCombates()
        {

            List<clsCombate> combates = new List<clsCombate>();

            try
            {
                
                commando.CommandText = "SELECT idCombate,fechaCombate from dbo.combates";
                commando.Connection = conexion;
                lector = commando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        combates.Add(new clsCombate((int)lector["idCombate"], (DateTime)lector["fechaCombate"]));
                    }
                }

            }
            catch (SqlException exception)
            {

                throw exception;

            }
            finally
            {

                lector.Close();
               
            }

            return combates;

        }


        /// <summary>
        /// Funcion que obtendra la lista de nombre de categorias de premios de la base de datos
        /// </summary>
        /// <returns>Lista de nombre de categorias(String)</returns>
        public List<String> obtenerCategoriasPremio()
        {

            List<String> premios = new List<String>();

            try
            {
               
                commando.CommandText = "SELECT nombreCategoriaPremio from dbo.categoriasPremios";
                commando.Connection = conexion;
                lector = commando.ExecuteReader();

                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        premios.Add((String)lector["nombreCategoriaPremio"]);
                    }
                }

            }
            catch (SqlException exception)
            {

                throw exception;

            }
            finally
            {

                lector.Close();
               
            }

            return premios;

        }


    }
}
