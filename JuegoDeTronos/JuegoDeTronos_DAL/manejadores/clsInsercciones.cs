using JuegoDeTronos_DAL.conexion;
using JuegoDeTronos_DAT.entidades;
using JuegoDeTronos_DAT.entidades_adaptadas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeTronos_DAL.manejadores
{
    public class clsInsercciones
    {
        clsMyConnection conexion;
        SqlConnection conection;
        SqlCommand commando;
        public clsInsercciones()
        {

            conexion = new clsMyConnection();
            conection = conexion.getConnection();
        }


        /// <summary>
        /// Procedimiento que insertara la clasificacion de un combate entre dos luchadores en la base de datos
        /// </summary>
        /// <param name="combate"></param>
        /// <param name="contrincante1"></param>
        /// <param name="contrincante2"></param>
        public void insertarClasificacionCombate(clsCombate combate, clsLuchadorClasificado contrincante1, clsLuchadorClasificado contrincante2)
        {

            int num_filas = 0;
            try
            {

                
                commando = conection.CreateCommand();
                commando.CommandText = "INSERT INTO dbo.clasificacionComabate (idCombate,idLuchador,puntos,idCategoriaPremio) VALUES (@idCombate,@idLuchador,@puntos,@idCategoriaPremio)";
                commando.Parameters.Add("@idCombate", System.Data.SqlDbType.Int).Value = combate.id;

                //contrincante1
                commando.Parameters.Add("@idLuchador", System.Data.SqlDbType.Int).Value = contrincante1.id;
                //inserccion sangrientos
                
                
                commando.Parameters.Add("@puntos", System.Data.SqlDbType.Int).Value = contrincante1.sangriento;
                commando.Parameters.Add("@idCategoriaPremio", System.Data.SqlDbType.Int).Value = 1;

                num_filas = commando.ExecuteNonQuery();

                //inserccion espectacular
                commando.Parameters.RemoveAt(3);
                commando.Parameters.RemoveAt(2);
                commando.Parameters.Add("@puntos", System.Data.SqlDbType.Int).Value = contrincante1.espectacular;
                commando.Parameters.Add("@idCategoriaPremio", System.Data.SqlDbType.Int).Value = 2;

                num_filas = commando.ExecuteNonQuery();

                //inserccion victorioso
                commando.Parameters.RemoveAt(3);
                commando.Parameters.RemoveAt(2);

                commando.Parameters.Add("@puntos", System.Data.SqlDbType.Int).Value = contrincante1.vistorioso;
                commando.Parameters.Add("@idCategoriaPremio", System.Data.SqlDbType.Int).Value = 3;

                num_filas = commando.ExecuteNonQuery();
                //fin contrincante 1

                //contrincante2
                commando.Parameters.RemoveAt(3);
                commando.Parameters.RemoveAt(2);
                commando.Parameters.RemoveAt(1);
                
                commando.Parameters.Add("@idLuchador", System.Data.SqlDbType.Int).Value = contrincante2.id;
                //inserccion sangrientos
                
                commando.Parameters.Add("@puntos", System.Data.SqlDbType.Int).Value = contrincante2.sangriento;
                commando.Parameters.Add("@idCategoriaPremio", System.Data.SqlDbType.Int).Value = 1;

                num_filas = commando.ExecuteNonQuery();

                //inserccion espectacular
                commando.Parameters.RemoveAt(3);
                commando.Parameters.RemoveAt(2);
                commando.Parameters.Add("@puntos", System.Data.SqlDbType.Int).Value = contrincante2.espectacular;
                commando.Parameters.Add("@idCategoriaPremio", System.Data.SqlDbType.Int).Value = 2;

                num_filas = commando.ExecuteNonQuery();

                //inserccion victorioso
                commando.Parameters.RemoveAt(3);
                commando.Parameters.RemoveAt(2);
                commando.Parameters.Add("@puntos", System.Data.SqlDbType.Int).Value = contrincante2.vistorioso;
                commando.Parameters.Add("@idCategoriaPremio", System.Data.SqlDbType.Int).Value = 3;

                num_filas = commando.ExecuteNonQuery();
                //fin contrincante 2
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                
                
            }
        }
    }
}
