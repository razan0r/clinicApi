using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface IPatientRepositpry
    {
        public Task<IEnumerable<Patient>> GetPatientsAsync();
        public Task<Patient> GetPatientAsync(int id);
        public Task<Patient> AddPatientAsync(Patient patient);
        public Task<bool> UpdatePatientAsync(int id, Patient patient);
        public Task<bool > UpdatePatientStatusAsync(int id, bool status);
    }
}
