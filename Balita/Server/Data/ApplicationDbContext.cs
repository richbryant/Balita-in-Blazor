using Balita.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Balita.Data.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Balita.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>(e =>
            {
                e.HasKey(p => p.Id);
                e.HasIndex(p => p.CategoryId);
                e.Property(p => p.CategoryId).IsRequired();
                e.Property(p => p.PostedDate).HasDefaultValueSql("GETDATE()");
                e.Property(p => p.CommentCount).HasDefaultValue(0);
                e.Property(p => p.PostHeadline).IsRequired();
                e.Property(p => p.PostText).IsRequired();
                e.Property(p => p.Image).IsRequired();
                e.Property(p => p.Image).HasColumnType("VARBINARY(MAX)");
                e.HasOne(p => p.Category)
                    .WithMany(c => c.Posts)
                    .HasForeignKey(c => c.CategoryId)
                    .IsRequired();
            });

            builder.Entity<Category>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasIndex(c => c.Name);
                e.Property(c => c.Name).IsRequired();
                e.HasMany(c => c.Posts)
                    .WithOne(p => p.Category)
                    .IsRequired();
            });

            builder.Entity<Comment>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasIndex(c => c.Username);
                e.HasIndex(C => C.PostId);
                e.HasOne(c => c.Parent)
                    .WithMany(c => c.Children)
                    .HasForeignKey(c => c.ResponseTo)
                    .OnDelete(DeleteBehavior.NoAction);
                e.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.PostId);
            });

            
            base.OnModelCreating(builder);
            // configure Identity properly
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
