using Jgs.Errors.Results;

namespace Jgs.Errors.Spec.Results;

public class WhenCastingToValue
{
    #region Requirements

    [Fact]
    public void ThenReturnValue()
    {
        var result = Result.Success(5);

        ((int) result).Should().Be(5);
    }

    #endregion
}
