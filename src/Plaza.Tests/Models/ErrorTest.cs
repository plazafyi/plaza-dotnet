using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Models;

namespace Plaza.Tests.Models;

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error
        {
            ErrorValue = new()
            {
                Code = "invalid_request",
                Message = "Missing required parameter: q",
                Details = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        ErrorError expectedErrorValue = new()
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Equal(expectedErrorValue, model.ErrorValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error
        {
            ErrorValue = new()
            {
                Code = "invalid_request",
                Message = "Missing required parameter: q",
                Details = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error
        {
            ErrorValue = new()
            {
                Code = "invalid_request",
                Message = "Missing required parameter: q",
                Details = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ErrorError expectedErrorValue = new()
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Equal(expectedErrorValue, deserialized.ErrorValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error
        {
            ErrorValue = new()
            {
                Code = "invalid_request",
                Message = "Missing required parameter: q",
                Details = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error
        {
            ErrorValue = new()
            {
                Code = "invalid_request",
                Message = "Missing required parameter: q",
                Details = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
        };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedCode = "invalid_request";
        string expectedMessage = "Missing required parameter: q";
        Dictionary<string, JsonElement> expectedDetails = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedMessage, model.Message);
        Assert.NotNull(model.Details);
        Assert.Equal(expectedDetails.Count, model.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(model.Details.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Details[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ErrorError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "invalid_request";
        string expectedMessage = "Missing required parameter: q";
        Dictionary<string, JsonElement> expectedDetails = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.NotNull(deserialized.Details);
        Assert.Equal(expectedDetails.Count, deserialized.Details.Count);
        foreach (var item in expectedDetails)
        {
            Assert.True(deserialized.Details.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Details[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
        };

        Assert.Null(model.Details);
        Assert.False(model.RawData.ContainsKey("details"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",

            Details = null,
        };

        Assert.Null(model.Details);
        Assert.True(model.RawData.ContainsKey("details"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",

            Details = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ErrorError
        {
            Code = "invalid_request",
            Message = "Missing required parameter: q",
            Details = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        ErrorError copied = new(model);

        Assert.Equal(model, copied);
    }
}
