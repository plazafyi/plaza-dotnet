using System;
using System.Collections.Generic;
using Plaza.Models;
using Plaza.Models.MapMatch;

namespace Plaza.Tests.Models.MapMatch;

public class MapMatchMatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MapMatchMatchParams
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

        Assert.Equal(expectedGeometry, parameters.Geometry);
        Assert.NotNull(parameters.Radiuses);
        Assert.Equal(expectedRadiuses.Count, parameters.Radiuses.Count);
        for (int i = 0; i < expectedRadiuses.Count; i++)
        {
            Assert.Equal(expectedRadiuses[i], parameters.Radiuses[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MapMatchMatchParams
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

        Assert.Null(parameters.Radiuses);
        Assert.False(parameters.RawBodyData.ContainsKey("radiuses"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MapMatchMatchParams
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

        Assert.Null(parameters.Radiuses);
        Assert.True(parameters.RawBodyData.ContainsKey("radiuses"));
    }

    [Fact]
    public void Url_Works()
    {
        MapMatchMatchParams parameters = new()
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

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/map-match"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MapMatchMatchParams
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

        MapMatchMatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
