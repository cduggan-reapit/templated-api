using MediatR;
using Reapit.Peepit.Keepit.Domain.Entities;

namespace Reapit.Peepit.Keepit.Core.UseCases.Dummies.CreateDummy;

/// <summary>Mediator request representing a command to create a new Dummy.</summary>
/// <param name="Name">The name of the object to create.</param>
public record CreateDummyCommand(string Name) : IRequest<Dummy>;