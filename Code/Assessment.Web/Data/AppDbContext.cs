using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assessment.Web.ViewModels;

namespace Assessment.Web.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {            
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Assessment.Web.ViewModels.ClientViewModel> ClientViewModel { get; set; }
    }
}
