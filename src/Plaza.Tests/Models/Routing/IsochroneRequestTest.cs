using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class IsochroneRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],
            Mode = IsochroneRequestMode.Auto,
        };

        PointGeometry expectedGeometry = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        List<long> expectedTime = [1];
        ApiEnum<string, IsochroneRequestMode> expectedMode = IsochroneRequestMode.Auto;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedTime.Count, model.Time.Count);
        for (int i = 0; i < expectedTime.Count; i++)
        {
            Assert.Equal(expectedTime[i], model.Time[i]);
        }
        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],
            Mode = IsochroneRequestMode.Auto,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IsochroneRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],
            Mode = IsochroneRequestMode.Auto,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IsochroneRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PointGeometry expectedGeometry = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        List<long> expectedTime = [1];
        ApiEnum<string, IsochroneRequestMode> expectedMode = IsochroneRequestMode.Auto;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedTime.Count, deserialized.Time.Count);
        for (int i = 0; i < expectedTime.Count; i++)
        {
            Assert.Equal(expectedTime[i], deserialized.Time[i]);
        }
        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],
            Mode = IsochroneRequestMode.Auto,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],

            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],

            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IsochroneRequest
        {
            Geometry = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Time = [1],
            Mode = IsochroneRequestMode.Auto,
        };

        IsochroneRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IsochroneRequestModeTest : TestBase
{
    [Theory]
    [InlineData(IsochroneRequestMode.Auto)]
    [InlineData(IsochroneRequestMode.Foot)]
    [InlineData(IsochroneRequestMode.Bicycle)]
    public void Validation_Works(IsochroneRequestMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IsochroneRequestMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IsochroneRequestMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IsochroneRequestMode.Auto)]
    [InlineData(IsochroneRequestMode.Foot)]
    [InlineData(IsochroneRequestMode.Bicycle)]
    public void SerializationRoundtrip_Works(IsochroneRequestMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IsochroneRequestMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IsochroneRequestMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IsochroneRequestMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IsochroneRequestMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
