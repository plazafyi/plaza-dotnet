using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Plaza.Core;

namespace Plaza.Models.Datasets;

/// <summary>
/// List of datasets visible to the authenticated user.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DatasetList, DatasetListFromRaw>))]
public sealed record class DatasetList : JsonModel
{
    /// <summary>
    /// Array of dataset metadata objects
    /// </summary>
    public required IReadOnlyList<Dataset> Datasets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Dataset>>("datasets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Dataset>>(
                "datasets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Datasets)
        {
            item.Validate();
        }
    }

    public DatasetList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DatasetList(DatasetList datasetList)
        : base(datasetList) { }
#pragma warning restore CS8618

    public DatasetList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DatasetList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DatasetListFromRaw.FromRawUnchecked"/>
    public static DatasetList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DatasetList(IReadOnlyList<Dataset> datasets)
        : this()
    {
        this.Datasets = datasets;
    }
}

class DatasetListFromRaw : IFromRawJson<DatasetList>
{
    /// <inheritdoc/>
    public DatasetList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DatasetList.FromRawUnchecked(rawData);
}
