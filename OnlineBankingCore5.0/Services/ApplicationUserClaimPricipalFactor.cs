using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineBankingCore5._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SymphonyInstitute.Ltd.Services
{
    public class ApplicationUserClaimsPricipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {

        public OnlineBankingContext _context;
        public ApplicationUserClaimsPricipalFactory(UserManager<ApplicationUser> userManager,
             RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options, OnlineBankingContext context) : base(userManager, roleManager, options)
        {
            _context = context;
        }

        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var _user = _context.Employees.FirstOrDefault(x => x.AspNetUserId == user.Id);
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFirstName", _user.FirstName ?? ""));
            identity.AddClaim(new Claim("UserLastName", _user.LastName ?? ""));
            identity.AddClaim(new Claim("UserId", _user.AspNetUserId ?? ""));
            return identity;
        }
    }
}
