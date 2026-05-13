using System;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Optimize;

namespace Plaza.Tests.Models.Optimize;

public class OptimizeCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OptimizeCreateParams
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
            Format = "format",
            Mode = Mode.Auto,
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
        string expectedFormat = "format";
        ApiEnum<string, Mode> expectedMode = Mode.Auto;
        bool expectedRoundtrip = false;

        Assert.Equal(expectedWaypoints, parameters.Waypoints);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedMode, parameters.Mode);
        Assert.Equal(expectedRoundtrip, parameters.Roundtrip);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new OptimizeCreateParams
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

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.Roundtrip);
        Assert.False(parameters.RawBodyData.ContainsKey("roundtrip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new OptimizeCreateParams
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
            Format = null,
            Mode = null,
            Roundtrip = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.Roundtrip);
        Assert.False(parameters.RawBodyData.ContainsKey("roundtrip"));
    }

    [Fact]
    public void Url_Works()
    {
        OptimizeCreateParams parameters = new()
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
            Format = "format",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/optimize?format=format"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OptimizeCreateParams
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
            Format = "format",
            Mode = Mode.Auto,
            Roundtrip = false,
        };

        OptimizeCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.Auto)]
    [InlineData(Mode.Foot)]
    [InlineData(Mode.Bicycle)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.Auto)]
    [InlineData(Mode.Foot)]
    [InlineData(Mode.Bicycle)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
