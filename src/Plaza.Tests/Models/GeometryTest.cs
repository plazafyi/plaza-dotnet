using System.Text.Json;
using Plaza.Core;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class GeometryTest : TestBase
{
    [Fact]
    public void PointValidationWorks()
    {
        Geometry value = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        value.Validate();
    }

    [Fact]
    public void LineStringValidationWorks()
    {
        Geometry value = new LineStringGeometry()
        {
            Coordinates =
            [
                [0, 0],
                [0, 0],
            ],
            Type = LineStringGeometryType.LineString,
        };
        value.Validate();
    }

    [Fact]
    public void PolygonValidationWorks()
    {
        Geometry value = new PolygonGeometry()
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = PolygonGeometryType.Polygon,
        };
        value.Validate();
    }

    [Fact]
    public void MultiPointValidationWorks()
    {
        Geometry value = new MultiPointGeometry()
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
    public void MultiLineStringValidationWorks()
    {
        Geometry value = new MultiLineStringGeometry()
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = MultiLineStringGeometryType.MultiLineString,
        };
        value.Validate();
    }

    [Fact]
    public void MultiPolygonValidationWorks()
    {
        Geometry value = new MultiPolygonGeometry()
        {
            Coordinates =
            [
                [
                    [
                        [0, 0],
                        [0, 0],
                        [0, 0],
                        [0, 0],
                    ],
                ],
            ],
            Type = MultiPolygonGeometryType.MultiPolygon,
        };
        value.Validate();
    }

    [Fact]
    public void PointSerializationRoundtripWorks()
    {
        Geometry value = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Geometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LineStringSerializationRoundtripWorks()
    {
        Geometry value = new LineStringGeometry()
        {
            Coordinates =
            [
                [0, 0],
                [0, 0],
            ],
            Type = LineStringGeometryType.LineString,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Geometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PolygonSerializationRoundtripWorks()
    {
        Geometry value = new PolygonGeometry()
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = PolygonGeometryType.Polygon,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Geometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultiPointSerializationRoundtripWorks()
    {
        Geometry value = new MultiPointGeometry()
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Geometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultiLineStringSerializationRoundtripWorks()
    {
        Geometry value = new MultiLineStringGeometry()
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = MultiLineStringGeometryType.MultiLineString,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Geometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultiPolygonSerializationRoundtripWorks()
    {
        Geometry value = new MultiPolygonGeometry()
        {
            Coordinates =
            [
                [
                    [
                        [0, 0],
                        [0, 0],
                        [0, 0],
                        [0, 0],
                    ],
                ],
            ],
            Type = MultiPolygonGeometryType.MultiPolygon,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Geometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
