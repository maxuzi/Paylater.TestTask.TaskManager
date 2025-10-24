using Microsoft.EntityFrameworkCore;
using Paylater.TestTask.TaskManager.Core.Users.Entities;

namespace Paylater.TestTask.TaskManager.Db.EntityFramework
{
    public class UserManagerDbContext : DbContext
    {
        public UserManagerDbContext( DbContextOptions<UserManagerDbContext> options ) : base( options ) { }
        
        public DbSet<User> UserTM { get; set; }
        public DbSet<UserTasks> UserTasksTM { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            
            modelBuilder.Entity<User>( entity =>
            {
                entity.HasKey( u => u.Id );
                entity.Property( u => u.Name ).IsRequired().HasMaxLength( 100 );

                entity.HasMany( u => u.Tasks );
                      //.WithOne( t => t.User )
                      //.HasForeignKey( t => t.UserId );
            } );

            modelBuilder.Entity<UserTasks>( entity =>
            {
                entity.HasKey( t => new { t.UserId, t.Id } );
                entity.Property( t => t.Title ).IsRequired().HasMaxLength( 100 );
                entity.Property( t => t.Description ).HasMaxLength( 1000 );
                entity.Property( t => t.Status ).IsRequired().HasMaxLength( 20 );
                entity.Property( t => t.CreatedAt ).IsRequired();
                entity.Property( t => t.UpdatedAt ).IsRequired();
            } );
        }
    }
}
