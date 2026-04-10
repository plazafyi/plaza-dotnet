using System;
using System.Collections.Generic;
using Plaza.Models.Geocode;

namespace Plaza.Tests.Models.Geocode;

public class GeocodeBatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GeocodeBatchParams { Addresses = ["string"] };

        List<string> expectedAddresses = ["string"];

        Assert.Equal(expectedAddresses.Count, parameters.Addresses.Count);
        for (int i = 0; i < expectedAddresses.Count; i++)
        {
            Assert.Equal(expectedAddresses[i], parameters.Addresses[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        GeocodeBatchParams parameters = new() { Addresses = ["string"] };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://plaza.fyi/api/v1/geocode/batch"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GeocodeBatchParams { Addresses = ["string"] };

        GeocodeBatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
