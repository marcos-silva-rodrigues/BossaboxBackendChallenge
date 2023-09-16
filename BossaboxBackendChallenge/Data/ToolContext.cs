using BossaboxBackendChallenge.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace BossaboxBackendChallenge.Data
{
    public class ToolContext: DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Tool> Tools { get; set; }

        public ToolContext(DbContextOptions<ToolContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tool>()
                    .HasMany(tool => tool.Tags)
                    .WithMany(tag => tag.Tools);
        }
    }
}
