using System;
using Plaza.Models.Datasets;

namespace Plaza.Tests.Models.Datasets;

public class DatasetDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DatasetDeleteParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DatasetDeleteParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/datasets/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DatasetDeleteParams { ID = "id" };

        DatasetDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
