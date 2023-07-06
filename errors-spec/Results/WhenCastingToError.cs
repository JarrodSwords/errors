namespace Jgs.Errors.Spec.Results;

public class WhenCastingToError
{
    #region Requirements

    [Fact]
    public void FromGeneric_ThenReturnError()
    {
        var error = new Error("foo");

        var result = Failure<int>(error);

        ((Error) result).Should().Be(error);
    }

    [Fact]
    public void ThenReturnError()
    {
        var error = new Error("foo");

        var result = Failure(error);

        ((Error) result).Should().Be(error);
    }

    #endregion
}
