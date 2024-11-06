using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Repositories;
using Clinic.Data;
using System.Numerics;
using Clinic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataContext _context;
        public DoctorRepository(DataContext context) => _context = context;
        public async Task<IEnumerable<Doctor>> GetDoctorsAsync() => await _context.Doctors.ToListAsync();
        public async Task<Doctor> GetDoctorAsync(int id) => await _context.Doctors.FindAsync(id);

        public async Task<Doctor> AddDoctorAsync(Doctor e) { 
            
            await _context.Doctors.AddAsync(e);
           await _context.SaveChangesAsync();
            return e;
        }

        public async Task<bool> UpdateDoctorAsync(int id, Doctor updateDoctors)
        {
            var e =await _context.Doctors.FindAsync(id);
            if (e != null)
            {
                e.Name = updateDoctors.Name;
                e.Status = updateDoctors.Status;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateDoctorStatusAsync(int id, bool status)
        {
            var doctor = await _context.Doctors.ToListAsync();
            var e = doctor.FirstOrDefault(e => e.Id == id);
            if (e != null)
            {
                e.Status = status;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

       
    }
}
