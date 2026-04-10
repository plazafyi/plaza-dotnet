using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class RoutingIsochroneResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RoutingIsochroneResponse
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
                    },
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "@id", JsonSerializer.SerializeToElement("bar") },
                        { "@type", JsonSerializer.SerializeToElement("bar") },
                        { "amenity", JsonSerializer.SerializeToElement("bar") },
                        { "cuisine", JsonSerializer.SerializeToElement("bar") },
                        { "name", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = GeoJsonFeatureType.Feature,
                    ID = "node/21154906",
                },
            ],
            Type = RoutingIsochroneResponseType.FeatureCollection,
        };

        List<GeoJsonFeature> expectedFeatures =
        [
            new()
            {
                Geometry = new PointGeometry()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = PointGeometryType.Point,
                },
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "@id", JsonSerializer.SerializeToElement("bar") },
                    { "@type", JsonSerializer.SerializeToElement("bar") },
                    { "amenity", JsonSerializer.SerializeToElement("bar") },
                    { "cuisine", JsonSerializer.SerializeToElement("bar") },
                    { "name", JsonSerializer.SerializeToElement("bar") },
                },
                Type = GeoJsonFeatureType.Feature,
                ID = "node/21154906",
            },
        ];
        ApiEnum<string, RoutingIsochroneResponseType> expectedType =
            RoutingIsochroneResponseType.FeatureCollection;

        Assert.Equal(expectedFeatures.Count, model.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], model.Features[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RoutingIsochroneResponse
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
                    },
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "@id", JsonSerializer.SerializeToElement("bar") },
                        { "@type", JsonSerializer.SerializeToElement("bar") },
                        { "amenity", JsonSerializer.SerializeToElement("bar") },
                        { "cuisine", JsonSerializer.SerializeToElement("bar") },
                        { "name", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = GeoJsonFeatureType.Feature,
                    ID = "node/21154906",
                },
            ],
            Type = RoutingIsochroneResponseType.FeatureCollection,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingIsochroneResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RoutingIsochroneResponse
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
                    },
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "@id", JsonSerializer.SerializeToElement("bar") },
                        { "@type", JsonSerializer.SerializeToElement("bar") },
                        { "amenity", JsonSerializer.SerializeToElement("bar") },
                        { "cuisine", JsonSerializer.SerializeToElement("bar") },
                        { "name", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = GeoJsonFeatureType.Feature,
                    ID = "node/21154906",
                },
            ],
            Type = RoutingIsochroneResponseType.FeatureCollection,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingIsochroneResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GeoJsonFeature> expectedFeatures =
        [
            new()
            {
                Geometry = new PointGeometry()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = PointGeometryType.Point,
                },
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "@id", JsonSerializer.SerializeToElement("bar") },
                    { "@type", JsonSerializer.SerializeToElement("bar") },
                    { "amenity", JsonSerializer.SerializeToElement("bar") },
                    { "cuisine", JsonSerializer.SerializeToElement("bar") },
                    { "name", JsonSerializer.SerializeToElement("bar") },
                },
                Type = GeoJsonFeatureType.Feature,
                ID = "node/21154906",
            },
        ];
        ApiEnum<string, RoutingIsochroneResponseType> expectedType =
            RoutingIsochroneResponseType.FeatureCollection;

        Assert.Equal(expectedFeatures.Count, deserialized.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], deserialized.Features[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RoutingIsochroneResponse
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
                    },
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "@id", JsonSerializer.SerializeToElement("bar") },
                        { "@type", JsonSerializer.SerializeToElement("bar") },
                        { "amenity", JsonSerializer.SerializeToElement("bar") },
                        { "cuisine", JsonSerializer.SerializeToElement("bar") },
                        { "name", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = GeoJsonFeatureType.Feature,
                    ID = "node/21154906",
                },
            ],
            Type = RoutingIsochroneResponseType.FeatureCollection,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RoutingIsochroneResponse
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
                    },
                    Properties = new Dictionary<string, JsonElement>()
                    {
                        { "@id", JsonSerializer.SerializeToElement("bar") },
                        { "@type", JsonSerializer.SerializeToElement("bar") },
                        { "amenity", JsonSerializer.SerializeToElement("bar") },
                        { "cuisine", JsonSerializer.SerializeToElement("bar") },
                        { "name", JsonSerializer.SerializeToElement("bar") },
                    },
                    Type = GeoJsonFeatureType.Feature,
                    ID = "node/21154906",
                },
            ],
            Type = RoutingIsochroneResponseType.FeatureCollection,
        };

        RoutingIsochroneResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoutingIsochroneResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(RoutingIsochroneResponseType.FeatureCollection)]
    public void Validation_Works(RoutingIsochroneResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingIsochroneResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingIsochroneResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingIsochroneResponseType.FeatureCollection)]
    public void SerializationRoundtrip_Works(RoutingIsochroneResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingIsochroneResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingIsochroneResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingIsochroneResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingIsochroneResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
