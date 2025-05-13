using ApiPersonajesAWS.Models;
using ApiPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonaje repo;

        public PersonajesController(RepositoryPersonaje repo) {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes() {
            var personajes = await this.repo.GetPersonajesAsync();
            return Ok(personajes);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonaje(string personaje, string img) {
            await this.repo.CreatePersonaje(personaje, img);
            return Ok(new { mensaje = "Personaje creado" });
        }
    }
}
