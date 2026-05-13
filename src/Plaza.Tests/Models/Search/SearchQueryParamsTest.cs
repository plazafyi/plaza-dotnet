using System;
using Plaza.Models.Search;

namespace Plaza.Tests.Models.Search;

public class SearchQueryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "q",
            Cursor = "cursor",
            Format = "format",
            Limit = 0,
            OutputFields = "output[fields]",
            OutputInclude = "output[include]",
            OutputPrecision = 0,
            OutputSort = "output[sort]",
        };

        string expectedQ = "q";
        string expectedCursor = "cursor";
        string expectedFormat = "format";
        long expectedLimit = 0;
        string expectedOutputFields = "output[fields]";
        string expectedOutputInclude = "output[include]";
        long expectedOutputPrecision = 0;
        string expectedOutputSort = "output[sort]";

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOutputFields, parameters.OutputFields);
        Assert.Equal(expectedOutputInclude, parameters.OutputInclude);
        Assert.Equal(expectedOutputPrecision, parameters.OutputPrecision);
        Assert.Equal(expectedOutputSort, parameters.OutputSort);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SearchQueryParams { Q = "q" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.OutputFields);
        Assert.False(parameters.RawQueryData.ContainsKey("output[fields]"));
        Assert.Null(parameters.OutputInclude);
        Assert.False(parameters.RawQueryData.ContainsKey("output[include]"));
        Assert.Null(parameters.OutputPrecision);
        Assert.False(parameters.RawQueryData.ContainsKey("output[precision]"));
        Assert.Null(parameters.OutputSort);
        Assert.False(parameters.RawQueryData.ContainsKey("output[sort]"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "q",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Format = null,
            Limit = null,
            OutputFields = null,
            OutputInclude = null,
            OutputPrecision = null,
            OutputSort = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.OutputFields);
        Assert.False(parameters.RawQueryData.ContainsKey("output[fields]"));
        Assert.Null(parameters.OutputInclude);
        Assert.False(parameters.RawQueryData.ContainsKey("output[include]"));
        Assert.Null(parameters.OutputPrecision);
        Assert.False(parameters.RawQueryData.ContainsKey("output[precision]"));
        Assert.Null(parameters.OutputSort);
        Assert.False(parameters.RawQueryData.ContainsKey("output[sort]"));
    }

    [Fact]
    public void Url_Works()
    {
        SearchQueryParams parameters = new()
        {
            Q = "q",
            Cursor = "cursor",
            Format = "format",
            Limit = 0,
            OutputFields = "output[fields]",
            OutputInclude = "output[include]",
            OutputPrecision = 0,
            OutputSort = "output[sort]",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://plaza.fyi/api/v1/search?q=q&cursor=cursor&format=format&limit=0&output%5bfields%5d=output%5bfields%5d&output%5binclude%5d=output%5binclude%5d&output%5bprecision%5d=0&output%5bsort%5d=output%5bsort%5d"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SearchQueryParams
        {
            Q = "q",
            Cursor = "cursor",
            Format = "format",
            Limit = 0,
            OutputFields = "output[fields]",
            OutputInclude = "output[include]",
            OutputPrecision = 0,
            OutputSort = "output[sort]",
        };

        SearchQueryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
