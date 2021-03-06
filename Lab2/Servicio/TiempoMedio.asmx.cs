﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace Servicio
{
    /// <summary>
    /// Descripción breve de TiempoMedio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TiempoMedio : System.Web.Services.WebService
    {

        [WebMethod]
        public double Dedicaciones(string asignatura)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = "Server=tcp:hads18-salaberria.database.windows.net,1433;Initial Catalog=HADS18-Salaberria;Persist Security Info=True;User ID=salaberria@hads18-salaberria;Password=Gorka1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                conexion.Open();
                String sql = "Select AVG(EstudiantesTareas.HReales) as tmedia From EstudiantesTareas, TareasGenericas Where (TareasGenericas.CodAsig = @param1 AND TareasGenericas.Codigo = EstudiantesTareas.CodTarea)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@param1", asignatura);
                double media = Convert.ToDouble(comando.ExecuteScalar());
                conexion.Dispose();
                return media;
            }
            catch (Exception ex)
            {
                return -1;
            }



        }
    }
}
