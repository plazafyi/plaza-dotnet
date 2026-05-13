using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.MapMatch;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.MapMatch;

public class MapMatchResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MapMatchResult
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
                        DistanceM = 0,
                        EdgeID = 0,
                        MatchingsIndex = 0,
                        Name = "name",
                        Original = [0, 0],
                        WaypointIndex = 0,
                    },
                    Type = Type.Feature,
                },
            ],
            Matchings =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Type = MapMatchResultType.FeatureCollection,
        };

        List<Feature> expectedFeatures =
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
                    DistanceM = 0,
                    EdgeID = 0,
                    MatchingsIndex = 0,
                    Name = "name",
                    Original = [0, 0],
                    WaypointIndex = 0,
                },
                Type = Type.Feature,
            },
        ];
        List<Dictionary<string, JsonElement>> expectedMatchings =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        ApiEnum<string, MapMatchResultType> expectedType = MapMatchResultType.FeatureCollection;

        Assert.Equal(expectedFeatures.Count, model.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], model.Features[i]);
        }
        Assert.Equal(expectedMatchings.Count, model.Matchings.Count);
        for (int i = 0; i < expectedMatchings.Count; i++)
        {
            Assert.Equal(expectedMatchings[i].Count, model.Matchings[i].Count);
            foreach (var item in expectedMatchings[i])
            {
                Assert.True(model.Matchings[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.Matchings[i][item.Key]));
            }
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MapMatchResult
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
                        DistanceM = 0,
                        EdgeID = 0,
                        MatchingsIndex = 0,
                        Name = "name",
                        Original = [0, 0],
                        WaypointIndex = 0,
                    },
                    Type = Type.Feature,
                },
            ],
            Matchings =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Type = MapMatchResultType.FeatureCollection,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MapMatchResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MapMatchResult
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
                        DistanceM = 0,
                        EdgeID = 0,
                        MatchingsIndex = 0,
                        Name = "name",
                        Original = [0, 0],
                        WaypointIndex = 0,
                    },
                    Type = Type.Feature,
                },
            ],
            Matchings =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Type = MapMatchResultType.FeatureCollection,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MapMatchResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Feature> expectedFeatures =
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
                    DistanceM = 0,
                    EdgeID = 0,
                    MatchingsIndex = 0,
                    Name = "name",
                    Original = [0, 0],
                    WaypointIndex = 0,
                },
                Type = Type.Feature,
            },
        ];
        List<Dictionary<string, JsonElement>> expectedMatchings =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        ApiEnum<string, MapMatchResultType> expectedType = MapMatchResultType.FeatureCollection;

        Assert.Equal(expectedFeatures.Count, deserialized.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], deserialized.Features[i]);
        }
        Assert.Equal(expectedMatchings.Count, deserialized.Matchings.Count);
        for (int i = 0; i < expectedMatchings.Count; i++)
        {
            Assert.Equal(expectedMatchings[i].Count, deserialized.Matchings[i].Count);
            foreach (var item in expectedMatchings[i])
            {
                Assert.True(deserialized.Matchings[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.Matchings[i][item.Key]));
            }
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MapMatchResult
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
                        DistanceM = 0,
                        EdgeID = 0,
                        MatchingsIndex = 0,
                        Name = "name",
                        Original = [0, 0],
                        WaypointIndex = 0,
                    },
                    Type = Type.Feature,
                },
            ],
            Matchings =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Type = MapMatchResultType.FeatureCollection,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MapMatchResult
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
                        DistanceM = 0,
                        EdgeID = 0,
                        MatchingsIndex = 0,
                        Name = "name",
                        Original = [0, 0],
                        WaypointIndex = 0,
                    },
                    Type = Type.Feature,
                },
            ],
            Matchings =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Type = MapMatchResultType.FeatureCollection,
        };

        MapMatchResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Feature
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 0,
                EdgeID = 0,
                MatchingsIndex = 0,
                Name = "name",
                Original = [0, 0],
                WaypointIndex = 0,
            },
            Type = Type.Feature,
        };

        Models::Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        Properties expectedProperties = new()
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Name = "name",
            Original = [0, 0],
            WaypointIndex = 0,
        };
        ApiEnum<string, Type> expectedType = Type.Feature;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedProperties, model.Properties);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Feature
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 0,
                EdgeID = 0,
                MatchingsIndex = 0,
                Name = "name",
                Original = [0, 0],
                WaypointIndex = 0,
            },
            Type = Type.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Feature
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 0,
                EdgeID = 0,
                MatchingsIndex = 0,
                Name = "name",
                Original = [0, 0],
                WaypointIndex = 0,
            },
            Type = Type.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Models::Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        Properties expectedProperties = new()
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Name = "name",
            Original = [0, 0],
            WaypointIndex = 0,
        };
        ApiEnum<string, Type> expectedType = Type.Feature;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedProperties, deserialized.Properties);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Feature
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 0,
                EdgeID = 0,
                MatchingsIndex = 0,
                Name = "name",
                Original = [0, 0],
                WaypointIndex = 0,
            },
            Type = Type.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Feature
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 0,
                EdgeID = 0,
                MatchingsIndex = 0,
                Name = "name",
                Original = [0, 0],
                WaypointIndex = 0,
            },
            Type = Type.Feature,
        };

        Feature copied = new(model);

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
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Name = "name",
            Original = [0, 0],
            WaypointIndex = 0,
        };

        double expectedDistanceM = 0;
        long expectedEdgeID = 0;
        long expectedMatchingsIndex = 0;
        string expectedName = "name";
        List<double> expectedOriginal = [0, 0];
        long expectedWaypointIndex = 0;

        Assert.Equal(expectedDistanceM, model.DistanceM);
        Assert.Equal(expectedEdgeID, model.EdgeID);
        Assert.Equal(expectedMatchingsIndex, model.MatchingsIndex);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.Original);
        Assert.Equal(expectedOriginal.Count, model.Original.Count);
        for (int i = 0; i < expectedOriginal.Count; i++)
        {
            Assert.Equal(expectedOriginal[i], model.Original[i]);
        }
        Assert.Equal(expectedWaypointIndex, model.WaypointIndex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Properties
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Name = "name",
            Original = [0, 0],
            WaypointIndex = 0,
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
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Name = "name",
            Original = [0, 0],
            WaypointIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Properties>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDistanceM = 0;
        long expectedEdgeID = 0;
        long expectedMatchingsIndex = 0;
        string expectedName = "name";
        List<double> expectedOriginal = [0, 0];
        long expectedWaypointIndex = 0;

        Assert.Equal(expectedDistanceM, deserialized.DistanceM);
        Assert.Equal(expectedEdgeID, deserialized.EdgeID);
        Assert.Equal(expectedMatchingsIndex, deserialized.MatchingsIndex);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.Original);
        Assert.Equal(expectedOriginal.Count, deserialized.Original.Count);
        for (int i = 0; i < expectedOriginal.Count; i++)
        {
            Assert.Equal(expectedOriginal[i], deserialized.Original[i]);
        }
        Assert.Equal(expectedWaypointIndex, deserialized.WaypointIndex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Properties
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Name = "name",
            Original = [0, 0],
            WaypointIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Properties { Name = "name" };

        Assert.Null(model.DistanceM);
        Assert.False(model.RawData.ContainsKey("distance_m"));
        Assert.Null(model.EdgeID);
        Assert.False(model.RawData.ContainsKey("edge_id"));
        Assert.Null(model.MatchingsIndex);
        Assert.False(model.RawData.ContainsKey("matchings_index"));
        Assert.Null(model.Original);
        Assert.False(model.RawData.ContainsKey("original"));
        Assert.Null(model.WaypointIndex);
        Assert.False(model.RawData.ContainsKey("waypoint_index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Properties { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Properties
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            DistanceM = null,
            EdgeID = null,
            MatchingsIndex = null,
            Original = null,
            WaypointIndex = null,
        };

        Assert.Null(model.DistanceM);
        Assert.False(model.RawData.ContainsKey("distance_m"));
        Assert.Null(model.EdgeID);
        Assert.False(model.RawData.ContainsKey("edge_id"));
        Assert.Null(model.MatchingsIndex);
        Assert.False(model.RawData.ContainsKey("matchings_index"));
        Assert.Null(model.Original);
        Assert.False(model.RawData.ContainsKey("original"));
        Assert.Null(model.WaypointIndex);
        Assert.False(model.RawData.ContainsKey("waypoint_index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Properties
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            DistanceM = null,
            EdgeID = null,
            MatchingsIndex = null,
            Original = null,
            WaypointIndex = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Properties
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Original = [0, 0],
            WaypointIndex = 0,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Properties
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Original = [0, 0],
            WaypointIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Properties
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Original = [0, 0],
            WaypointIndex = 0,

            Name = null,
        };

        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Properties
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Original = [0, 0],
            WaypointIndex = 0,

            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Properties
        {
            DistanceM = 0,
            EdgeID = 0,
            MatchingsIndex = 0,
            Name = "name",
            Original = [0, 0],
            WaypointIndex = 0,
        };

        Properties copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Feature)]
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
    [InlineData(Type.Feature)]
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

public class MapMatchResultTypeTest : TestBase
{
    [Theory]
    [InlineData(MapMatchResultType.FeatureCollection)]
    public void Validation_Works(MapMatchResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MapMatchResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MapMatchResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MapMatchResultType.FeatureCollection)]
    public void SerializationRoundtrip_Works(MapMatchResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MapMatchResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MapMatchResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MapMatchResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MapMatchResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
