using System.Text.Json;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Datasets;
using Elevation = Plaza.Models.Elevation;
using Features = Plaza.Models.Features;
using Geocode = Plaza.Models.Geocode;
using MapMatch = Plaza.Models.MapMatch;
using Optimize = Plaza.Models.Optimize;
using Routing = Plaza.Models.Routing;

namespace Plaza.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, GeoJsonFeatureType>(),
            new ApiEnumConverter<string, LineStringGeometryType>(),
            new ApiEnumConverter<string, MultiLineStringGeometryType>(),
            new ApiEnumConverter<string, MultiPointGeometryType>(),
            new ApiEnumConverter<string, MultiPolygonGeometryType>(),
            new ApiEnumConverter<string, PointGeometryType>(),
            new ApiEnumConverter<string, PolygonGeometryType>(),
            new ApiEnumConverter<string, Code>(),
            new ApiEnumConverter<string, Features::BatchRequestElementType>(),
            new ApiEnumConverter<string, Features::Type>(),
            new ApiEnumConverter<string, Scope>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Geocode::Type>(),
            new ApiEnumConverter<string, Geocode::GeocodeResultType>(),
            new ApiEnumConverter<string, Geocode::OsmType>(),
            new ApiEnumConverter<string, Geocode::Source>(),
            new ApiEnumConverter<string, Geocode::GeocodingFeatureType>(),
            new ApiEnumConverter<string, Geocode::ReverseGeocodeResultType>(),
            new ApiEnumConverter<string, Routing::IsochroneRequestMode>(),
            new ApiEnumConverter<string, Routing::MatrixRequestMode>(),
            new ApiEnumConverter<string, Routing::Type>(),
            new ApiEnumConverter<string, Routing::RouteRequestGeometries>(),
            new ApiEnumConverter<string, Routing::RouteRequestMode>(),
            new ApiEnumConverter<string, Routing::RouteRequestOverview>(),
            new ApiEnumConverter<string, Routing::RouteRequestTrafficModel>(),
            new ApiEnumConverter<string, Routing::RouteResultType>(),
            new ApiEnumConverter<string, Routing::RoutingIsochroneResponseType>(),
            new ApiEnumConverter<string, Routing::Mode>(),
            new ApiEnumConverter<string, Routing::RoutingMatrixParamsMode>(),
            new ApiEnumConverter<string, Routing::Geometries>(),
            new ApiEnumConverter<string, Routing::RoutingRouteParamsMode>(),
            new ApiEnumConverter<string, Routing::Overview>(),
            new ApiEnumConverter<string, Routing::TrafficModel>(),
            new ApiEnumConverter<string, Elevation::Type>(),
            new ApiEnumConverter<string, Elevation::ElevationProfileResultType>(),
            new ApiEnumConverter<string, MapMatch::Type>(),
            new ApiEnumConverter<string, MapMatch::MapMatchResultType>(),
            new ApiEnumConverter<string, Optimize::Type>(),
            new ApiEnumConverter<string, Optimize::OptimizeCompletedResultType>(),
            new ApiEnumConverter<string, Optimize::Status>(),
            new ApiEnumConverter<string, Optimize::OptimizeProcessingResultStatus>(),
            new ApiEnumConverter<string, Optimize::OptimizeRequestMode>(),
            new ApiEnumConverter<string, Optimize::Mode>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="PlazaInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
