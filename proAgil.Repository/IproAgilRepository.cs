using System.Threading.Tasks;
using proAgil.Domain;

namespace proAgil.Repository
{
    public interface IproAgilRepository
    {
         void Add<T>(T entity) where T:class;
         void Update<T>(T entity) where T:class;
         void Delete<T>(T entity) where T:class;
         Task<bool> SaveChangesAsync();

        //Evento
        Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool Includepalestrantes); 
        Task<Evento[]> GetAllEventosAsync(bool Includepalestrantes);
        Task<Evento> GetEventoAsyncById(int EventoId, bool Includepalestrantes);     

        //Palestrante
        Task<Palestrante[]> GetPalestrantesAsyncByName(string Name, bool IncludeEventos); 
        Task<Palestrante> GetPalestrantesAsync(int PalestranteId, bool IncludeEventos); 
    }
}