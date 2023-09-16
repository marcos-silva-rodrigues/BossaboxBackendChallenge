using BossaboxBackendChallenge.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossaboxBackendChallenge.Test.Mocks
{
    public  class MockDB : IDbContextFactory<ToolContext>
    {
        public ToolContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ToolContext>()
            .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
            .Options;

            return new ToolContext(options);
        }
    }
}
