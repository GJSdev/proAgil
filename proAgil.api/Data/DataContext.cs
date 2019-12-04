using Microsoft.EntityFrameworkCore;
using proAgil.api.Models;

namespace proAgil.api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Evento> Eventos {get;set;}
    }
}