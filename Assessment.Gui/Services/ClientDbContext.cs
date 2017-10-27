namespace Assessment.Gui.Services
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClientDbContext : DbContext
    {
        public ClientDbContext()
            : base("name=ClientModel")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
    }
}
