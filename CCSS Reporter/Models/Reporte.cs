namespace CCSS_Reporter.Models
{
    public class Reporte
    {
        public Paciente Paciente { get; set; } = new Paciente();

        public Profesional Profesional { get; set; } = new Profesional();

        public DateTime fechaAtencion { get; set; } = DateTime.Now;


    }
}
