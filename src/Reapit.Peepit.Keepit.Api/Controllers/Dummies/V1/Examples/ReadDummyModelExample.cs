using System.Diagnostics.CodeAnalysis;
using Reapit.Peepit.Keepit.Api.Controllers.Dummies.V1.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Reapit.Peepit.Keepit.Api.Controllers.Dummies.V1.Examples;

/// <summary>Swagger example provider for the <see cref="ReadDummyResponseModel"/> type.</summary>
[ExcludeFromCodeCoverage]
public class ReadDummyModelExample : IExamplesProvider<ReadDummyResponseModel>
{
    /// <inheritdoc/>
    public ReadDummyResponseModel GetExamples()
        => ReadDummyModelExampleBase.GetExample();
}