using System;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class RoutingNearestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RoutingNearestParams
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

        Assert.Equal(expectedGeometry, parameters.Geometry);
        Assert.Equal(expectedRadius, parameters.Radius);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RoutingNearestParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        };

        Assert.Null(parameters.Radius);
        Assert.False(parameters.RawBodyData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RoutingNearestParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },

            Radius = null,
        };

        Assert.Null(parameters.Radius);
        Assert.True(parameters.RawBodyData.ContainsKey("radius"));
    }

    [Fact]
    public void Url_Works()
    {
        RoutingNearestParams parameters = new()
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/nearest"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RoutingNearestParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Radius = 1,
        };

        RoutingNearestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
