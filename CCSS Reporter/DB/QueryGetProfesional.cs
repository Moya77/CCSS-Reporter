using CCSS_Reporter.Models;
using NLog;
using System.Data.SqlClient;

namespace CCSS_Reporter.DB
{


    public interface IQueryGetProfesional
    {
        public Profesional ObtenerProfesional(string identificacion);
    }
    public class QueryGetProfesional : IQueryGetProfesional
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        IConfiguration config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
  .Build();

        public QueryGetProfesional() { }



        public Profesional ObtenerProfesional(string identificacion)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(config.GetConnectionString("Conexion")))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetProfesional", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", identificacion);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Profesional profesional = new Profesional();
                                profesional.Identificacion1 = reader.GetString(0);
                                profesional.CodigoProfesional1 = reader.GetString(1);
                                profesional.NombreCompleto1 = reader.GetString(2);
                                profesional.Correo = reader.GetString(3);
                                profesional.Pais1 = reader.GetString(4);
                                profesional.Estado1 = reader.GetString(5);
                                profesional.Provincia1 = reader.GetString(6);
                                return profesional;
                            }
                            return new();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new();
            }
        }

    }
}
