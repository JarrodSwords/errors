namespace Jgs.Errors.Spec.Results;

public class OnSuccess
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
        Result originalResult = new Error("foo");

        var result = originalResult.Then(() => nextResult);

        result.Should().Be(originalResult);
    }

    [Theory]
    [MemberData(nameof(GetResults))]
    public void AfterSuccess_ThenExecuteNextOperation(Result nextResult)
    {
        var result = Success().Then(() => nextResult);

        result.Should().Be(nextResult);
    }

    #endregion
}
