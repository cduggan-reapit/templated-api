using System.Diagnostics.CodeAnalysis;
using Reapit.Peepit.Keepit.Api.Controllers.Dummies.V1.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Reapit.Peepit.Keepit.Api.Controllers.Dummies.V1.Examples;

/// <summary>Swagger example provider for the <see cref="ReadDummyResponseModel"/> type.</summary>
[ExcludeFromCodeCoverage]
public class ReadDummyModelCollectionExample : IExamplesProvider<IEnumerable<ReadDummyResponseModel>>
{
    /// <inheritdoc/>
    public IEnumerable<ReadDummyResponseModel> GetExamples()
        => new[] { ReadDummyModelExampleBase.GetExample() };
}