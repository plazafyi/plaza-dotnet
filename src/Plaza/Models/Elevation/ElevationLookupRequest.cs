using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Elevation;

/// <summary>
/// Request body for elevation lookup. Accepts a single Point or a MultiPoint geometry.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ElevationLookupRequest, ElevationLookupRequestFromRaw>))]
public sealed record class ElevationLookupRequest : JsonModel
{
    /// <summary>
    /// Point or MultiPoint geometry to look up elevations for
    /// </summary>
    public required ElevationLookupRequestGeometry Geometry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ElevationLookupRequestGeometry>("geometry");
        }
        init { this._rawData.Set("geometry", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Geometry.Validate();
    }

    public ElevationLookupRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElevationLookupRequest(ElevationLookupRequest elevationLookupRequest)
        : base(elevationLookupRequest) { }
#pragma warning restore CS8618

    public ElevationLookupRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElevationLookupRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElevationLookupRequestFromRaw.FromRawUnchecked"/>
    public static ElevationLookupRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElevationLookupRequest(ElevationLookupRequestGeometry geometry)
        : this()
    {
        this.Geometry = geometry;
    }
}

class ElevationLookupRequestFromRaw : IFromRawJson<ElevationLookupRequest>
{
    /// <inheritdoc/>
    public ElevationLookupRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElevationLookupRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Point or MultiPoint geometry to look up elevations for
/// </summary>
[JsonConverter(typeof(ElevationLookupRequestGeometryConverter))]
public record class ElevationLookupRequestGeometry : ModelBase
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

    public ElevationLookupRequestGeometry(PointGeometry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElevationLookupRequestGeometry(MultiPointGeometry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ElevationLookupRequestGeometry(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PointGeometry"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPoint(out var value)) {
    ///     // `value` is of type `PointGeometry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPoint([NotNullWhen(true)] out PointGeometry? value)
    {
        value = this.Value as PointGeometry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MultiPointGeometry"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMultiPoint(out var value)) {
    ///     // `value` is of type `MultiPointGeometry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMultiPoint([NotNullWhen(true)] out MultiPointGeometry? value)
    {
        value = this.Value as MultiPointGeometry;
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
    ///     (PointGeometry value) =&gt; {...},
    ///     (MultiPointGeometry value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<PointGeometry> point,
        System::Action<MultiPointGeometry> multiPoint
    )
    {
        switch (this.Value)
        {
            case PointGeometry value:
                point(value);
                break;
            case MultiPointGeometry value:
                multiPoint(value);
                break;
            default:
                throw new PlazaInvalidDataException(
                    "Data did not match any variant of ElevationLookupRequestGeometry"
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
    ///     (PointGeometry value) =&gt; {...},
    ///     (MultiPointGeometry value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<PointGeometry, T> point,
        System::Func<MultiPointGeometry, T> multiPoint
    )
    {
        return this.Value switch
        {
            PointGeometry value => point(value),
            MultiPointGeometry value => multiPoint(value),
            _ => throw new PlazaInvalidDataException(
                "Data did not match any variant of ElevationLookupRequestGeometry"
            ),
        };
    }

    public static implicit operator ElevationLookupRequestGeometry(PointGeometry value) =>
        new(value);

    public static implicit operator ElevationLookupRequestGeometry(MultiPointGeometry value) =>
        new(value);

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
            throw new PlazaInvalidDataException(
                "Data did not match any variant of ElevationLookupRequestGeometry"
            );
        }
        this.Switch((point) => point.Validate(), (multiPoint) => multiPoint.Validate());
    }

    public virtual bool Equals(ElevationLookupRequestGeometry? other) =>
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
            PointGeometry _ => 0,
            MultiPointGeometry _ => 1,
            _ => -1,
        };
    }
}

sealed class ElevationLookupRequestGeometryConverter : JsonConverter<ElevationLookupRequestGeometry>
{
    public override ElevationLookupRequestGeometry? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<PointGeometry>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<MultiPointGeometry>(element, options);
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
        ElevationLookupRequestGeometry value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
