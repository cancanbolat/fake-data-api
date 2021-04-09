using Bogus;
using fake_data_api.Models;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fake_data_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //GENFU
        [HttpGet]
        public IActionResult Get()
        {
            var users = A.ListOf<User>();
            return Ok(users);
        }
        
        //BOGUS
        [HttpGet("{count}")]
        public ActionResult Get(int count)
        {
            var fakeUser = new Faker<User>("tr")
                .RuleFor(u => u.Id, f => f.Random.Guid())
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName)
                .RuleFor(u => u.UserName, f => f.Person.UserName)
                .RuleFor(u => u.Avatar, f => f.Person.Avatar)
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(u => u.Street, f => f.Person.Address.Street)
                .RuleFor(u => u.Suite, f => f.Person.Address.Suite)
                .RuleFor(u => u.City, f => f.Person.Address.City)
                .RuleFor(u => u.Phone, f => f.Person.Phone)
                .RuleFor(u => u.CompanyName, f => f.Person.Company.Name);

            var users = fakeUser.Generate(count);
            return Ok(users);
        }
    }
}
