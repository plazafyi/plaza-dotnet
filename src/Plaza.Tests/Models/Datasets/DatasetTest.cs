using System;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Datasets;

namespace Plaza.Tests.Models.Datasets;

public class DatasetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            Attribution = "attribution",
            Description = "description",
            EdgeCount = 0,
            ErrorMessage = "error_message",
            FeatureCount = 0,
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",
            StorageBytes = 0,
            StrictMode = true,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedInsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "NYC Bike Lanes";
        ApiEnum<string, Scope> expectedScope = Scope.Plaza;
        string expectedSlug = "nyc-bike-lanes";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedAddressCount = 0;
        string expectedAttribution = "attribution";
        string expectedDescription = "description";
        long expectedEdgeCount = 0;
        string expectedErrorMessage = "error_message";
        long expectedFeatureCount = 0;
        string expectedLicense = "license";
        JsonElement expectedSchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedSourceFormat = "source_format";
        string expectedSourceUrl = "https://example.com";
        long expectedStorageBytes = 0;
        bool expectedStrictMode = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInsertedAt, model.InsertedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedScope, model.Scope);
        Assert.Equal(expectedSlug, model.Slug);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedAddressCount, model.AddressCount);
        Assert.Equal(expectedAttribution, model.Attribution);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEdgeCount, model.EdgeCount);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedFeatureCount, model.FeatureCount);
        Assert.Equal(expectedLicense, model.License);
        Assert.NotNull(model.SchemaDefinition);
        Assert.True(JsonElement.DeepEquals(expectedSchemaDefinition, model.SchemaDefinition.Value));
        Assert.Equal(expectedSourceFormat, model.SourceFormat);
        Assert.Equal(expectedSourceUrl, model.SourceUrl);
        Assert.Equal(expectedStorageBytes, model.StorageBytes);
        Assert.Equal(expectedStrictMode, model.StrictMode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            Attribution = "attribution",
            Description = "description",
            EdgeCount = 0,
            ErrorMessage = "error_message",
            FeatureCount = 0,
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",
            StorageBytes = 0,
            StrictMode = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dataset>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            Attribution = "attribution",
            Description = "description",
            EdgeCount = 0,
            ErrorMessage = "error_message",
            FeatureCount = 0,
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",
            StorageBytes = 0,
            StrictMode = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dataset>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedInsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "NYC Bike Lanes";
        ApiEnum<string, Scope> expectedScope = Scope.Plaza;
        string expectedSlug = "nyc-bike-lanes";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedAddressCount = 0;
        string expectedAttribution = "attribution";
        string expectedDescription = "description";
        long expectedEdgeCount = 0;
        string expectedErrorMessage = "error_message";
        long expectedFeatureCount = 0;
        string expectedLicense = "license";
        JsonElement expectedSchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedSourceFormat = "source_format";
        string expectedSourceUrl = "https://example.com";
        long expectedStorageBytes = 0;
        bool expectedStrictMode = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedInsertedAt, deserialized.InsertedAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.Equal(expectedSlug, deserialized.Slug);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedAddressCount, deserialized.AddressCount);
        Assert.Equal(expectedAttribution, deserialized.Attribution);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEdgeCount, deserialized.EdgeCount);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedFeatureCount, deserialized.FeatureCount);
        Assert.Equal(expectedLicense, deserialized.License);
        Assert.NotNull(deserialized.SchemaDefinition);
        Assert.True(
            JsonElement.DeepEquals(expectedSchemaDefinition, deserialized.SchemaDefinition.Value)
        );
        Assert.Equal(expectedSourceFormat, deserialized.SourceFormat);
        Assert.Equal(expectedSourceUrl, deserialized.SourceUrl);
        Assert.Equal(expectedStorageBytes, deserialized.StorageBytes);
        Assert.Equal(expectedStrictMode, deserialized.StrictMode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            Attribution = "attribution",
            Description = "description",
            EdgeCount = 0,
            ErrorMessage = "error_message",
            FeatureCount = 0,
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",
            StorageBytes = 0,
            StrictMode = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Attribution = "attribution",
            Description = "description",
            ErrorMessage = "error_message",
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",
        };

        Assert.Null(model.AddressCount);
        Assert.False(model.RawData.ContainsKey("address_count"));
        Assert.Null(model.EdgeCount);
        Assert.False(model.RawData.ContainsKey("edge_count"));
        Assert.Null(model.FeatureCount);
        Assert.False(model.RawData.ContainsKey("feature_count"));
        Assert.Null(model.StorageBytes);
        Assert.False(model.RawData.ContainsKey("storage_bytes"));
        Assert.Null(model.StrictMode);
        Assert.False(model.RawData.ContainsKey("strict_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Attribution = "attribution",
            Description = "description",
            ErrorMessage = "error_message",
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Attribution = "attribution",
            Description = "description",
            ErrorMessage = "error_message",
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            AddressCount = null,
            EdgeCount = null,
            FeatureCount = null,
            StorageBytes = null,
            StrictMode = null,
        };

        Assert.Null(model.AddressCount);
        Assert.False(model.RawData.ContainsKey("address_count"));
        Assert.Null(model.EdgeCount);
        Assert.False(model.RawData.ContainsKey("edge_count"));
        Assert.Null(model.FeatureCount);
        Assert.False(model.RawData.ContainsKey("feature_count"));
        Assert.Null(model.StorageBytes);
        Assert.False(model.RawData.ContainsKey("storage_bytes"));
        Assert.Null(model.StrictMode);
        Assert.False(model.RawData.ContainsKey("strict_mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Attribution = "attribution",
            Description = "description",
            ErrorMessage = "error_message",
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            AddressCount = null,
            EdgeCount = null,
            FeatureCount = null,
            StorageBytes = null,
            StrictMode = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            EdgeCount = 0,
            FeatureCount = 0,
            StorageBytes = 0,
            StrictMode = true,
        };

        Assert.Null(model.Attribution);
        Assert.False(model.RawData.ContainsKey("attribution"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.License);
        Assert.False(model.RawData.ContainsKey("license"));
        Assert.Null(model.SchemaDefinition);
        Assert.False(model.RawData.ContainsKey("schema_definition"));
        Assert.Null(model.SourceFormat);
        Assert.False(model.RawData.ContainsKey("source_format"));
        Assert.Null(model.SourceUrl);
        Assert.False(model.RawData.ContainsKey("source_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            EdgeCount = 0,
            FeatureCount = 0,
            StorageBytes = 0,
            StrictMode = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            EdgeCount = 0,
            FeatureCount = 0,
            StorageBytes = 0,
            StrictMode = true,

            Attribution = null,
            Description = null,
            ErrorMessage = null,
            License = null,
            SchemaDefinition = null,
            SourceFormat = null,
            SourceUrl = null,
        };

        Assert.Null(model.Attribution);
        Assert.True(model.RawData.ContainsKey("attribution"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.License);
        Assert.True(model.RawData.ContainsKey("license"));
        Assert.Null(model.SchemaDefinition);
        Assert.True(model.RawData.ContainsKey("schema_definition"));
        Assert.Null(model.SourceFormat);
        Assert.True(model.RawData.ContainsKey("source_format"));
        Assert.Null(model.SourceUrl);
        Assert.True(model.RawData.ContainsKey("source_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            EdgeCount = 0,
            FeatureCount = 0,
            StorageBytes = 0,
            StrictMode = true,

            Attribution = null,
            Description = null,
            ErrorMessage = null,
            License = null,
            SchemaDefinition = null,
            SourceFormat = null,
            SourceUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Dataset
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            InsertedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "NYC Bike Lanes",
            Scope = Scope.Plaza,
            Slug = "nyc-bike-lanes",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AddressCount = 0,
            Attribution = "attribution",
            Description = "description",
            EdgeCount = 0,
            ErrorMessage = "error_message",
            FeatureCount = 0,
            License = "license",
            SchemaDefinition = JsonSerializer.Deserialize<JsonElement>("{}"),
            SourceFormat = "source_format",
            SourceUrl = "https://example.com",
            StorageBytes = 0,
            StrictMode = true,
        };

        Dataset copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScopeTest : TestBase
{
    [Theory]
    [InlineData(Scope.Plaza)]
    [InlineData(Scope.User)]
    public void Validation_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Scope.Plaza)]
    [InlineData(Scope.User)]
    public void SerializationRoundtrip_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Ready)]
    [InlineData(Status.Error)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Processing)]
    [InlineData(Status.Ready)]
    [InlineData(Status.Error)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
