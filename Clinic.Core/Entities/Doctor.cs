namespace Clinic.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Patient> patients { get; set; }
        public List<Turn> turns { get; set; }


    }
}
