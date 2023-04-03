using CCSS_Reporter.Models;
using NLog;
using System.Data.SqlClient;

namespace CCSS_Reporter.DB
{
    public interface ICommandRegSintomasPaciente
    {
        public void RegistrarSintomasPaciente(SintomasPaciente sintomas);
    }
    public class CommandRegSintomasPaciente : ICommandRegSintomasPaciente
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        IConfiguration config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
  .Build();

        public CommandRegSintomasPaciente() { }



        public void RegistrarSintomasPaciente(SintomasPaciente sintomas)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(config.GetConnectionString("Conexion")))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("RegSintomasPaciente", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_paciente", sintomas.Id_paciente1);
                        cmd.Parameters.AddWithValue("@MotivoConsulta", sintomas.MotivoConsulta1);
                        cmd.Parameters.AddWithValue("@Sintomas", sintomas.Sintomas1);
                        cmd.Parameters.AddWithValue("@OtrasCondiciones", sintomas.OtrasCondiciones1);
                        cmd.Parameters.AddWithValue("@ReapacicionOnuevoCancer", sintomas.ReapacicionOnuevoCancer1);
                        cmd.ExecuteNonQuery();
                    }
                    foreach (string alergia in sintomas.AlergiasSeleccionadas)
                    {
                        using (SqlCommand cmd = new SqlCommand("RegAlergiaPaciente", cn))
                        {

                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_paciente", sintomas.Id_paciente1);
                            cmd.Parameters.AddWithValue("@alergia", alergia);
                            cmd.ExecuteNonQuery();

                        }
                    }

                    foreach (string enfermedad in sintomas.EnfermedadesSeleccionadas)
                    {
                        using (SqlCommand cmd = new SqlCommand("RegEnfermedadPaciente", cn))
                        {

                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_paciente", sintomas.Id_paciente1);
                            cmd.Parameters.AddWithValue("@enfermedad", enfermedad);
                            cmd.ExecuteNonQuery();

                        }
                    }

                    foreach (string OtrosSintomas in sintomas.OtrosSintomasSeleccionadas)
                    {
                        using (SqlCommand cmd = new SqlCommand("RegOtrosSintomasPaciente", cn))
                        {

                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_paciente", sintomas.Id_paciente1);
                            cmd.Parameters.AddWithValue("@sintoma", OtrosSintomas);
                            cmd.ExecuteNonQuery();

                        }
                    }
                    cn.Close();

                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}

