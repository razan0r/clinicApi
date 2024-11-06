
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic;
using Clinic.Core.Repositories;
using Clinic.Core.Services;
using Clinic.Entities;

namespace Clinic.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _doctorRepository.GetDoctorsAsync();
        }
        public async Task<Doctor> GetDoctorAsync(int id)
        {
            return await _doctorRepository.GetDoctorAsync(id);
        }

        public async Task<Doctor> AddDoctorAsync(Doctor e)
        {
           await _doctorRepository.AddDoctorAsync(e);
            return e;

        }
        public async Task<bool> UpdateDoctorAsync(int id, Doctor e)
        {
            return await _doctorRepository.UpdateDoctorAsync(id, e);

        }

        public async Task<bool > UpdateDoctorStatusAsync(int id, bool status)
        {
            return await _doctorRepository.UpdateDoctorStatusAsync(id, status);

        }




    }
}
