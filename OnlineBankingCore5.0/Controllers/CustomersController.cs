#nullable disable
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
    public class CustomersController : ControllerBase
    {
        private readonly OnlineBankingContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public CustomersController(OnlineBankingContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomers(int id)
        {
            var Customers = await _context.Customers.FindAsync(id);

            if (Customers == null)
            {
                return NotFound();
            }

            return Customers;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]

        public async Task<IActionResult> PutCustomers(int id, Customer Customers)
        {
            if (id != Customers.Id)
            {
                return BadRequest();
            }

            _context.Entry(Customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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




        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            var Customers = await _context.Customers.FindAsync(id);
            if (Customers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(Customers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        //// POST: api/Customers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomers(Customer Customers)

        {

            var user = new ApplicationUser()
            {
                Email = Customers.Emails,
                UserName = Customers.Emails
            };

            var result = await userManager.CreateAsync(user, Customers.Password);

            string id = user.Id;
            if (!result.Succeeded)
            {

                return NotFound();
            }
            else
            {

                Customers.AspNetUserId = id;
                _context.Customers.Add(Customers);
                await _context.SaveChangesAsync();

            }



            return CreatedAtAction("GetCustomers", new { id = Customers.Id }, Customers);
        }

        [HttpGet]
        [Route("getLast10")]
        public IEnumerable<ViewCustomerTop> GetLastCustomers()
        {

            var getTen = _context.ViewCustomerTops.FromSqlRaw("select * from ViewCustomerTop").ToList().Take(10);

            return getTen;

        }
    }
}
