namespace Jgs.Errors.Spec;

public class WhenCheckingEquality
{
    #region Implementation

    public static IEnumerable<object[]> GetEqualErrors()
    {
        yield return new object[] { new Error("foo", "bar"), new Error("foo", "bar") };
        yield return new object[] { new Error("foo", "bar"), new Error("foo", "bat") };
    }

    #endregion

    #region Requirements

    [Fact]
    public void WithDifferentCodes_ThenObjectsAreNotEqual()
    {
        var e1 = new Error("foo", "bat");
        var e2 = new Error("bar", "bat");

        e2.Should().NotBe(e1);
    }

    [Theory]
    [MemberData(nameof(GetEqualErrors))]
    public void WithSameCode_ThenObjectsAreEqual(Error e1, Error e2) => e2.Should().Be(e1);

    #endregion
}
