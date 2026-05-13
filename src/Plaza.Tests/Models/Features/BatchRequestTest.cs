using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Features;

namespace Plaza.Tests.Models.Features;

public class BatchRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchRequest
        {
            Elements =
            [
                new() { ID = 21154906, Type = BatchRequestElementType.Node },
                new() { ID = 4589123, Type = BatchRequestElementType.Way },
            ],
        };

        List<BatchRequestElement> expectedElements =
        [
            new() { ID = 21154906, Type = BatchRequestElementType.Node },
            new() { ID = 4589123, Type = BatchRequestElementType.Way },
        ];

        Assert.Equal(expectedElements.Count, model.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], model.Elements[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchRequest
        {
            Elements =
            [
                new() { ID = 21154906, Type = BatchRequestElementType.Node },
                new() { ID = 4589123, Type = BatchRequestElementType.Way },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchRequest
        {
            Elements =
            [
                new() { ID = 21154906, Type = BatchRequestElementType.Node },
                new() { ID = 4589123, Type = BatchRequestElementType.Way },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BatchRequestElement> expectedElements =
        [
            new() { ID = 21154906, Type = BatchRequestElementType.Node },
            new() { ID = 4589123, Type = BatchRequestElementType.Way },
        ];

        Assert.Equal(expectedElements.Count, deserialized.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], deserialized.Elements[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchRequest
        {
            Elements =
            [
                new() { ID = 21154906, Type = BatchRequestElementType.Node },
                new() { ID = 4589123, Type = BatchRequestElementType.Way },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchRequest
        {
            Elements =
            [
                new() { ID = 21154906, Type = BatchRequestElementType.Node },
                new() { ID = 4589123, Type = BatchRequestElementType.Way },
            ],
        };

        BatchRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchRequestElementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchRequestElement { ID = 21154906, Type = BatchRequestElementType.Node };

        long expectedID = 21154906;
        ApiEnum<string, BatchRequestElementType> expectedType = BatchRequestElementType.Node;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchRequestElement { ID = 21154906, Type = BatchRequestElementType.Node };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchRequestElement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchRequestElement { ID = 21154906, Type = BatchRequestElementType.Node };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchRequestElement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 21154906;
        ApiEnum<string, BatchRequestElementType> expectedType = BatchRequestElementType.Node;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchRequestElement { ID = 21154906, Type = BatchRequestElementType.Node };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchRequestElement { ID = 21154906, Type = BatchRequestElementType.Node };

        BatchRequestElement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchRequestElementTypeTest : TestBase
{
    [Theory]
    [InlineData(BatchRequestElementType.Node)]
    [InlineData(BatchRequestElementType.Way)]
    [InlineData(BatchRequestElementType.Relation)]
    public void Validation_Works(BatchRequestElementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchRequestElementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchRequestElementType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchRequestElementType.Node)]
    [InlineData(BatchRequestElementType.Way)]
    [InlineData(BatchRequestElementType.Relation)]
    public void SerializationRoundtrip_Works(BatchRequestElementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchRequestElementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchRequestElementType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchRequestElementType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchRequestElementType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
