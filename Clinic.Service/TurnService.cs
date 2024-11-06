using Clinic.Core.Repositories;
using Clinic.Core.Services;
using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clinic.Service.TurnService;

namespace Clinic.Service
{


    public class TurnService : ITurnService
    {
        private readonly ITurnRepository _turnRepository;
        public TurnService(ITurnRepository TurnRepository)
        {
            _turnRepository = TurnRepository;

        }

        public async Task<IEnumerable<Turn>> GetTurnsAsync()
        {
            return await _turnRepository.GetTurnsAsync();
        }
        public async Task<Turn> GetTurnAsync(int id)
        {
            return await _turnRepository.GetTurnAsync(id);
        }
        public async Task<Turn> AddTurnAsync(Turn e)
        {
           await _turnRepository.AddTurnAsync(e);
            return e;

        }
        public async Task<bool> UpdateTurnAsync(int id, Turn e)
        {
            return await _turnRepository.UpdateTurnAsync(id, e);

        }

        public async Task<IEnumerable<Turn>> DeleteAsync(int id)
        {
             return await _turnRepository.DeleteAsync(id);

        }



    }

}
