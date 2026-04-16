using System;
using Plaza.Models.Query;

namespace Plaza.Tests.Models.Query;

public class QueryExecuteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QueryExecuteParams
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
            Format = "format",
        };

        string expectedData =
            "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));";
        string expectedFormat = "format";

        Assert.Equal(expectedData, parameters.Data);
        Assert.Equal(expectedFormat, parameters.Format);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QueryExecuteParams
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new QueryExecuteParams
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",

            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void Url_Works()
    {
        QueryExecuteParams parameters = new()
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
            Format = "format",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/query?format=format"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QueryExecuteParams
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
            Format = "format",
        };

        QueryExecuteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
