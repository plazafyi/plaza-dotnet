using System.Text.Json;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Elevation;

namespace Plaza.Tests.Models.Elevation;

public class ElevationProfileRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElevationProfileRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.34, 48.858],
                    [2.2945, 48.8584],
                ],
                Type = LineStringGeometryType.LineString,
            },
        };

        LineStringGeometry expectedGeometry = new()
        {
            Coordinates =
            [
                [2.3522, 48.8566],
                [2.34, 48.858],
                [2.2945, 48.8584],
            ],
            Type = LineStringGeometryType.LineString,
        };

        Assert.Equal(expectedGeometry, model.Geometry);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElevationProfileRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.34, 48.858],
                    [2.2945, 48.8584],
                ],
                Type = LineStringGeometryType.LineString,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationProfileRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElevationProfileRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.34, 48.858],
                    [2.2945, 48.8584],
                ],
                Type = LineStringGeometryType.LineString,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationProfileRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        LineStringGeometry expectedGeometry = new()
        {
            Coordinates =
            [
                [2.3522, 48.8566],
                [2.34, 48.858],
                [2.2945, 48.8584],
            ],
            Type = LineStringGeometryType.LineString,
        };

        Assert.Equal(expectedGeometry, deserialized.Geometry);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElevationProfileRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.34, 48.858],
                    [2.2945, 48.8584],
                ],
                Type = LineStringGeometryType.LineString,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElevationProfileRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.34, 48.858],
                    [2.2945, 48.8584],
                ],
                Type = LineStringGeometryType.LineString,
            },
        };

        ElevationProfileRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
