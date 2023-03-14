using System.ComponentModel.DataAnnotations;

namespace CCSS_Reporter.Models
{
    public class Profesional
    {
        private string Identificacion;
        private string CodigoProfesional;
        private string NombreCompleto;
        private string correo;
        private string Pais;
        private string Estado;
        private string Provincia;

        public Profesional() { }
        public Profesional(string identificacion, string codigoProfesional, string nombreCompleto, string correo, string pais, string estado, string provincia)
        {
            Identificacion = identificacion;
            CodigoProfesional = codigoProfesional;
            NombreCompleto = nombreCompleto;
            this.correo = correo;
            Pais = pais;
            Estado = estado;
            Provincia = provincia;
        }

        public string Identificacion1 { get => Identificacion; set => Identificacion = value; }
        public string CodigoProfesional1 { get => CodigoProfesional; set => CodigoProfesional = value; }
        public string NombreCompleto1 { get => NombreCompleto; set => NombreCompleto = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Pais1 { get => Pais; set => Pais = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string Provincia1 { get => Provincia; set => Provincia = value; }
    }
}
