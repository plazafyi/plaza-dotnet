using System;
using System.Collections.Generic;
using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models;
using Plaza.Models.Routing;

namespace Plaza.Tests.Models.Routing;

public class RouteRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
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
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,
            TrafficModel = RouteRequestTrafficModel.BestGuess,
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
        long expectedAlternatives = 0;
        bool expectedAnnotations = true;
        DateTimeOffset expectedDepartAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        RouteRequestEv expectedEv = new()
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };
        string expectedExclude = "exclude";
        ApiEnum<string, RouteRequestGeometries> expectedGeometries = RouteRequestGeometries.Geojson;
        ApiEnum<string, RouteRequestMode> expectedMode = RouteRequestMode.Auto;
        ApiEnum<string, RouteRequestOverview> expectedOverview = RouteRequestOverview.Full;
        bool expectedSteps = true;
        ApiEnum<string, RouteRequestTrafficModel> expectedTrafficModel =
            RouteRequestTrafficModel.BestGuess;
        List<PointGeometry> expectedWaypoints =
        [
            new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        ];

        Assert.Equal(expectedDestination, model.Destination);
        Assert.Equal(expectedOrigin, model.Origin);
        Assert.Equal(expectedAlternatives, model.Alternatives);
        Assert.Equal(expectedAnnotations, model.Annotations);
        Assert.Equal(expectedDepartAt, model.DepartAt);
        Assert.Equal(expectedEv, model.Ev);
        Assert.Equal(expectedExclude, model.Exclude);
        Assert.Equal(expectedGeometries, model.Geometries);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedOverview, model.Overview);
        Assert.Equal(expectedSteps, model.Steps);
        Assert.Equal(expectedTrafficModel, model.TrafficModel);
        Assert.NotNull(model.Waypoints);
        Assert.Equal(expectedWaypoints.Count, model.Waypoints.Count);
        for (int i = 0; i < expectedWaypoints.Count; i++)
        {
            Assert.Equal(expectedWaypoints[i], model.Waypoints[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
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
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,
            TrafficModel = RouteRequestTrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
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
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,
            TrafficModel = RouteRequestTrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        long expectedAlternatives = 0;
        bool expectedAnnotations = true;
        DateTimeOffset expectedDepartAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        RouteRequestEv expectedEv = new()
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };
        string expectedExclude = "exclude";
        ApiEnum<string, RouteRequestGeometries> expectedGeometries = RouteRequestGeometries.Geojson;
        ApiEnum<string, RouteRequestMode> expectedMode = RouteRequestMode.Auto;
        ApiEnum<string, RouteRequestOverview> expectedOverview = RouteRequestOverview.Full;
        bool expectedSteps = true;
        ApiEnum<string, RouteRequestTrafficModel> expectedTrafficModel =
            RouteRequestTrafficModel.BestGuess;
        List<PointGeometry> expectedWaypoints =
        [
            new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
        ];

        Assert.Equal(expectedDestination, deserialized.Destination);
        Assert.Equal(expectedOrigin, deserialized.Origin);
        Assert.Equal(expectedAlternatives, deserialized.Alternatives);
        Assert.Equal(expectedAnnotations, deserialized.Annotations);
        Assert.Equal(expectedDepartAt, deserialized.DepartAt);
        Assert.Equal(expectedEv, deserialized.Ev);
        Assert.Equal(expectedExclude, deserialized.Exclude);
        Assert.Equal(expectedGeometries, deserialized.Geometries);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedOverview, deserialized.Overview);
        Assert.Equal(expectedSteps, deserialized.Steps);
        Assert.Equal(expectedTrafficModel, deserialized.TrafficModel);
        Assert.NotNull(deserialized.Waypoints);
        Assert.Equal(expectedWaypoints.Count, deserialized.Waypoints.Count);
        for (int i = 0; i < expectedWaypoints.Count; i++)
        {
            Assert.Equal(expectedWaypoints[i], deserialized.Waypoints[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
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
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,
            TrafficModel = RouteRequestTrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RouteRequest
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
            TrafficModel = RouteRequestTrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        Assert.Null(model.Alternatives);
        Assert.False(model.RawData.ContainsKey("alternatives"));
        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
        Assert.Null(model.Geometries);
        Assert.False(model.RawData.ContainsKey("geometries"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Overview);
        Assert.False(model.RawData.ContainsKey("overview"));
        Assert.Null(model.Steps);
        Assert.False(model.RawData.ContainsKey("steps"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RouteRequest
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
            TrafficModel = RouteRequestTrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RouteRequest
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
            TrafficModel = RouteRequestTrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],

            // Null should be interpreted as omitted for these properties
            Alternatives = null,
            Annotations = null,
            Geometries = null,
            Mode = null,
            Overview = null,
            Steps = null,
        };

        Assert.Null(model.Alternatives);
        Assert.False(model.RawData.ContainsKey("alternatives"));
        Assert.Null(model.Annotations);
        Assert.False(model.RawData.ContainsKey("annotations"));
        Assert.Null(model.Geometries);
        Assert.False(model.RawData.ContainsKey("geometries"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Overview);
        Assert.False(model.RawData.ContainsKey("overview"));
        Assert.Null(model.Steps);
        Assert.False(model.RawData.ContainsKey("steps"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RouteRequest
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
            TrafficModel = RouteRequestTrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],

            // Null should be interpreted as omitted for these properties
            Alternatives = null,
            Annotations = null,
            Geometries = null,
            Mode = null,
            Overview = null,
            Steps = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Alternatives = 0,
            Annotations = true,
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,
        };

        Assert.Null(model.DepartAt);
        Assert.False(model.RawData.ContainsKey("depart_at"));
        Assert.Null(model.Ev);
        Assert.False(model.RawData.ContainsKey("ev"));
        Assert.Null(model.Exclude);
        Assert.False(model.RawData.ContainsKey("exclude"));
        Assert.Null(model.TrafficModel);
        Assert.False(model.RawData.ContainsKey("traffic_model"));
        Assert.Null(model.Waypoints);
        Assert.False(model.RawData.ContainsKey("waypoints"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Alternatives = 0,
            Annotations = true,
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Alternatives = 0,
            Annotations = true,
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,

            DepartAt = null,
            Ev = null,
            Exclude = null,
            TrafficModel = null,
            Waypoints = null,
        };

        Assert.Null(model.DepartAt);
        Assert.True(model.RawData.ContainsKey("depart_at"));
        Assert.Null(model.Ev);
        Assert.True(model.RawData.ContainsKey("ev"));
        Assert.Null(model.Exclude);
        Assert.True(model.RawData.ContainsKey("exclude"));
        Assert.Null(model.TrafficModel);
        Assert.True(model.RawData.ContainsKey("traffic_model"));
        Assert.Null(model.Waypoints);
        Assert.True(model.RawData.ContainsKey("waypoints"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
            Alternatives = 0,
            Annotations = true,
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,

            DepartAt = null,
            Ev = null,
            Exclude = null,
            TrafficModel = null,
            Waypoints = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RouteRequest
        {
            Destination = new() { Coordinates = [2.2945, 48.8584], Type = PointGeometryType.Point },
            Origin = new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point },
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
            Geometries = RouteRequestGeometries.Geojson,
            Mode = RouteRequestMode.Auto,
            Overview = RouteRequestOverview.Full,
            Steps = true,
            TrafficModel = RouteRequestTrafficModel.BestGuess,
            Waypoints = [new() { Coordinates = [2.3522, 48.8566], Type = PointGeometryType.Point }],
        };

        RouteRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RouteRequestEvTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteRequestEv>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RouteRequestEv
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RouteRequestEv>(
            element,
            ModelBase.SerializerOptions
        );
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
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
        var model = new RouteRequestEv
        {
            BatteryCapacityWh = 75000,
            ConnectorTypes = ["string"],
            InitialChargePct = 0,
            MinChargePct = 0,
            MinPowerKw = 0,
        };

        RouteRequestEv copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RouteRequestGeometriesTest : TestBase
{
    [Theory]
    [InlineData(RouteRequestGeometries.Geojson)]
    [InlineData(RouteRequestGeometries.Polyline)]
    [InlineData(RouteRequestGeometries.Polyline6)]
    public void Validation_Works(RouteRequestGeometries rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRequestGeometries> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestGeometries>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RouteRequestGeometries.Geojson)]
    [InlineData(RouteRequestGeometries.Polyline)]
    [InlineData(RouteRequestGeometries.Polyline6)]
    public void SerializationRoundtrip_Works(RouteRequestGeometries rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRequestGeometries> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestGeometries>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestGeometries>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestGeometries>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RouteRequestModeTest : TestBase
{
    [Theory]
    [InlineData(RouteRequestMode.Auto)]
    [InlineData(RouteRequestMode.Foot)]
    [InlineData(RouteRequestMode.Bicycle)]
    public void Validation_Works(RouteRequestMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRequestMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RouteRequestMode.Auto)]
    [InlineData(RouteRequestMode.Foot)]
    [InlineData(RouteRequestMode.Bicycle)]
    public void SerializationRoundtrip_Works(RouteRequestMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRequestMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RouteRequestOverviewTest : TestBase
{
    [Theory]
    [InlineData(RouteRequestOverview.Full)]
    [InlineData(RouteRequestOverview.Simplified)]
    [InlineData(RouteRequestOverview.False)]
    public void Validation_Works(RouteRequestOverview rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRequestOverview> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestOverview>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RouteRequestOverview.Full)]
    [InlineData(RouteRequestOverview.Simplified)]
    [InlineData(RouteRequestOverview.False)]
    public void SerializationRoundtrip_Works(RouteRequestOverview rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRequestOverview> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestOverview>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestOverview>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestOverview>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RouteRequestTrafficModelTest : TestBase
{
    [Theory]
    [InlineData(RouteRequestTrafficModel.BestGuess)]
    [InlineData(RouteRequestTrafficModel.Optimistic)]
    [InlineData(RouteRequestTrafficModel.Pessimistic)]
    public void Validation_Works(RouteRequestTrafficModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRequestTrafficModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestTrafficModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RouteRequestTrafficModel.BestGuess)]
    [InlineData(RouteRequestTrafficModel.Optimistic)]
    [InlineData(RouteRequestTrafficModel.Pessimistic)]
    public void SerializationRoundtrip_Works(RouteRequestTrafficModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRequestTrafficModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestTrafficModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestTrafficModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRequestTrafficModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
