using DatabaseStreaming.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseStreaming.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleAsArrayController : ControllerBase
    {
        [HttpGet]
        public Person[] Get([FromServices] PersonContext dbContext) =>
            dbContext.People.ToArray();
    }
}
