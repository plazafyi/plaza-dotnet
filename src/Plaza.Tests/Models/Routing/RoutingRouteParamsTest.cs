using System;
using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class RoutingRouteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RoutingRouteParams
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
            Alternatives = 0,
            Annotations = true,
            DepartAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Ev = new()
            {
                BatteryCapacityWh = 75000,
                ConnectorTypes = ["string"],
                InitialChargePct = 0,
                MinChargePct = 0,
                MinPowerKw = 0,
            },
            Exclude = "exclude",
            Geometries = Geometries.Geojson,
            Mode = RoutingRouteParamsMode.Auto,
            Overview = Overview.Full,
            Steps = true,
            TrafficModel = TrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        PointGeometry expectedDestination = new()
        {
            Coordinates = [2.2945, 48.8584],
            Type = PointGeometryType.Point,
        };
        PointGeometry expectedOrigin = new()
        {
            Coordinates = [2.3522, 48.8566],
            Type = PointGeometryType.Point,
        };
        string expectedFormat = "format";
        long expectedAlternatives = 0;
        bool expectedAnnotations = true;
        DateTimeOffset expectedDepartAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Ev expectedEv = new()
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };
        string expectedExclude = "exclude";
        ApiEnum<string, Geometries> expectedGeometries = Geometries.Geojson;
        ApiEnum<string, RoutingRouteParamsMode> expectedMode = RoutingRouteParamsMode.Auto;
        ApiEnum<string, Overview> expectedOverview = Overview.Full;
        bool expectedSteps = true;
        ApiEnum<string, TrafficModel> expectedTrafficModel = TrafficModel.BestGuess;
        List<PointGeometry> expectedWaypoints =
        [
            new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        ];

        Assert.Equal(expectedDestination, parameters.Destination);
        Assert.Equal(expectedOrigin, parameters.Origin);
        Assert.Equal(expectedFormat, parameters.Format);
        Assert.Equal(expectedAlternatives, parameters.Alternatives);
        Assert.Equal(expectedAnnotations, parameters.Annotations);
        Assert.Equal(expectedDepartAt, parameters.DepartAt);
        Assert.Equal(expectedEv, parameters.Ev);
        Assert.Equal(expectedExclude, parameters.Exclude);
        Assert.Equal(expectedGeometries, parameters.Geometries);
        Assert.Equal(expectedMode, parameters.Mode);
        Assert.Equal(expectedOverview, parameters.Overview);
        Assert.Equal(expectedSteps, parameters.Steps);
        Assert.Equal(expectedTrafficModel, parameters.TrafficModel);
        Assert.NotNull(parameters.Waypoints);
        Assert.Equal(expectedWaypoints.Count, parameters.Waypoints.Count);
        for (int i = 0; i < expectedWaypoints.Count; i++)
        {
            Assert.Equal(expectedWaypoints[i], parameters.Waypoints[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RoutingRouteParams
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            DepartAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Ev = new()
            {
                BatteryCapacityWh = 75000,
                ConnectorTypes = ["string"],
                InitialChargePct = 0,
                MinChargePct = 0,
                MinPowerKw = 0,
            },
            Exclude = "exclude",
            TrafficModel = TrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Alternatives);
        Assert.False(parameters.RawBodyData.ContainsKey("alternatives"));
        Assert.Null(parameters.Annotations);
        Assert.False(parameters.RawBodyData.ContainsKey("annotations"));
        Assert.Null(parameters.Geometries);
        Assert.False(parameters.RawBodyData.ContainsKey("geometries"));
        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.Overview);
        Assert.False(parameters.RawBodyData.ContainsKey("overview"));
        Assert.Null(parameters.Steps);
        Assert.False(parameters.RawBodyData.ContainsKey("steps"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RoutingRouteParams
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            DepartAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Ev = new()
            {
                BatteryCapacityWh = 75000,
                ConnectorTypes = ["string"],
                InitialChargePct = 0,
                MinChargePct = 0,
                MinPowerKw = 0,
            },
            Exclude = "exclude",
            TrafficModel = TrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],

            // Null should be interpreted as omitted for these properties
            Format = null,
            Alternatives = null,
            Annotations = null,
            Geometries = null,
            Mode = null,
            Overview = null,
            Steps = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
        Assert.Null(parameters.Alternatives);
        Assert.False(parameters.RawBodyData.ContainsKey("alternatives"));
        Assert.Null(parameters.Annotations);
        Assert.False(parameters.RawBodyData.ContainsKey("annotations"));
        Assert.Null(parameters.Geometries);
        Assert.False(parameters.RawBodyData.ContainsKey("geometries"));
        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.Overview);
        Assert.False(parameters.RawBodyData.ContainsKey("overview"));
        Assert.Null(parameters.Steps);
        Assert.False(parameters.RawBodyData.ContainsKey("steps"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RoutingRouteParams
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
            Alternatives = 0,
            Annotations = true,
            Geometries = Geometries.Geojson,
            Mode = RoutingRouteParamsMode.Auto,
            Overview = Overview.Full,
            Steps = true,
        };

        Assert.Null(parameters.DepartAt);
        Assert.False(parameters.RawBodyData.ContainsKey("depart_at"));
        Assert.Null(parameters.Ev);
        Assert.False(parameters.RawBodyData.ContainsKey("ev"));
        Assert.Null(parameters.Exclude);
        Assert.False(parameters.RawBodyData.ContainsKey("exclude"));
        Assert.Null(parameters.TrafficModel);
        Assert.False(parameters.RawBodyData.ContainsKey("traffic_model"));
        Assert.Null(parameters.Waypoints);
        Assert.False(parameters.RawBodyData.ContainsKey("waypoints"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RoutingRouteParams
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
            Alternatives = 0,
            Annotations = true,
            Geometries = Geometries.Geojson,
            Mode = RoutingRouteParamsMode.Auto,
            Overview = Overview.Full,
            Steps = true,

            DepartAt = null,
            Ev = null,
            Exclude = null,
            TrafficModel = null,
            Waypoints = null,
        };

        Assert.Null(parameters.DepartAt);
        Assert.True(parameters.RawBodyData.ContainsKey("depart_at"));
        Assert.Null(parameters.Ev);
        Assert.True(parameters.RawBodyData.ContainsKey("ev"));
        Assert.Null(parameters.Exclude);
        Assert.True(parameters.RawBodyData.ContainsKey("exclude"));
        Assert.Null(parameters.TrafficModel);
        Assert.True(parameters.RawBodyData.ContainsKey("traffic_model"));
        Assert.Null(parameters.Waypoints);
        Assert.True(parameters.RawBodyData.ContainsKey("waypoints"));
    }

    [Fact]
    public void Url_Works()
    {
        RoutingRouteParams parameters = new()
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/route?format=format"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RoutingRouteParams
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Format = "format",
            Alternatives = 0,
            Annotations = true,
            DepartAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Ev = new()
            {
                BatteryCapacityWh = 75000,
                ConnectorTypes = ["string"],
                InitialChargePct = 0,
                MinChargePct = 0,
                MinPowerKw = 0,
            },
            Exclude = "exclude",
            Geometries = Geometries.Geojson,
            Mode = RoutingRouteParamsMode.Auto,
            Overview = Overview.Full,
            Steps = true,
            TrafficModel = TrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        RoutingRouteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };

        double expectedBatteryCapacityWh = 75000;
        List<string> expectedConnectorTypes = ["string"];
        double expectedInitialChargePct = 0;
        double expectedMinChargePct = 0;
        double expectedMinPowerKw = 0;

        Assert.Equal(expectedBatteryCapacityWh, model.BatteryCapacityWh);
        Assert.NotNull(model.ConnectorTypes);
        Assert.Equal(expectedConnectorTypes.Count, model.ConnectorTypes.Count);
        for (int i = 0; i < expectedConnectorTypes.Count; i++)
        {
            Assert.Equal(expectedConnectorTypes[i], model.ConnectorTypes[i]);
        }
        Assert.Equal(expectedInitialChargePct, model.InitialChargePct);
        Assert.Equal(expectedMinChargePct, model.MinChargePct);
        Assert.Equal(expectedMinPowerKw, model.MinPowerKw);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ev>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ev>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedBatteryCapacityWh = 75000;
        List<string> expectedConnectorTypes = ["string"];
        double expectedInitialChargePct = 0;
        double expectedMinChargePct = 0;
        double expectedMinPowerKw = 0;

        Assert.Equal(expectedBatteryCapacityWh, deserialized.BatteryCapacityWh);
        Assert.NotNull(deserialized.ConnectorTypes);
        Assert.Equal(expectedConnectorTypes.Count, deserialized.ConnectorTypes.Count);
        for (int i = 0; i < expectedConnectorTypes.Count; i++)
        {
            Assert.Equal(expectedConnectorTypes[i], deserialized.ConnectorTypes[i]);
        }
        Assert.Equal(expectedInitialChargePct, deserialized.InitialChargePct);
        Assert.Equal(expectedMinChargePct, deserialized.MinChargePct);
        Assert.Equal(expectedMinPowerKw, deserialized.MinPowerKw);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            MinPowerKw = 0,
        };

        Assert.Null(model.InitialChargePct);
        Assert.False(model.RawData.ContainsKey("initial_charge_pct"));
        Assert.Null(model.MinChargePct);
        Assert.False(model.RawData.ContainsKey("min_charge_pct"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            MinPowerKw = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            MinPowerKw = 0,

            // Null should be interpreted as omitted for these properties
            InitialChargePct = null,
            MinChargePct = null,
        };

        Assert.Null(model.InitialChargePct);
        Assert.False(model.RawData.ContainsKey("initial_charge_pct"));
        Assert.Null(model.MinChargePct);
        Assert.False(model.RawData.ContainsKey("min_charge_pct"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            MinPowerKw = 0,

            // Null should be interpreted as omitted for these properties
            InitialChargePct = null,
            MinChargePct = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            InitialChargePct = 0,
            MinChargePct = 0,
        };

        Assert.Null(model.ConnectorTypes);
        Assert.False(model.RawData.ContainsKey("connector_types"));
        Assert.Null(model.MinPowerKw);
        Assert.False(model.RawData.ContainsKey("min_power_kw"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            InitialChargePct = 0,
            MinChargePct = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            InitialChargePct = 0,
            MinChargePct = 0,

            ConnectorTypes = null,
            MinPowerKw = null,
        };

        Assert.Null(model.ConnectorTypes);
        Assert.True(model.RawData.ContainsKey("connector_types"));
        Assert.Null(model.MinPowerKw);
        Assert.True(model.RawData.ContainsKey("min_power_kw"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            InitialChargePct = 0,
            MinChargePct = 0,

            ConnectorTypes = null,
            MinPowerKw = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Ev
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };

        Ev copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GeometriesTest : TestBase
{
    [Theory]
    [InlineData(Geometries.Geojson)]
    [InlineData(Geometries.Polyline)]
    [InlineData(Geometries.Polyline6)]
    public void Validation_Works(Geometries rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Geometries> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Geometries>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Geometries.Geojson)]
    [InlineData(Geometries.Polyline)]
    [InlineData(Geometries.Polyline6)]
    public void SerializationRoundtrip_Works(Geometries rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Geometries> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Geometries>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Geometries>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Geometries>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RoutingRouteParamsModeTest : TestBase
{
    [Theory]
    [InlineData(RoutingRouteParamsMode.Auto)]
    [InlineData(RoutingRouteParamsMode.Foot)]
    [InlineData(RoutingRouteParamsMode.Bicycle)]
    public void Validation_Works(RoutingRouteParamsMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingRouteParamsMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingRouteParamsMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingRouteParamsMode.Auto)]
    [InlineData(RoutingRouteParamsMode.Foot)]
    [InlineData(RoutingRouteParamsMode.Bicycle)]
    public void SerializationRoundtrip_Works(RoutingRouteParamsMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingRouteParamsMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RoutingRouteParamsMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingRouteParamsMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RoutingRouteParamsMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OverviewTest : TestBase
{
    [Theory]
    [InlineData(Overview.Full)]
    [InlineData(Overview.Simplified)]
    [InlineData(Overview.False)]
    public void Validation_Works(Overview rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Overview> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Overview>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Overview.Full)]
    [InlineData(Overview.Simplified)]
    [InlineData(Overview.False)]
    public void SerializationRoundtrip_Works(Overview rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Overview> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Overview>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Overview>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Overview>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrafficModelTest : TestBase
{
    [Theory]
    [InlineData(TrafficModel.BestGuess)]
    [InlineData(TrafficModel.Optimistic)]
    [InlineData(TrafficModel.Pessimistic)]
    public void Validation_Works(TrafficModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrafficModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrafficModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrafficModel.BestGuess)]
    [InlineData(TrafficModel.Optimistic)]
    [InlineData(TrafficModel.Pessimistic)]
    public void SerializationRoundtrip_Works(TrafficModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrafficModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrafficModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrafficModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrafficModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
