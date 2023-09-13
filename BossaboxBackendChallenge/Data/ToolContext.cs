using BossaboxBackendChallenge.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace BossaboxBackendChallenge.Data
{
    public class ToolContext: DbContext
    {
        public DbSet<Tag> Blogs { get; set; }
        public DbSet<Tool> Posts { get; set; }

        public string DbPath { get; }
        public ToolContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={DbPath}");
    }
}
