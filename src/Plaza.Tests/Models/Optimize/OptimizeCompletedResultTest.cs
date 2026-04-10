using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Optimize;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.Optimize;

public class OptimizeCompletedResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OptimizeCompletedResult
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

        List<Feature> expectedFeatures =
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
        ];
        string expectedOptimization = "optimization";
        bool expectedRoundtrip = true;
        double expectedTotalCostS = 0;
        ApiEnum<string, OptimizeCompletedResultType> expectedType =
            OptimizeCompletedResultType.FeatureCollection;

        Assert.Equal(expectedFeatures.Count, model.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], model.Features[i]);
        }
        Assert.Equal(expectedOptimization, model.Optimization);
        Assert.Equal(expectedRoundtrip, model.Roundtrip);
        Assert.Equal(expectedTotalCostS, model.TotalCostS);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OptimizeCompletedResult
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeCompletedResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OptimizeCompletedResult
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OptimizeCompletedResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Feature> expectedFeatures =
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
        ];
        string expectedOptimization = "optimization";
        bool expectedRoundtrip = true;
        double expectedTotalCostS = 0;
        ApiEnum<string, OptimizeCompletedResultType> expectedType =
            OptimizeCompletedResultType.FeatureCollection;

        Assert.Equal(expectedFeatures.Count, deserialized.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], deserialized.Features[i]);
        }
        Assert.Equal(expectedOptimization, deserialized.Optimization);
        Assert.Equal(expectedRoundtrip, deserialized.Roundtrip);
        Assert.Equal(expectedTotalCostS, deserialized.TotalCostS);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OptimizeCompletedResult
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OptimizeCompletedResult
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

        OptimizeCompletedResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Feature
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
        };

        Models::Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        Properties expectedProperties = new()
        {
            CostS = 0,
            CumulativeCostS = 0,
            WaypointIndex = 0,
        };
        ApiEnum<string, Type> expectedType = Type.Feature;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedProperties, model.Properties);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Feature
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Feature
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Feature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Models::Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        Properties expectedProperties = new()
        {
            CostS = 0,
            CumulativeCostS = 0,
            WaypointIndex = 0,
        };
        ApiEnum<string, Type> expectedType = Type.Feature;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedProperties, deserialized.Properties);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Feature
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Feature
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
        };

        Feature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PropertiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Properties
        {
            CostS = 0,
            CumulativeCostS = 0,
            WaypointIndex = 0,
        };

        double expectedCostS = 0;
        double expectedCumulativeCostS = 0;
        long expectedWaypointIndex = 0;

        Assert.Equal(expectedCostS, model.CostS);
        Assert.Equal(expectedCumulativeCostS, model.CumulativeCostS);
        Assert.Equal(expectedWaypointIndex, model.WaypointIndex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Properties
        {
            CostS = 0,
            CumulativeCostS = 0,
            WaypointIndex = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Properties>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Properties
        {
            CostS = 0,
            CumulativeCostS = 0,
            WaypointIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Properties>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCostS = 0;
        double expectedCumulativeCostS = 0;
        long expectedWaypointIndex = 0;

        Assert.Equal(expectedCostS, deserialized.CostS);
        Assert.Equal(expectedCumulativeCostS, deserialized.CumulativeCostS);
        Assert.Equal(expectedWaypointIndex, deserialized.WaypointIndex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Properties
        {
            CostS = 0,
            CumulativeCostS = 0,
            WaypointIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Properties
        {
            CostS = 0,
            CumulativeCostS = 0,
            WaypointIndex = 0,
        };

        Properties copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Feature)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Feature)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OptimizeCompletedResultTypeTest : TestBase
{
    [Theory]
    [InlineData(OptimizeCompletedResultType.FeatureCollection)]
    public void Validation_Works(OptimizeCompletedResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OptimizeCompletedResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OptimizeCompletedResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OptimizeCompletedResultType.FeatureCollection)]
    public void SerializationRoundtrip_Works(OptimizeCompletedResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OptimizeCompletedResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OptimizeCompletedResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OptimizeCompletedResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OptimizeCompletedResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
