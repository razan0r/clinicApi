using AutoMapper;
using Clinic.API.Model;
using Clinic.Core.DTOs;
using Clinic.Core.Services;
using Clinic.Data;
using Clinic.Entities;
using Clinic.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic.Controllers
{
    [Route("Clinic/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private readonly ITurnService _turnService;
        private readonly IMapper _mapper;

        public TurnController(ITurnService turnService, IMapper mapper)
        {
            _turnService = turnService;
            _mapper = mapper;

        }
        // GET: api/<TurnController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _turnService.GetTurnsAsync();
            var listDto = list.Select(p => _mapper.Map<TurnDto>(p));
            return Ok(listDto);
        }

        // GET api/<TurnController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (await _turnService.GetTurnAsync(id) == null)
                return NotFound();
            var turn = await _turnService.GetTurnAsync(id);
            var turnDto = _mapper.Map<TurnDto>(turn);
            return Ok(turnDto);
        }

        // POST api/<TurnController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TurnPostModel t)
        {
            var turnToAdd = _mapper.Map<Turn>(t);
            var addturn = await _turnService.AddTurnAsync(turnToAdd);
            var newturn = await _turnService.GetTurnAsync(addturn.turnId);
            var turnDto = _mapper.Map<TurnDto>(newturn);
            return Ok(turnDto);
        }

        // PUT api/<TurnController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TurnPostModel t)
        {

            var exsistturn = await _turnService.GetTurnAsync(id);
            if (exsistturn == null)
                return NotFound();
            _mapper.Map(t, exsistturn);
            if (await _turnService.UpdateTurnAsync(id, exsistturn))
                return Ok(_mapper.Map<TurnDto>(exsistturn));
            return BadRequest("There is no Doctor/Patient with this id!");
        }

        // DELETE api/<TurnController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var turn = await _turnService.GetTurnAsync(id);

            if (turn == null)
                return NotFound();
            return Ok(await _turnService.DeleteAsync(id));


        }
    }
}
