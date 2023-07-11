namespace Jgs.Errors.Spec.Results;

public class WhenInstantiatingGeneric
{
    #region Requirements

    [Fact]
    public void FromError_ThenReturnFailure()
    {
        var error = new Error("foo");
        Result<int?> result = error;

        using var scope = new AssertionScope();

        result.IsFailure.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(error);
        result.Value.Should().BeNull();
    }

    [Fact]
    public void FromValue_ThenReturnSuccess()
    {
        const int count = 5;
        Result<int> result = count;

        using var scope = new AssertionScope();

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().BeNull();
        result.Value.Should().Be(count);
    }

    [Fact]
    public void WithError_ThenReturnFailure()
    {
        var error = new Error("foo");
        var result = new Result<int?>(error);

        using var scope = new AssertionScope();

        result.IsFailure.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(error);
        result.Value.Should().BeNull();
    }

    [Fact]
    public void WithValue_ThenReturnSuccess()
    {
        const int count = 5;
        var result = new Result<int>(count);

        using var scope = new AssertionScope();

        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().BeNull();
        result.Value.Should().Be(count);
    }

    #endregion
}
