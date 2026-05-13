using System.Threading.Tasks;
using Plaza.Models;

namespace Plaza.Tests.Services;

public class OptimizeServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var optimizeResult = await this.client.Optimize.Create(
            new()
            {
                Waypoints = new()
                {
                    Coordinates =
                    [
                        [2.3522, 48.8566],
                        [2.3376, 48.8606],
                        [2.2945, 48.8584],
                    ],
                    Type = MultiPointGeometryType.MultiPoint,
                },
            },
            TestContext.Current.CancellationToken
        );
        optimizeResult.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var optimizeJobStatus = await this.client.Optimize.Retrieve(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        optimizeJobStatus.Validate();
    }
}
