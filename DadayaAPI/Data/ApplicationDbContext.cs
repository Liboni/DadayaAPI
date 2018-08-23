using Microsoft.EntityFrameworkCore;
using DadayaAPI.Data;

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
        public DbSet<GalleryType> GalleryTypes { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<DadayaAPI.Data.Staff> Staff { get; set; }
    }
}
