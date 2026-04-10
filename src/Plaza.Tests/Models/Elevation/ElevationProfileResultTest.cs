using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Elevation;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.Elevation;

public class ElevationProfileResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElevationProfileResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                AvgElevationM = 67.8,
                MaxElevationM = 155.3,
                MinElevationM = 28.1,
                TotalAscentM = 127.4,
                TotalDescentM = 89.2,
            },
            Type = ElevationProfileResultType.Feature,
        };

        Models::Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        ElevationProfileResultProperties expectedProperties = new()
        {
            AvgElevationM = 67.8,
            MaxElevationM = 155.3,
            MinElevationM = 28.1,
            TotalAscentM = 127.4,
            TotalDescentM = 89.2,
        };
        ApiEnum<string, ElevationProfileResultType> expectedType =
            ElevationProfileResultType.Feature;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedProperties, model.Properties);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElevationProfileResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                AvgElevationM = 67.8,
                MaxElevationM = 155.3,
                MinElevationM = 28.1,
                TotalAscentM = 127.4,
                TotalDescentM = 89.2,
            },
            Type = ElevationProfileResultType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationProfileResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElevationProfileResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                AvgElevationM = 67.8,
                MaxElevationM = 155.3,
                MinElevationM = 28.1,
                TotalAscentM = 127.4,
                TotalDescentM = 89.2,
            },
            Type = ElevationProfileResultType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationProfileResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Models::Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        ElevationProfileResultProperties expectedProperties = new()
        {
            AvgElevationM = 67.8,
            MaxElevationM = 155.3,
            MinElevationM = 28.1,
            TotalAscentM = 127.4,
            TotalDescentM = 89.2,
        };
        ApiEnum<string, ElevationProfileResultType> expectedType =
            ElevationProfileResultType.Feature;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedProperties, deserialized.Properties);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElevationProfileResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                AvgElevationM = 67.8,
                MaxElevationM = 155.3,
                MinElevationM = 28.1,
                TotalAscentM = 127.4,
                TotalDescentM = 89.2,
            },
            Type = ElevationProfileResultType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElevationProfileResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new()
            {
                AvgElevationM = 67.8,
                MaxElevationM = 155.3,
                MinElevationM = 28.1,
                TotalAscentM = 127.4,
                TotalDescentM = 89.2,
            },
            Type = ElevationProfileResultType.Feature,
        };

        ElevationProfileResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElevationProfileResultPropertiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElevationProfileResultProperties
        {
            AvgElevationM = 67.8,
            MaxElevationM = 155.3,
            MinElevationM = 28.1,
            TotalAscentM = 127.4,
            TotalDescentM = 89.2,
        };

        double expectedAvgElevationM = 67.8;
        double expectedMaxElevationM = 155.3;
        double expectedMinElevationM = 28.1;
        double expectedTotalAscentM = 127.4;
        double expectedTotalDescentM = 89.2;

        Assert.Equal(expectedAvgElevationM, model.AvgElevationM);
        Assert.Equal(expectedMaxElevationM, model.MaxElevationM);
        Assert.Equal(expectedMinElevationM, model.MinElevationM);
        Assert.Equal(expectedTotalAscentM, model.TotalAscentM);
        Assert.Equal(expectedTotalDescentM, model.TotalDescentM);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElevationProfileResultProperties
        {
            AvgElevationM = 67.8,
            MaxElevationM = 155.3,
            MinElevationM = 28.1,
            TotalAscentM = 127.4,
            TotalDescentM = 89.2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationProfileResultProperties>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElevationProfileResultProperties
        {
            AvgElevationM = 67.8,
            MaxElevationM = 155.3,
            MinElevationM = 28.1,
            TotalAscentM = 127.4,
            TotalDescentM = 89.2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationProfileResultProperties>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAvgElevationM = 67.8;
        double expectedMaxElevationM = 155.3;
        double expectedMinElevationM = 28.1;
        double expectedTotalAscentM = 127.4;
        double expectedTotalDescentM = 89.2;

        Assert.Equal(expectedAvgElevationM, deserialized.AvgElevationM);
        Assert.Equal(expectedMaxElevationM, deserialized.MaxElevationM);
        Assert.Equal(expectedMinElevationM, deserialized.MinElevationM);
        Assert.Equal(expectedTotalAscentM, deserialized.TotalAscentM);
        Assert.Equal(expectedTotalDescentM, deserialized.TotalDescentM);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElevationProfileResultProperties
        {
            AvgElevationM = 67.8,
            MaxElevationM = 155.3,
            MinElevationM = 28.1,
            TotalAscentM = 127.4,
            TotalDescentM = 89.2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElevationProfileResultProperties
        {
            AvgElevationM = 67.8,
            MaxElevationM = 155.3,
            MinElevationM = 28.1,
            TotalAscentM = 127.4,
            TotalDescentM = 89.2,
        };

        ElevationProfileResultProperties copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElevationProfileResultTypeTest : TestBase
{
    [Theory]
    [InlineData(ElevationProfileResultType.Feature)]
    public void Validation_Works(ElevationProfileResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElevationProfileResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ElevationProfileResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<PlazaInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ElevationProfileResultType.Feature)]
    public void SerializationRoundtrip_Works(ElevationProfileResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElevationProfileResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ElevationProfileResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ElevationProfileResultType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ElevationProfileResultType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
