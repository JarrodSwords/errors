using Jgs.Errors.Results;

namespace Jgs.Errors.Spec.Results;

public class WhenCastingToError
{
    #region Requirements

    [Fact]
    public void FromGeneric_ThenReturnError()
    {
        var error = new Error("foo");

        var result = Result.Failure<int>(error);

        ((Error) result).Should().Be(error);
    }

    [Fact]
    public void ThenReturnError()
    {
        var error = new Error("foo");

        var result = Result.Failure(error);

        ((Error) result).Should().Be(error);
    }

    #endregion
}
