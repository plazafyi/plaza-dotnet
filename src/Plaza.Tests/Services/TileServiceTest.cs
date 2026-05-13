using System.Threading.Tasks;

namespace Plaza.Tests.Services;

public class TileServiceTest : TestBase
{
    [Fact]
    public async Task Get_Works()
    {
        await this.client.Tiles.Get(
            0,
            new() { Z = 0, X = 0 },
            TestContext.Current.CancellationToken
        );
    }
}
