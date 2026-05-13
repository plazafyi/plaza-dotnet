using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models;

/// <summary>
/// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
/// determines the coordinate structure.
/// </summary>
[JsonConverter(typeof(GeometryConverter))]
public record class Geometry : ModelBase
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

    public Geometry(PointGeometry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Geometry(LineStringGeometry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Geometry(PolygonGeometry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Geometry(MultiPointGeometry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Geometry(MultiLineStringGeometry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Geometry(MultiPolygonGeometry value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Geometry(JsonElement element)
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
    /// type <see cref="LineStringGeometry"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLineString(out var value)) {
    ///     // `value` is of type `LineStringGeometry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLineString([NotNullWhen(true)] out LineStringGeometry? value)
    {
        value = this.Value as LineStringGeometry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PolygonGeometry"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPolygon(out var value)) {
    ///     // `value` is of type `PolygonGeometry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPolygon([NotNullWhen(true)] out PolygonGeometry? value)
    {
        value = this.Value as PolygonGeometry;
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
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MultiLineStringGeometry"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMultiLineString(out var value)) {
    ///     // `value` is of type `MultiLineStringGeometry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMultiLineString([NotNullWhen(true)] out MultiLineStringGeometry? value)
    {
        value = this.Value as MultiLineStringGeometry;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MultiPolygonGeometry"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMultiPolygon(out var value)) {
    ///     // `value` is of type `MultiPolygonGeometry`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMultiPolygon([NotNullWhen(true)] out MultiPolygonGeometry? value)
    {
        value = this.Value as MultiPolygonGeometry;
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
    ///     (LineStringGeometry value) =&gt; {...},
    ///     (PolygonGeometry value) =&gt; {...},
    ///     (MultiPointGeometry value) =&gt; {...},
    ///     (MultiLineStringGeometry value) =&gt; {...},
    ///     (MultiPolygonGeometry value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<PointGeometry> point,
        System::Action<LineStringGeometry> lineString,
        System::Action<PolygonGeometry> polygon,
        System::Action<MultiPointGeometry> multiPoint,
        System::Action<MultiLineStringGeometry> multiLineString,
        System::Action<MultiPolygonGeometry> multiPolygon
    )
    {
        switch (this.Value)
        {
            case PointGeometry value:
                point(value);
                break;
            case LineStringGeometry value:
                lineString(value);
                break;
            case PolygonGeometry value:
                polygon(value);
                break;
            case MultiPointGeometry value:
                multiPoint(value);
                break;
            case MultiLineStringGeometry value:
                multiLineString(value);
                break;
            case MultiPolygonGeometry value:
                multiPolygon(value);
                break;
            default:
                throw new PlazaInvalidDataException("Data did not match any variant of Geometry");
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
    ///     (LineStringGeometry value) =&gt; {...},
    ///     (PolygonGeometry value) =&gt; {...},
    ///     (MultiPointGeometry value) =&gt; {...},
    ///     (MultiLineStringGeometry value) =&gt; {...},
    ///     (MultiPolygonGeometry value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<PointGeometry, T> point,
        System::Func<LineStringGeometry, T> lineString,
        System::Func<PolygonGeometry, T> polygon,
        System::Func<MultiPointGeometry, T> multiPoint,
        System::Func<MultiLineStringGeometry, T> multiLineString,
        System::Func<MultiPolygonGeometry, T> multiPolygon
    )
    {
        return this.Value switch
        {
            PointGeometry value => point(value),
            LineStringGeometry value => lineString(value),
            PolygonGeometry value => polygon(value),
            MultiPointGeometry value => multiPoint(value),
            MultiLineStringGeometry value => multiLineString(value),
            MultiPolygonGeometry value => multiPolygon(value),
            _ => throw new PlazaInvalidDataException("Data did not match any variant of Geometry"),
        };
    }

    public static implicit operator Geometry(PointGeometry value) => new(value);

    public static implicit operator Geometry(LineStringGeometry value) => new(value);

    public static implicit operator Geometry(PolygonGeometry value) => new(value);

    public static implicit operator Geometry(MultiPointGeometry value) => new(value);

    public static implicit operator Geometry(MultiLineStringGeometry value) => new(value);

    public static implicit operator Geometry(MultiPolygonGeometry value) => new(value);

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
            throw new PlazaInvalidDataException("Data did not match any variant of Geometry");
        }
        this.Switch(
            (point) => point.Validate(),
            (lineString) => lineString.Validate(),
            (polygon) => polygon.Validate(),
            (multiPoint) => multiPoint.Validate(),
            (multiLineString) => multiLineString.Validate(),
            (multiPolygon) => multiPolygon.Validate()
        );
    }

    public virtual bool Equals(Geometry? other) =>
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
            LineStringGeometry _ => 1,
            PolygonGeometry _ => 2,
            MultiPointGeometry _ => 3,
            MultiLineStringGeometry _ => 4,
            MultiPolygonGeometry _ => 5,
            _ => -1,
        };
    }
}

sealed class GeometryConverter : JsonConverter<Geometry>
{
    public override Geometry? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "Point":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PointGeometry>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "LineString":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<LineStringGeometry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "Polygon":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PolygonGeometry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "MultiPoint":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MultiPointGeometry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "MultiLineString":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MultiLineStringGeometry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "MultiPolygon":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<MultiPolygonGeometry>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Geometry(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Geometry value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
