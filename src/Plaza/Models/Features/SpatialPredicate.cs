using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Features;

/// <summary>
/// Spatial predicates for filtering features by geographic relationship. Predicates
/// are mutually exclusive — use exactly one per request. The parameter name is the
/// spatial operation, the value is a GeoJSON geometry to test against.
///
/// <para>| Predicate | Meaning | |---|---| | `around` | Within radius meters (requires
/// `radius`) | | `intersects` | Feature overlaps the input geometry | | `within`
/// | Feature is fully inside the input geometry | | `contains` | Feature fully contains
/// the input geometry | | `crosses` | Feature crosses the input geometry | | `touches`
/// | Feature shares boundary but not interior | | `not_intersects` | Feature does
/// not overlap | | `not_within` | Feature is not fully inside | | `not_contains`
/// | Feature does not fully contain | </para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SpatialPredicate, SpatialPredicateFromRaw>))]
public sealed record class SpatialPredicate : JsonModel
{
    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Around
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("around");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("around", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Contains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("contains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Crosses
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("crosses");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("crosses", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Intersects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("intersects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("intersects", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? NotContains
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("not_contains");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("not_contains", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? NotIntersects
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("not_intersects");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("not_intersects", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? NotWithin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("not_within");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("not_within", value);
        }
    }

    /// <summary>
    /// Search radius in meters. Required for `around`, optional buffer for other predicates.
    /// </summary>
    public double? Radius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("radius");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("radius", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Touches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("touches");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("touches", value);
        }
    }

    /// <summary>
    /// GeoJSON Geometry object per RFC 7946. Discriminated union — the `type` field
    /// determines the coordinate structure.
    /// </summary>
    public Geometry? Within
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Geometry>("within");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("within", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Around?.Validate();
        this.Contains?.Validate();
        this.Crosses?.Validate();
        this.Intersects?.Validate();
        this.NotContains?.Validate();
        this.NotIntersects?.Validate();
        this.NotWithin?.Validate();
        _ = this.Radius;
        this.Touches?.Validate();
        this.Within?.Validate();
    }

    public SpatialPredicate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpatialPredicate(SpatialPredicate spatialPredicate)
        : base(spatialPredicate) { }
#pragma warning restore CS8618

    public SpatialPredicate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpatialPredicate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpatialPredicateFromRaw.FromRawUnchecked"/>
    public static SpatialPredicate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpatialPredicateFromRaw : IFromRawJson<SpatialPredicate>
{
    /// <inheritdoc/>
    public SpatialPredicate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SpatialPredicate.FromRawUnchecked(rawData);
}
