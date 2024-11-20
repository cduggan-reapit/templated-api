using Microsoft.EntityFrameworkCore;
using Reapit.Peepit.Keepit.Data.Context;
using Reapit.Peepit.Keepit.Data.Helpers;
using Reapit.Peepit.Keepit.Domain.Entities;

namespace Reapit.Peepit.Keepit.Data.Repositories;

/// <inheritdoc />
public class DummyRepository : IDummyRepository
{
    private readonly DemoDbContext _context;

    /// <summary>Initializes a new instance of the <see cref="DummyRepository"/> class.</summary>
    /// <param name="context">The database context.</param>
    public DummyRepository(DemoDbContext context)
        => _context = context;
    
    /// <inheritdoc />
    public async Task<IEnumerable<Dummy>> GetAsync(
        string? name, 
        DateTime? createdFrom, 
        DateTime? createdTo, 
        DateTime? modifiedFrom, 
        DateTime? modifiedTo,
        CancellationToken cancellationToken) 
        => await _context.Dummies.ApplyNameFilter(name)
            .ApplyCreatedFromFilter(createdFrom)
            .ApplyCreatedToFilter(createdTo)
            .ApplyModifiedFromFilter(modifiedFrom)
            .ApplyModifiedToFilter(modifiedTo)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    /// <inheritdoc/>
    public async Task<Dummy?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Dummies.SingleOrDefaultAsync(dummy => dummy.Id == id, cancellationToken);

    /// <inheritdoc />
    public async Task CreateAsync(Dummy entity, CancellationToken cancellationToken)
        => await _context.AddAsync(entity, cancellationToken);

    /// <inheritdoc />
    public async Task UpdateAsync(Dummy entity, CancellationToken cancellationToken)
        => await Task.FromResult(_context.Dummies.Update(entity));

    /// <inheritdoc />
    public async Task DeleteAsync(Dummy entity, CancellationToken cancellationToken)
        => await Task.FromResult(_context.Dummies.Remove(entity));
}