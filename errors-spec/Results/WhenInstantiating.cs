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
    }

    #endregion
}
