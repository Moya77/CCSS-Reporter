using CCSS_Reporter.Models;
using NLog;
using System.Data.SqlClient;

namespace CCSS_Reporter.DB
{


    public interface IQueryGetClinica
    {
        public Clinica ObtenerClinica(string identificacion);
    }
    public class QueryGetClinica : IQueryGetClinica
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        IConfiguration config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
  .Build();

        public QueryGetClinica() { }



        public Clinica ObtenerClinica(string identificacion)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(config.GetConnectionString("Conexion")))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetClinica", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Identificacion", identificacion);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Clinica clinica = new();
                                clinica.NombreClinica1 = reader.GetString(0);
                                clinica.CedulaJuridica1 = reader.GetString(1);
                                clinica.Pais = reader.GetString(2);
                                clinica.ProvinciaEstado = reader.GetString(3);
                                clinica.Distrito = reader.GetString(4);
                                clinica.Telefono1 = reader.GetString(5);
                                clinica.Correo = reader.GetString(6);
                                clinica.DireccionWeb = reader.GetString(7);
                                return clinica;
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
