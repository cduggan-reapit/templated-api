using FluentValidation;
using FluentValidation.Results;
using Reapit.Platform.Common.Exceptions;
using Reapit.Peepit.Keepit.Core.UseCases.Dummies.GetDummyById;
using Reapit.Peepit.Keepit.Data.Repositories;
using Reapit.Peepit.Keepit.Data.Services;
using Reapit.Peepit.Keepit.Domain.Entities;

namespace Reapit.Peepit.Keepit.Core.UnitTests.UseCases.Dummies.GetDummyById;

public class GetDummyByIdQueryHandlerTests
{
    private readonly IValidator<GetDummyByIdQuery> _validator = Substitute.For<IValidator<GetDummyByIdQuery>>();
    private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly IDummyRepository _dummyRepository = Substitute.For<IDummyRepository>();

    [Fact]
    public async Task Handle_ThrowsValidationException_WhenValidationFails()
    {
        var query = GetQuery(Guid.NewGuid());
        _validator.ValidateAsync(Arg.Any<GetDummyByIdQuery>(), Arg.Any<CancellationToken>())
            .Returns(new ValidationResult(new[] { new ValidationFailure("propertyName", "errorMessage") }));

        var sut = CreateSut();
        var action = () => sut.Handle(query, default);
        await action.Should().ThrowAsync<ValidationException>();
    }

    [Fact]
    public async Task Handle_ThrowsNotFoundException_WhenObjectNotFound()
    {
        var query = GetQuery(Guid.NewGuid());
        
        _validator.ValidateAsync(Arg.Any<GetDummyByIdQuery>(), Arg.Any<CancellationToken>())
            .Returns(new ValidationResult());

        _dummyRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(null as Dummy);

        var sut = CreateSut();
        var action = () => sut.Handle(query, default);
        await action.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task Handle_ReturnsDummy_WhenMatchingObjectFound()
    {
        var id = Guid.NewGuid();
        var query = GetQuery(id);
        var expected = new Dummy("test-dummy") { Id = id };
        
        _validator.ValidateAsync(Arg.Any<GetDummyByIdQuery>(), Arg.Any<CancellationToken>())
            .Returns(new ValidationResult());

        _dummyRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(expected);

        var sut = CreateSut();
        var actual = await sut.Handle(query, default);
        actual.Should().BeEquivalentTo(expected);
    }

    /*
     * Private methods
     */

    private GetDummyByIdQueryHandler CreateSut()
    {
        _unitOfWork.Dummies.Returns(_dummyRepository);
        return new GetDummyByIdQueryHandler(_validator, _unitOfWork);
    }

    private static GetDummyByIdQuery GetQuery(Guid id)
        => new($"{id:N}");
}