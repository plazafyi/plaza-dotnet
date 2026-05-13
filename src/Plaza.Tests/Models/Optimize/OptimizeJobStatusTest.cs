using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Optimize;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.Optimize;

public class OptimizeJobStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OptimizeJobStatus
        {
            Status = Status.Completed,
            Result = new()
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
            },
        };

        ApiEnum<string, Status> expectedStatus = Status.Completed;
        OptimizeCompletedResult expectedResult = new()
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

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OptimizeJobStatus
        {
            Status = Status.Completed,
            Result = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeJobStatus>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OptimizeJobStatus
        {
            Status = Status.Completed,
            Result = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeJobStatus>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.Completed;
        OptimizeCompletedResult expectedResult = new()
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

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OptimizeJobStatus
        {
            Status = Status.Completed,
            Result = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OptimizeJobStatus { Status = Status.Completed };

        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new OptimizeJobStatus { Status = Status.Completed };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OptimizeJobStatus
        {
            Status = Status.Completed,

            Result = null,
        };

        Assert.Null(model.Result);
        Assert.True(model.RawData.ContainsKey("result"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OptimizeJobStatus
        {
            Status = Status.Completed,

            Result = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OptimizeJobStatus
        {
            Status = Status.Completed,
            Result = new()
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
            },
        };

        OptimizeJobStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Completed)]
    [InlineData(Status.Processing)]
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
    [InlineData(Status.Completed)]
    [InlineData(Status.Processing)]
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
