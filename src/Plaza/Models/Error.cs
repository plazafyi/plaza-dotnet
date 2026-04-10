using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models;

/// <summary>
/// Standard API error envelope. Every error response wraps a single `error` object
/// with a machine-readable `code`, a human-readable `message`, and optional structured `details`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// Error payload
    /// </summary>
    public required ErrorError ErrorValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ErrorError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorValue.Validate();
    }

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Error(ErrorError errorValue)
        : this()
    {
        this.ErrorValue = errorValue;
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}

/// <summary>
/// Error payload
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ErrorError, ErrorErrorFromRaw>))]
public sealed record class ErrorError : JsonModel
{
    /// <summary>
    /// Machine-readable error code (e.g. `invalid_request`, `not_found`, `rate_limited`,
    /// `query_error`, `daily_limit_exceeded`)
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Human-readable explanation of what went wrong
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// Structured details when available (e.g. field-level validation errors, rate
    /// limit metadata, billing info)
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Details
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("details");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "details",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Message;
        _ = this.Details;
    }

    public ErrorError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ErrorError(ErrorError errorError)
        : base(errorError) { }
#pragma warning restore CS8618

    public ErrorError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorErrorFromRaw.FromRawUnchecked"/>
    public static ErrorError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorErrorFromRaw : IFromRawJson<ErrorError>
{
    /// <inheritdoc/>
    public ErrorError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ErrorError.FromRawUnchecked(rawData);
}
