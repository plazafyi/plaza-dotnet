using System.Threading.Tasks;
using Plaza.Models.Features;

namespace Plaza.Tests.Services;

public class FeatureServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var geoJsonFeature = await this.client.Features.Retrieve(
            0,
            new() { Type = "type" },
            TestContext.Current.CancellationToken
        );
        geoJsonFeature.Validate();
    }

    [Fact]
    public async Task Batch_Works()
    {
        var featureCollection = await this.client.Features.Batch(
            new()
            {
                Elements =
                [
                    new() { ID = 21154906, Type = Type.Node },
                    new() { ID = 4589123, Type = Type.Way },
                ],
            },
            TestContext.Current.CancellationToken
        );
        featureCollection.Validate();
    }

    [Fact]
    public async Task Query_Works()
    {
        var featureCollection = await this.client.Features.Query(
            new(),
            TestContext.Current.CancellationToken
        );
        featureCollection.Validate();
    }
}
