using System.Diagnostics.CodeAnalysis;
using Reapit.Peepit.Keepit.Api.Controllers.Dummies.V1.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Reapit.Peepit.Keepit.Api.Controllers.Dummies.V1.Examples;

/// <summary>Swagger example provider for the <see cref="WriteDummyRequestModel"/> type.</summary>
[ExcludeFromCodeCoverage]
public class WriteDummyModelExample : IExamplesProvider<WriteDummyRequestModel>
{
    /// <inheritdoc />
    public WriteDummyRequestModel GetExamples()
        => new(Name: "Dummy Name");
}