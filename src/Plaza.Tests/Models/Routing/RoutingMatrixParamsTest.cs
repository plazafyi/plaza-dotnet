using System;
using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class RoutingMatrixParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RoutingMatrixParams
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
            Mode = RoutingMatrixParamsMode.Auto,
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
        ApiEnum<string, RoutingMatrixParamsMode> expectedMode = RoutingMatrixParamsMode.Auto;

        Assert.Equal(expectedDestinations.Count, parameters.Destinations.Count);
        for (int i = 0; i < expectedDestinations.Count; i++)
        {
            Assert.Equal(expectedDestinations[i], parameters.Destinations[i]);
        }
        Assert.Equal(expectedOrigins.Count, parameters.Origins.Count);
        for (int i = 0; i < expectedOrigins.Count; i++)
        {
            Assert.Equal(expectedOrigins[i], parameters.Origins[i]);
        }
        Assert.Equal(expectedAnnotations, parameters.Annotations);
        Assert.Equal(expectedFallbackSpeed, parameters.FallbackSpeed);
        Assert.Equal(expectedMode, parameters.Mode);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RoutingMatrixParams
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

        Assert.Null(parameters.Annotations);
        Assert.False(parameters.RawBodyData.ContainsKey("annotations"));
        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RoutingMatrixParams
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

        Assert.Null(parameters.Annotations);
        Assert.False(parameters.RawBodyData.ContainsKey("annotations"));
        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RoutingMatrixParams
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
            Mode = RoutingMatrixParamsMode.Auto,
        };

        Assert.Null(parameters.FallbackSpeed);
        Assert.False(parameters.RawBodyData.ContainsKey("fallback_speed"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RoutingMatrixParams
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
            Mode = RoutingMatrixParamsMode.Auto,

            FallbackSpeed = null,
        };

        Assert.Null(parameters.FallbackSpeed);
        Assert.True(parameters.RawBodyData.ContainsKey("fallback_speed"));
    }

    [Fact]
    public void Url_Works()
    {
        RoutingMatrixParams parameters = new()
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/matrix"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RoutingMatrixParams
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
            Mode = RoutingMatrixParamsMode.Auto,
        };

        RoutingMatrixParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RoutingMatrixParamsModeTest : TestBase
{
    [Theory]
    [InlineData(RoutingMatrixParamsMode.Auto)]
    [InlineData(RoutingMatrixParamsMode.Foot)]
    [InlineData(RoutingMatrixParamsMode.Bicycle)]
    public void Validation_Works(RoutingMatrixParamsMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingMatrixParamsMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingMatrixParamsMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingMatrixParamsMode.Auto)]
    [InlineData(RoutingMatrixParamsMode.Foot)]
    [InlineData(RoutingMatrixParamsMode.Bicycle)]
    public void SerializationRoundtrip_Works(RoutingMatrixParamsMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingMatrixParamsMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RoutingMatrixParamsMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingMatrixParamsMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RoutingMatrixParamsMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
