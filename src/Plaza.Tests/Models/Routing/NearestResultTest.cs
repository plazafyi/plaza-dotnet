using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Routing;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.Routing;

public class NearestResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NearestResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 12.4,
                EdgeID = 0,
                EdgeLengthM = 0,
                Highway = "highway",
                OsmWayID = 0,
                Surface = "surface",
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
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            Highway = "highway",
            OsmWayID = 0,
            Surface = "surface",
        };
        ApiEnum<string, Type> expectedType = Type.Feature;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedProperties, model.Properties);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NearestResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 12.4,
                EdgeID = 0,
                EdgeLengthM = 0,
                Highway = "highway",
                OsmWayID = 0,
                Surface = "surface",
            },
            Type = Type.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NearestResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NearestResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 12.4,
                EdgeID = 0,
                EdgeLengthM = 0,
                Highway = "highway",
                OsmWayID = 0,
                Surface = "surface",
            },
            Type = Type.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NearestResult>(
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
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            Highway = "highway",
            OsmWayID = 0,
            Surface = "surface",
        };
        ApiEnum<string, Type> expectedType = Type.Feature;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedProperties, deserialized.Properties);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NearestResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 12.4,
                EdgeID = 0,
                EdgeLengthM = 0,
                Highway = "highway",
                OsmWayID = 0,
                Surface = "surface",
            },
            Type = Type.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NearestResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 12.4,
                EdgeID = 0,
                EdgeLengthM = 0,
                Highway = "highway",
                OsmWayID = 0,
                Surface = "surface",
            },
            Type = Type.Feature,
        };

        NearestResult copied = new(model);

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
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            Highway = "highway",
            OsmWayID = 0,
            Surface = "surface",
        };

        double expectedDistanceM = 12.4;
        long expectedEdgeID = 0;
        double expectedEdgeLengthM = 0;
        string expectedHighway = "highway";
        long expectedOsmWayID = 0;
        string expectedSurface = "surface";

        Assert.Equal(expectedDistanceM, model.DistanceM);
        Assert.Equal(expectedEdgeID, model.EdgeID);
        Assert.Equal(expectedEdgeLengthM, model.EdgeLengthM);
        Assert.Equal(expectedHighway, model.Highway);
        Assert.Equal(expectedOsmWayID, model.OsmWayID);
        Assert.Equal(expectedSurface, model.Surface);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Properties
        {
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            Highway = "highway",
            OsmWayID = 0,
            Surface = "surface",
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
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            Highway = "highway",
            OsmWayID = 0,
            Surface = "surface",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Properties>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDistanceM = 12.4;
        long expectedEdgeID = 0;
        double expectedEdgeLengthM = 0;
        string expectedHighway = "highway";
        long expectedOsmWayID = 0;
        string expectedSurface = "surface";

        Assert.Equal(expectedDistanceM, deserialized.DistanceM);
        Assert.Equal(expectedEdgeID, deserialized.EdgeID);
        Assert.Equal(expectedEdgeLengthM, deserialized.EdgeLengthM);
        Assert.Equal(expectedHighway, deserialized.Highway);
        Assert.Equal(expectedOsmWayID, deserialized.OsmWayID);
        Assert.Equal(expectedSurface, deserialized.Surface);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Properties
        {
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            Highway = "highway",
            OsmWayID = 0,
            Surface = "surface",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Properties { Highway = "highway", Surface = "surface" };

        Assert.Null(model.DistanceM);
        Assert.False(model.RawData.ContainsKey("distance_m"));
        Assert.Null(model.EdgeID);
        Assert.False(model.RawData.ContainsKey("edge_id"));
        Assert.Null(model.EdgeLengthM);
        Assert.False(model.RawData.ContainsKey("edge_length_m"));
        Assert.Null(model.OsmWayID);
        Assert.False(model.RawData.ContainsKey("osm_way_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Properties { Highway = "highway", Surface = "surface" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Properties
        {
            Highway = "highway",
            Surface = "surface",

            // Null should be interpreted as omitted for these properties
            DistanceM = null,
            EdgeID = null,
            EdgeLengthM = null,
            OsmWayID = null,
        };

        Assert.Null(model.DistanceM);
        Assert.False(model.RawData.ContainsKey("distance_m"));
        Assert.Null(model.EdgeID);
        Assert.False(model.RawData.ContainsKey("edge_id"));
        Assert.Null(model.EdgeLengthM);
        Assert.False(model.RawData.ContainsKey("edge_length_m"));
        Assert.Null(model.OsmWayID);
        Assert.False(model.RawData.ContainsKey("osm_way_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Properties
        {
            Highway = "highway",
            Surface = "surface",

            // Null should be interpreted as omitted for these properties
            DistanceM = null,
            EdgeID = null,
            EdgeLengthM = null,
            OsmWayID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Properties
        {
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            OsmWayID = 0,
        };

        Assert.Null(model.Highway);
        Assert.False(model.RawData.ContainsKey("highway"));
        Assert.Null(model.Surface);
        Assert.False(model.RawData.ContainsKey("surface"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Properties
        {
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            OsmWayID = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Properties
        {
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            OsmWayID = 0,

            Highway = null,
            Surface = null,
        };

        Assert.Null(model.Highway);
        Assert.True(model.RawData.ContainsKey("highway"));
        Assert.Null(model.Surface);
        Assert.True(model.RawData.ContainsKey("surface"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Properties
        {
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            OsmWayID = 0,

            Highway = null,
            Surface = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Properties
        {
            DistanceM = 12.4,
            EdgeID = 0,
            EdgeLengthM = 0,
            Highway = "highway",
            OsmWayID = 0,
            Surface = "surface",
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
