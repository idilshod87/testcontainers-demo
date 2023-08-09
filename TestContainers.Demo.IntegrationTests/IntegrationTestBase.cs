using NUnit.Framework;

using Testcontainers.PostgreSql;

namespace TestContainers.Demo.IntegrationTests;

public class IntegrationTestBase
{
    private PostgreSqlContainer _postgreSqlContainer = null!;

    public TestWebApplicationFactory TestApp { get; private set; } = null!;

    [OneTimeSetUp]
    public async Task InitializeAsync()
    {
        _postgreSqlContainer = new PostgreSqlBuilder()
            .WithImage("postgres:14.7")
            .WithCleanUp(true)
            .WithEnvironment("ConnectionString", "<some connection string>")
            .Build();

        await _postgreSqlContainer.StartAsync();

        TestApp = new TestWebApplicationFactory(_postgreSqlContainer.GetConnectionString());
    }

    [OneTimeTearDown]
    public Task DisposeAsync()
    {
        return _postgreSqlContainer.DisposeAsync().AsTask();
    }
}
