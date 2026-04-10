using System.Threading.Tasks;

namespace Plaza.Tests.Services;

public class DatasetServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var dataset = await this.client.Datasets.Create(
            new() { Name = "NYC Bike Lanes", Slug = "nyc-bike-lanes" },
            TestContext.Current.CancellationToken
        );
        dataset.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var dataset = await this.client.Datasets.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        dataset.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var datasetList = await this.client.Datasets.List(
            new(),
            TestContext.Current.CancellationToken
        );
        datasetList.Validate();
    }

    [Fact]
    public async Task Delete_Works()
    {
        await this.client.Datasets.Delete("id", new(), TestContext.Current.CancellationToken);
    }
}
