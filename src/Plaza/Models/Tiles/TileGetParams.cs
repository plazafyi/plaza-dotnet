using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Plaza.Core;

namespace Plaza.Models.Tiles;

/// <summary>
/// Get a Mapbox Vector Tile
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TileGetParams : ParamsBase
{
    public required long Z { get; init; }

    public required long X { get; init; }

    public long? Y { get; init; }

    public TileGetParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TileGetParams(TileGetParams tileGetParams)
        : base(tileGetParams)
    {
        this.Z = tileGetParams.Z;
        this.X = tileGetParams.X;
        this.Y = tileGetParams.Y;
    }
#pragma warning restore CS8618

    public TileGetParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TileGetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        long z,
        long x,
        long y
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.Z = z;
        this.X = x;
        this.Y = y;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TileGetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        long z,
        long x,
        long y
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            z,
            x,
            y
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["Z"] = JsonSerializer.SerializeToElement(this.Z),
                    ["X"] = JsonSerializer.SerializeToElement(this.X),
                    ["Y"] = JsonSerializer.SerializeToElement(this.Y),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TileGetParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Z.Equals(other.Z)
            && this.X.Equals(other.X)
            && (this.Y?.Equals(other.Y) ?? other.Y == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v1/tiles/{0}/{1}/{2}", this.Z, this.X, this.Y)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        request.Headers.Add("Accept", "application/vnd.mapbox-vector-tile");
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
