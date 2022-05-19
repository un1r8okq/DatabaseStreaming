using Microsoft.AspNetCore.Mvc;

namespace DatabaseStreamingAPI
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly PersonContext _dbContext;

        public PeopleController(ILogger<PeopleController> logger, PersonContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetPeople")]
        public IEnumerable<Person> Get()
        {
            return _dbContext.People.AsEnumerable();
        }

        [HttpPost(Name = "AddPeople")]
        public async Task<IEnumerable<Person>> Post([FromBody] IEnumerable<Person> people)
        {
            await _dbContext.People.AddRangeAsync(people);
            await _dbContext.SaveChangesAsync();
            return people;
        }
    }
}
