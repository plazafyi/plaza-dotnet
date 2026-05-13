using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class RouteResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RouteResult
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 4523.7,
                DurationS = 847.2,
                Annotations = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ChargeProfile =
                [
                    [0],
                ],
                ChargingStops =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Edges =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                EnergyUsedWh = 0,
            },
            Type = RouteResultType.Feature,
        };

        Geometry expectedGeometry = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        RouteResultProperties expectedProperties = new()
        {
            DistanceM = 4523.7,
            DurationS = 847.2,
            Annotations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ChargeProfile =
            [
                [0],
            ],
            ChargingStops =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Edges =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            EnergyUsedWh = 0,
        };
        ApiEnum<string, RouteResultType> expectedType = RouteResultType.Feature;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedProperties, model.Properties);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RouteResult
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 4523.7,
                DurationS = 847.2,
                Annotations = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ChargeProfile =
                [
                    [0],
                ],
                ChargingStops =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Edges =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                EnergyUsedWh = 0,
            },
            Type = RouteResultType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RouteResult
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 4523.7,
                DurationS = 847.2,
                Annotations = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ChargeProfile =
                [
                    [0],
                ],
                ChargingStops =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Edges =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                EnergyUsedWh = 0,
            },
            Type = RouteResultType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Geometry expectedGeometry = new PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        RouteResultProperties expectedProperties = new()
        {
            DistanceM = 4523.7,
            DurationS = 847.2,
            Annotations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ChargeProfile =
            [
                [0],
            ],
            ChargingStops =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Edges =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            EnergyUsedWh = 0,
        };
        ApiEnum<string, RouteResultType> expectedType = RouteResultType.Feature;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedProperties, deserialized.Properties);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RouteResult
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 4523.7,
                DurationS = 847.2,
                Annotations = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ChargeProfile =
                [
                    [0],
                ],
                ChargingStops =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Edges =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                EnergyUsedWh = 0,
            },
            Type = RouteResultType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RouteResult
        {
            Geometry = new PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = PointGeometryType.Point,
            },
            Properties = new()
            {
                DistanceM = 4523.7,
                DurationS = 847.2,
                Annotations = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ChargeProfile =
                [
                    [0],
                ],
                ChargingStops =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                Edges =
                [
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                ],
                EnergyUsedWh = 0,
            },
            Type = RouteResultType.Feature,
        };

        RouteResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RouteResultPropertiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RouteResultProperties
        {
            DistanceM = 4523.7,
            DurationS = 847.2,
            Annotations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ChargeProfile =
            [
                [0],
            ],
            ChargingStops =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Edges =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            EnergyUsedWh = 0,
        };

        double expectedDistanceM = 4523.7;
        double expectedDurationS = 847.2;
        Dictionary<string, JsonElement> expectedAnnotations = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<List<double>> expectedChargeProfile =
        [
            [0],
        ];
        List<Dictionary<string, JsonElement>> expectedChargingStops =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        List<Dictionary<string, JsonElement>> expectedEdges =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        double expectedEnergyUsedWh = 0;

        Assert.Equal(expectedDistanceM, model.DistanceM);
        Assert.Equal(expectedDurationS, model.DurationS);
        Assert.NotNull(model.Annotations);
        Assert.Equal(expectedAnnotations.Count, model.Annotations.Count);
        foreach (var item in expectedAnnotations)
        {
            Assert.True(model.Annotations.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Annotations[item.Key]));
        }
        Assert.NotNull(model.ChargeProfile);
        Assert.Equal(expectedChargeProfile.Count, model.ChargeProfile.Count);
        for (int i = 0; i < expectedChargeProfile.Count; i++)
        {
            Assert.Equal(expectedChargeProfile[i].Count, model.ChargeProfile[i].Count);
            for (int i1 = 0; i1 < expectedChargeProfile[i].Count; i1++)
            {
                Assert.Equal(expectedChargeProfile[i][i1], model.ChargeProfile[i][i1]);
            }
        }
        Assert.NotNull(model.ChargingStops);
        Assert.Equal(expectedChargingStops.Count, model.ChargingStops.Count);
        for (int i = 0; i < expectedChargingStops.Count; i++)
        {
            Assert.Equal(expectedChargingStops[i].Count, model.ChargingStops[i].Count);
            foreach (var item in expectedChargingStops[i])
            {
                Assert.True(model.ChargingStops[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.ChargingStops[i][item.Key]));
            }
        }
        Assert.NotNull(model.Edges);
        Assert.Equal(expectedEdges.Count, model.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.Equal(expectedEdges[i].Count, model.Edges[i].Count);
            foreach (var item in expectedEdges[i])
            {
                Assert.True(model.Edges[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.Edges[i][item.Key]));
            }
        }
        Assert.Equal(expectedEnergyUsedWh, model.EnergyUsedWh);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RouteResultProperties
        {
            DistanceM = 4523.7,
            DurationS = 847.2,
            Annotations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ChargeProfile =
            [
                [0],
            ],
            ChargingStops =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Edges =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            EnergyUsedWh = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteResultProperties>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RouteResultProperties
        {
            DistanceM = 4523.7,
            DurationS = 847.2,
            Annotations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ChargeProfile =
            [
                [0],
            ],
            ChargingStops =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Edges =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            EnergyUsedWh = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteResultProperties>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDistanceM = 4523.7;
        double expectedDurationS = 847.2;
        Dictionary<string, JsonElement> expectedAnnotations = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<List<double>> expectedChargeProfile =
        [
            [0],
        ];
        List<Dictionary<string, JsonElement>> expectedChargingStops =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        List<Dictionary<string, JsonElement>> expectedEdges =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        double expectedEnergyUsedWh = 0;

        Assert.Equal(expectedDistanceM, deserialized.DistanceM);
        Assert.Equal(expectedDurationS, deserialized.DurationS);
        Assert.NotNull(deserialized.Annotations);
        Assert.Equal(expectedAnnotations.Count, deserialized.Annotations.Count);
        foreach (var item in expectedAnnotations)
        {
            Assert.True(deserialized.Annotations.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Annotations[item.Key]));
        }
        Assert.NotNull(deserialized.ChargeProfile);
        Assert.Equal(expectedChargeProfile.Count, deserialized.ChargeProfile.Count);
        for (int i = 0; i < expectedChargeProfile.Count; i++)
        {
            Assert.Equal(expectedChargeProfile[i].Count, deserialized.ChargeProfile[i].Count);
            for (int i1 = 0; i1 < expectedChargeProfile[i].Count; i1++)
            {
                Assert.Equal(expectedChargeProfile[i][i1], deserialized.ChargeProfile[i][i1]);
            }
        }
        Assert.NotNull(deserialized.ChargingStops);
        Assert.Equal(expectedChargingStops.Count, deserialized.ChargingStops.Count);
        for (int i = 0; i < expectedChargingStops.Count; i++)
        {
            Assert.Equal(expectedChargingStops[i].Count, deserialized.ChargingStops[i].Count);
            foreach (var item in expectedChargingStops[i])
            {
                Assert.True(deserialized.ChargingStops[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.ChargingStops[i][item.Key]));
            }
        }
        Assert.NotNull(deserialized.Edges);
        Assert.Equal(expectedEdges.Count, deserialized.Edges.Count);
        for (int i = 0; i < expectedEdges.Count; i++)
        {
            Assert.Equal(expectedEdges[i].Count, deserialized.Edges[i].Count);
            foreach (var item in expectedEdges[i])
            {
                Assert.True(deserialized.Edges[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.Edges[i][item.Key]));
            }
        }
        Assert.Equal(expectedEnergyUsedWh, deserialized.EnergyUsedWh);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RouteResultProperties
        {
            DistanceM = 4523.7,
            DurationS = 847.2,
            Annotations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ChargeProfile =
            [
                [0],
            ],
            ChargingStops =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Edges =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            EnergyUsedWh = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RouteResultProperties { DistanceM = 4523.7, DurationS = 847.2 };

        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
        Assert.Null(model.ChargeProfile);
        Assert.False(model.RawData.ContainsKey("charge_profile"));
        Assert.Null(model.ChargingStops);
        Assert.False(model.RawData.ContainsKey("charging_stops"));
        Assert.Null(model.Edges);
        Assert.False(model.RawData.ContainsKey("edges"));
        Assert.Null(model.EnergyUsedWh);
        Assert.False(model.RawData.ContainsKey("energy_used_wh"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RouteResultProperties { DistanceM = 4523.7, DurationS = 847.2 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RouteResultProperties
        {
            DistanceM = 4523.7,
            DurationS = 847.2,

            Annotations = null,
            ChargeProfile = null,
            ChargingStops = null,
            Edges = null,
            EnergyUsedWh = null,
        };

        Assert.Null(model.Annotations);
        Assert.True(model.RawData.ContainsKey("annotations"));
        Assert.Null(model.ChargeProfile);
        Assert.True(model.RawData.ContainsKey("charge_profile"));
        Assert.Null(model.ChargingStops);
        Assert.True(model.RawData.ContainsKey("charging_stops"));
        Assert.Null(model.Edges);
        Assert.True(model.RawData.ContainsKey("edges"));
        Assert.Null(model.EnergyUsedWh);
        Assert.True(model.RawData.ContainsKey("energy_used_wh"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RouteResultProperties
        {
            DistanceM = 4523.7,
            DurationS = 847.2,

            Annotations = null,
            ChargeProfile = null,
            ChargingStops = null,
            Edges = null,
            EnergyUsedWh = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RouteResultProperties
        {
            DistanceM = 4523.7,
            DurationS = 847.2,
            Annotations = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ChargeProfile =
            [
                [0],
            ],
            ChargingStops =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            Edges =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
            EnergyUsedWh = 0,
        };

        RouteResultProperties copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RouteResultTypeTest : TestBase
{
    [Theory]
    [InlineData(RouteResultType.Feature)]
    public void Validation_Works(RouteResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RouteResultType.Feature)]
    public void SerializationRoundtrip_Works(RouteResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
