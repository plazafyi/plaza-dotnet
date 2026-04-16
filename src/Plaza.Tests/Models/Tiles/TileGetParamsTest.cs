using System;
using Plaza.Models.Tiles;

namespace Plaza.Tests.Models.Tiles;

public class TileGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TileGetParams
        {
            Z = 0,
            X = 0,
            Y = 0,
        };

        long expectedZ = 0;
        long expectedX = 0;
        long expectedY = 0;

        Assert.Equal(expectedZ, parameters.Z);
        Assert.Equal(expectedX, parameters.X);
        Assert.Equal(expectedY, parameters.Y);
    }

    [Fact]
    public void Url_Works()
    {
        TileGetParams parameters = new()
        {
            Z = 0,
            X = 0,
            Y = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/tiles/0/0/0"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TileGetParams
        {
            Z = 0,
            X = 0,
            Y = 0,
        };

        TileGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
