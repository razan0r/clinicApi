using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface IDoctorRepository
    {
        public  Task<IEnumerable<Doctor>> GetDoctorsAsync();
        public Task<Doctor> GetDoctorAsync(int id);
        public Task<Doctor> AddDoctorAsync(Doctor doctor);
        public Task<bool> UpdateDoctorAsync(int id,Doctor doctor);
        public Task<bool> UpdateDoctorStatusAsync(int id,bool status);
        
    }
}
