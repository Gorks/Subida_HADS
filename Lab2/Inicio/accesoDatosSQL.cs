using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Inicio
{
    public class accesoDatosSQL
    {
        public SqlConnection conexion = new SqlConnection();
        public SqlCommand comando = new SqlCommand();

        public DataSet dataSet = new DataSet("Datos");

        SqlDataAdapter Adaptador_de_asignaturas_alumno;
        SqlDataAdapter Adaptador_genericas;
        SqlDataAdapter Adaptador_tareas_alumno;

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

        public String login(string email, string pass)
        {
            string sql = "Select * From Usuarios where email=@param1 and pass=@param2 and confirmado ='true' ";
       
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@param1", email);
            cmd.Parameters.AddWithValue("@param2", pass);
            System.Diagnostics.Debug.WriteLine("Hay conexion");
            
            SqlDataReader reader = cmd.ExecuteReader();
            
            
            if (reader.HasRows)
            {
                reader.Read();
                String x = reader.GetString(5);
                reader.Close();
                return x;
            }
            else
            {
                reader.Close();
                return "ERROR";
            }
        }


        public DataSet asignaturasAlumno(string email)
        {
            string sql = "select GruposClase.codigoasig from GruposClase, EstudiantesGrupo where EstudiantesGrupo.Grupo=GruposClase.codigo and EstudiantesGrupo.email=@param1";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@param1", email);

            Adaptador_de_asignaturas_alumno = new SqlDataAdapter(cmd);
            Adaptador_de_asignaturas_alumno.Fill(dataSet, "AsigAlum");
            return dataSet;

        }

        public DataView genericasAlumno(string email)
        {
            String sql = "Select codAsig, Codigo,Descripcion,HEstimadas,TipoTarea From TareasGenericas WHERE Explotacion=1 AND Codigo NOT IN (Select CodTarea FROM EstudiantesTareas WHERE Email=@param1)";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@param1", email);
            Adaptador_genericas = new SqlDataAdapter(cmd);

           

            Adaptador_genericas.Fill(dataSet, "tabla_tareas");

            DataTable table = new DataTable();
            table = dataSet.Tables["tabla_tareas"];
            DataView dataview = new DataView(table);
            return dataview;
        }

        public DataTable tareasAlumno(string email)
        {
            String sql = "SELECT Email, CodTarea, HEstimadas, HReales From EstudiantesTareas WHERE Email = @param1";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            System.Diagnostics.Debug.WriteLine(email);
            cmd.Parameters.AddWithValue("@param1", email);
            Adaptador_tareas_alumno = new SqlDataAdapter(cmd);
           
            
            Adaptador_tareas_alumno.Fill(dataSet, "tabla_tareas_alumnos");

            DataTable table = new DataTable();
            table = dataSet.Tables["tabla_tareas_alumnos"];
            
            return table;

        }


        public DataTable instanciar(string email, string tarea, int est, int real, DataTable tabla_actualizar)
        {
            String sql = "insert into EstudiantesTareas values (@param1, @param2, @param3, @param4)";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@param1", email);
            cmd.Parameters.AddWithValue("@param2", tarea);
            cmd.Parameters.AddWithValue("@param3", est);
            cmd.Parameters.AddWithValue("@param4", real);

            //Se crea un adaptador y se mete el comando de insercion

            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.InsertCommand = cmd;

            //Crear una nueva fila en la tabla que se ha recibido(latabla de instanciar tarea)

            DataRow fila_nueva = tabla_actualizar.NewRow();

            fila_nueva["Email"] = email;
            fila_nueva["CodTarea"] = tarea;
            fila_nueva["HEstimadas"] = est;
            fila_nueva["HReales"] = real;


            //Añadir la nueva fila


            tabla_actualizar.Rows.Add(fila_nueva);


            //actualizar la tabla

            adaptador.Update(tabla_actualizar);

            return tabla_actualizar;




        }
    }
}