namespace CCSS_Reporter.Models
{
    public class SintomasPaciente
    {
        private string Id_paciente;
        private string MotivoConsulta;
        private string Sintomas;
        private List<string> Alergias = new();
        private List<string> alergiasSeleccionadas = new();
        private List<string> Enfermedades = new();
        private List<string> enfermedadesSeleccionadas = new();
        private string OtrasCondiciones;
        private string ReapacicionOnuevoCancer;
        private List<string> OtrosSintomas = new();
        private List<string> otrosSintomasSeleccionadas = new();

        public SintomasPaciente()
        {
            Alergias.Add("Medicamentos");
            Alergias.Add("Polietilenglicol");
            Alergias.Add("Medio ambiente");
            Alergias.Add("Otros");

            Enfermedades.Add("Enfermedad de Addison");
            Enfermedades.Add("Alergias");
            Enfermedades.Add("Arritmias");
            Enfermedades.Add("Fibrilación auricular");
            Enfermedades.Add("Vasculitis autoinmune");
            Enfermedades.Add("Parálisis de Bell (parálisis facial)");
            Enfermedades.Add("Bronquitis");
            Enfermedades.Add("Cáncer");
            Enfermedades.Add("Enfermedad celíaca (intolerancia al gluten)");
            Enfermedades.Add("Enfermedad renal crónica");
            Enfermedades.Add("Insuficiencia cardíaca congestiva");
            Enfermedades.Add("Enfermedad de Crohn");
            Enfermedades.Add("TVP (coágulos de sangre)");
            Enfermedades.Add("Diabetes");
            Enfermedades.Add("Encefalitis (inflamación cerebral/dolores de cabeza)");
            Enfermedades.Add("Epilepsia (convulsiones)");
            Enfermedades.Add("Enfermedades del corazón");
            Enfermedades.Add("Herpes tipo 1");
            Enfermedades.Add("Herpes tipo 2");
            Enfermedades.Add("VIH");
            Enfermedades.Add("Hipertensión (presión arterial alta)");
            Enfermedades.Add("Enfermedad inflamatoria intestinal");
            Enfermedades.Add("Enfermedad renal aguda");
            Enfermedades.Add("Enfermedad hepática");
            Enfermedades.Add("Lupus");
            Enfermedades.Add("Aborto espontáneo");
            Enfermedades.Add("Esclerosis múltiple");
            Enfermedades.Add("Miastenia gravis");
            Enfermedades.Add("Infarto de miocardio (ataque al corazón)");
            Enfermedades.Add("Miocarditis");
            Enfermedades.Add("Osteoartritis");
            Enfermedades.Add("Pericarditis");
            Enfermedades.Add("Anemia perniciosa");
            Enfermedades.Add("Neumonía");
            Enfermedades.Add("Parto prematuro");
            Enfermedades.Add("Psoriasis");
            Enfermedades.Add("Artritis psoriásica");
            Enfermedades.Add("Embolia pulmonar");
            Enfermedades.Add("Artritis reumatoide");
            Enfermedades.Add("Herpes zóster");
            Enfermedades.Add("Síndrome de Sjogren");
            Enfermedades.Add("Nacimiento sin vida");
            Enfermedades.Add("Accidente cerebrovascular");
            Enfermedades.Add("Ataques isquémicos transitorios (AIT)");
            Enfermedades.Add("Trastorno de la tiroides");
            Enfermedades.Add("Colitis ulcerosa");

            OtrosSintomas1.Add("Síntomas de COVID o Enfermedad de COVID");
            OtrosSintomas1.Add("Disminución del bienestar");
            OtrosSintomas1.Add("Disminución del estado de salud");
            OtrosSintomas1.Add("Fatiga extrema");
            OtrosSintomas1.Add("Incapacidad para participar en actividades rutinarias");
            OtrosSintomas1.Add("Pérdida de energía");
            OtrosSintomas1.Add("Dolor inexplicable");
            OtrosSintomas1.Add("Debilidad");
            OtrosSintomas1.Add("Fiebre inexplicable");
            OtrosSintomas1.Add("Sensaciones corporales inexplicables");
            OtrosSintomas1.Add("Sudores nocturnos");
            OtrosSintomas1.Add("Sofocos");
            OtrosSintomas1.Add("Intolerancia al frío");
            OtrosSintomas1.Add("Intolerancia al calor");
            OtrosSintomas1.Add("Sensibilidad a los cambios de temperatura");
            OtrosSintomas1.Add("Cambio en la capacidad de caminar");
            OtrosSintomas1.Add("Cambio en el pensamiento");
            OtrosSintomas1.Add("Ya no me siento como antes");
            OtrosSintomas1.Add("Aumento de peso inexplicable");
            OtrosSintomas1.Add("Pérdida de peso inexplicable");
            OtrosSintomas1.Add("Sueño fragmentado");
            OtrosSintomas1.Add("No puedo dormir");
            OtrosSintomas1.Add("Insomnio");



        }

        public string Id_paciente1 { get => Id_paciente; set => Id_paciente = value; }
        public string MotivoConsulta1 { get => MotivoConsulta; set => MotivoConsulta = value; }
        public string Sintomas1 { get => Sintomas; set => Sintomas = value; }
        public List<string> Alergias1 { get => Alergias; set => Alergias = value; }
        public List<string> Enfermedades1 { get => Enfermedades; set => Enfermedades = value; }
        public string OtrasCondiciones1 { get => OtrasCondiciones; set => OtrasCondiciones = value; }
        public string ReapacicionOnuevoCancer1 { get => ReapacicionOnuevoCancer; set => ReapacicionOnuevoCancer = value; }
        public List<string> OtrosSintomas1 { get => OtrosSintomas; set => OtrosSintomas = value; }
        public List<string> OtrosSintomasSeleccionadas { get => otrosSintomasSeleccionadas; set => otrosSintomasSeleccionadas = value; }
        public List<string> EnfermedadesSeleccionadas { get => enfermedadesSeleccionadas; set => enfermedadesSeleccionadas = value; }
        public List<string> AlergiasSeleccionadas { get => alergiasSeleccionadas; set => alergiasSeleccionadas = value; }
    }
}
