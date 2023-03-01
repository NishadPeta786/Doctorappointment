using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doctorappointment.Models;

namespace Doctorappointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRegistrationsController : ControllerBase
    {
        private readonly NishadoctorDbContext _context;

        public PatientRegistrationsController(NishadoctorDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRegistration>>> GetPatientRegistrations()
        {
            return await _context.PatientRegistrations.ToListAsync();
        }

        // GET: api/PatientRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientRegistration>> GetPatientRegistration(int id)
        {
            var patientRegistration = await _context.PatientRegistrations.FindAsync(id);

            if (patientRegistration == null)
            {
                return NotFound();
            }

            return patientRegistration;
        }

        // PUT: api/PatientRegistrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientRegistration(int id, PatientRegistration patientRegistration)
        {
            if (id != patientRegistration.patient_id)
            {
                return BadRequest();
            }

            _context.Entry(patientRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientRegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PatientRegistrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientRegistration>> PostPatientRegistration(PatientRegistration patientRegistration)
        {
            _context.PatientRegistrations.Add(patientRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientRegistration", new { id = patientRegistration.patient_id }, patientRegistration);
        }

        // DELETE: api/PatientRegistrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientRegistration>> DeletePatientRegistration(int id)
        {
            var patientRegistration = await _context.PatientRegistrations.FindAsync(id);
            if (patientRegistration == null)
            {
                return NotFound();
            }

            _context.PatientRegistrations.Remove(patientRegistration);
            await _context.SaveChangesAsync();

            return patientRegistration;
        }

        private bool PatientRegistrationExists(int id)
        {
            return _context.PatientRegistrations.Any(e => e.patient_id == id);
        }
    }
}
