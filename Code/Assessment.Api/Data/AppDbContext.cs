using Microsoft.EntityFrameworkCore;
using Assessment.Web;

namespace Assessment.Api.Data
{
    public class AppDbContext: DbContext
    {
        // TODO Lose after scaffolding.
        public AppDbContext()
        {            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {            
        }

        public DbSet<Client> Clients { get; set; }
    }
}
