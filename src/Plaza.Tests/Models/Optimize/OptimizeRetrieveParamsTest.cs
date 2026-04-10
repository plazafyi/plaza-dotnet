using System;
using Plaza.Models.Optimize;

namespace Plaza.Tests.Models.Optimize;

public class OptimizeRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OptimizeRetrieveParams { JobID = "job_id" };

        string expectedJobID = "job_id";

        Assert.Equal(expectedJobID, parameters.JobID);
    }

    [Fact]
    public void Url_Works()
    {
        OptimizeRetrieveParams parameters = new() { JobID = "job_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://plaza.fyi/api/v1/optimize/job_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OptimizeRetrieveParams { JobID = "job_id" };

        OptimizeRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
