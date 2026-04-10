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
/// Status of an async optimization job. When `completed`, the `result` field contains
/// the full OptimizeCompletedResult. When `processing`, the job is still running
/// — poll again. Failed jobs return a standard Error response (HTTP 422), not this schema.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OptimizeJobStatus, OptimizeJobStatusFromRaw>))]
public sealed record class OptimizeJobStatus : JsonModel
{
    /// <summary>
    /// Current job state
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
    /// Completed optimization result as a GeoJSON FeatureCollection. Each Feature
    /// is a waypoint in optimized visit order. Top-level fields provide summary statistics.
    /// </summary>
    public OptimizeCompletedResult? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OptimizeCompletedResult>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        this.Result?.Validate();
    }

    public OptimizeJobStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OptimizeJobStatus(OptimizeJobStatus optimizeJobStatus)
        : base(optimizeJobStatus) { }
#pragma warning restore CS8618

    public OptimizeJobStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OptimizeJobStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptimizeJobStatusFromRaw.FromRawUnchecked"/>
    public static OptimizeJobStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OptimizeJobStatus(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class OptimizeJobStatusFromRaw : IFromRawJson<OptimizeJobStatus>
{
    /// <inheritdoc/>
    public OptimizeJobStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OptimizeJobStatus.FromRawUnchecked(rawData);
}

/// <summary>
/// Current job state
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Completed,
    Processing,
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
            "completed" => Status.Completed,
            "processing" => Status.Processing,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Completed => "completed",
                Status.Processing => "processing",
                _ => throw new PlazaInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
