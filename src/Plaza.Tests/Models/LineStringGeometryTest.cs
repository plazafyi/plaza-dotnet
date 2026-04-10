using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class LineStringGeometryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LineStringGeometry
        {
            Coordinates =
            [
                [0, 0],
                [0, 0],
            ],
            Type = LineStringGeometryType.LineString,
        };

        List<List<double>> expectedCoordinates =
        [
            [0, 0],
            [0, 0],
        ];
        ApiEnum<string, LineStringGeometryType> expectedType = LineStringGeometryType.LineString;

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
        var model = new LineStringGeometry
        {
            Coordinates =
            [
                [0, 0],
                [0, 0],
            ],
            Type = LineStringGeometryType.LineString,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineStringGeometry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LineStringGeometry
        {
            Coordinates =
            [
                [0, 0],
                [0, 0],
            ],
            Type = LineStringGeometryType.LineString,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineStringGeometry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<List<double>> expectedCoordinates =
        [
            [0, 0],
            [0, 0],
        ];
        ApiEnum<string, LineStringGeometryType> expectedType = LineStringGeometryType.LineString;

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
        var model = new LineStringGeometry
        {
            Coordinates =
            [
                [0, 0],
                [0, 0],
            ],
            Type = LineStringGeometryType.LineString,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LineStringGeometry
        {
            Coordinates =
            [
                [0, 0],
                [0, 0],
            ],
            Type = LineStringGeometryType.LineString,
        };

        LineStringGeometry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LineStringGeometryTypeTest : TestBase
{
    [Theory]
    [InlineData(LineStringGeometryType.LineString)]
    public void Validation_Works(LineStringGeometryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LineStringGeometryType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LineStringGeometryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LineStringGeometryType.LineString)]
    public void SerializationRoundtrip_Works(LineStringGeometryType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LineStringGeometryType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LineStringGeometryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LineStringGeometryType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LineStringGeometryType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
