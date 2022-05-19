using Microsoft.AspNetCore.Mvc;

namespace DatabaseStreamingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonContext _dbContext;

        public PersonController(ILogger<PersonController> logger, PersonContext dbContext)
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