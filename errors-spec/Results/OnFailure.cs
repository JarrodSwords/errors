using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace Jgs.Errors.Spec.Results;

public class OnFailure
{
    #region Implementation

    public static IEnumerable<object[]> GetResults()
    {
        yield return new object[] { Success() };
        yield return new object[] { new Error("foo") };
    }

    #endregion

    #region Requirements

    [Theory]
    [MemberData(nameof(GetResults))]
    public void AfterFailure_ThenExecuteNextOperation(Result nextResult)
    {
        var result = Failure(new Error("foo")).OnFailure(() => nextResult);

        result.Should().Be(nextResult);
    }

    [Theory]
    [MemberData(nameof(GetResults))]
    public void AfterSuccess_ThenBypassNextOperation(Result nextResult)
    {
        var originalResult = Success();

        var result = originalResult.OnFailure(() => nextResult);

        result.Should().Be(originalResult);
    }

    #endregion
}
