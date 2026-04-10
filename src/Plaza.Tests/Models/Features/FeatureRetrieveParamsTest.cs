using System;
using Plaza.Models.Features;

namespace Plaza.Tests.Models.Features;

public class FeatureRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FeatureRetrieveParams { Type = "type", ID = 0 };

        string expectedType = "type";
        long expectedID = 0;

        Assert.Equal(expectedType, parameters.Type);
        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        FeatureRetrieveParams parameters = new() { Type = "type", ID = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://plaza.fyi/api/v1/features/type/0"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FeatureRetrieveParams { Type = "type", ID = 0 };

        FeatureRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
