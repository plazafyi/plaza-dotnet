using System;
using Plaza.Models.Datasets;

namespace Plaza.Tests.Models.Datasets;

public class DatasetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DatasetCreateParams
        {
            Name = "NYC Bike Lanes",
            Slug = "nyc-bike-lanes",
            Attribution = "attribution",
            Description = "description",
            License = "license",
            SourceUrl = "https://example.com",
            StrictMode = true,
        };

        string expectedName = "NYC Bike Lanes";
        string expectedSlug = "nyc-bike-lanes";
        string expectedAttribution = "attribution";
        string expectedDescription = "description";
        string expectedLicense = "license";
        string expectedSourceUrl = "https://example.com";
        bool expectedStrictMode = true;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSlug, parameters.Slug);
        Assert.Equal(expectedAttribution, parameters.Attribution);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedLicense, parameters.License);
        Assert.Equal(expectedSourceUrl, parameters.SourceUrl);
        Assert.Equal(expectedStrictMode, parameters.StrictMode);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DatasetCreateParams
        {
            Name = "NYC Bike Lanes",
            Slug = "nyc-bike-lanes",
        };

        Assert.Null(parameters.Attribution);
        Assert.False(parameters.RawBodyData.ContainsKey("attribution"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.License);
        Assert.False(parameters.RawBodyData.ContainsKey("license"));
        Assert.Null(parameters.SourceUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("source_url"));
        Assert.Null(parameters.StrictMode);
        Assert.False(parameters.RawBodyData.ContainsKey("strict_mode"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DatasetCreateParams
        {
            Name = "NYC Bike Lanes",
            Slug = "nyc-bike-lanes",

            Attribution = null,
            Description = null,
            License = null,
            SourceUrl = null,
            StrictMode = null,
        };

        Assert.Null(parameters.Attribution);
        Assert.True(parameters.RawBodyData.ContainsKey("attribution"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.License);
        Assert.True(parameters.RawBodyData.ContainsKey("license"));
        Assert.Null(parameters.SourceUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("source_url"));
        Assert.Null(parameters.StrictMode);
        Assert.True(parameters.RawBodyData.ContainsKey("strict_mode"));
    }

    [Fact]
    public void Url_Works()
    {
        DatasetCreateParams parameters = new() { Name = "NYC Bike Lanes", Slug = "nyc-bike-lanes" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/datasets"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DatasetCreateParams
        {
            Name = "NYC Bike Lanes",
            Slug = "nyc-bike-lanes",
            Attribution = "attribution",
            Description = "description",
            License = "license",
            SourceUrl = "https://example.com",
            StrictMode = true,
        };

        DatasetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
