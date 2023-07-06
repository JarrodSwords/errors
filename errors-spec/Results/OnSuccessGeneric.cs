using Jgs.Errors.Results;
using static Jgs.Errors.Results.Result;

namespace Jgs.Errors.Spec.Results;

public class OnSuccessGeneric
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
    public void AfterFailure_ThenBypassNextOperation(Result nextResult)
    {
        Result<int> originalResult = new Error("foo");

        var result = originalResult.OnSuccess(() => nextResult);

        result.Should().Be(originalResult);
    }

    [Theory]
    [MemberData(nameof(GetResults))]
    public void AfterSuccess_ThenExecuteNextOperation(Result nextResult)
    {
        var result = Success(5).OnSuccess(() => nextResult);

        result.Should().Be(nextResult);
    }

    #endregion
}
