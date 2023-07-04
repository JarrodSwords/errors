namespace Jgs.Errors.Results;

public class Result
{
    #region Creation

    public Result(Error? error = default)
    {
        Error = error;
    }

    #endregion

    #region Implementation

    public Error? Error { get; }
    public bool IsFailure => !IsSuccess;
    public bool IsSuccess => Error is null;

    #endregion

    #region Static Interface

    public static Result Success() => new();

    public static implicit operator Result(Error error) => new(error);

    #endregion
}

public class Result<T> : Result where T : notnull
{
    #region Creation

    public Result(T value)
    {
        Value = value;
    }

    #endregion

    #region Implementation

    public T Value { get; }

    #endregion

    #region Static Interface

    public static implicit operator Result<T>(T value) => new(value);

    #endregion
}
