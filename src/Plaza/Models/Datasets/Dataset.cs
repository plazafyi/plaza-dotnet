using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Datasets;

/// <summary>
/// Metadata for a custom dataset. Datasets contain user-uploaded geospatial features
/// separate from the OSM data.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Dataset, DatasetFromRaw>))]
public sealed record class Dataset : JsonModel
{
    /// <summary>
    /// Dataset UUID
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Creation timestamp (UTC)
    /// </summary>
    public required System::DateTimeOffset InsertedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("inserted_at");
        }
        init { this._rawData.Set("inserted_at", value); }
    }

    /// <summary>
    /// Human-readable dataset name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Dataset scope: plaza (managed by Plaza) or user (user-owned)
    /// </summary>
    public required ApiEnum<string, Scope> Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Scope>>("scope");
        }
        init { this._rawData.Set("scope", value); }
    }

    /// <summary>
    /// URL-friendly identifier
    /// </summary>
    public required string Slug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("slug");
        }
        init { this._rawData.Set("slug", value); }
    }

    /// <summary>
    /// Current processing status
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Last update timestamp (UTC)
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Number of addresses in this dataset
    /// </summary>
    public long? AddressCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("address_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("address_count", value);
        }
    }

    /// <summary>
    /// Required attribution text
    /// </summary>
    public string? Attribution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("attribution");
        }
        init { this._rawData.Set("attribution", value); }
    }

    /// <summary>
    /// Dataset description
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Number of routing edges in this dataset
    /// </summary>
    public long? EdgeCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("edge_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("edge_count", value);
        }
    }

    /// <summary>
    /// Error message if status is 'error'
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// Number of features in this dataset
    /// </summary>
    public long? FeatureCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("feature_count");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("feature_count", value);
        }
    }

    /// <summary>
    /// License identifier (e.g. CC-BY-4.0)
    /// </summary>
    public string? License
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("license");
        }
        init { this._rawData.Set("license", value); }
    }

    /// <summary>
    /// Detected or user-defined property schema
    /// </summary>
    public JsonElement? SchemaDefinition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("schema_definition");
        }
        init { this._rawData.Set("schema_definition", value); }
    }

    /// <summary>
    /// Data format (geojson)
    /// </summary>
    public string? SourceFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_format");
        }
        init { this._rawData.Set("source_format", value); }
    }

    /// <summary>
    /// URL of the original data source
    /// </summary>
    public string? SourceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_url");
        }
        init { this._rawData.Set("source_url", value); }
    }

    /// <summary>
    /// Total storage consumed in bytes
    /// </summary>
    public long? StorageBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("storage_bytes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("storage_bytes", value);
        }
    }

    /// <summary>
    /// Whether strict schema validation is enabled
    /// </summary>
    public bool? StrictMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("strict_mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.InsertedAt;
        _ = this.Name;
        this.Scope.Validate();
        _ = this.Slug;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.AddressCount;
        _ = this.Attribution;
        _ = this.Description;
        _ = this.EdgeCount;
        _ = this.ErrorMessage;
        _ = this.FeatureCount;
        _ = this.License;
        _ = this.SchemaDefinition;
        _ = this.SourceFormat;
        _ = this.SourceUrl;
        _ = this.StorageBytes;
        _ = this.StrictMode;
    }

    public Dataset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Dataset(Dataset dataset)
        : base(dataset) { }
#pragma warning restore CS8618

    public Dataset(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dataset(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DatasetFromRaw.FromRawUnchecked"/>
    public static Dataset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DatasetFromRaw : IFromRawJson<Dataset>
{
    /// <inheritdoc/>
    public Dataset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Dataset.FromRawUnchecked(rawData);
}

/// <summary>
/// Dataset scope: plaza (managed by Plaza) or user (user-owned)
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    Plaza,
    User,
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "plaza" => Scope.Plaza,
            "user" => Scope.User,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.Plaza => "plaza",
                Scope.User => "user",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Current processing status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Processing,
    Ready,
    Error,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "processing" => Status.Processing,
            "ready" => Status.Ready,
            "error" => Status.Error,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Processing => "processing",
                Status.Ready => "ready",
                Status.Error => "error",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
