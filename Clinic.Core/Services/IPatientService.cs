using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services
{
    public interface IPatientService
    {
        public Task<IEnumerable<Patient>> GetPatientsAsync();
        public Task<Patient> GetPatientAsync(int id);
        public Task<Patient> AddPatientAsync(Patient Patient);
        public Task<bool> UpdatePatientAsync(int id, Patient Patient);
        public Task<bool> UpdatePatientStatusAsync(int id, bool status);

    }
}
