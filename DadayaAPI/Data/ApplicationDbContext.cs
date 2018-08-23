
namespace DadayaAPI.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionsInRole> PermissionsInRoles { get; set; }
        public DbSet<Notice> Notices { get; set; }
    }
}
