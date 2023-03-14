using CCSS_Reporter.Models;
using NLog;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CCSS_Reporter.DB
{
    public interface ICommandRegClinica
    {
        public void RegistrarClinica(Clinica clinica);
    }
    public class CommandRegClinica : ICommandRegClinica
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        IConfiguration config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
  .Build();

        public CommandRegClinica() { }



        public void RegistrarClinica(Clinica clinica)
        {
            try { 
            using (SqlConnection cn = new SqlConnection(config.GetConnectionString("Conexion")))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("RegClinica", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreClinica", clinica.NombreClinica1);
                    cmd.Parameters.AddWithValue("@CedulaJuridica", clinica.CedulaJuridica1);
                    cmd.Parameters.AddWithValue("@pais", clinica.Pais);
                    cmd.Parameters.AddWithValue("@provinciaEstado", clinica.ProvinciaEstado);
                    cmd.Parameters.AddWithValue("@distrito", clinica.Distrito);
                    cmd.Parameters.AddWithValue("@Telefono", clinica.Telefono1);
                    cmd.Parameters.AddWithValue("@correo", clinica.Correo);
                    cmd.Parameters.AddWithValue("@direccionWeb", clinica.DireccionWeb);
                    cmd.ExecuteNonQuery();
                }
                }

                }catch (Exception ex){
                Logger.Error(ex);
                 }
            }
        }
    }

