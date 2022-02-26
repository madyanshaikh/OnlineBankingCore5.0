using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Models;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineBankingCore5._0.Models;

namespace OnlineBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly OnlineBankingContext context;

        public DepartmentsController(OnlineBankingContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Route("getDepartsEmployee")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDeparts()
        {

            var Hr = await context.Departments.Where<Department>(x => x.Id == 1001).Include(a => a.Employees).ToListAsync();
            var Complaint = await context.Departments.Where<Department>(x => x.Id == 1002).Include(a => a.Employees).ToListAsync();
            var Quality = await context.Departments.Where<Department>(x => x.Id == 1003).Include(a => a.Employees).ToListAsync();
            var Collection = await context.Departments.Where<Department>(x => x.Id == 1004).Include(a => a.Employees).ToListAsync();
            var CreditCard = await context.Departments.Where<Department>(x => x.Id == 1005).Include(a => a.Employees).ToListAsync();
            var Loan = await context.Departments.Where<Department>(x => x.Id == 1006).Include(a => a.Employees).ToListAsync();
            var it = await context.Departments.Where<Department>(x => x.Id == 1007).Include(a => a.Employees).ToListAsync();
            
            return Ok(new {hr=Hr,complaint=Complaint,quality =Quality,Collection = Collection,creditcard=CreditCard,loan=Loan,it = it});

        }

       
    }
}
