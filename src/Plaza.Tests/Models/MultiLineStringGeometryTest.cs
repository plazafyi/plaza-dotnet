using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class MultiLineStringGeometryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MultiLineStringGeometry
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = MultiLineStringGeometryType.MultiLineString,
        };

        List<List<List<double>>> expectedCoordinates =
        [
            [
                [0, 0],
                [0, 0],
            ],
        ];
        ApiEnum<string, MultiLineStringGeometryType> expectedType =
            MultiLineStringGeometryType.MultiLineString;

        Assert.Equal(expectedCoordinates.Count, model.Coordinates.Count);
        for (int i = 0; i < expectedCoordinates.Count; i++)
        {
            Assert.Equal(expectedCoordinates[i].Count, model.Coordinates[i].Count);
            for (int i1 = 0; i1 < expectedCoordinates[i].Count; i1++)
            {
                Assert.Equal(expectedCoordinates[i][i1].Count, model.Coordinates[i][i1].Count);
                for (int i2 = 0; i2 < expectedCoordinates[i][i1].Count; i2++)
                {
                    Assert.Equal(expectedCoordinates[i][i1][i2], model.Coordinates[i][i1][i2]);
                }
            }
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MultiLineStringGeometry
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = MultiLineStringGeometryType.MultiLineString,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultiLineStringGeometry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MultiLineStringGeometry
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = MultiLineStringGeometryType.MultiLineString,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MultiLineStringGeometry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<List<List<double>>> expectedCoordinates =
        [
            [
                [0, 0],
                [0, 0],
            ],
        ];
        ApiEnum<string, MultiLineStringGeometryType> expectedType =
            MultiLineStringGeometryType.MultiLineString;

        Assert.Equal(expectedCoordinates.Count, deserialized.Coordinates.Count);
        for (int i = 0; i < expectedCoordinates.Count; i++)
        {
            Assert.Equal(expectedCoordinates[i].Count, deserialized.Coordinates[i].Count);
            for (int i1 = 0; i1 < expectedCoordinates[i].Count; i1++)
            {
                Assert.Equal(
                    expectedCoordinates[i][i1].Count,
                    deserialized.Coordinates[i][i1].Count
                );
                for (int i2 = 0; i2 < expectedCoordinates[i][i1].Count; i2++)
                {
                    Assert.Equal(
                        expectedCoordinates[i][i1][i2],
                        deserialized.Coordinates[i][i1][i2]
                    );
                }
            }
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MultiLineStringGeometry
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = MultiLineStringGeometryType.MultiLineString,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MultiLineStringGeometry
        {
            Coordinates =
            [
                [
                    [0, 0],
                    [0, 0],
                ],
            ],
            Type = MultiLineStringGeometryType.MultiLineString,
        };

        MultiLineStringGeometry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MultiLineStringGeometryTypeTest : TestBase
{
    [Theory]
    [InlineData(MultiLineStringGeometryType.MultiLineString)]
    public void Validation_Works(MultiLineStringGeometryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MultiLineStringGeometryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MultiLineStringGeometryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MultiLineStringGeometryType.MultiLineString)]
    public void SerializationRoundtrip_Works(MultiLineStringGeometryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MultiLineStringGeometryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MultiLineStringGeometryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MultiLineStringGeometryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MultiLineStringGeometryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
