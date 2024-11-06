namespace Clinic.Entities
{
    public class Turn
    {
        public int turnId { get; set; }
        public DateTime date { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
