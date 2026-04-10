using System.Threading.Tasks;
using Plaza.Models;

namespace Plaza.Tests.Services;

public class RoutingServiceTest : TestBase
{
    [Fact]
    public async Task Isochrone_Works()
    {
        var response = await this.client.Routing.Isochrone(
            new()
            {
                Geometry = new()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = PointGeometryType.Point,
                },
                Time = [1],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Matrix_Works()
    {
        await this.client.Routing.Matrix(
            new()
            {
                Destinations =
                [
                    new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
                ],
                Origins =
                [
                    new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                    new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact]
    public async Task Nearest_Works()
    {
        var nearestResult = await this.client.Routing.Nearest(
            new()
            {
                Geometry = new()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = PointGeometryType.Point,
                },
            },
            TestContext.Current.CancellationToken
        );
        nearestResult.Validate();
    }

    [Fact]
    public async Task Route_Works()
    {
        var routeResult = await this.client.Routing.Route(
            new()
            {
                Destination = new()
                {
                    Coordinates = [2.2945, 48.8584],
                    Type = PointGeometryType.Point,
                },
                Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            },
            TestContext.Current.CancellationToken
        );
        routeResult.Validate();
    }
}
