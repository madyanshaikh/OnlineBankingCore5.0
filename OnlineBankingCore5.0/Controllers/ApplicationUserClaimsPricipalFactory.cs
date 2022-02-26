
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using OnlineBanking.Models;
//using System.Security.Claims;

//namespace OnlineBanking.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ApplicationUserClaimsPricipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
//    {
//        private ApplicationDbContext _context;

//        public ApplicationUserClaimsPricipalFactory(UserManager<ApplicationUser> userManager,
//             RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options, ApplicationDbContext context) : base(userManager, roleManager, options)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        [Route("GetClaims")]
//        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
//        {
//            var _user = _context.Employees.FirstOrDefault(x => x.AspNetUserId == user.Id);
//            var identity = await base.GenerateClaimsAsync(user);
//            identity.AddClaim(new Claim("UserFirstName", _user.FirstName ?? ""));
//            identity.AddClaim(new Claim("UserLastName", _user.LastName ?? ""));
//            identity.AddClaim(new Claim("UserId", _user.AspNetUserId ?? ""));
//            return identity;
//        }
//    }

//}
