using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Conexion
    {
        public MySqlConnection conexion()
        {
            string servidor = "localhost";
            string bd = "tp2laboratorio4";
            string usuario = "root";
            string password = "root";

            string cadenaConexion = "Database=" + bd + "; Data Source=" +
                servidor + "; User Id= " + usuario + "; Password=" +
                password + "";

            try
            {
                MySqlConnection ConexionBD = new MySqlConnection(cadenaConexion);

                return ConexionBD;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Message);

                return null;
            }
        }
    }
}
