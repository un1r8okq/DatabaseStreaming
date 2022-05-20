using DatabaseStreaming.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStreaming.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleAsArrayController : ControllerBase
    {
        [HttpGet]
        public async Task<Person[]> Get([FromServices] PersonContext dbContext) =>
            await dbContext.People.ToArrayAsync();
    }
}
