using Intro_Web_ASP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intro_Web_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController()
        {
            _peopleService = new PeopleService();
        }

        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> GetPeople(int id)
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id);
            if (people == null)
                return NotFound($"No se encontró la persona con ID {id}.");
            return Ok(people);
        }

        [HttpGet("search/{search}")]
        public List<People> GetPeople(string search)
        {
            return Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
        }

        [HttpGet]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }

            Repository.People.Add(people);
            return NoContent();
        }
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People { Id = 1, Name = "John Doe", Birthdate = new DateTime(1990, 1, 1) },
            new People { Id = 2, Name = "Jane Smith", Birthdate = new DateTime(1985, 5, 15) },
            new People { Id = 3, Name = "Alice Johnson", Birthdate = new DateTime(2000, 12, 31) }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
