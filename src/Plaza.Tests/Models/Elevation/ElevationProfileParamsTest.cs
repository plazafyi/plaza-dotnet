using System;
using Plaza.Models;
using Plaza.Models.Elevation;

namespace Plaza.Tests.Models.Elevation;

public class ElevationProfileParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ElevationProfileParams
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

        Assert.Equal(expectedGeometry, parameters.Geometry);
    }

    [Fact]
    public void Url_Works()
    {
        ElevationProfileParams parameters = new()
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

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://plaza.fyi/api/v1/elevation/profile"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ElevationProfileParams
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

        ElevationProfileParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
