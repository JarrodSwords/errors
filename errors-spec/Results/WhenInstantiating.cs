using FluentAssertions.Execution;
using Jgs.Errors.Results;

namespace Jgs.Errors.Spec.Results;

public class WhenInstantiating
{
    #region Requirements

    [Fact]
    public void ThenReturnSuccess()
    {
        var result = Result.Success();

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
    }

    [Fact]
    public void WithError_ThenReturnFailure()
    {
        var error = new Error("foo");
        var result = new Result(error);

        using var scope = new AssertionScope();

        result.IsFailure.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(error);
    }

    #endregion
}
