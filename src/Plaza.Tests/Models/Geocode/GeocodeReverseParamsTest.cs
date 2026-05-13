using System;
using Plaza.Models;
using Plaza.Models.Geocode;

namespace Plaza.Tests.Models.Geocode;

public class GeocodeReverseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GeocodeReverseParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
            Lang = "lang",
            Limit = 1,
            Radius = 1,
        };

        PointGeometry expectedGeometry = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string expectedFormat = "format";
        string expectedLang = "lang";
        long expectedLimit = 1;
        double expectedRadius = 1;

        Assert.Equal(expectedGeometry, parameters.Geometry);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedLang, parameters.Lang);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedRadius, parameters.Radius);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GeocodeReverseParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Limit = 1,
            Radius = 1,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GeocodeReverseParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Limit = 1,
            Radius = 1,

            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GeocodeReverseParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
        };

        Assert.Null(parameters.Lang);
        Assert.False(parameters.RawBodyData.ContainsKey("lang"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Radius);
        Assert.False(parameters.RawBodyData.ContainsKey("radius"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GeocodeReverseParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",

            Lang = null,
            Limit = null,
            Radius = null,
        };

        Assert.Null(parameters.Lang);
        Assert.True(parameters.RawBodyData.ContainsKey("lang"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawBodyData.ContainsKey("limit"));
        Assert.Null(parameters.Radius);
        Assert.True(parameters.RawBodyData.ContainsKey("radius"));
    }

    [Fact]
    public void Url_Works()
    {
        GeocodeReverseParams parameters = new()
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://plaza.fyi/api/v1/geocode/reverse?format=format"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GeocodeReverseParams
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
            Lang = "lang",
            Limit = 1,
            Radius = 1,
        };

        GeocodeReverseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
