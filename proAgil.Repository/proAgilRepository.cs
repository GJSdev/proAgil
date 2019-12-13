using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proAgil.Domain;

namespace proAgil.Repository
{
    public class proAgilRepository : IproAgilRepository
    {
        private readonly proAgilContext _context;
        
        public proAgilRepository(proAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        //metodos gerais
        public void Add<T>(T entity) where T:class
        {
            _context.Add(entity);
        }
         public void Update<T>(T entity) where T:class
         {
             _context.Update(entity);
         }
         public void Delete<T>(T entity) where T:class
         {
            _context.Remove(entity);
         }

         public async Task<bool> SaveChangesAsync()
         {            
            return (await _context.SaveChangesAsync()) > 0;
         }

        //Evento
        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool Includepalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c=>c.Lotes)
            .Include(c=>c.RedesSociais);

            if(Includepalestrantes)
            {
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(p=>p.Palestrante);
            }
            query = query.OrderByDescending(c=>c.DataEvento)
            .Where(c=>c.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        } 

        public async Task<Evento[]> GetAllEventosAsync(bool Includepalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c=>c.Lotes)
            .Include(c=>c.RedesSociais);

            if(Includepalestrantes)
            {
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(p=>p.Palestrante);
            }
            query = query.OrderByDescending(c=>c.DataEvento);
            return await query.ToArrayAsync();

        }

        public async Task<Evento> GetEventoAsyncById(int EventoId, bool Includepalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c=>c.Lotes)
            .Include(c=>c.RedesSociais);

            if(Includepalestrantes)
            {
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(p=>p.Palestrante);
            }
            query = query.OrderByDescending(c=>c.DataEvento)
            .Where(c=>c.Id == EventoId);
            return await query.FirstOrDefaultAsync();
        }


        //Palestrante
        public async Task<Palestrante[]> GetPalestrantesAsyncByName(string Name, bool IncludeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
             .Include(c=>c.RedesSociais);

            if(IncludeEventos)
            {
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(e=>e.Evento);
            }
            query = query.OrderBy(c=>c.Nome)
            .Where(c=>c.Nome.ToLower().Contains(Name.ToLower()));
            return await query.ToArrayAsync();
        } 

        public async Task<Palestrante> GetPalestrantesAsync(int PalestranteId, bool IncludeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
             .Include(c=>c.RedesSociais);

            if(IncludeEventos)
            {
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(e=>e.Evento);
            }
            query = query.OrderBy(p=>p.Nome)
            .Where(p => p.Id == PalestranteId);
            return await query.FirstOrDefaultAsync();
        }

    }
}