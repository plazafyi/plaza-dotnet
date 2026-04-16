using System;
using System.Text.Json;
using Plaza.Core;
using Plaza.Models.Elevation;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.Elevation;

public class ElevationLookupParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ElevationLookupParams
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Format = "format",
        };

        Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        string expectedFormat = "format";

        Assert.Equal(expectedGeometry, parameters.Geometry);
        Assert.Equal(expectedFormat, parameters.Format);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ElevationLookupParams
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ElevationLookupParams
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },

            // Null should be interpreted as omitted for these properties
            Format = null,
        };

        Assert.Null(parameters.Format);
        Assert.False(parameters.RawQueryData.ContainsKey("format"));
    }

    [Fact]
    public void Url_Works()
    {
        ElevationLookupParams parameters = new()
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Format = "format",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://plaza.fyi/api/v1/elevation?format=format"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ElevationLookupParams
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Format = "format",
        };

        ElevationLookupParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GeometryTest : TestBase
{
    [Fact]
    public void PointValidationWorks()
    {
        Geometry value = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        value.Validate();
    }

    [Fact]
    public void MultiPointValidationWorks()
    {
        Geometry value = new Models::MultiPointGeometry()
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = Models::MultiPointGeometryType.MultiPoint,
        };
        value.Validate();
    }

    [Fact]
    public void PointSerializationRoundtripWorks()
    {
        Geometry value = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Geometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MultiPointSerializationRoundtripWorks()
    {
        Geometry value = new Models::MultiPointGeometry()
        {
            Coordinates =
            [
                [0, 0],
            ],
            Type = Models::MultiPointGeometryType.MultiPoint,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Geometry>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
