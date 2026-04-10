using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Optimize;

namespace Plaza.Tests.Models.Optimize;

public class OptimizeRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },
            Mode = OptimizeRequestMode.Auto,
            Roundtrip = false,
        };

        MultiPointGeometry expectedWaypoints = new()
        {
            Coordinates =
            [
                [2.3522, 48.8566],
                [2.3376, 48.8606],
                [2.2945, 48.8584],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };
        ApiEnum<string, OptimizeRequestMode> expectedMode = OptimizeRequestMode.Auto;
        bool expectedRoundtrip = false;

        Assert.Equal(expectedWaypoints, model.Waypoints);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedRoundtrip, model.Roundtrip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },
            Mode = OptimizeRequestMode.Auto,
            Roundtrip = false,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },
            Mode = OptimizeRequestMode.Auto,
            Roundtrip = false,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MultiPointGeometry expectedWaypoints = new()
        {
            Coordinates =
            [
                [2.3522, 48.8566],
                [2.3376, 48.8606],
                [2.2945, 48.8584],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };
        ApiEnum<string, OptimizeRequestMode> expectedMode = OptimizeRequestMode.Auto;
        bool expectedRoundtrip = false;

        Assert.Equal(expectedWaypoints, deserialized.Waypoints);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedRoundtrip, deserialized.Roundtrip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },
            Mode = OptimizeRequestMode.Auto,
            Roundtrip = false,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Roundtrip);
        Assert.False(model.RawData.ContainsKey("roundtrip"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },

            // Null should be interpreted as omitted for these properties
            Mode = null,
            Roundtrip = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Roundtrip);
        Assert.False(model.RawData.ContainsKey("roundtrip"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },

            // Null should be interpreted as omitted for these properties
            Mode = null,
            Roundtrip = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OptimizeRequest
        {
            Waypoints = new()
            {
                Coordinates =
                [
                    [2.3522, 48.8566],
                    [2.3376, 48.8606],
                    [2.2945, 48.8584],
                ],
                Type = MultiPointGeometryType.MultiPoint,
            },
            Mode = OptimizeRequestMode.Auto,
            Roundtrip = false,
        };

        OptimizeRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OptimizeRequestModeTest : TestBase
{
    [Theory]
    [InlineData(OptimizeRequestMode.Auto)]
    [InlineData(OptimizeRequestMode.Foot)]
    [InlineData(OptimizeRequestMode.Bicycle)]
    public void Validation_Works(OptimizeRequestMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OptimizeRequestMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OptimizeRequestMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OptimizeRequestMode.Auto)]
    [InlineData(OptimizeRequestMode.Foot)]
    [InlineData(OptimizeRequestMode.Bicycle)]
    public void SerializationRoundtrip_Works(OptimizeRequestMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OptimizeRequestMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OptimizeRequestMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OptimizeRequestMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OptimizeRequestMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
