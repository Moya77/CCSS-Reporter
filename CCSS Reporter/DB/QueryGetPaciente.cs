using CCSS_Reporter.Models;
using NLog;
using System.Data.SqlClient;

namespace CCSS_Reporter.DB
{


    public interface IQueryGetPaciente
    {
        public Paciente ObtenerPaciente(string identificacion);
    }
    public class QueryGetPaciente : IQueryGetPaciente
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        IConfiguration config = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
  .Build();

        public QueryGetPaciente() { }



        public Paciente ObtenerPaciente(string identificacion)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(config.GetConnectionString("Conexion")))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetPaciente", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@identificacion", identificacion);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Paciente paciente = new();
                                paciente.Identificacion = identificacion;
                                paciente.Nombre = reader.GetString(1);
                                paciente.PrimerApellido = reader.GetString(2);
                                paciente.SegundoApellido = reader.GetString(3);
                                paciente.FechaNacimiento = reader.GetString(4);
                                paciente.Genero = reader.GetString(5);
                                paciente.NumeroContacto = reader.GetString(6);
                                paciente.Pais = reader.GetString(7);
                                paciente.ProvinciaOestado = reader.GetString(8);
                                paciente.Distrito = reader.GetString(9);
                                paciente.Dondehabita = reader.GetString(10);
                                paciente.EstadoCivil = reader.GetString(11);
                                paciente.CorreoElectronico = reader.GetString(12);
                                paciente.FechaRegistro = reader.GetString(13);
                                paciente.Ocupacion = reader.GetString(14);

                                return paciente;
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
