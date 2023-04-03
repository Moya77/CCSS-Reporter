using CCSS_Reporter.Models;
using NLog;
using System.Data.SqlClient;

namespace CCSS_Reporter.DB
{
    public interface ICommandRegInyeccion
    {
        public void RegistrarInyeccion(Inyeccion inyeccion);
    }
    public class CommandRegInyeccion : ICommandRegInyeccion
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        IConfiguration config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
  .Build();

        public CommandRegInyeccion() { }



        public void RegistrarInyeccion(Inyeccion inyeccion)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(config.GetConnectionString("Conexion")))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("RegInyeccionPaciente", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_paciente", inyeccion.Id_paciente);
                        cmd.Parameters.AddWithValue("@VacunaSaramRubParoti", inyeccion.VacunaSaramRubParoti1);
                        cmd.Parameters.AddWithValue("@VacunaTetHepAoBInfl", inyeccion.VacunaTetHepAoBInfl1);
                        cmd.Parameters.AddWithValue("@CantCovid", inyeccion.CantCovid1);
                        cmd.Parameters.AddWithValue("@CovidComent", inyeccion.CovidComent1);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}

