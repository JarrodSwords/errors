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

    public Result Bind(Func<Result> next) => IsSuccess ? next() : this;
    public Result OnFailure(Func<Result> next) => IsFailure ? next() : this;
    public Result OnSuccess(Func<Result> next) => Bind(next);

    #endregion

    #region Static Interface

    public static Result Failure(Error error) => new(error);
    public static Result<T> Failure<T>(Error error) => new(error);
    public static Result Success() => new();
    public static Result<T> Success<T>(T value) => new(value);

    public static implicit operator Error(Result source) => source.Error;
    public static implicit operator Result(Error error) => new(error);

    #endregion
}

public class Result<T> : Result
{
    #region Creation

    public Result(Error error) : base(error)
    {
    }

    public Result(T value)
    {
        Value = value;
    }

    #endregion

    #region Implementation

    public T? Value { get; }

    #endregion

    #region Static Interface

    public static implicit operator Result<T>(Error error) => new(error);
    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator T(Result<T> source) => source.Value;

    #endregion
}
