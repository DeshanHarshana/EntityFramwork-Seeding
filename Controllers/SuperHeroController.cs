using EntityFramwork_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramwork_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public SuperHeroController(DataContext context) {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if(hero == null)
            {
                return NotFound("Hero not found");
            }
            return Ok(hero);    
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _dataContext.SuperHeroes.Add(hero);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task <ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var dbHero= await _dataContext.SuperHeroes.FindAsync(request.Id);
            if(dbHero == null)
            {
                return NotFound("Hero Not found");
            }

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName; 
            dbHero.MyProperty = request.MyProperty;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.SuperHeroes.ToListAsync());
        }
    }
}
