using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Geocode;

namespace Plaza.Tests.Models.Geocode;

public class GeocodeResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeocodeResult
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
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
            Type = GeocodeResultType.FeatureCollection,
        };

        List<GeocodingFeature> expectedFeatures =
        [
            new()
            {
                Geometry = new PointGeometry()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = PointGeometryType.Point,
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
        ApiEnum<string, GeocodeResultType> expectedType = GeocodeResultType.FeatureCollection;

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
        var model = new GeocodeResult
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
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
            Type = GeocodeResultType.FeatureCollection,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeocodeResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GeocodeResult
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
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
            Type = GeocodeResultType.FeatureCollection,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeocodeResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GeocodingFeature> expectedFeatures =
        [
            new()
            {
                Geometry = new PointGeometry()
                {
                    Coordinates = [2.3522, 48.8566],
                    Type = PointGeometryType.Point,
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
        ApiEnum<string, GeocodeResultType> expectedType = GeocodeResultType.FeatureCollection;

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
        var model = new GeocodeResult
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
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
            Type = GeocodeResultType.FeatureCollection,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GeocodeResult
        {
            Features =
            [
                new()
                {
                    Geometry = new PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = PointGeometryType.Point,
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
            Type = GeocodeResultType.FeatureCollection,
        };

        GeocodeResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GeocodeResultTypeTest : TestBase
{
    [Theory]
    [InlineData(GeocodeResultType.FeatureCollection)]
    public void Validation_Works(GeocodeResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GeocodeResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GeocodeResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GeocodeResultType.FeatureCollection)]
    public void SerializationRoundtrip_Works(GeocodeResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GeocodeResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GeocodeResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GeocodeResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GeocodeResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
