using System;
using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Features = Plaza.Models.Features;

namespace Plaza.Tests.Models.Features;

public class FeatureBatchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Features::FeatureBatchParams
        {
            Elements =
            [
                new() { ID = 21154906, Type = Features::Type.Node },
                new() { ID = 4589123, Type = Features::Type.Way },
            ],
        };

        List<Features::Element> expectedElements =
        [
            new() { ID = 21154906, Type = Features::Type.Node },
            new() { ID = 4589123, Type = Features::Type.Way },
        ];

        Assert.Equal(expectedElements.Count, parameters.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], parameters.Elements[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        Features::FeatureBatchParams parameters = new()
        {
            Elements =
            [
                new() { ID = 21154906, Type = Features::Type.Node },
                new() { ID = 4589123, Type = Features::Type.Way },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://plaza.fyi/api/v1/features/batch"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Features::FeatureBatchParams
        {
            Elements =
            [
                new() { ID = 21154906, Type = Features::Type.Node },
                new() { ID = 4589123, Type = Features::Type.Way },
            ],
        };

        Features::FeatureBatchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ElementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Features::Element { ID = 21154906, Type = Features::Type.Node };

        long expectedID = 21154906;
        ApiEnum<string, Features::Type> expectedType = Features::Type.Node;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Features::Element { ID = 21154906, Type = Features::Type.Node };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Features::Element>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Features::Element { ID = 21154906, Type = Features::Type.Node };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Features::Element>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedID = 21154906;
        ApiEnum<string, Features::Type> expectedType = Features::Type.Node;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Features::Element { ID = 21154906, Type = Features::Type.Node };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Features::Element { ID = 21154906, Type = Features::Type.Node };

        Features::Element copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Features::Type.Node)]
    [InlineData(Features::Type.Way)]
    [InlineData(Features::Type.Relation)]
    public void Validation_Works(Features::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Features::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Features::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Features::Type.Node)]
    [InlineData(Features::Type.Way)]
    [InlineData(Features::Type.Relation)]
    public void SerializationRoundtrip_Works(Features::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Features::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Features::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Features::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Features::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
