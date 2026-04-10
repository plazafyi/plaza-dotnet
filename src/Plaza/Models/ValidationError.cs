using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models;

/// <summary>
/// Validation error with per-field details. The `details` object maps field names
/// to arrays of error messages.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ValidationError, ValidationErrorFromRaw>))]
public sealed record class ValidationError : JsonModel
{
    public required ValidationErrorError Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ValidationErrorError>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
    }

    public ValidationError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValidationError(ValidationError validationError)
        : base(validationError) { }
#pragma warning restore CS8618

    public ValidationError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValidationError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValidationErrorFromRaw.FromRawUnchecked"/>
    public static ValidationError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ValidationError(ValidationErrorError error)
        : this()
    {
        this.Error = error;
    }
}

class ValidationErrorFromRaw : IFromRawJson<ValidationError>
{
    /// <inheritdoc/>
    public ValidationError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ValidationError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ValidationErrorError, ValidationErrorErrorFromRaw>))]
public sealed record class ValidationErrorError : JsonModel
{
    /// <summary>
    /// Always `validation_failed`
    /// </summary>
    public required ApiEnum<string, Code> Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Code>>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Human-readable summary
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
    /// Map of field names to error message arrays
    /// </summary>
    public IReadOnlyDictionary<string, IReadOnlyList<string>>? Details
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, ImmutableArray<string>>
            >("details");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyList<string>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ImmutableArray<string>>?>(
                "details",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => ImmutableArray.ToImmutableArray(entry.Value)
                    )
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Code.Validate();
        _ = this.Message;
        _ = this.Details;
    }

    public ValidationErrorError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ValidationErrorError(ValidationErrorError validationErrorError)
        : base(validationErrorError) { }
#pragma warning restore CS8618

    public ValidationErrorError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ValidationErrorError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ValidationErrorErrorFromRaw.FromRawUnchecked"/>
    public static ValidationErrorError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ValidationErrorErrorFromRaw : IFromRawJson<ValidationErrorError>
{
    /// <inheritdoc/>
    public ValidationErrorError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ValidationErrorError.FromRawUnchecked(rawData);
}

/// <summary>
/// Always `validation_failed`
/// </summary>
[JsonConverter(typeof(CodeConverter))]
public enum Code
{
    ValidationFailed,
}

sealed class CodeConverter : JsonConverter<Code>
{
    public override Code Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "validation_failed" => Code.ValidationFailed,
            _ => (Code)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Code value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Code.ValidationFailed => "validation_failed",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
