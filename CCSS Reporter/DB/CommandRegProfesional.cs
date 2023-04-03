using CCSS_Reporter.Models;
using NLog;
using System.Data.SqlClient;

namespace CCSS_Reporter.DB
{
    public interface ICommandRegProfesional
    {
        public string RegistrarProfesional(Profesional profesional);
    }
    public class CommandRegProfesional : ICommandRegProfesional
    {
        IConfiguration config = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
       .Build();


        public CommandRegProfesional() { }
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        public string RegistrarProfesional(Profesional profesional)
        {
            try
            {

                using (SqlConnection cn = new SqlConnection(config.GetConnectionString("Conexion")))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("RegProfesional", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", profesional.Identificacion1);
                        cmd.Parameters.AddWithValue("@Codigo_profesional", profesional.CodigoProfesional1);
                        cmd.Parameters.AddWithValue("@Nombre_completo", profesional.NombreCompleto1);
                        cmd.Parameters.AddWithValue("@Correo", profesional.Correo);
                        cmd.Parameters.AddWithValue("@Pais", profesional.Pais1);
                        cmd.Parameters.AddWithValue("@Estado", profesional.Estado1);
                        cmd.Parameters.AddWithValue("@Provincia", profesional.Provincia1);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader.GetString(0);
                            }
                        }
                    }
                }
                return "";
            }
            catch (SqlException ex)
            {
                Logger.Error(ex.ToString());
                return "";
            }
        }
    }
}
