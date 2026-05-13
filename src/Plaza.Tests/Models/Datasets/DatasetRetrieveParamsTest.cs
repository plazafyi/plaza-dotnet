using System;
using Plaza.Models.Datasets;

namespace Plaza.Tests.Models.Datasets;

public class DatasetRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DatasetRetrieveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DatasetRetrieveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/datasets/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DatasetRetrieveParams { ID = "id" };

        DatasetRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
