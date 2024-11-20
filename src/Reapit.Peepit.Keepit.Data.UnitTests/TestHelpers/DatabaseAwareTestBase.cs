using Reapit.Peepit.Keepit.Data.Context;
using Reapit.Peepit.Keepit.Data.UnitTests.Context;

namespace Reapit.Peepit.Keepit.Data.UnitTests.TestHelpers;

public abstract class DatabaseAwareTestBase
{
    private readonly TestDbContextFactory _contextFactory = new();
    private DemoDbContext? _context;

    public DemoDbContext GetContext(bool ensureCreated = true)
        => _context ??= _contextFactory.CreateContext(ensureCreated);
    
    public async Task<DemoDbContext> GetContextAsync(bool ensureCreated = true, CancellationToken cancellationToken = default)
        => _context ??= await _contextFactory.CreateContextAsync(ensureCreated, cancellationToken);
}