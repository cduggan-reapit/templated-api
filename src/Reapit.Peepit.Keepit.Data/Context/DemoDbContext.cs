using Microsoft.EntityFrameworkCore;
using Reapit.Peepit.Keepit.Data.Context.Configuration;
using Reapit.Peepit.Keepit.Domain.Entities;

namespace Reapit.Peepit.Keepit.Data.Context;

public class DemoDbContext : DbContext
{
    public DbSet<Dummy> Dummies { get; set; }

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfiguration(new DummyConfiguration());
}