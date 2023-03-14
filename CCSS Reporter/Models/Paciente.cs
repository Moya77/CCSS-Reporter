using System.IO;

namespace CCSS_Reporter.Models
{
    public class Paciente
    {
        private string identificacion;
        private string nombre;
        private string primerApellido;
        private string segundoApellido;
        private string fechaNacimiento;
        private string genero;
        private string numeroContacto;
        private string pais;
        private string provinciaOestado;
        private string distrito;
        private string dondehabita;
        private string estadoCivil;
        private string correoElectronico;
        private string fechaRegistro;
        private string ocupacion;

        public Paciente() { }

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Genero { get => genero; set => genero = value; }
        public string NumeroContacto { get => numeroContacto; set => numeroContacto = value; }
        public string Pais { get => pais; set => pais = value; }
        public string ProvinciaOestado { get => provinciaOestado; set => provinciaOestado = value; }
        public string Distrito { get => distrito; set => distrito = value; }
        public string EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string Ocupacion { get => ocupacion; set => ocupacion = value; }
        public string Dondehabita { get => dondehabita; set => dondehabita = value; }
    }
}
