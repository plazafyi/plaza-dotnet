using System.Text.Json;
using Plaza.Core;
using Plaza.Exceptions;
using Plaza.Models.Elevation;
using Models = Plaza.Models;

namespace Plaza.Tests.Models.Elevation;

public class ElevationLookupResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElevationLookupResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new(35.2),
            Type = Type.Feature,
        };

        Models::Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        Properties expectedProperties = new(35.2);
        ApiEnum<string, Type> expectedType = Type.Feature;

        Assert.Equal(expectedGeometry, model.Geometry);
        Assert.Equal(expectedProperties, model.Properties);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElevationLookupResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new(35.2),
            Type = Type.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationLookupResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElevationLookupResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new(35.2),
            Type = Type.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElevationLookupResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Models::Geometry expectedGeometry = new Models::PointGeometry()
        {
            Coordinates = [2.3522, 48.8566],
            Type = Models::PointGeometryType.Point,
        };
        Properties expectedProperties = new(35.2);
        ApiEnum<string, Type> expectedType = Type.Feature;

        Assert.Equal(expectedGeometry, deserialized.Geometry);
        Assert.Equal(expectedProperties, deserialized.Properties);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElevationLookupResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new(35.2),
            Type = Type.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElevationLookupResult
        {
            Geometry = new Models::PointGeometry()
            {
                Coordinates = [2.3522, 48.8566],
                Type = Models::PointGeometryType.Point,
            },
            Properties = new(35.2),
            Type = Type.Feature,
        };

        ElevationLookupResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PropertiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Properties { ElevationM = 35.2 };

        double expectedElevationM = 35.2;

        Assert.Equal(expectedElevationM, model.ElevationM);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Properties { ElevationM = 35.2 };

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
        var model = new Properties { ElevationM = 35.2 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Properties>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedElevationM = 35.2;

        Assert.Equal(expectedElevationM, deserialized.ElevationM);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Properties { ElevationM = 35.2 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Properties { ElevationM = 35.2 };

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
