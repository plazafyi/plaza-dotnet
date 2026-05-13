using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Geocode;

/// <summary>
/// Batch geocoding result. Each entry in `results` is a FeatureCollection corresponding
/// to the input address at the same index. Order is preserved.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GeocodeBatchResponse, GeocodeBatchResponseFromRaw>))]
public sealed record class GeocodeBatchResponse : JsonModel
{
    /// <summary>
    /// Number of addresses processed (always equals length of results)
    /// </summary>
    public required long Count
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("count");
        }
        init { this._rawData.Set("count", value); }
    }

    /// <summary>
    /// Array of FeatureCollections, one per input address. Empty FeatureCollections
    /// indicate no match.
    /// </summary>
    public required IReadOnlyList<GeocodeResult> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<GeocodeResult>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<GeocodeResult>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public GeocodeBatchResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GeocodeBatchResponse(GeocodeBatchResponse geocodeBatchResponse)
        : base(geocodeBatchResponse) { }
#pragma warning restore CS8618

    public GeocodeBatchResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GeocodeBatchResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GeocodeBatchResponseFromRaw.FromRawUnchecked"/>
    public static GeocodeBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GeocodeBatchResponseFromRaw : IFromRawJson<GeocodeBatchResponse>
{
    /// <inheritdoc/>
    public GeocodeBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GeocodeBatchResponse.FromRawUnchecked(rawData);
}
