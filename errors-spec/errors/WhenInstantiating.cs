namespace Jgs.Errors.Spec.Errors;

public class WhenInstantiating
{
    #region Requirements

    [Theory]
    [InlineData("code", "description")]
    public void ThenPropertiesAreExpected(string expectedCode, string expectedDescription)
    {
        var (code, description) = new Error(expectedCode, expectedDescription);

        using var scope = new AssertionScope();

        code.Should().Be(code);
        description.Should().Be(description);
    }

    #endregion
}
