using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;
using Plaza.Exceptions;
using System = System;

namespace Plaza.Models.Optimize;

/// <summary>
/// Async optimization in progress. Poll `GET /api/v1/optimize/{job_id}` until the
/// status changes to `completed` or `failed`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<OptimizeProcessingResult, OptimizeProcessingResultFromRaw>)
)]
public sealed record class OptimizeProcessingResult : JsonModel
{
    /// <summary>
    /// Job ID for polling the result
    /// </summary>
    public required string JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("job_id");
        }
        init { this._rawData.Set("job_id", value); }
    }

    /// <summary>
    /// Always `processing`
    /// </summary>
    public required ApiEnum<string, OptimizeProcessingResultStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, OptimizeProcessingResultStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JobID;
        this.Status.Validate();
    }

    public OptimizeProcessingResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OptimizeProcessingResult(OptimizeProcessingResult optimizeProcessingResult)
        : base(optimizeProcessingResult) { }
#pragma warning restore CS8618

    public OptimizeProcessingResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OptimizeProcessingResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptimizeProcessingResultFromRaw.FromRawUnchecked"/>
    public static OptimizeProcessingResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptimizeProcessingResultFromRaw : IFromRawJson<OptimizeProcessingResult>
{
    /// <inheritdoc/>
    public OptimizeProcessingResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OptimizeProcessingResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Always `processing`
/// </summary>
[JsonConverter(typeof(OptimizeProcessingResultStatusConverter))]
public enum OptimizeProcessingResultStatus
{
    Processing,
}

sealed class OptimizeProcessingResultStatusConverter : JsonConverter<OptimizeProcessingResultStatus>
{
    public override OptimizeProcessingResultStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "processing" => OptimizeProcessingResultStatus.Processing,
            _ => (OptimizeProcessingResultStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OptimizeProcessingResultStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OptimizeProcessingResultStatus.Processing => "processing",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
