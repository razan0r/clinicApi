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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        public PatientController(IPatientService patientService,IMapper mapper)
        {
            _patientService = patientService;
            _mapper=mapper;
        }
        // GET: api/<PatientController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _patientService.GetPatientsAsync();
            var listDto = list.Select(p => _mapper.Map<PatientDto>(p));
            return Ok(listDto);
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            if (await _patientService.GetPatientAsync(id) == null)
                return NotFound();
            var patient =await _patientService.GetPatientAsync(id);
            var patientDto = _mapper.Map<PatientDto>(patient);
            return Ok(patientDto);
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PatientPostModel p)
        {

            var patientToAdd = _mapper.Map<Patient>(p);
            var addpatient = await _patientService.AddPatientAsync(patientToAdd);
            var newpatient =await _patientService.GetPatientAsync(addpatient.Id);
            var patientDto = _mapper.Map<PatientDto>(newpatient);
            return Ok(patientDto);
        }



        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PatientPostModel p)
        {
            var exsistpatient =await _patientService.GetPatientAsync(id);
            if (exsistpatient == null)
                return NotFound();
            _mapper.Map(p, exsistpatient);
            await _patientService.UpdatePatientAsync(id, exsistpatient);
            return Ok(_mapper.Map<PatientDto>(exsistpatient));
        }

        // DELETE api/<PatientController>/5
        [HttpPut("{id}/status")]
        public async Task<ActionResult> Put(int id, bool status)
        {
            var patient =await _patientService.GetPatientAsync(id);

            if (patient == null)
                return NotFound();
            await _patientService.UpdatePatientStatusAsync(id, status);
            return Ok();
        }
    }
}
