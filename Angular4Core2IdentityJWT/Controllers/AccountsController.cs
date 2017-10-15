using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Angular4Core2IdentityJWT.ViewModels;
using Angular4Core2IdentityJWT.Models.Entities;
using Angular4Core2IdentityJWT.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Angular4Core2IdentityJWT.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ExtendedIdentityDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public AccountsController(UserManager<AppUser> _userManager, IMapper _mapper, ExtendedIdentityDbContext _context)
        {
            userManager = _userManager;
            mapper = _mapper;
            context = _context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = mapper.Map<AppUser>(model);
            var result = await userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded)
            {
                foreach (var e in result.Errors)
                {
                    ModelState.TryAddModelError(e.Code, e.Description);
                }
                return new BadRequestObjectResult(ModelState);
            }

            await context.OtherUsers.AddAsync(new OtherUser { IdentityId = userIdentity.Id, Location = model.Location });
            await context.SaveChangesAsync();

            return new OkResult();
        }
    }
}