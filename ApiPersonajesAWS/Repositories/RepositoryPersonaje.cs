using ApiPersonajesAWS.Data;
using ApiPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonajesAWS.Repositories
{
    public class RepositoryPersonaje
    {
        private PersonajesContext context;

        public RepositoryPersonaje(PersonajesContext context) {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync() {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<int> GetNextIdAsync() {
            int maxid = await this.context.Personajes.MaxAsync(p => p.idpersonaje);
            return maxid + 1;
        }

        public async Task CreatePersonaje(string personaje, string img) {
            Personaje nuevo = new Personaje();
            nuevo.idpersonaje = await this.GetNextIdAsync();
            nuevo.personaje = personaje;
            nuevo.imagen = img;
            await this.context.Personajes.AddAsync(nuevo);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonaje(int id, string personaje, string img) {
            Personaje p = await this.context.Personajes.FindAsync(id);
            if (p != null) {
                p.personaje = personaje;
                p.imagen = img;
                await this.context.SaveChangesAsync();
            }
        }
    }
}
