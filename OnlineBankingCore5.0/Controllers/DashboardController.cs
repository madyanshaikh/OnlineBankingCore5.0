
using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Models;
using OnlineBankingCore5._0.Models;
using System.Linq;

namespace OnlineBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly OnlineBankingContext context;

        public DashboardController(OnlineBankingContext _context)
        {
            context = _context;
        }


        [HttpGet] 
        [Route("getCards")]
        public IActionResult GetDashboardCards()
        {
            var employee=context.Employees.Count();
            var Departs = context.Departments.Count();
            var customer= context.Customers.Count();
            var complaint = context.Complaints.Count();
            var city = context.Cities.Count();
            var qualification = context.Qualifications.Count();
            var branch = context.Branches.Count();

            return Ok(new {employee = employee,department=Departs,customer=customer,
                complaint = complaint,city=city,qualification=qualification,branch = branch});
        }

    }
}
