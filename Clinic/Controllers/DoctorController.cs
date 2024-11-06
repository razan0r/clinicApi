
using AutoMapper;
using Clinic.API.Model;
using Clinic.Core.DTOs;
using Clinic.Core.Services;
using Clinic.Data;
using Clinic.Entities;
using Clinic.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic.Controllers
{
    [Route("Clinic/[controller]")]
    [ApiController]

    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }
        // GET: api/<DoctorController>
        [HttpGet]
        public async Task< ActionResult> Get()
        {
            var list = await _doctorService.GetDoctorsAsync();
            var listDto = list.Select(d => _mapper.Map<DoctorDto>(d));
            return Ok(listDto); 
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult> Get(int id)
        {
            if (_doctorService.GetDoctorAsync(id) == null)
                return NotFound();
            var doctor = _doctorService.GetDoctorAsync(id);
            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return Ok(doctorDto);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] DoctorPostModel d)
        {
            var doctorToAdd = _mapper.Map<Doctor>(d);
            var addDoctor =await _doctorService.AddDoctorAsync(doctorToAdd);
            var newDoctor =await _doctorService.GetDoctorAsync(addDoctor.Id);
            var doctorDto = _mapper.Map<DoctorDto>(newDoctor);
            return Ok(doctorDto);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public async Task< ActionResult> Put(int id, [FromBody] DoctorPostModel d)
        {
            var exsistDoctor = await _doctorService.GetDoctorAsync(id);
            if (exsistDoctor == null)
                return NotFound();
            _mapper.Map(d, exsistDoctor);
            _doctorService.UpdateDoctorAsync(id, exsistDoctor);
            return Ok(_mapper.Map<DoctorDto>(exsistDoctor));

        }

        // DELETE api/<DoctorController>/5
        [HttpPut("{id}/status")]
        public async Task <ActionResult> Put(int id, bool status)
        {
            var doctor = _doctorService.GetDoctorAsync(id);

            if (doctor == null)
                return NotFound();
            _doctorService.UpdateDoctorStatusAsync(id, status);
            return Ok();
        }
    }
}
