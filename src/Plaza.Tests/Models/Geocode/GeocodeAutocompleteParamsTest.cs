using System;
using Plaza.Models;
using Plaza.Models.Geocode;

namespace Plaza.Tests.Models.Geocode;

public class GeocodeAutocompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GeocodeAutocompleteParams
        {
            Q = "221B Bak",
            Format = "format",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,
        };

        string expectedQ = "221B Bak";
        string expectedFormat = "format";
        string expectedCountryCode = "xx";
        PointGeometry expectedFocus = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string expectedLang = "lang";
        string expectedLayer = "layer";
        long expectedLimit = 1;

        Assert.Equal(expectedQ, parameters.Q);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedCountryCode, parameters.CountryCode);
        Assert.Equal(expectedFocus, parameters.Focus);
        Assert.Equal(expectedLang, parameters.Lang);
        Assert.Equal(expectedLayer, parameters.Layer);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GeocodeAutocompleteParams
        {
            Q = "221B Bak",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GeocodeAutocompleteParams
        {
            Q = "221B Bak",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,

            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GeocodeAutocompleteParams { Q = "221B Bak", Format = "format" };

        Assert.Null(parameters.CountryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("country_code"));
        Assert.Null(parameters.Focus);
        Assert.False(parameters.RawBodyData.ContainsKey("focus"));
        Assert.Null(parameters.Lang);
        Assert.False(parameters.RawBodyData.ContainsKey("lang"));
        Assert.Null(parameters.Layer);
        Assert.False(parameters.RawBodyData.ContainsKey("layer"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawBodyData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GeocodeAutocompleteParams
        {
            Q = "221B Bak",
            Format = "format",

            CountryCode = null,
            Focus = null,
            Lang = null,
            Layer = null,
            Limit = null,
        };

        Assert.Null(parameters.CountryCode);
        Assert.True(parameters.RawBodyData.ContainsKey("country_code"));
        Assert.Null(parameters.Focus);
        Assert.True(parameters.RawBodyData.ContainsKey("focus"));
        Assert.Null(parameters.Lang);
        Assert.True(parameters.RawBodyData.ContainsKey("lang"));
        Assert.Null(parameters.Layer);
        Assert.True(parameters.RawBodyData.ContainsKey("layer"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawBodyData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        GeocodeAutocompleteParams parameters = new() { Q = "221B Bak", Format = "format" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://plaza.fyi/api/v1/geocode/autocomplete?format=format"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GeocodeAutocompleteParams
        {
            Q = "221B Bak",
            Format = "format",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,
        };

        GeocodeAutocompleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
