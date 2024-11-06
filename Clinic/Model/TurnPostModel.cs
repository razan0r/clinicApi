namespace Clinic.API.Model
{
    public class TurnPostModel
    {
        public DateTime date { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
