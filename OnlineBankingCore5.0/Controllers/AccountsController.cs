using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBankingCore5._0.Models;


namespace OnlineBankingCore5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly OnlineBankingContext context;

        public AccountsController(UserManager<ApplicationUser> userManager , OnlineBankingContext _context)
        {
            _userManager = userManager;
            context = _context;
        }


        [HttpGet]
        [Route("getAccounts")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAcccounts()
        {
                var acc =  context.Customers.Include(x=>x.Account).ToList();

            return Ok(acc);
        }
       
 
    }
}