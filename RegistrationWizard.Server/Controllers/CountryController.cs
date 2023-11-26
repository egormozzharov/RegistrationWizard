using Microsoft.AspNetCore.Mvc;
using RegistrationWizard.Server.Models;

namespace RegistrationWizard.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        public CountryController()
        {
        }

        [HttpGet]
        public IEnumerable<Country> Get()
        {
            var country1Guid = Guid.Parse("ef3b6952-f83c-4e96-99ef-1dabbd62efab");
            var country2Guid = Guid.Parse("9b8d4fd6-7f1a-4367-a207-67c4b5c200f8");

            var province1Guid = Guid.Parse("b9c5023f-6b45-4c02-8ea4-5b889bc777b0");
            var province2Guid = Guid.Parse("a9240150-3bc5-4a83-abbf-53ba0119ed76");
            var province3Guid = Guid.Parse("103cdf4f-a85b-4e6d-8da8-8d4c63a3a467");
            var province4Guid = Guid.Parse("387a4b87-12a2-4770-a85a-a31fea0340dc");

            return new List<Country>()
            {
                new Country() { Id = country1Guid, Name = "Country1",
                    Provinces = new List<Province>()
                    {
                        new Province() { Id = province1Guid, CountryId = country1Guid, Name = "Province1" },
                        new Province() { Id = province2Guid, CountryId = country1Guid, Name = "Province2" },
                    },
                },
                new Country() { Id = country2Guid, Name = "Country2",
                    Provinces = new List<Province>()
                    {
                        new Province() { Id = province3Guid, CountryId = country2Guid, Name = "Province3" },
                        new Province() { Id = province4Guid, CountryId = country2Guid, Name = "Province4" },
                    },
                }
            };
        }
    }
}
