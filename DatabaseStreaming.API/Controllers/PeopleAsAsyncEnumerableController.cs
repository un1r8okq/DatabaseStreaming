using DatabaseStreaming.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseStreaming.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleAsAsyncEnumerableController : ControllerBase
    {
        [HttpGet]
        public async IAsyncEnumerable<Person> Get([FromServices] PersonContext dbContext)
        {
            await foreach (var person in dbContext.People.AsAsyncEnumerable())
            {
                yield return person;
            }
        }
    }
}
