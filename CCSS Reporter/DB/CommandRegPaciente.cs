using CCSS_Reporter.Models;
using NLog;
using System.Data.SqlClient;

namespace CCSS_Reporter.DB
{
    public interface ICommandRegPaciente
    {
        public void RegistrarPaciente(Paciente paciente);
    }
    public class CommandRegPaciente : ICommandRegPaciente
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        IConfiguration config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
  .Build();

        public CommandRegPaciente() { }



        public void RegistrarPaciente(Paciente paciente)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(config.GetConnectionString("Conexion")))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("RegPaciente", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@identificacion", paciente.Identificacion);
                        cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                        cmd.Parameters.AddWithValue("@primerApellido", paciente.PrimerApellido);
                        cmd.Parameters.AddWithValue("@segundoApellido", paciente.SegundoApellido);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@genero", paciente.Genero);
                        cmd.Parameters.AddWithValue("@numeroContacto", paciente.NumeroContacto);
                        cmd.Parameters.AddWithValue("@pais", paciente.Pais);
                        cmd.Parameters.AddWithValue("@provinciaOestado", paciente.ProvinciaOestado);
                        cmd.Parameters.AddWithValue("@distrito", paciente.Distrito);
                        cmd.Parameters.AddWithValue("@dondehabita", paciente.Dondehabita);
                        cmd.Parameters.AddWithValue("@estadoCivil", paciente.EstadoCivil);
                        cmd.Parameters.AddWithValue("@correoElectronico", paciente.CorreoElectronico);
                        cmd.Parameters.AddWithValue("@fechaRegistro", paciente.FechaRegistro);
                        cmd.Parameters.AddWithValue("@ocupacion", paciente.Ocupacion);
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

