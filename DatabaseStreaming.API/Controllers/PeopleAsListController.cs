using DatabaseStreaming.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStreaming.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleAsListController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Person>> Get([FromServices] PersonContext dbContext) =>
            await dbContext.People.ToListAsync();
    }
}
