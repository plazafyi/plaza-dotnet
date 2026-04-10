using System.Threading.Tasks;

namespace Plaza.Tests.Services;

public class QueryServiceTest : TestBase
{
    [Fact]
    public async Task Execute_Works()
    {
        var featureCollection = await this.client.Query.Execute(
            new()
            {
                Data =
                    "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
            },
            TestContext.Current.CancellationToken
        );
        featureCollection.Validate();
    }
}
