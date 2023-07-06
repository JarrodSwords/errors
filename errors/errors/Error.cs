namespace Jgs.Errors;

public class Error : ValueObject
{
    #region Creation

    public Error(string code, string? description = default)
    {
        Code = code;
        Description = description;
    }

    public void Deconstruct(out string code, out string? description)
    {
        code = Code;
        description = Description;
    }

    #endregion

    #region Implementation

    public string Code { get; }
    public string? Description { get; }

    #endregion

    #region Equality

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }

    #endregion
}
