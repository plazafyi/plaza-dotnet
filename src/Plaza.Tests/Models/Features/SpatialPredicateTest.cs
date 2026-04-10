using System.Text.Json;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Features;

namespace Plaza.Tests.Models.Features;

public class SpatialPredicateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpatialPredicate
        {
            Around = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Contains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Crosses = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Intersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotContains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotIntersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotWithin = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Radius = 500,
            Touches = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Within = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        Geometry expectedAround = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedContains = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedCrosses = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedIntersects = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedNotContains = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedNotIntersects = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedNotWithin = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        double expectedRadius = 500;
        Geometry expectedTouches = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedWithin = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        Assert.Equal(expectedAround, model.Around);
        Assert.Equal(expectedContains, model.Contains);
        Assert.Equal(expectedCrosses, model.Crosses);
        Assert.Equal(expectedIntersects, model.Intersects);
        Assert.Equal(expectedNotContains, model.NotContains);
        Assert.Equal(expectedNotIntersects, model.NotIntersects);
        Assert.Equal(expectedNotWithin, model.NotWithin);
        Assert.Equal(expectedRadius, model.Radius);
        Assert.Equal(expectedTouches, model.Touches);
        Assert.Equal(expectedWithin, model.Within);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SpatialPredicate
        {
            Around = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Contains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Crosses = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Intersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotContains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotIntersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotWithin = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Radius = 500,
            Touches = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Within = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpatialPredicate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpatialPredicate
        {
            Around = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Contains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Crosses = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Intersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotContains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotIntersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotWithin = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Radius = 500,
            Touches = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Within = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpatialPredicate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Geometry expectedAround = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedContains = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedCrosses = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedIntersects = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedNotContains = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedNotIntersects = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedNotWithin = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        double expectedRadius = 500;
        Geometry expectedTouches = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Geometry expectedWithin = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        Assert.Equal(expectedAround, deserialized.Around);
        Assert.Equal(expectedContains, deserialized.Contains);
        Assert.Equal(expectedCrosses, deserialized.Crosses);
        Assert.Equal(expectedIntersects, deserialized.Intersects);
        Assert.Equal(expectedNotContains, deserialized.NotContains);
        Assert.Equal(expectedNotIntersects, deserialized.NotIntersects);
        Assert.Equal(expectedNotWithin, deserialized.NotWithin);
        Assert.Equal(expectedRadius, deserialized.Radius);
        Assert.Equal(expectedTouches, deserialized.Touches);
        Assert.Equal(expectedWithin, deserialized.Within);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SpatialPredicate
        {
            Around = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Contains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Crosses = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Intersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotContains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotIntersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotWithin = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Radius = 500,
            Touches = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Within = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SpatialPredicate { };

        Assert.Null(model.Around);
        Assert.False(model.RawData.ContainsKey("around"));
        Assert.Null(model.Contains);
        Assert.False(model.RawData.ContainsKey("contains"));
        Assert.Null(model.Crosses);
        Assert.False(model.RawData.ContainsKey("crosses"));
        Assert.Null(model.Intersects);
        Assert.False(model.RawData.ContainsKey("intersects"));
        Assert.Null(model.NotContains);
        Assert.False(model.RawData.ContainsKey("not_contains"));
        Assert.Null(model.NotIntersects);
        Assert.False(model.RawData.ContainsKey("not_intersects"));
        Assert.Null(model.NotWithin);
        Assert.False(model.RawData.ContainsKey("not_within"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
        Assert.Null(model.Touches);
        Assert.False(model.RawData.ContainsKey("touches"));
        Assert.Null(model.Within);
        Assert.False(model.RawData.ContainsKey("within"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SpatialPredicate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SpatialPredicate
        {
            // Null should be interpreted as omitted for these properties
            Around = null,
            Contains = null,
            Crosses = null,
            Intersects = null,
            NotContains = null,
            NotIntersects = null,
            NotWithin = null,
            Radius = null,
            Touches = null,
            Within = null,
        };

        Assert.Null(model.Around);
        Assert.False(model.RawData.ContainsKey("around"));
        Assert.Null(model.Contains);
        Assert.False(model.RawData.ContainsKey("contains"));
        Assert.Null(model.Crosses);
        Assert.False(model.RawData.ContainsKey("crosses"));
        Assert.Null(model.Intersects);
        Assert.False(model.RawData.ContainsKey("intersects"));
        Assert.Null(model.NotContains);
        Assert.False(model.RawData.ContainsKey("not_contains"));
        Assert.Null(model.NotIntersects);
        Assert.False(model.RawData.ContainsKey("not_intersects"));
        Assert.Null(model.NotWithin);
        Assert.False(model.RawData.ContainsKey("not_within"));
        Assert.Null(model.Radius);
        Assert.False(model.RawData.ContainsKey("radius"));
        Assert.Null(model.Touches);
        Assert.False(model.RawData.ContainsKey("touches"));
        Assert.Null(model.Within);
        Assert.False(model.RawData.ContainsKey("within"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SpatialPredicate
        {
            // Null should be interpreted as omitted for these properties
            Around = null,
            Contains = null,
            Crosses = null,
            Intersects = null,
            NotContains = null,
            NotIntersects = null,
            NotWithin = null,
            Radius = null,
            Touches = null,
            Within = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SpatialPredicate
        {
            Around = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Contains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Crosses = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Intersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotContains = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotIntersects = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            NotWithin = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Radius = 500,
            Touches = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Within = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
        };

        SpatialPredicate copied = new(model);

        Assert.Equal(model, copied);
    }
}
