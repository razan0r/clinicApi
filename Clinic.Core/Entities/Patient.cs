namespace Clinic.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Turn> turns { get; set; }

    }
}
