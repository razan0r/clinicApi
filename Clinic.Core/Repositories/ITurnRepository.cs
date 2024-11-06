using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Repositories
{
    public interface ITurnRepository
    {
        public Task<IEnumerable<Turn>> GetTurnsAsync();
        public Task<Turn> GetTurnAsync(int id);
        public Task<Turn> AddTurnAsync(Turn turn);
        public Task<bool> UpdateTurnAsync(int id, Turn turn);
        public Task<IEnumerable<Turn>> DeleteAsync(int id);
        

    }
}
