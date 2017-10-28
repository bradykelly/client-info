using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Assessment.Dto;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Web.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {            
        }

        public DbSet<Client> Clients { get; set; }
    }
}
