using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Geocode;

namespace Plaza.Tests.Models.Geocode;

public class GeocodingFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeocodingFeature
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
        };

        Geometry expectedGeometry = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Properties expectedProperties = new()
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
        };
        ApiEnum<string, GeocodingFeatureType> expectedType = GeocodingFeatureType.Feature;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedProperties, model.Properties);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GeocodingFeature
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeocodingFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GeocodingFeature
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeocodingFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Geometry expectedGeometry = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        Properties expectedProperties = new()
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
        };
        ApiEnum<string, GeocodingFeatureType> expectedType = GeocodingFeatureType.Feature;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedProperties, deserialized.Properties);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GeocodingFeature
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GeocodingFeature
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
        };

        GeocodingFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PropertiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Properties
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
        };

        string expectedDisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom";
        string expectedCategory = "restaurant";
        string expectedCity = "London";
        double expectedConfidence = 0;
        string expectedCountry = "United Kingdom";
        string expectedCountryCode = "GB";
        double expectedDistanceM = 0;
        string expectedFullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom";
        string expectedHouseNumber = "221B";
        bool expectedInterpolated = true;
        string expectedName = "Eiffel Tower";
        long expectedOsmID = 21154906;
        ApiEnum<string, OsmType> expectedOsmType = OsmType.Node;
        string expectedPostcode = "NW1 6XE";
        double expectedScore = 0;
        ApiEnum<string, Source> expectedSource = Source.Structured;
        string expectedState = "England";
        string expectedStreet = "Baker Street";
        string expectedSubcategory = "italian";
        Dictionary<string, string> expectedTags = new() { { "foo", "string" } };
        string expectedWikipedia = "en:Eiffel Tower";

        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedDistanceM, model.DistanceM);
        Assert.Equal(expectedFullAddress, model.FullAddress);
        Assert.Equal(expectedHouseNumber, model.HouseNumber);
        Assert.Equal(expectedInterpolated, model.Interpolated);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOsmID, model.OsmID);
        Assert.Equal(expectedOsmType, model.OsmType);
        Assert.Equal(expectedPostcode, model.Postcode);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreet, model.Street);
        Assert.Equal(expectedSubcategory, model.Subcategory);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        foreach (var item in expectedTags)
        {
            Assert.True(model.Tags.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Tags[item.Key]);
        }
        Assert.Equal(expectedWikipedia, model.Wikipedia);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Properties
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Properties>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Properties
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Properties>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom";
        string expectedCategory = "restaurant";
        string expectedCity = "London";
        double expectedConfidence = 0;
        string expectedCountry = "United Kingdom";
        string expectedCountryCode = "GB";
        double expectedDistanceM = 0;
        string expectedFullAddress = "221B Baker Street, London, NW1 6XE, United Kingdom";
        string expectedHouseNumber = "221B";
        bool expectedInterpolated = true;
        string expectedName = "Eiffel Tower";
        long expectedOsmID = 21154906;
        ApiEnum<string, OsmType> expectedOsmType = OsmType.Node;
        string expectedPostcode = "NW1 6XE";
        double expectedScore = 0;
        ApiEnum<string, Source> expectedSource = Source.Structured;
        string expectedState = "England";
        string expectedStreet = "Baker Street";
        string expectedSubcategory = "italian";
        Dictionary<string, string> expectedTags = new() { { "foo", "string" } };
        string expectedWikipedia = "en:Eiffel Tower";

        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedDistanceM, deserialized.DistanceM);
        Assert.Equal(expectedFullAddress, deserialized.FullAddress);
        Assert.Equal(expectedHouseNumber, deserialized.HouseNumber);
        Assert.Equal(expectedInterpolated, deserialized.Interpolated);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOsmID, deserialized.OsmID);
        Assert.Equal(expectedOsmType, deserialized.OsmType);
        Assert.Equal(expectedPostcode, deserialized.Postcode);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreet, deserialized.Street);
        Assert.Equal(expectedSubcategory, deserialized.Subcategory);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        foreach (var item in expectedTags)
        {
            Assert.True(deserialized.Tags.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Tags[item.Key]);
        }
        Assert.Equal(expectedWikipedia, deserialized.Wikipedia);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Properties
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Properties
        {
            DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
        };

        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryCode);
        Assert.False(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.DistanceM);
        Assert.False(model.RawData.ContainsKey("distance_m"));
        Assert.Null(model.FullAddress);
        Assert.False(model.RawData.ContainsKey("full_address"));
        Assert.Null(model.HouseNumber);
        Assert.False(model.RawData.ContainsKey("house_number"));
        Assert.Null(model.Interpolated);
        Assert.False(model.RawData.ContainsKey("interpolated"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OsmID);
        Assert.False(model.RawData.ContainsKey("osm_id"));
        Assert.Null(model.OsmType);
        Assert.False(model.RawData.ContainsKey("osm_type"));
        Assert.Null(model.Postcode);
        Assert.False(model.RawData.ContainsKey("postcode"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
        Assert.Null(model.Source);
        Assert.False(model.RawData.ContainsKey("source"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.False(model.RawData.ContainsKey("street"));
        Assert.Null(model.Subcategory);
        Assert.False(model.RawData.ContainsKey("subcategory"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Wikipedia);
        Assert.False(model.RawData.ContainsKey("wikipedia"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Properties
        {
            DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Properties
        {
            DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",

            Category = null,
            City = null,
            Confidence = null,
            Country = null,
            CountryCode = null,
            DistanceM = null,
            FullAddress = null,
            HouseNumber = null,
            Interpolated = null,
            Name = null,
            OsmID = null,
            OsmType = null,
            Postcode = null,
            Score = null,
            Source = null,
            State = null,
            Street = null,
            Subcategory = null,
            Tags = null,
            Wikipedia = null,
        };

        Assert.Null(model.Category);
        Assert.True(model.RawData.ContainsKey("category"));
        Assert.Null(model.City);
        Assert.True(model.RawData.ContainsKey("city"));
        Assert.Null(model.Confidence);
        Assert.True(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Country);
        Assert.True(model.RawData.ContainsKey("country"));
        Assert.Null(model.CountryCode);
        Assert.True(model.RawData.ContainsKey("country_code"));
        Assert.Null(model.DistanceM);
        Assert.True(model.RawData.ContainsKey("distance_m"));
        Assert.Null(model.FullAddress);
        Assert.True(model.RawData.ContainsKey("full_address"));
        Assert.Null(model.HouseNumber);
        Assert.True(model.RawData.ContainsKey("house_number"));
        Assert.Null(model.Interpolated);
        Assert.True(model.RawData.ContainsKey("interpolated"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.OsmID);
        Assert.True(model.RawData.ContainsKey("osm_id"));
        Assert.Null(model.OsmType);
        Assert.True(model.RawData.ContainsKey("osm_type"));
        Assert.Null(model.Postcode);
        Assert.True(model.RawData.ContainsKey("postcode"));
        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
        Assert.Null(model.Source);
        Assert.True(model.RawData.ContainsKey("source"));
        Assert.Null(model.State);
        Assert.True(model.RawData.ContainsKey("state"));
        Assert.Null(model.Street);
        Assert.True(model.RawData.ContainsKey("street"));
        Assert.Null(model.Subcategory);
        Assert.True(model.RawData.ContainsKey("subcategory"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Wikipedia);
        Assert.True(model.RawData.ContainsKey("wikipedia"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Properties
        {
            DisplayName = "221B Baker Street, London, NW1 6XE, United Kingdom",

            Category = null,
            City = null,
            Confidence = null,
            Country = null,
            CountryCode = null,
            DistanceM = null,
            FullAddress = null,
            HouseNumber = null,
            Interpolated = null,
            Name = null,
            OsmID = null,
            OsmType = null,
            Postcode = null,
            Score = null,
            Source = null,
            State = null,
            Street = null,
            Subcategory = null,
            Tags = null,
            Wikipedia = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Properties
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
        };

        Properties copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OsmTypeTest : TestBase
{
    [Theory]
    [InlineData(OsmType.Node)]
    [InlineData(OsmType.Way)]
    [InlineData(OsmType.Relation)]
    public void Validation_Works(OsmType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OsmType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OsmType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OsmType.Node)]
    [InlineData(OsmType.Way)]
    [InlineData(OsmType.Relation)]
    public void SerializationRoundtrip_Works(OsmType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OsmType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OsmType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OsmType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OsmType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Structured)]
    [InlineData(Source.Fuzzy)]
    [InlineData(Source.Address)]
    [InlineData(Source.Place)]
    [InlineData(Source.Interpolation)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Structured)]
    [InlineData(Source.Fuzzy)]
    [InlineData(Source.Address)]
    [InlineData(Source.Place)]
    [InlineData(Source.Interpolation)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GeocodingFeatureTypeTest : TestBase
{
    [Theory]
    [InlineData(GeocodingFeatureType.Feature)]
    public void Validation_Works(GeocodingFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GeocodingFeatureType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GeocodingFeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GeocodingFeatureType.Feature)]
    public void SerializationRoundtrip_Works(GeocodingFeatureType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GeocodingFeatureType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GeocodingFeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GeocodingFeatureType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GeocodingFeatureType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
