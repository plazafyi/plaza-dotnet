using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class MatrixRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            FallbackSpeed = 1,
            Mode = MatrixRequestMode.Auto,
        };

        List<PointGeometry> expectedDestinations =
        [
            new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
        ];
        List<PointGeometry> expectedOrigins =
        [
            new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
        ];
        string expectedAnnotations = "annotations";
        double expectedFallbackSpeed = 1;
        ApiEnum<string, MatrixRequestMode> expectedMode = MatrixRequestMode.Auto;

        Assert.Equal(expectedDestinations.Count, model.Destinations.Count);
        for (int i = 0; i < expectedDestinations.Count; i++)
        {
            Assert.Equal(expectedDestinations[i], model.Destinations[i]);
        }
        Assert.Equal(expectedOrigins.Count, model.Origins.Count);
        for (int i = 0; i < expectedOrigins.Count; i++)
        {
            Assert.Equal(expectedOrigins[i], model.Origins[i]);
        }
        Assert.Equal(expectedAnnotations, model.Annotations);
        Assert.Equal(expectedFallbackSpeed, model.FallbackSpeed);
        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            FallbackSpeed = 1,
            Mode = MatrixRequestMode.Auto,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatrixRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            FallbackSpeed = 1,
            Mode = MatrixRequestMode.Auto,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatrixRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PointGeometry> expectedDestinations =
        [
            new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
        ];
        List<PointGeometry> expectedOrigins =
        [
            new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
        ];
        string expectedAnnotations = "annotations";
        double expectedFallbackSpeed = 1;
        ApiEnum<string, MatrixRequestMode> expectedMode = MatrixRequestMode.Auto;

        Assert.Equal(expectedDestinations.Count, deserialized.Destinations.Count);
        for (int i = 0; i < expectedDestinations.Count; i++)
        {
            Assert.Equal(expectedDestinations[i], deserialized.Destinations[i]);
        }
        Assert.Equal(expectedOrigins.Count, deserialized.Origins.Count);
        for (int i = 0; i < expectedOrigins.Count; i++)
        {
            Assert.Equal(expectedOrigins[i], deserialized.Origins[i]);
        }
        Assert.Equal(expectedAnnotations, deserialized.Annotations);
        Assert.Equal(expectedFallbackSpeed, deserialized.FallbackSpeed);
        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            FallbackSpeed = 1,
            Mode = MatrixRequestMode.Auto,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            FallbackSpeed = 1,
        };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            FallbackSpeed = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            FallbackSpeed = 1,

            // Null should be interpreted as omitted for these properties
            Annotations = null,
            Mode = null,
        };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            FallbackSpeed = 1,

            // Null should be interpreted as omitted for these properties
            Annotations = null,
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            Mode = MatrixRequestMode.Auto,
        };

        Assert.Null(model.FallbackSpeed);
        Assert.False(model.RawData.ContainsKey("fallback_speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            Mode = MatrixRequestMode.Auto,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            Mode = MatrixRequestMode.Auto,

            FallbackSpeed = null,
        };

        Assert.Null(model.FallbackSpeed);
        Assert.True(model.RawData.ContainsKey("fallback_speed"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            Mode = MatrixRequestMode.Auto,

            FallbackSpeed = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MatrixRequest
        {
            Destinations =
            [
                new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            ],
            Origins =
            [
                new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
                new() { Coordinates = [2.3376, 48.8606], Type = PointGeometryType.Point },
            ],
            Annotations = "annotations",
            FallbackSpeed = 1,
            Mode = MatrixRequestMode.Auto,
        };

        MatrixRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MatrixRequestModeTest : TestBase
{
    [Theory]
    [InlineData(MatrixRequestMode.Auto)]
    [InlineData(MatrixRequestMode.Foot)]
    [InlineData(MatrixRequestMode.Bicycle)]
    public void Validation_Works(MatrixRequestMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatrixRequestMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatrixRequestMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MatrixRequestMode.Auto)]
    [InlineData(MatrixRequestMode.Foot)]
    [InlineData(MatrixRequestMode.Bicycle)]
    public void SerializationRoundtrip_Works(MatrixRequestMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatrixRequestMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatrixRequestMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatrixRequestMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatrixRequestMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
