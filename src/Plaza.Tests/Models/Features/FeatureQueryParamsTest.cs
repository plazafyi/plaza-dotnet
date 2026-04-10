using System;
using Plaza.Models;
using Plaza.Models.Features;

namespace Plaza.Tests.Models.Features;

public class FeatureQueryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FeatureQueryParams
        {
            Cursor = "cursor",
            Format = "format",
            H3 = "h3",
            Limit = 0,
            Type = "type",
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

        string expectedCursor = "cursor";
        string expectedFormat = "format";
        string expectedH3 = "h3";
        long expectedLimit = 0;
        string expectedType = "type";
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

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedH3, parameters.H3);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedAround, parameters.Around);
        Assert.Equal(expectedContains, parameters.Contains);
        Assert.Equal(expectedCrosses, parameters.Crosses);
        Assert.Equal(expectedIntersects, parameters.Intersects);
        Assert.Equal(expectedNotContains, parameters.NotContains);
        Assert.Equal(expectedNotIntersects, parameters.NotIntersects);
        Assert.Equal(expectedNotWithin, parameters.NotWithin);
        Assert.Equal(expectedRadius, parameters.Radius);
        Assert.Equal(expectedTouches, parameters.Touches);
        Assert.Equal(expectedWithin, parameters.Within);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FeatureQueryParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.H3);
        Assert.False(parameters.RawQueryData.ContainsKey("h3"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.Around);
        Assert.False(parameters.RawBodyData.ContainsKey("around"));
        Assert.Null(parameters.Contains);
        Assert.False(parameters.RawBodyData.ContainsKey("contains"));
        Assert.Null(parameters.Crosses);
        Assert.False(parameters.RawBodyData.ContainsKey("crosses"));
        Assert.Null(parameters.Intersects);
        Assert.False(parameters.RawBodyData.ContainsKey("intersects"));
        Assert.Null(parameters.NotContains);
        Assert.False(parameters.RawBodyData.ContainsKey("not_contains"));
        Assert.Null(parameters.NotIntersects);
        Assert.False(parameters.RawBodyData.ContainsKey("not_intersects"));
        Assert.Null(parameters.NotWithin);
        Assert.False(parameters.RawBodyData.ContainsKey("not_within"));
        Assert.Null(parameters.Radius);
        Assert.False(parameters.RawBodyData.ContainsKey("radius"));
        Assert.Null(parameters.Touches);
        Assert.False(parameters.RawBodyData.ContainsKey("touches"));
        Assert.Null(parameters.Within);
        Assert.False(parameters.RawBodyData.ContainsKey("within"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FeatureQueryParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Format = null,
            H3 = null,
            Limit = null,
            Type = null,
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

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.H3);
        Assert.False(parameters.RawQueryData.ContainsKey("h3"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.Around);
        Assert.False(parameters.RawBodyData.ContainsKey("around"));
        Assert.Null(parameters.Contains);
        Assert.False(parameters.RawBodyData.ContainsKey("contains"));
        Assert.Null(parameters.Crosses);
        Assert.False(parameters.RawBodyData.ContainsKey("crosses"));
        Assert.Null(parameters.Intersects);
        Assert.False(parameters.RawBodyData.ContainsKey("intersects"));
        Assert.Null(parameters.NotContains);
        Assert.False(parameters.RawBodyData.ContainsKey("not_contains"));
        Assert.Null(parameters.NotIntersects);
        Assert.False(parameters.RawBodyData.ContainsKey("not_intersects"));
        Assert.Null(parameters.NotWithin);
        Assert.False(parameters.RawBodyData.ContainsKey("not_within"));
        Assert.Null(parameters.Radius);
        Assert.False(parameters.RawBodyData.ContainsKey("radius"));
        Assert.Null(parameters.Touches);
        Assert.False(parameters.RawBodyData.ContainsKey("touches"));
        Assert.Null(parameters.Within);
        Assert.False(parameters.RawBodyData.ContainsKey("within"));
    }

    [Fact]
    public void Url_Works()
    {
        FeatureQueryParams parameters = new()
        {
            Cursor = "cursor",
            Format = "format",
            H3 = "h3",
            Limit = 0,
            Type = "type",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://plaza.fyi/api/v1/features?cursor=cursor&format=format&h3=h3&limit=0&type=type"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FeatureQueryParams
        {
            Cursor = "cursor",
            Format = "format",
            H3 = "h3",
            Limit = 0,
            Type = "type",
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

        FeatureQueryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
