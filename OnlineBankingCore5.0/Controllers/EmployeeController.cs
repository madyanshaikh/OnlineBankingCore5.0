
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;
using OnlineBankingCore5._0.Models;

namespace OnlineBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly OnlineBankingContext _context;

        public EmployeeController(UserManager<ApplicationUser> userManager, OnlineBankingContext context)
        {
            this.userManager = userManager;
            _context = context;
        }

        //GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {

            var employee = await _context.Employees.Include(x => x.AspNetUser).ToListAsync();

            return employee;
        }
        [HttpGet]
        [Route("StudentQualification")]
        public IActionResult GetEmployeeQualification()
        {

            var employee = _context.Employees.Include(t => t.Qualification);
            

            return Ok (employee.ToList());
        }
        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id.Equals(id));
        }
        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id == null)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var user = new ApplicationUser()
            {
                UserName = employee.Email,
                Email = employee.Email
                



            };

            var result = await this.userManager.CreateAsync(user, employee.Password);

            string id = user.Id;
          

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
              
                employee.AspNetUserId = id;
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();

            }
            return employee;
        }


        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
       

    }
}
