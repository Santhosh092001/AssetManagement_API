using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.DBContext
{
    public class AMDbcontext : DbContext
    {
        public AMDbcontext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRoleMap>()
                .HasNoKey();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<UserAssetMap> UserAssetMaps { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleMap> UserRoleMaps { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
