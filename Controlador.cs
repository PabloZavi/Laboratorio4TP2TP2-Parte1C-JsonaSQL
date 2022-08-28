using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Controlador : Conexion
    {
        public bool existePais(int codigoPais)
        {
            bool existe = false;

            try
            {
                MySqlDataReader reader;
                String sql = "Select * from tp2laboratorio4.pais WHERE codigoPais=" + codigoPais + ";";

                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                if (reader.Read()) existe = true;
                else existe = false;

                conexionBD.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }


            return existe;
        }

        public void actualizarPais(long codigoPais, string nombrePais, string capitalPais, string regionPais, long poblacion, double latitud, double longitud)
        {
            try
            {
                //MySqlDataReader reader;
                //String sql = "Select * from tp2laboratorio4.pais WHERE codigoPais='" + nombrePais + "'";
                //String sql = "UPDATE tp2laboratorio4.pais SET nombrePais = '" + nombrePais +
                //    "', capitalPais = '" + capitalPais +
                //    "', region = '" + regionPais +
                //    "', poblacion = " + poblacion +
                //    ", latitud = " + latitud +
                //    ", longitud = " + longitud +
                //    " WHERE codigoPais = " + codigoPais + ";";

                //Con el método anterior, cuando las latitudes y/o longitudes tenían decimales, se convertían los puntos en comas
                //al hacer el update a sql y por ende no se podía realizar, por lo que para evitar estos inconvenientes
                //lo mejor es parametrizar de la siguiente forma

                String sql = "UPDATE tp2laboratorio4.pais SET nombrePais = @nombre, capitalPais = @capital," +
                    " region = @region, poblacion = @poblacion, latitud = @latitud, longitud = @longitud " +
                    "WHERE codigoPais = @codigo;";

                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);

                MySqlParameter parCodigo = comando.Parameters.Add("@codigo", MySqlDbType.Int32);
                MySqlParameter parNombre = comando.Parameters.Add("@nombre", MySqlDbType.String);
                MySqlParameter parCapital = comando.Parameters.Add("@capital", MySqlDbType.String);
                MySqlParameter parRegion = comando.Parameters.Add("@region", MySqlDbType.String);
                MySqlParameter parPoblacion = comando.Parameters.Add("@poblacion", MySqlDbType.Int32);
                MySqlParameter parLatitud = comando.Parameters.Add("@latitud", MySqlDbType.Double);
                MySqlParameter parLongitud = comando.Parameters.Add("@longitud", MySqlDbType.Double);
                parCodigo.Value = codigoPais;
                parNombre.Value = nombrePais;
                parCapital.Value = capitalPais;
                parRegion.Value = regionPais;
                parPoblacion.Value = poblacion;
                parLatitud.Value = latitud;
                parLongitud.Value = longitud;

                comando.ExecuteNonQuery();

                conexionBD.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void insertarPais(int codigoPais, string nombrePais, string capitalPais, string regionPais, long poblacion, double latitud, double longitud)
        {
            try
            {
                //MySqlDataReader reader;
                //String sql = "Select * from tp2laboratorio4.pais WHERE codigoPais='" + nombrePais + "'";
                //String sql = "insert into tp2laboratorio4.pais(codigoPais, nombrePais, capitalPais, region, poblacion, latitud, longitud) values ("
                //    + codigoPais + ","
                //    + "'" + nombrePais + "',"
                //    + "'" + capitalPais + "',"
                //    + "'" + regionPais + "',"
                //    + poblacion + ","
                //    + latitud + ","
                //    + longitud + ");";

                //Con el método anterior, cuando las latitudes y/o longitudes tenían decimales, se convertían los puntos en comas
                //al hacer el update a sql y por ende no se podía realizar, por lo que para evitar estos inconvenientes
                //lo mejor es parametrizar de la siguiente forma

                String sql = "insert into tp2laboratorio4.pais(codigoPais, nombrePais, capitalPais, region, poblacion, latitud, longitud) " +
                    "values (@codigo, @nombre, @capital, @region, @poblacion, @latitud, @longitud);";
                    
                MySqlConnection conexionBD = base.conexion();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlParameter parCodigo = comando.Parameters.Add("@codigo", MySqlDbType.Int32);
                MySqlParameter parNombre = comando.Parameters.Add("@nombre", MySqlDbType.String);
                MySqlParameter parCapital = comando.Parameters.Add("@capital", MySqlDbType.String);
                MySqlParameter parRegion = comando.Parameters.Add("@region", MySqlDbType.String);
                MySqlParameter parPoblacion = comando.Parameters.Add("@poblacion", MySqlDbType.Int32);
                MySqlParameter parLatitud = comando.Parameters.Add("@latitud", MySqlDbType.Double);
                MySqlParameter parLongitud = comando.Parameters.Add("@longitud", MySqlDbType.Double);
                parCodigo.Value = codigoPais;
                parNombre.Value = nombrePais;
                parCapital.Value = capitalPais;
                parRegion.Value = regionPais;
                parPoblacion.Value = poblacion;
                parLatitud.Value = latitud;
                parLongitud.Value = longitud;
                comando.ExecuteNonQuery();

                conexionBD.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }



    }
}
