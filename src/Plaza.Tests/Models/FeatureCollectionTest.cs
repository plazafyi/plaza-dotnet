using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class FeatureCollectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureCollection
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
            Type = Type.FeatureCollection,
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
        ApiEnum<string, Type> expectedType = Type.FeatureCollection;

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
        var model = new FeatureCollection
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
            Type = Type.FeatureCollection,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureCollection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureCollection
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
            Type = Type.FeatureCollection,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureCollection>(
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
        ApiEnum<string, Type> expectedType = Type.FeatureCollection;

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
        var model = new FeatureCollection
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
            Type = Type.FeatureCollection,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureCollection
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
            Type = Type.FeatureCollection,
        };

        FeatureCollection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.FeatureCollection)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.FeatureCollection)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
