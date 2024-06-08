namespace Jgs.Errors.Results;

public class Result
{
    public Result(Error? error = default)
    {
        Error = error;
    }

    public Error? Error { get; }
    public bool IsFailure => !IsSuccess;
    public bool IsSuccess => Error is null;

    public Result Catch(Func<Error, Result> next) => IsFailure ? next(Error!) : this;
    public Result<T> Catch<T>(Func<Error, Result<T>> next) => IsFailure ? next(Error!) : Error!;
    public Result Then(Func<Result> next) => IsSuccess ? next() : this;
    public Result<T> Then<T>(Func<Result<T>> next) => IsSuccess ? next() : Error!;

    public static Result Failure(Error error) => new(error);
    public static Result<T> Failure<T>(Error error) => new(error);
    public static Result Success() => new();
    public static Result<T> Success<T>(T value) => new(value);

    public static implicit operator Error(Result source) => source.Error;
    public static implicit operator Result(Error error) => new(error);
}

public class Result<T> : Result
{
    public Result(Error error) : base(error)
    {
    }

    public Result(T value)
    {
        Value = value;
    }

    public T? Value { get; }

    public Result Then(Func<T, Result> next) => IsSuccess ? next(Value!) : Error!;
    public Result<T> Then(Func<T, Result<T>> next) => IsSuccess ? next(Value!) : Error!;
    public Result<TOut> Then<TOut>(Func<T, Result<TOut>> next) => IsSuccess ? next(Value!) : Error!;

    public static implicit operator Result<T>(Error error) => new(error);
    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator T(Result<T> source) => source.Value;
}
