using System.Threading.Tasks;
using Plaza.Models;

namespace Plaza.Tests.Services;

public class MapMatchServiceTest : TestBase
{
    [Fact]
    public async Task Match_Works()
    {
        var mapMatchResult = await this.client.MapMatch.Match(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        mapMatchResult.Validate();
    }
}
