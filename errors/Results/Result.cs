namespace Jgs.Errors.Results;

public class Result
{
    #region Implementation

    public bool IsSuccess { get; } = true;

    #endregion

    #region Static Interface

    public static Result Success() => new();

    #endregion
}
