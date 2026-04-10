using System.Text.Json;
using Plaza.Core;
using Plaza.Models.Optimize;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.Optimize;

public class OptimizeResultTest : TestBase
{
    [Fact]
    public void CompletedValidationWorks()
    {
        OptimizeResult value = new OptimizeCompletedResult()
        {
            Features =
            [
                new()
                {
                    Geometry = new Models::PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = Models::PointGeometryType.Point,
                    },
                    Properties = new()
                    {
                        CostS = 0,
                        CumulativeCostS = 0,
                        WaypointIndex = 0,
                    },
                    Type = Type.Feature,
                },
            ],
            Optimization = "optimization",
            Roundtrip = true,
            TotalCostS = 0,
            Type = OptimizeCompletedResultType.FeatureCollection,
        };
        value.Validate();
    }

    [Fact]
    public void ProcessingValidationWorks()
    {
        OptimizeResult value = new OptimizeProcessingResult()
        {
            JobID = "opt_abc123",
            Status = OptimizeProcessingResultStatus.Processing,
        };
        value.Validate();
    }

    [Fact]
    public void CompletedSerializationRoundtripWorks()
    {
        OptimizeResult value = new OptimizeCompletedResult()
        {
            Features =
            [
                new()
                {
                    Geometry = new Models::PointGeometry()
                    {
                        Coordinates = [2.3522, 48.8566],
                        Type = Models::PointGeometryType.Point,
                    },
                    Properties = new()
                    {
                        CostS = 0,
                        CumulativeCostS = 0,
                        WaypointIndex = 0,
                    },
                    Type = Type.Feature,
                },
            ],
            Optimization = "optimization",
            Roundtrip = true,
            TotalCostS = 0,
            Type = OptimizeCompletedResultType.FeatureCollection,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ProcessingSerializationRoundtripWorks()
    {
        OptimizeResult value = new OptimizeProcessingResult()
        {
            JobID = "opt_abc123",
            Status = OptimizeProcessingResultStatus.Processing,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
