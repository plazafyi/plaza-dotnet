using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Routing;

/// <summary>
/// Request body for distance matrix calculation. Computes travel durations (and
/// optionally distances) between every origin-destination pair. Maximum 2,500 pairs
/// (origins × destinations), each list capped at 50 coordinates.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MatrixRequest, MatrixRequestFromRaw>))]
public sealed record class MatrixRequest : JsonModel
{
    /// <summary>
    /// Array of destination coordinates as GeoJSON Points (max 50)
    /// </summary>
    public required IReadOnlyList<PointGeometry> Destinations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PointGeometry>>("destinations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PointGeometry>>(
                "destinations",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Array of origin coordinates as GeoJSON Points (max 50)
    /// </summary>
    public required IReadOnlyList<PointGeometry> Origins
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PointGeometry>>("origins");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PointGeometry>>(
                "origins",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Comma-separated list of annotations to include: `duration` (always included),
    /// `distance`. Example: `duration,distance`.
    /// </summary>
    public string? Annotations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("annotations");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("annotations", value);
        }
    }

    /// <summary>
    /// Fallback speed in km/h for pairs where no route exists. When set, unreachable
    /// pairs get estimated values instead of null.
    /// </summary>
    public double? FallbackSpeed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("fallback_speed");
        }
        init { this._rawData.Set("fallback_speed", value); }
    }

    /// <summary>
    /// Travel mode (default: `auto`)
    /// </summary>
    public ApiEnum<string, MatrixRequestMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MatrixRequestMode>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Destinations)
        {
            item.Validate();
        }
        foreach (var item in this.Origins)
        {
            item.Validate();
        }
        _ = this.Annotations;
        _ = this.FallbackSpeed;
        this.Mode?.Validate();
    }

    public MatrixRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatrixRequest(MatrixRequest matrixRequest)
        : base(matrixRequest) { }
#pragma warning restore CS8618

    public MatrixRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatrixRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MatrixRequestFromRaw.FromRawUnchecked"/>
    public static MatrixRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MatrixRequestFromRaw : IFromRawJson<MatrixRequest>
{
    /// <inheritdoc/>
    public MatrixRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MatrixRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Travel mode (default: `auto`)
/// </summary>
[JsonConverter(typeof(MatrixRequestModeConverter))]
public enum MatrixRequestMode
{
    Auto,
    Foot,
    Bicycle,
}

sealed class MatrixRequestModeConverter : JsonConverter<MatrixRequestMode>
{
    public override MatrixRequestMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => MatrixRequestMode.Auto,
            "foot" => MatrixRequestMode.Foot,
            "bicycle" => MatrixRequestMode.Bicycle,
            _ => (MatrixRequestMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MatrixRequestMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MatrixRequestMode.Auto => "auto",
                MatrixRequestMode.Foot => "foot",
                MatrixRequestMode.Bicycle => "bicycle",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
