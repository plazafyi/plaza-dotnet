using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class ValidationErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ValidationError
        {
            Error = new()
            {
                Code = Code.ValidationFailed,
                Message = "message",
                Details = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "name", ["can't be blank"] },
                    { "slug", ["has already been taken"] },
                },
            },
        };

        ValidationErrorError expectedError = new()
        {
            Code = Code.ValidationFailed,
            Message = "message",
            Details = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "name", ["can't be blank"] },
                { "slug", ["has already been taken"] },
            },
        };

        Assert.Equal(expectedError, model.Error);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ValidationError
        {
            Error = new()
            {
                Code = Code.ValidationFailed,
                Message = "message",
                Details = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "name", ["can't be blank"] },
                    { "slug", ["has already been taken"] },
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidationError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ValidationError
        {
            Error = new()
            {
                Code = Code.ValidationFailed,
                Message = "message",
                Details = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "name", ["can't be blank"] },
                    { "slug", ["has already been taken"] },
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidationError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ValidationErrorError expectedError = new()
        {
            Code = Code.ValidationFailed,
            Message = "message",
            Details = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "name", ["can't be blank"] },
                { "slug", ["has already been taken"] },
            },
        };

        Assert.Equal(expectedError, deserialized.Error);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ValidationError
        {
            Error = new()
            {
                Code = Code.ValidationFailed,
                Message = "message",
                Details = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "name", ["can't be blank"] },
                    { "slug", ["has already been taken"] },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ValidationError
        {
            Error = new()
            {
                Code = Code.ValidationFailed,
                Message = "message",
                Details = new Dictionary<string, IReadOnlyList<string>>()
                {
                    { "name", ["can't be blank"] },
                    { "slug", ["has already been taken"] },
                },
            },
        };

        ValidationError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ValidationErrorErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ValidationErrorError
        {
            Code = Code.ValidationFailed,
            Message = "message",
            Details = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "name", ["can't be blank"] },
                { "slug", ["has already been taken"] },
            },
        };

        ApiEnum<string, Code> expectedCode = Code.ValidationFailed;
        string expectedMessage = "message";
        Dictionary<string, List<string>> expectedDetails = new()
        {
            { "name", ["can't be blank"] },
            { "slug", ["has already been taken"] },
        };

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedMessage, model.Message);
        Assert.NotNull(model.Details);
        Assert.Equal(expectedDetails.Count, model.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(model.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], model.Details[item.Key][i]);
            }
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ValidationErrorError
        {
            Code = Code.ValidationFailed,
            Message = "message",
            Details = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "name", ["can't be blank"] },
                { "slug", ["has already been taken"] },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidationErrorError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ValidationErrorError
        {
            Code = Code.ValidationFailed,
            Message = "message",
            Details = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "name", ["can't be blank"] },
                { "slug", ["has already been taken"] },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValidationErrorError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Code> expectedCode = Code.ValidationFailed;
        string expectedMessage = "message";
        Dictionary<string, List<string>> expectedDetails = new()
        {
            { "name", ["can't be blank"] },
            { "slug", ["has already been taken"] },
        };

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.NotNull(deserialized.Details);
        Assert.Equal(expectedDetails.Count, deserialized.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(deserialized.Details.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.Details[item.Key].Count);
            for (int i = 0; i < value.Count; i++)
            {
                Assert.Equal(value[i], deserialized.Details[item.Key][i]);
            }
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ValidationErrorError
        {
            Code = Code.ValidationFailed,
            Message = "message",
            Details = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "name", ["can't be blank"] },
                { "slug", ["has already been taken"] },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ValidationErrorError { Code = Code.ValidationFailed, Message = "message" };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ValidationErrorError { Code = Code.ValidationFailed, Message = "message" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ValidationErrorError
        {
            Code = Code.ValidationFailed,
            Message = "message",

            Details = null,
        };

        Assert.Null(model.Details);
        Assert.True(model.RawData.ContainsKey("details"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ValidationErrorError
        {
            Code = Code.ValidationFailed,
            Message = "message",

            Details = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ValidationErrorError
        {
            Code = Code.ValidationFailed,
            Message = "message",
            Details = new Dictionary<string, IReadOnlyList<string>>()
            {
                { "name", ["can't be blank"] },
                { "slug", ["has already been taken"] },
            },
        };

        ValidationErrorError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CodeTest : TestBase
{
    [Theory]
    [InlineData(Code.ValidationFailed)]
    public void Validation_Works(Code rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Code> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Code>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Code.ValidationFailed)]
    public void SerializationRoundtrip_Works(Code rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Code> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Code>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Code>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Code>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
