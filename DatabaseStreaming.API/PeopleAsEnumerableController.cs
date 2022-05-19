using DatabaseStreaming.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseStreaming.API
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleAsEnumerableController : ControllerBase
    {
        [HttpGet(Name = "GetPeople")]
        public IEnumerable<Person> Get([FromServices] PersonContext dbContext) =>
            dbContext.People.AsEnumerable();
    }
}
