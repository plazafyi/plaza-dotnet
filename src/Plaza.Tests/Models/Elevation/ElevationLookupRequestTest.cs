using System.Text.Json;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Elevation;

namespace Plaza.Tests.Models.Elevation;

public class ElevationLookupRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElevationLookupRequest
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        ElevationLookupRequestGeometry expectedGeometry = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        Assert.Equal(expectedGeometry, model.Geometry);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElevationLookupRequest
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationLookupRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElevationLookupRequest
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationLookupRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ElevationLookupRequestGeometry expectedGeometry = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        Assert.Equal(expectedGeometry, deserialized.Geometry);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElevationLookupRequest
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElevationLookupRequest
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        ElevationLookupRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElevationLookupRequestGeometryTest : TestBase
{
    [Fact]
    public void PointValidationWorks()
    {
        ElevationLookupRequestGeometry value = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        value.Validate();
    }

    [Fact]
    public void MultiPointValidationWorks()
    {
        ElevationLookupRequestGeometry value = new MultiPointGeometry()
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };
        value.Validate();
    }

    [Fact]
    public void PointSerializationRoundtripWorks()
    {
        ElevationLookupRequestGeometry value = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationLookupRequestGeometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultiPointSerializationRoundtripWorks()
    {
        ElevationLookupRequestGeometry value = new MultiPointGeometry()
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationLookupRequestGeometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
