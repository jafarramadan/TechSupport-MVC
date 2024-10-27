using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechSupport.Models;

namespace TechSupport.Data
{
    public class TechSupportDbContext : IdentityDbContext<ApplicationUser>
    {
        public TechSupportDbContext(DbContextOptions<TechSupportDbContext> options) : base(options) { }


        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<RepairJob> RepairJobs { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<KnowledgeBaseArticle> KnowledgeBaseArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            seedRoles(modelBuilder);

        }




        private void seedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole
                {
                    Id = "1",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Technician",
                    NormalizedName = "TECHNICIAN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            );
        }
    }
    
}
