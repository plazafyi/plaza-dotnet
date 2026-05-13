using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class PointGeometryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PointGeometry
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        List<double> expectedCoordinates = [2.3522, 48.8566];
        ApiEnum<string, PointGeometryType> expectedType = PointGeometryType.Point;

        Assert.Equal(expectedCoordinates.Count, model.Coordinates.Count);
        for (int i = 0; i < expectedCoordinates.Count; i++)
        {
            Assert.Equal(expectedCoordinates[i], model.Coordinates[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PointGeometry
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PointGeometry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PointGeometry
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PointGeometry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<double> expectedCoordinates = [2.3522, 48.8566];
        ApiEnum<string, PointGeometryType> expectedType = PointGeometryType.Point;

        Assert.Equal(expectedCoordinates.Count, deserialized.Coordinates.Count);
        for (int i = 0; i < expectedCoordinates.Count; i++)
        {
            Assert.Equal(expectedCoordinates[i], deserialized.Coordinates[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PointGeometry
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PointGeometry
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };

        PointGeometry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PointGeometryTypeTest : TestBase
{
    [Theory]
    [InlineData(PointGeometryType.Point)]
    public void Validation_Works(PointGeometryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PointGeometryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PointGeometryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PointGeometryType.Point)]
    public void SerializationRoundtrip_Works(PointGeometryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PointGeometryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PointGeometryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PointGeometryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PointGeometryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
