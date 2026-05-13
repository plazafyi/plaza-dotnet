using System;
using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Models.Datasets;

namespace Plaza.Tests.Models.Datasets;

public class DatasetListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DatasetList
        {
            Datasets =
            [
                new()
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
                },
            ],
        };

        List<Dataset> expectedDatasets =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedDatasets.Count, model.Datasets.Count);
        for (int i = 0; i < expectedDatasets.Count; i++)
        {
            Assert.Equal(expectedDatasets[i], model.Datasets[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DatasetList
        {
            Datasets =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DatasetList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DatasetList
        {
            Datasets =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DatasetList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Dataset> expectedDatasets =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedDatasets.Count, deserialized.Datasets.Count);
        for (int i = 0; i < expectedDatasets.Count; i++)
        {
            Assert.Equal(expectedDatasets[i], deserialized.Datasets[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DatasetList
        {
            Datasets =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DatasetList
        {
            Datasets =
            [
                new()
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
                },
            ],
        };

        DatasetList copied = new(model);

        Assert.Equal(model, copied);
    }
}
