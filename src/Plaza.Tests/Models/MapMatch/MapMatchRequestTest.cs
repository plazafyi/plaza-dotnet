using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.MapMatch;

namespace Plaza.Tests.Models.MapMatch;

public class MapMatchRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },
            Radiuses = [0],
        };

        LineStringGeometry expectedGeometry = new()
        {
            Coordinates =
            [
                [2.3522, 48.8566],
                [2.353, 48.857],
                [2.354, 48.8575],
            ],
            Type = LineStringGeometryType.LineString,
        };
        List<double> expectedRadiuses = [0];

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.NotNull(model.Radiuses);
        Assert.Equal(expectedRadiuses.Count, model.Radiuses.Count);
        for (int i = 0; i < expectedRadiuses.Count; i++)
        {
            Assert.Equal(expectedRadiuses[i], model.Radiuses[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },
            Radiuses = [0],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MapMatchRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },
            Radiuses = [0],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MapMatchRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        LineStringGeometry expectedGeometry = new()
        {
            Coordinates =
            [
                [2.3522, 48.8566],
                [2.353, 48.857],
                [2.354, 48.8575],
            ],
            Type = LineStringGeometryType.LineString,
        };
        List<double> expectedRadiuses = [0];

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.NotNull(deserialized.Radiuses);
        Assert.Equal(expectedRadiuses.Count, deserialized.Radiuses.Count);
        for (int i = 0; i < expectedRadiuses.Count; i++)
        {
            Assert.Equal(expectedRadiuses[i], deserialized.Radiuses[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },
            Radiuses = [0],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },
        };

        Assert.Null(model.Radiuses);
        Assert.False(model.RawData.ContainsKey("radiuses"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },

            Radiuses = null,
        };

        Assert.Null(model.Radiuses);
        Assert.True(model.RawData.ContainsKey("radiuses"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },

            Radiuses = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MapMatchRequest
        {
            Geometry = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.353, 48.857],
                    [2.354, 48.8575],
                ],
                Type = LineStringGeometryType.LineString,
            },
            Radiuses = [0],
        };

        MapMatchRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
