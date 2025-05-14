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
        public async Task<IActionResult> CreatePersonaje(string personaje, string imagen) {
            await this.repo.CreatePersonaje(personaje, imagen);
            return Ok(new { mensaje = "Personaje creado" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonaje([FromBody] Personaje personaje) {
            await this.repo.UpdatePersonaje(
                personaje.idpersonaje,
                personaje.personaje,
                personaje.imagen
            );
            return Ok(new { mensaje = "Personaje actualizado" });
        }
    }
}
