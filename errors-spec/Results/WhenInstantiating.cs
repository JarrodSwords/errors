namespace Jgs.Errors.Spec.Results;

public class WhenInstantiating
{
    #region Requirements

    [Fact]
    public void FromError_ThenReturnFailure()
    {
        var error = new Error("foo");
        Result result = error;

        using var scope = new AssertionScope();

        result.IsFailure.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(error);
    }

    [Fact]
    public void ThenReturnSuccess()
    {
        var result = Success();

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().BeNull();
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
