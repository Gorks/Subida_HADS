using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Inicio
{
    public class accesoDatosSQL
    {
        public SqlConnection conexion = new SqlConnection();
        public SqlCommand comando = new SqlCommand();

        public string conectar()
        {
            try
            {
                conexion.ConnectionString = "Server=tcp:hads18-salaberria.database.windows.net,1433;Initial Catalog=HADS18-Salaberria;Persist Security Info=False;User ID=salaberria@hads18-salaberria;Password=Gorka1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                conexion.Open();
            }
            catch(Exception ex)
            {
                return "ERROR EN LA CONEXION";
            }
            return "CONEXION OK";
        }

        public void cerrar()
        {
            conexion.Close();
        }

        public Boolean registrar(string email, string nombre, string apellido, int numconfir, string tipo, string pass) {
            
            Boolean confirmado = false;
            int codpass = 0;
            string sql2 = "Select email From Usuarios where email=@param1";
            string sql = "INSERT INTO Usuarios(email,nombre,apellidos, numconfir, confirmado, tipo, pass, codpass) VALUES(@param1,@param2,@param3, @param4, @param5, @param6, @param7, @param8)";
            comando = new SqlCommand(sql2, conexion);
            comando.Parameters.AddWithValue("@param1", email);
            SqlDataReader reader = comando.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@param1", email);
                comando.Parameters.AddWithValue("@param2", nombre);
                comando.Parameters.AddWithValue("@param3", apellido);
                comando.Parameters.AddWithValue("@param4", numconfir);
                comando.Parameters.AddWithValue("@param5", confirmado);
                comando.Parameters.AddWithValue("@param6", tipo);
                comando.Parameters.AddWithValue("@param7", pass);
                comando.Parameters.AddWithValue("@param8", codpass);
                System.Diagnostics.Debug.WriteLine(comando.Parameters[1]);
                comando.ExecuteNonQuery();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }

            ;

            


        }

        public Boolean confirmar(string email, int numconfir)
        {
            string sql = "Select email, numconfir From Usuarios where email=@param1 and numconfir=@param2";
            string sql2 = "UPDATE USUARIOS SET confirmado ='true' where email=@param1";
            comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@param1", email);
            comando.Parameters.AddWithValue("@param2", numconfir);
            System.Diagnostics.Debug.WriteLine("Hay conexion");
            SqlDataReader reader = comando.ExecuteReader();
            
            if (reader.HasRows)
            {
                reader.Close();
                comando = new SqlCommand(sql2, conexion);
                comando.Parameters.AddWithValue("@param1", email);
                comando.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean solicitud_cambio(string email, int codpass)
        {
            string sql = "Select email From Usuarios where email=@param1";
            string sql2 = "UPDATE USUARIOS SET codpass = @param2 where email=@param1";
            comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@param1", email);
            System.Diagnostics.Debug.WriteLine("Hay conexion");
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                comando = new SqlCommand(sql2, conexion);
                comando.Parameters.AddWithValue("@param1", email);
                comando.Parameters.AddWithValue("@param2", codpass);
                comando.ExecuteNonQuery();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public Boolean realizar_cambio(string email, int codpass, string pass)
        {
            string sql = "Select email From Usuarios where email=@param1 and codpass=@param2";
            string sql2 = "UPDATE USUARIOS SET pass = @param2 where email=@param1";
            comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@param1", email);
            comando.Parameters.AddWithValue("@param2", codpass);
            System.Diagnostics.Debug.WriteLine("Hay conexion");
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                comando = new SqlCommand(sql2, conexion);
                comando.Parameters.AddWithValue("@param1", email);
                comando.Parameters.AddWithValue("@param2", pass);
                comando.ExecuteNonQuery();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public Boolean login(string email, string pass)
        {
            string sql = "Select email From Usuarios where email=@param1 and pass=@param2 and confirmado ='true' ";
       
            comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@param1", email);
            comando.Parameters.AddWithValue("@param2", pass);
            System.Diagnostics.Debug.WriteLine("Hay conexion");
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }
    }
}