using System;
using Plaza;

namespace Plaza.Tests;

public class TestBase
{
    protected IPlazaClient client;

    public TestBase()
    {
        client = new PlazaClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
