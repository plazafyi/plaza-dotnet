using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Optimize;

namespace Plaza.Tests.Models.Optimize;

public class OptimizeProcessingResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OptimizeProcessingResult
        {
            JobID = "opt_abc123",
            Status = OptimizeProcessingResultStatus.Processing,
        };

        string expectedJobID = "opt_abc123";
        ApiEnum<string, OptimizeProcessingResultStatus> expectedStatus =
            OptimizeProcessingResultStatus.Processing;

        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OptimizeProcessingResult
        {
            JobID = "opt_abc123",
            Status = OptimizeProcessingResultStatus.Processing,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeProcessingResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OptimizeProcessingResult
        {
            JobID = "opt_abc123",
            Status = OptimizeProcessingResultStatus.Processing,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeProcessingResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedJobID = "opt_abc123";
        ApiEnum<string, OptimizeProcessingResultStatus> expectedStatus =
            OptimizeProcessingResultStatus.Processing;

        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OptimizeProcessingResult
        {
            JobID = "opt_abc123",
            Status = OptimizeProcessingResultStatus.Processing,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OptimizeProcessingResult
        {
            JobID = "opt_abc123",
            Status = OptimizeProcessingResultStatus.Processing,
        };

        OptimizeProcessingResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OptimizeProcessingResultStatusTest : TestBase
{
    [Theory]
    [InlineData(OptimizeProcessingResultStatus.Processing)]
    public void Validation_Works(OptimizeProcessingResultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OptimizeProcessingResultStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OptimizeProcessingResultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OptimizeProcessingResultStatus.Processing)]
    public void SerializationRoundtrip_Works(OptimizeProcessingResultStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OptimizeProcessingResultStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OptimizeProcessingResultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OptimizeProcessingResultStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OptimizeProcessingResultStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
