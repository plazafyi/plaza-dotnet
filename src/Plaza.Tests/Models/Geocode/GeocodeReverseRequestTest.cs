using System.Text.Json;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Geocode;

namespace Plaza.Tests.Models.Geocode;

public class GeocodeReverseRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Limit = 1,
            Radius = 1,
        };

        PointGeometry expectedGeometry = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string expectedLang = "lang";
        long expectedLimit = 1;
        double expectedRadius = 1;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedLang, model.Lang);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedRadius, model.Radius);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Limit = 1,
            Radius = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeocodeReverseRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Limit = 1,
            Radius = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeocodeReverseRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PointGeometry expectedGeometry = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string expectedLang = "lang";
        long expectedLimit = 1;
        double expectedRadius = 1;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedLang, deserialized.Lang);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedRadius, deserialized.Radius);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Limit = 1,
            Radius = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        };

        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },

            Lang = null,
            Limit = null,
            Radius = null,
        };

        Assert.Null(model.Lang);
        Assert.True(model.RawData.ContainsKey("lang"));
        Assert.Null(model.Limit);
        Assert.True(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Radius);
        Assert.True(model.RawData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },

            Lang = null,
            Limit = null,
            Radius = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GeocodeReverseRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Limit = 1,
            Radius = 1,
        };

        GeocodeReverseRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
