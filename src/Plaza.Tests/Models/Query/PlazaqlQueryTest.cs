using System.Text.Json;
using Plaza.Core;
using Plaza.Models.Query;

namespace Plaza.Tests.Models.Query;

public class PlazaqlQueryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlazaqlQuery
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
        };

        string expectedData =
            "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));";

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlazaqlQuery
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlazaqlQuery>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlazaqlQuery
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlazaqlQuery>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedData =
            "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));";

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlazaqlQuery
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlazaqlQuery
        {
            Data =
                "$$ = search(node, amenity: \"cafe\").around(distance: 500, geometry: point(48.8566, 2.3522));",
        };

        PlazaqlQuery copied = new(model);

        Assert.Equal(model, copied);
    }
}
