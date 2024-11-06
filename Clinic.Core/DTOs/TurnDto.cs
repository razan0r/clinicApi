using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.DTOs
{
    public class TurnDto
    {
        public int turnId { get; set; }
        public DateTime date { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
