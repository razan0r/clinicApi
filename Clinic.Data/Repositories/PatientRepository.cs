using Clinic.Core.Repositories;
using Clinic.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Data.Repositories
{
    public class PatientRepository:IPatientRepositpry
    {
        private readonly DataContext _context;
        public PatientRepository(DataContext context) => _context = context;
        public async Task<IEnumerable<Patient>> GetPatientsAsync() =>await _context.Patients.ToListAsync();
         public async Task<Patient> GetPatientAsync(int id) => await _context.Patients.FirstAsync(e => e.Id == id);

        public async Task<Patient> AddPatientAsync(Patient e) { 
           await _context.Patients.AddAsync(e); 
           await _context.SaveChangesAsync();
            return e;
        }

        public async Task<bool> UpdatePatientAsync(int id, Patient updatePatients)
        {

            var e = await _context.Patients.FindAsync( id);
            if (e != null)
            {
                e.Name = updatePatients.Name;
                e.Status = updatePatients.Status;
               await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePatientStatusAsync(int id, bool status)
        {
            var patient = await _context.Patients.ToListAsync();
            var e = patient.FirstOrDefault(e => e.Id == id);
            if (e != null)
            {
                e.Status = status;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}

