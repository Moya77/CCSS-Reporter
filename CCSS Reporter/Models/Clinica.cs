namespace CCSS_Reporter.Models
{
    public class Clinica
    {
        private string NombreClinica;
        private string CedulaJuridica;
        private string pais;
        private string provinciaEstado;
        private string distrito;
        private string Telefono;
        private string correo;
        private string direccionWeb;

        public Clinica() { }
        public Clinica(string nombreClinica, string cedulaJuridica, string pais, string provinciaEstado, string distrito, string telefono, string correo, string direccionWeb)
        {
            NombreClinica = nombreClinica;
            CedulaJuridica = cedulaJuridica;
            this.pais = pais;
            this.provinciaEstado = provinciaEstado;
            this.distrito = distrito;
            Telefono = telefono;
            this.correo = correo;
            this.direccionWeb = direccionWeb;
        }

        public string NombreClinica1 { get => NombreClinica; set => NombreClinica = value; }
        public string CedulaJuridica1 { get => CedulaJuridica; set => CedulaJuridica = value; }
        public string Pais { get => pais; set => pais = value; }
        public string ProvinciaEstado { get => provinciaEstado; set => provinciaEstado = value; }
        public string Distrito { get => distrito; set => distrito = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string DireccionWeb { get => direccionWeb; set => direccionWeb = value; }
    }
}
