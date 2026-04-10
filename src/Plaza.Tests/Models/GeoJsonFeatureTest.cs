using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class GeoJsonFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeoJsonFeature
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
        };

        Geometry expectedGeometry = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "@id", JsonSerializer.SerializeToElement("bar") },
            { "@type", JsonSerializer.SerializeToElement("bar") },
            { "amenity", JsonSerializer.SerializeToElement("bar") },
            { "cuisine", JsonSerializer.SerializeToElement("bar") },
            { "name", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, GeoJsonFeatureType> expectedType = GeoJsonFeatureType.Feature;
        string expectedID = "node/21154906";

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GeoJsonFeature
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeoJsonFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GeoJsonFeature
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeoJsonFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Geometry expectedGeometry = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "@id", JsonSerializer.SerializeToElement("bar") },
            { "@type", JsonSerializer.SerializeToElement("bar") },
            { "amenity", JsonSerializer.SerializeToElement("bar") },
            { "cuisine", JsonSerializer.SerializeToElement("bar") },
            { "name", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, GeoJsonFeatureType> expectedType = GeoJsonFeatureType.Feature;
        string expectedID = "node/21154906";

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(deserialized.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Properties[item.Key]));
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GeoJsonFeature
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GeoJsonFeature
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
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GeoJsonFeature
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GeoJsonFeature
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GeoJsonFeature
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

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GeoJsonFeature
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
        };

        GeoJsonFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GeoJsonFeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(GeoJsonFeatureType.Feature)]
    public void Validation_Works(GeoJsonFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GeoJsonFeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GeoJsonFeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GeoJsonFeatureType.Feature)]
    public void SerializationRoundtrip_Works(GeoJsonFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GeoJsonFeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GeoJsonFeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GeoJsonFeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GeoJsonFeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
