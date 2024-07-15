using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PianoStoreProject.Data
{
    public class PSPDBContext : IdentityDbContext<AppUser>
    {
        public PSPDBContext()
        {
        }
        public PSPDBContext(DbContextOptions<PSPDBContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var table = entityType.GetTableName();
                if (table.StartsWith("AspNet"))
                {
                    entityType.SetTableName(table.Substring(6));
                }
            };
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ContactMessages> ContactMessages { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<ManagedEmails> ManagedEmails { get; set; }
        public virtual DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
    }
}
