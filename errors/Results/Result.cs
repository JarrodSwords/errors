﻿namespace Jgs.Errors.Results;

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

    #endregion
}
