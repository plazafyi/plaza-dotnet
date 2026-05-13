using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Models;
using Plaza.Models.Geocode;

namespace Plaza.Tests.Models.Geocode;

public class GeocodeBatchResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GeocodeBatchResponse
        {
            Count = 0,
            Results =
            [
                new()
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
                },
            ],
        };

        long expectedCount = 0;
        List<GeocodeResult> expectedResults =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GeocodeBatchResponse
        {
            Count = 0,
            Results =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeocodeBatchResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GeocodeBatchResponse
        {
            Count = 0,
            Results =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GeocodeBatchResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCount = 0;
        List<GeocodeResult> expectedResults =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GeocodeBatchResponse
        {
            Count = 0,
            Results =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GeocodeBatchResponse
        {
            Count = 0,
            Results =
            [
                new()
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
                },
            ],
        };

        GeocodeBatchResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
