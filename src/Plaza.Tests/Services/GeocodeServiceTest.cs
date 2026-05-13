using System.Threading.Tasks;
using Plaza.Models;

namespace Plaza.Tests.Services;

public class GeocodeServiceTest : TestBase
{
    [Fact]
    public async Task Autocomplete_Works()
    {
        var autocompleteResult = await this.client.Geocode.Autocomplete(
            new() { Q = "221B Bak" },
            TestContext.Current.CancellationToken
        );
        autocompleteResult.Validate();
    }

    [Fact]
    public async Task Batch_Works()
    {
        var response = await this.client.Geocode.Batch(
            new() { Addresses = ["string"] },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact]
    public async Task Forward_Works()
    {
        var geocodeResult = await this.client.Geocode.Forward(
            new() { Q = "221B Baker Street, London" },
            TestContext.Current.CancellationToken
        );
        geocodeResult.Validate();
    }

    [Fact]
    public async Task Reverse_Works()
    {
        var reverseGeocodeResult = await this.client.Geocode.Reverse(
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
        reverseGeocodeResult.Validate();
    }
}
