using System.Text.Json;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Geocode;

namespace Plaza.Tests.Models.Geocode;

public class AutocompleteRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteRequest
        {
            Q = "221B Bak",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,
        };

        string expectedQ = "221B Bak";
        string expectedCountryCode = "xx";
        PointGeometry expectedFocus = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string expectedLang = "lang";
        string expectedLayer = "layer";
        long expectedLimit = 1;

        Assert.Equal(expectedQ, model.Q);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedFocus, model.Focus);
        Assert.Equal(expectedLang, model.Lang);
        Assert.Equal(expectedLayer, model.Layer);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteRequest
        {
            Q = "221B Bak",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteRequest
        {
            Q = "221B Bak",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedQ = "221B Bak";
        string expectedCountryCode = "xx";
        PointGeometry expectedFocus = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string expectedLang = "lang";
        string expectedLayer = "layer";
        long expectedLimit = 1;

        Assert.Equal(expectedQ, deserialized.Q);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedFocus, deserialized.Focus);
        Assert.Equal(expectedLang, deserialized.Lang);
        Assert.Equal(expectedLayer, deserialized.Layer);
        Assert.Equal(expectedLimit, deserialized.Limit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteRequest
        {
            Q = "221B Bak",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutocompleteRequest { Q = "221B Bak" };

        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.Focus);
        Assert.False(model.RawData.ContainsKey("focus"));
        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
        Assert.Null(model.Layer);
        Assert.False(model.RawData.ContainsKey("layer"));
        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutocompleteRequest { Q = "221B Bak" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AutocompleteRequest
        {
            Q = "221B Bak",

            CountryCode = null,
            Focus = null,
            Lang = null,
            Layer = null,
            Limit = null,
        };

        Assert.Null(model.CountryCode);
        Assert.True(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.Focus);
        Assert.True(model.RawData.ContainsKey("focus"));
        Assert.Null(model.Lang);
        Assert.True(model.RawData.ContainsKey("lang"));
        Assert.Null(model.Layer);
        Assert.True(model.RawData.ContainsKey("layer"));
        Assert.Null(model.Limit);
        Assert.True(model.RawData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutocompleteRequest
        {
            Q = "221B Bak",

            CountryCode = null,
            Focus = null,
            Lang = null,
            Layer = null,
            Limit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteRequest
        {
            Q = "221B Bak",
            CountryCode = "xx",
            Focus = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Lang = "lang",
            Layer = "layer",
            Limit = 1,
        };

        AutocompleteRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
