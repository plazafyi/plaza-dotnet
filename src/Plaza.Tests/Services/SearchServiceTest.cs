using System.Threading.Tasks;

namespace Plaza.Tests.Services;

public class SearchServiceTest : TestBase
{
    [Fact]
    public async Task Query_Works()
    {
        var featureCollection = await this.client.Search.Query(
            new() { Q = "q" },
            TestContext.Current.CancellationToken
        );
        featureCollection.Validate();
    }
}
