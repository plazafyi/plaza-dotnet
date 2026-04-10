using System;
using Plaza.Models.Datasets;

namespace Plaza.Tests.Models.Datasets;

public class DatasetListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DatasetListParams { Scope = "scope" };

        string expectedScope = "scope";

        Assert.Equal(expectedScope, parameters.Scope);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DatasetListParams { };

        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DatasetListParams
        {
            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawQueryData.ContainsKey("scope"));
    }

    [Fact]
    public void Url_Works()
    {
        DatasetListParams parameters = new() { Scope = "scope" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://plaza.fyi/api/v1/datasets?scope=scope"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DatasetListParams { Scope = "scope" };

        DatasetListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
