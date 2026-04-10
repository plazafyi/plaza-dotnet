using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Query;

/// <summary>
/// PlazaQL query request. The query is executed against Plaza's OSM database and
/// results are returned as GeoJSON.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PlazaqlQuery, PlazaqlQueryFromRaw>))]
public sealed record class PlazaqlQuery : JsonModel
{
    /// <summary>
    /// PlazaQL query string
    /// </summary>
    public required string Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
    }

    public PlazaqlQuery() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlazaqlQuery(PlazaqlQuery plazaqlQuery)
        : base(plazaqlQuery) { }
#pragma warning restore CS8618

    public PlazaqlQuery(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlazaqlQuery(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlazaqlQueryFromRaw.FromRawUnchecked"/>
    public static PlazaqlQuery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PlazaqlQuery(string data)
        : this()
    {
        this.Data = data;
    }
}

class PlazaqlQueryFromRaw : IFromRawJson<PlazaqlQuery>
{
    /// <inheritdoc/>
    public PlazaqlQuery FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlazaqlQuery.FromRawUnchecked(rawData);
}
