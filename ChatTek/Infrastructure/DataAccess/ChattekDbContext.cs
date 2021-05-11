using ChatTek.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatTek.Infrastructure.DataAccess
{
    public class ChattekDbContext : DbContext
    {
        public ChattekDbContext(DbContextOptions options) : base(options) {  }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<MessageText> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
                throw new ArgumentNullException(nameof(modelBuilder));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChattekDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string connectionString = ("Server=localhost;Database=chattek;user=root;password=admin;SslMode=none;charset=utf8");

                builder.UseMySql(connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    mySqlOptions =>
                    {
                        mySqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(1), errorNumbersToAdd: null);
                    });
            }

            base.OnConfiguring(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            /*foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOnUtc = _dateTimeService.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedOnUtc = _dateTimeService.Now;
                        break;
                }
            }*/

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
