using EntityFramwork_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramwork_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public PersonController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            return Ok(await _dataContext.Persons.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var hero = await _dataContext.Persons.FindAsync(id);
            if (hero == null)
            {
                return NotFound("Person not found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddHero(Person hero)
        {
            _dataContext.Persons.Add(hero);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Persons.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdateHero(Person request)
        {
            var dbHero = await _dataContext.Persons.FindAsync(request.Id);
            if (dbHero == null)
            {
                return NotFound("Person Not found");
            }

            dbHero.Name = request.Name;
            dbHero.Name = request.Name;
            dbHero.Description = request.Description;
            

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Persons.ToListAsync());
        }
    }
}
