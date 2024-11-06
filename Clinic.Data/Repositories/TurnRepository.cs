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
    public class TurnRepository : ITurnRepository
    {
        private readonly DataContext _context;
        public TurnRepository(DataContext context) => _context = context;
        public async Task<IEnumerable<Turn>> GetTurnsAsync() => await _context.Turns.Include(t => t.Patient).Include(t => t.Doctor).ToListAsync();
        public async Task<Turn> GetTurnAsync(int code) => await _context.Turns.FirstAsync(e => e.turnId == code);

        public async Task<Turn> AddTurnAsync(Turn e)
        {
            if (_context.Doctors.Any(d => d.Id == e.DoctorId) && _context.Patients.Any(p => p.Id == e.PatientId))
            {
                await _context.Turns.AddAsync(e);
                await _context.SaveChangesAsync();
            }

            return e;
        }

        public async Task<bool> UpdateTurnAsync(int code, Turn updateTurns)
        {
            if (_context.Doctors.Any(d => d.Id == updateTurns.DoctorId) && _context.Patients.Any(p => p.Id == updateTurns.PatientId))
            {
                var e = await _context.Turns.FindAsync(code);
                if (e != null)
                {
                    e.date = updateTurns.date;
                    e.DoctorId = updateTurns.DoctorId;
                    e.PatientId = updateTurns.PatientId;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;

        }

        public async Task<IEnumerable<Turn>> DeleteAsync(int id)
        {
            var turnToDelete = _context.Turns.FirstOrDefault(x => x.turnId == id);

            if (turnToDelete != null)
            {
                _context.Turns.Remove(turnToDelete);
                await _context.SaveChangesAsync();
            }
            return _context.Turns;
        }

    }
}
