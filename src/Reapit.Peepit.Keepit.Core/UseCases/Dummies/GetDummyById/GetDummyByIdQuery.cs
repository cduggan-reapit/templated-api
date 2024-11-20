﻿using MediatR;
using Reapit.Peepit.Keepit.Domain.Entities;

namespace Reapit.Peepit.Keepit.Core.UseCases.Dummies.GetDummyById;

/// <summary>Mediator request representing a query to fetch a single Dummy.</summary>
/// <param name="Id">The unique identifier of the Dummy to return.</param>
public record GetDummyByIdQuery(string Id) : IRequest<Dummy>;