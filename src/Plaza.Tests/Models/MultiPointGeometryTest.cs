using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class MultiPointGeometryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultiPointGeometry
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };

        List<List<double>> expectedCoordinates =
        [
            [0, 0],
        ];
        ApiEnum<string, MultiPointGeometryType> expectedType = MultiPointGeometryType.MultiPoint;

        Assert.Equal(expectedCoordinates.Count, model.Coordinates.Count);
        for (int i = 0; i < expectedCoordinates.Count; i++)
        {
            Assert.Equal(expectedCoordinates[i].Count, model.Coordinates[i].Count);
            for (int i1 = 0; i1 < expectedCoordinates[i].Count; i1++)
            {
                Assert.Equal(expectedCoordinates[i][i1], model.Coordinates[i][i1]);
            }
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MultiPointGeometry
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultiPointGeometry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MultiPointGeometry
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultiPointGeometry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<List<double>> expectedCoordinates =
        [
            [0, 0],
        ];
        ApiEnum<string, MultiPointGeometryType> expectedType = MultiPointGeometryType.MultiPoint;

        Assert.Equal(expectedCoordinates.Count, deserialized.Coordinates.Count);
        for (int i = 0; i < expectedCoordinates.Count; i++)
        {
            Assert.Equal(expectedCoordinates[i].Count, deserialized.Coordinates[i].Count);
            for (int i1 = 0; i1 < expectedCoordinates[i].Count; i1++)
            {
                Assert.Equal(expectedCoordinates[i][i1], deserialized.Coordinates[i][i1]);
            }
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MultiPointGeometry
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MultiPointGeometry
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = MultiPointGeometryType.MultiPoint,
        };

        MultiPointGeometry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MultiPointGeometryTypeTest : TestBase
{
    [Theory]
    [InlineData(MultiPointGeometryType.MultiPoint)]
    public void Validation_Works(MultiPointGeometryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MultiPointGeometryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MultiPointGeometryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MultiPointGeometryType.MultiPoint)]
    public void SerializationRoundtrip_Works(MultiPointGeometryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MultiPointGeometryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MultiPointGeometryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MultiPointGeometryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MultiPointGeometryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
