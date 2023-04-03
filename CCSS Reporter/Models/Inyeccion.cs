namespace CCSS_Reporter.Models
{
    public class Inyeccion
    {
        string id_paciente = "";
        bool VacunaSaramRubParoti = false;
        bool VacunaTetHepAoBInfl = false;
        int CantCovid = 0;
        string CovidComent = "";

        public Inyeccion() { }

        public bool VacunaSaramRubParoti1 { get => VacunaSaramRubParoti; set => VacunaSaramRubParoti = value; }
        public bool VacunaTetHepAoBInfl1 { get => VacunaTetHepAoBInfl; set => VacunaTetHepAoBInfl = value; }
        public int CantCovid1 { get => CantCovid; set => CantCovid = value; }
        public string CovidComent1 { get => CovidComent; set => CovidComent = value; }
        public string Id_paciente { get => id_paciente; set => id_paciente = value; }
    }
}
