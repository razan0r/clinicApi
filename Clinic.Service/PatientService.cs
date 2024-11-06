using Clinic.Core.Repositories;
using Clinic.Core.Services;
using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Service
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepositpry _patientRepositpry;
        public PatientService(IPatientRepositpry PatientRepositpry) => _patientRepositpry = PatientRepositpry;

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _patientRepositpry.GetPatientsAsync();
        }
       
        public async Task<Patient> GetPatientAsync(int id)
        {
            return await _patientRepositpry.GetPatientAsync(id);
        }
        public async Task<Patient> AddPatientAsync(Patient e)
        {
           await _patientRepositpry.AddPatientAsync(e);
            return e;
        }
        public async Task<bool> UpdatePatientAsync(int id, Patient e)
        {
            return await _patientRepositpry.UpdatePatientAsync(id, e);

        }

        public async Task<bool> UpdatePatientStatusAsync(int id, bool status)
        {
           return await _patientRepositpry.UpdatePatientStatusAsync(id,status);
        }




    }
}
