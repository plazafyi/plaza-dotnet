using System.Threading.Tasks;
using Plaza.Models;

namespace Plaza.Tests.Services;

public class ElevationServiceTest : TestBase
{
    [Fact]
    public async Task Lookup_Works()
    {
        var elevationLookupResult = await this.client.Elevation.Lookup(
            new()
            {
                Geometry = new PointGeometry()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = PointGeometryType.Point,
                },
            },
            TestContext.Current.CancellationToken
        );
        elevationLookupResult.Validate();
    }

    [Fact]
    public async Task Profile_Works()
    {
        var elevationProfileResult = await this.client.Elevation.Profile(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        elevationProfileResult.Validate();
    }
}
