using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Features;

/// <summary>
/// Fetch multiple OSM elements by their type and ID in a single request. Maximum
/// 100 elements per batch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchRequest, BatchRequestFromRaw>))]
public sealed record class BatchRequest : JsonModel
{
    /// <summary>
    /// Array of element references to fetch
    /// </summary>
    public required IReadOnlyList<BatchRequestElement> Elements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BatchRequestElement>>("elements");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BatchRequestElement>>(
                "elements",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
    }

    public BatchRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchRequest(BatchRequest batchRequest)
        : base(batchRequest) { }
#pragma warning restore CS8618

    public BatchRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchRequestFromRaw.FromRawUnchecked"/>
    public static BatchRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BatchRequest(IReadOnlyList<BatchRequestElement> elements)
        : this()
    {
        this.Elements = elements;
    }
}

class BatchRequestFromRaw : IFromRawJson<BatchRequest>
{
    /// <inheritdoc/>
    public BatchRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to a single OSM element
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BatchRequestElement, BatchRequestElementFromRaw>))]
public sealed record class BatchRequestElement : JsonModel
{
    /// <summary>
    /// OSM element ID
    /// </summary>
    public required long ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// OSM element type
    /// </summary>
    public required ApiEnum<string, BatchRequestElementType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BatchRequestElementType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public BatchRequestElement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BatchRequestElement(BatchRequestElement batchRequestElement)
        : base(batchRequestElement) { }
#pragma warning restore CS8618

    public BatchRequestElement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchRequestElement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BatchRequestElementFromRaw.FromRawUnchecked"/>
    public static BatchRequestElement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BatchRequestElementFromRaw : IFromRawJson<BatchRequestElement>
{
    /// <inheritdoc/>
    public BatchRequestElement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BatchRequestElement.FromRawUnchecked(rawData);
}

/// <summary>
/// OSM element type
/// </summary>
[JsonConverter(typeof(BatchRequestElementTypeConverter))]
public enum BatchRequestElementType
{
    Node,
    Way,
    Relation,
}

sealed class BatchRequestElementTypeConverter : JsonConverter<BatchRequestElementType>
{
    public override BatchRequestElementType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "node" => BatchRequestElementType.Node,
            "way" => BatchRequestElementType.Way,
            "relation" => BatchRequestElementType.Relation,
            _ => (BatchRequestElementType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BatchRequestElementType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BatchRequestElementType.Node => "node",
                BatchRequestElementType.Way => "way",
                BatchRequestElementType.Relation => "relation",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
