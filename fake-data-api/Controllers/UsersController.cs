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
        [HttpGet("{language}/{count}")]
        public ActionResult Get(int count, string language = "en")
        {
            var fakeUser = new Faker<User>(language)
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

/*
 af_ZA	Afrikaans		
fr_CH	French (Switzerland)
ar	Arabic		
ge	Georgian
az	Azerbaijani		
hr	Hrvatski
cz	Czech		
id_ID	Indonesia
de	German		
it	Italian
de_AT	German (Austria)		
ja	Japanese
de_CH	German (Switzerland)		
ko	Korean
el	Greek		
lv	Latvian
en	English		
nb_NO	Norwegian
en_AU	English (Australia)		
ne	Nepalese
en_AU_ocker	English (Australia Ocker)		
nl	Dutch
en_BORK	English (Bork)		
nl_BE	Dutch (Belgium)
en_CA	English (Canada)		
pl	Polish
en_GB	English (Great Britain)		
pt_BR	Portuguese (Brazil)
en_IE	English (Ireland)		
pt_PT	Portuguese (Portugal)
en_IND	English (India)		
ro	Romanian
en_NG	Nigeria (English)		
ru	Russian
en_US	English (United States)		
sk	Slovakian
en_ZA	English (South Africa)		
sv	Swedish
es	Spanish		
tr	Turkish
es_MX	Spanish (Mexico)		
uk	Ukrainian
fa	Farsi		
vi	Vietnamese
fi	Finnish		
zh_CN	Chinese
fr	French		
zh_TW	Chinese (Taiwan)
fr_CA	French (Canada)		
zu_ZA	Zulu (South Africa)
 */
