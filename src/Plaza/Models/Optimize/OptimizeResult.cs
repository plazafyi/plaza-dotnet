using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Optimize;

/// <summary>
/// Optimization response — either a completed FeatureCollection with the optimized
/// route, or an async job reference to poll.
/// </summary>
[JsonConverter(typeof(OptimizeResultConverter))]
public record class OptimizeResult : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public OptimizeResult(OptimizeCompletedResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OptimizeResult(OptimizeProcessingResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OptimizeResult(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OptimizeCompletedResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCompleted(out var value)) {
    ///     // `value` is of type `OptimizeCompletedResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCompleted([NotNullWhen(true)] out OptimizeCompletedResult? value)
    {
        value = this.Value as OptimizeCompletedResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OptimizeProcessingResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickProcessing(out var value)) {
    ///     // `value` is of type `OptimizeProcessingResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickProcessing([NotNullWhen(true)] out OptimizeProcessingResult? value)
    {
        value = this.Value as OptimizeProcessingResult;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="PlazaInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (OptimizeCompletedResult value) =&gt; {...},
    ///     (OptimizeProcessingResult value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<OptimizeCompletedResult> completed,
        System::Action<OptimizeProcessingResult> processing
    )
    {
        switch (this.Value)
        {
            case OptimizeCompletedResult value:
                completed(value);
                break;
            case OptimizeProcessingResult value:
                processing(value);
                break;
            default:
                throw new PlazaInvalidDataException(
                    "Data did not match any variant of OptimizeResult"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="PlazaInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (OptimizeCompletedResult value) =&gt; {...},
    ///     (OptimizeProcessingResult value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<OptimizeCompletedResult, T> completed,
        System::Func<OptimizeProcessingResult, T> processing
    )
    {
        return this.Value switch
        {
            OptimizeCompletedResult value => completed(value),
            OptimizeProcessingResult value => processing(value),
            _ => throw new PlazaInvalidDataException(
                "Data did not match any variant of OptimizeResult"
            ),
        };
    }

    public static implicit operator OptimizeResult(OptimizeCompletedResult value) => new(value);

    public static implicit operator OptimizeResult(OptimizeProcessingResult value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="PlazaInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new PlazaInvalidDataException("Data did not match any variant of OptimizeResult");
        }
        this.Switch((completed) => completed.Validate(), (processing) => processing.Validate());
    }

    public virtual bool Equals(OptimizeResult? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            OptimizeCompletedResult _ => 0,
            OptimizeProcessingResult _ => 1,
            _ => -1,
        };
    }
}

sealed class OptimizeResultConverter : JsonConverter<OptimizeResult>
{
    public override OptimizeResult? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<OptimizeCompletedResult>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is PlazaInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<OptimizeProcessingResult>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is PlazaInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        OptimizeResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
