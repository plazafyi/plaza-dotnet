using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Geocode;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.Geocode;

public class AutocompleteResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutocompleteResult
        {
            Features =
            [
                new()
                {
                    Geometry = new Models::PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = Models::PointGeometryType.Point,
                    },
                    Properties = new()
                    {
                        DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        Category = "restaurant",
                        City = "London",
                        Confidence = 0,
                        Country = "United Kingdom",
                        CountryCode = "GB",
                        DistanceM = 0,
                        FullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        HouseNumber = "221B",
                        Interpolated = true,
                        Name = "Eiffel Tower",
                        OsmID = 21154906,
                        OsmType = OsmType.Node,
                        Postcode = "NW1 6XE",
                        Score = 0,
                        Source = Source.Structured,
                        State = "England",
                        Street = "Baker Street",
                        Subcategory = "italian",
                        Tags = new Dictionary<string, string>() { { "foo", "string" } },
                        Wikipedia = "en:Eiffel Tower",
                    },
                    Type = GeocodingFeatureType.Feature,
                },
            ],
            Type = Type.FeatureCollection,
        };

        List<GeocodingFeature> expectedFeatures =
        [
            new()
            {
                Geometry = new Models::PointGeometry()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = Models::PointGeometryType.Point,
                },
                Properties = new()
                {
                    DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
                    Category = "restaurant",
                    City = "London",
                    Confidence = 0,
                    Country = "United Kingdom",
                    CountryCode = "GB",
                    DistanceM = 0,
                    FullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom",
                    HouseNumber = "221B",
                    Interpolated = true,
                    Name = "Eiffel Tower",
                    OsmID = 21154906,
                    OsmType = OsmType.Node,
                    Postcode = "NW1 6XE",
                    Score = 0,
                    Source = Source.Structured,
                    State = "England",
                    Street = "Baker Street",
                    Subcategory = "italian",
                    Tags = new Dictionary<string, string>() { { "foo", "string" } },
                    Wikipedia = "en:Eiffel Tower",
                },
                Type = GeocodingFeatureType.Feature,
            },
        ];
        ApiEnum<string, Type> expectedType = Type.FeatureCollection;

        Assert.Equal(expectedFeatures.Count, model.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], model.Features[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutocompleteResult
        {
            Features =
            [
                new()
                {
                    Geometry = new Models::PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = Models::PointGeometryType.Point,
                    },
                    Properties = new()
                    {
                        DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        Category = "restaurant",
                        City = "London",
                        Confidence = 0,
                        Country = "United Kingdom",
                        CountryCode = "GB",
                        DistanceM = 0,
                        FullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        HouseNumber = "221B",
                        Interpolated = true,
                        Name = "Eiffel Tower",
                        OsmID = 21154906,
                        OsmType = OsmType.Node,
                        Postcode = "NW1 6XE",
                        Score = 0,
                        Source = Source.Structured,
                        State = "England",
                        Street = "Baker Street",
                        Subcategory = "italian",
                        Tags = new Dictionary<string, string>() { { "foo", "string" } },
                        Wikipedia = "en:Eiffel Tower",
                    },
                    Type = GeocodingFeatureType.Feature,
                },
            ],
            Type = Type.FeatureCollection,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutocompleteResult
        {
            Features =
            [
                new()
                {
                    Geometry = new Models::PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = Models::PointGeometryType.Point,
                    },
                    Properties = new()
                    {
                        DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        Category = "restaurant",
                        City = "London",
                        Confidence = 0,
                        Country = "United Kingdom",
                        CountryCode = "GB",
                        DistanceM = 0,
                        FullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        HouseNumber = "221B",
                        Interpolated = true,
                        Name = "Eiffel Tower",
                        OsmID = 21154906,
                        OsmType = OsmType.Node,
                        Postcode = "NW1 6XE",
                        Score = 0,
                        Source = Source.Structured,
                        State = "England",
                        Street = "Baker Street",
                        Subcategory = "italian",
                        Tags = new Dictionary<string, string>() { { "foo", "string" } },
                        Wikipedia = "en:Eiffel Tower",
                    },
                    Type = GeocodingFeatureType.Feature,
                },
            ],
            Type = Type.FeatureCollection,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutocompleteResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GeocodingFeature> expectedFeatures =
        [
            new()
            {
                Geometry = new Models::PointGeometry()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = Models::PointGeometryType.Point,
                },
                Properties = new()
                {
                    DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
                    Category = "restaurant",
                    City = "London",
                    Confidence = 0,
                    Country = "United Kingdom",
                    CountryCode = "GB",
                    DistanceM = 0,
                    FullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom",
                    HouseNumber = "221B",
                    Interpolated = true,
                    Name = "Eiffel Tower",
                    OsmID = 21154906,
                    OsmType = OsmType.Node,
                    Postcode = "NW1 6XE",
                    Score = 0,
                    Source = Source.Structured,
                    State = "England",
                    Street = "Baker Street",
                    Subcategory = "italian",
                    Tags = new Dictionary<string, string>() { { "foo", "string" } },
                    Wikipedia = "en:Eiffel Tower",
                },
                Type = GeocodingFeatureType.Feature,
            },
        ];
        ApiEnum<string, Type> expectedType = Type.FeatureCollection;

        Assert.Equal(expectedFeatures.Count, deserialized.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], deserialized.Features[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutocompleteResult
        {
            Features =
            [
                new()
                {
                    Geometry = new Models::PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = Models::PointGeometryType.Point,
                    },
                    Properties = new()
                    {
                        DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        Category = "restaurant",
                        City = "London",
                        Confidence = 0,
                        Country = "United Kingdom",
                        CountryCode = "GB",
                        DistanceM = 0,
                        FullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        HouseNumber = "221B",
                        Interpolated = true,
                        Name = "Eiffel Tower",
                        OsmID = 21154906,
                        OsmType = OsmType.Node,
                        Postcode = "NW1 6XE",
                        Score = 0,
                        Source = Source.Structured,
                        State = "England",
                        Street = "Baker Street",
                        Subcategory = "italian",
                        Tags = new Dictionary<string, string>() { { "foo", "string" } },
                        Wikipedia = "en:Eiffel Tower",
                    },
                    Type = GeocodingFeatureType.Feature,
                },
            ],
            Type = Type.FeatureCollection,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutocompleteResult
        {
            Features =
            [
                new()
                {
                    Geometry = new Models::PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = Models::PointGeometryType.Point,
                    },
                    Properties = new()
                    {
                        DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        Category = "restaurant",
                        City = "London",
                        Confidence = 0,
                        Country = "United Kingdom",
                        CountryCode = "GB",
                        DistanceM = 0,
                        FullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom",
                        HouseNumber = "221B",
                        Interpolated = true,
                        Name = "Eiffel Tower",
                        OsmID = 21154906,
                        OsmType = OsmType.Node,
                        Postcode = "NW1 6XE",
                        Score = 0,
                        Source = Source.Structured,
                        State = "England",
                        Street = "Baker Street",
                        Subcategory = "italian",
                        Tags = new Dictionary<string, string>() { { "foo", "string" } },
                        Wikipedia = "en:Eiffel Tower",
                    },
                    Type = GeocodingFeatureType.Feature,
                },
            ],
            Type = Type.FeatureCollection,
        };

        AutocompleteResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.FeatureCollection)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.FeatureCollection)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
