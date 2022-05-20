using DatabaseStreaming.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseStreaming.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleAsListController : ControllerBase
    {
        [HttpGet]
        public List<Person> Get([FromServices] PersonContext dbContext) =>
            dbContext.People.ToList();
    }
}
