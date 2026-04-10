using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Geocode;

/// <summary>
/// Request body for autocomplete suggestions. Optimized for low-latency type-ahead UIs.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AutocompleteRequest, AutocompleteRequestFromRaw>))]
public sealed record class AutocompleteRequest : JsonModel
{
    /// <summary>
    /// Partial address or place name input
    /// </summary>
    public required string Q
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("q");
        }
        init { this._rawData.Set("q", value); }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code to restrict results
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country_code");
        }
        init { this._rawData.Set("country_code", value); }
    }

    /// <summary>
    /// GeoJSON Point geometry per RFC 7946. Coordinates use [longitude, latitude]
    /// order. Optional third element is altitude in meters.
    /// </summary>
    public PointGeometry? Focus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PointGeometry>("focus");
        }
        init { this._rawData.Set("focus", value); }
    }

    /// <summary>
    /// Preferred response language (ISO 639-1)
    /// </summary>
    public string? Lang
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lang");
        }
        init { this._rawData.Set("lang", value); }
    }

    /// <summary>
    /// Filter by result layer (e.g. `address`, `place`, `poi`)
    /// </summary>
    public string? Layer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("layer");
        }
        init { this._rawData.Set("layer", value); }
    }

    /// <summary>
    /// Maximum number of suggestions (default: 5, max: 20)
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Q;
        _ = this.CountryCode;
        this.Focus?.Validate();
        _ = this.Lang;
        _ = this.Layer;
        _ = this.Limit;
    }

    public AutocompleteRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutocompleteRequest(AutocompleteRequest autocompleteRequest)
        : base(autocompleteRequest) { }
#pragma warning restore CS8618

    public AutocompleteRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutocompleteRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutocompleteRequestFromRaw.FromRawUnchecked"/>
    public static AutocompleteRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AutocompleteRequest(string q)
        : this()
    {
        this.Q = q;
    }
}

class AutocompleteRequestFromRaw : IFromRawJson<AutocompleteRequest>
{
    /// <inheritdoc/>
    public AutocompleteRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AutocompleteRequest.FromRawUnchecked(rawData);
}
