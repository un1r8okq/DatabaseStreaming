using DatabaseStreaming.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseStreaming.API
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleAsEnumerableController : ControllerBase
    {
        private readonly ILogger<PeopleAsEnumerableController> _logger;
        private readonly PersonContext _dbContext;

        public PeopleAsEnumerableController(ILogger<PeopleAsEnumerableController> logger, PersonContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetPeople")]
        public IEnumerable<Person> Get()
        {
            return _dbContext.People.AsEnumerable();
        }
    }
}
