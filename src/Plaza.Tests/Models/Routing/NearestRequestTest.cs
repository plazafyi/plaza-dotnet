using System.Text.Json;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class NearestRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Radius = 1,
        };

        PointGeometry expectedGeometry = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        double expectedRadius = 1;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedRadius, model.Radius);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Radius = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NearestRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Radius = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NearestRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PointGeometry expectedGeometry = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        double expectedRadius = 1;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedRadius, deserialized.Radius);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Radius = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        };

        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },

            Radius = null,
        };

        Assert.Null(model.Radius);
        Assert.True(model.RawData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },

            Radius = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NearestRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Radius = 1,
        };

        NearestRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
